using System;
using System.Collections.Generic;
using System.Windows.Forms; // For TextBox
using System.Xml.Linq; // For XElement
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StationeersStructureXMLConverter
{
    public static class SourceExtraction
    {
        public static List<XElement> ExtractSpawnEntries(List<object> things, TextBox output)
        {
            var spawnEntries = new List<XElement>();
            int exportedCount = 0;
            int debugCount = 0;
            int maxDebug = 5;  // Limit debug to first 5
            foreach (var thingObj in things)
            {
                if (thingObj is XElement)
                {
                    var thingElement = (XElement)thingObj;
                    var xsiNs = "http://www.w3.org/2001/XMLSchema-instance";
                    var xsiType = thingElement.Attribute(XName.Get("type", xsiNs))?.Value ?? "Unknown";
                    var cleanId = xsiType.Replace("SaveData", "");  // "SolarPanelSaveData" → "SolarPanel"
                    var prefabName = thingElement.Element("PrefabName")?.Value ?? cleanId;  // Prefer PrefabName

                    // Classify tag by type (use prefabName for "Structure..." or "DynamicThing...")
                    string tagName = "Item";  // Default
                    if (prefabName.StartsWith("Structure")) tagName = "Structure";
                    else if (prefabName.StartsWith("DynamicThing")) tagName = "DynamicThing";

                    // Temp debug for first 5
                    if (debugCount < maxDebug)
                    {
                        output.Text += $"Debug: xsiType='{xsiType}' → tagName='{tagName}', prefabName='{prefabName}'.\r\n";
                        debugCount++;
                    }

                    var spawnEntry = new XElement(tagName,
                        new XAttribute("Id", prefabName),
                        new XAttribute("HideInStartScreen", "true")
                    );

                    AddBasicProps(thingElement, spawnEntry);  // Sub-method
                    AddDamageState(thingElement, spawnEntry);  // Sub-method
                    AddBuildState(thingElement, spawnEntry);  // Sub-method
                    AddNetworkProps(thingElement, spawnEntry);  // Sub-method
                    AddSpawnPositionAndReagents(thingElement, spawnEntry);  // Sub-method

                    spawnEntries.Add(spawnEntry);
                    exportedCount++;
                }
            }
            output.Text += $"Extracted {exportedCount} spawn entries, {spawnEntries.Count(tag => tag.Name.LocalName == "Structure")} Structures, {spawnEntries.Count(tag => tag.Name.LocalName == "Item")} Items.\r\n";
            return spawnEntries;
        }

        // Sub-method: Add basic props (CustomName, IsCustomName, CustomColorIndex, Indestructable)
        private static void AddBasicProps(XElement thingElement, XElement spawnEntry)
        {
            var customName = thingElement.Element("CustomName");
            if (customName != null)
            {
                spawnEntry.Add(new XElement("CustomName", customName.Value ?? ""));
            }

            var isCustomName = thingElement.Element("IsCustomName")?.Value;
            if (isCustomName != null)
            {
                spawnEntry.Add(new XElement("IsCustomName", isCustomName));
            }

            var customColorIndex = thingElement.Element("CustomColorIndex")?.Value;
            if (customColorIndex != null)
            {
                spawnEntry.Add(new XElement("CustomColorIndex", customColorIndex));
            }

            var indestructable = thingElement.Element("Indestructable")?.Value;
            if (indestructable != null)
            {
                spawnEntry.Add(new XElement("Indestructable", indestructable));
            }
        }

        // Sub-method: Add DamageState (nested copy, only if any value >0)
        private static void AddDamageState(XElement thingElement, XElement spawnEntry)
        {
            var damageState = thingElement.Element("DamageState");
            if (damageState != null)
            {
                bool hasDamage = false;
                foreach (var damageType in damageState.Elements())
                {
                    if (int.TryParse(damageType.Value, out int value) && value > 0)
                    {
                        hasDamage = true;
                        break;
                    }
                }

                if (hasDamage)
                {
                    var damageEntry = new XElement("DamageState");
                    foreach (var damageType in damageState.Elements())
                    {
                        damageEntry.Add(new XElement(damageType.Name, damageType.Value));  // Copy each <Brute>0</Brute> individually
                    }
                    spawnEntry.Add(damageEntry);
                }
            }
        }

        // Sub-method: Add build state props (CurrentBuildState, MothershipReferenceId, HasSpawnedWreckage)
        private static void AddBuildState(XElement thingElement, XElement spawnEntry)
        {
            var currentBuildState = thingElement.Element("CurrentBuildState")?.Value;
            if (currentBuildState != null)
            {
                spawnEntry.Add(new XElement("CurrentBuildState", currentBuildState));
            }

            var hasSpawnedWreckage = thingElement.Element("HasSpawnedWreckage")?.Value;
            if (hasSpawnedWreckage != null)
            {
                spawnEntry.Add(new XElement("HasSpawnedWreckage", hasSpawnedWreckage));
            }
        }

        // Sub-method: Add network props (NetworkId)
        private static void AddNetworkProps(XElement thingElement, XElement spawnEntry)
        {
            var networkId = thingElement.Element("CableNetworkId")?.Value ?? thingElement.Element("PipeNetworkId")?.Value ?? "0";
            if (networkId != "0")
            {
                spawnEntry.Add(new XElement("NetworkId", networkId));
            }
        }

        // Sub-method: Add SpawnPosition and Reagents
        private static void AddSpawnPositionAndReagents(XElement thingElement, XElement spawnEntry)
        {
            // Add SpawnPosition
            var spawnPosition = BuildSpawnPosition(thingElement);  // Sub-method
            spawnEntry.Add(spawnPosition);

            // Add Reagents if present
            var reagents = thingElement.Element("Reagents");
            if (reagents != null)
            {
                spawnEntry.Add(reagents.Elements());
            }
        }

        // Sub-method: Build <SpawnPosition Rule="Explicit"><Offset x="121" y="88" z="-80"/><Rotation x="2.10734363E-08" y="0.7071066" z="-2.10734132E-08" w="0.707106948"/></SpawnPosition>
        private static XElement BuildSpawnPosition(XElement thingElement)
        {
            // Parse WorldPosition <x> <y> <z>
            var worldPos = thingElement.Element("WorldPosition");
            var offsetX = worldPos?.Element("x")?.Value ?? "0";
            var offsetY = worldPos?.Element("y")?.Value ?? "0";
            var offsetZ = worldPos?.Element("z")?.Value ?? "0";

            // Parse WorldRotation <x> <y> <z> <w> (quaternion)
            var worldRot = thingElement.Element("WorldRotation");
            var rotX = worldRot?.Element("x")?.Value ?? "0";
            var rotY = worldRot?.Element("y")?.Value ?? "0";
            var rotZ = worldRot?.Element("z")?.Value ?? "0";
            var rotW = worldRot?.Element("w")?.Value ?? "1";

            return new XElement("SpawnPosition",
                new XAttribute("Rule", "Explicit"),
                new XElement("Offset",
                    new XAttribute("x", offsetX),
                    new XAttribute("y", offsetY),
                    new XAttribute("z", offsetZ)
                ),
                new XElement("Rotation",
                    new XAttribute("x", rotX),
                    new XAttribute("y", rotY),
                    new XAttribute("z", rotZ),
                    new XAttribute("w", rotW)
                )
            );
        }
    }
}
