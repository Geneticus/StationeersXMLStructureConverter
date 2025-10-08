using System;
using System.Collections.Generic;
using System.Windows.Forms; // For TextBox
using System.Xml.Linq; // For XElement
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StationeersStructureXMLConverter
{
    public static class DestinationExport
    {
        // Export to new schema: Standalone <Thing> XML files for each ThingSaveData (prefab style)
        private static void TransformToBatch(List<object> things, string destPath, TextBox output)
        {
            int exportedCount = 0;
            foreach (var thingObj in things)
            {
                if (thingObj is XElement thingElement)
                {
                    var xsiType = thingElement.Attribute(XName.Get("type", "http://www.w3.org/2001/XMLSchema-instance"))?.Value ?? "Unknown";
                    var exportDoc = new XDocument(
                        new XElement("Thing",  // New schema root for prefab
                            new XAttribute("type", xsiType),
                            thingElement.Elements()  // Copy child elements (Position, Reagents, etc.)
                        )
                    );
                    string fileName = $"Thing_{exportedCount + 1}_{xsiType}.xml";
                    string exportPath = Path.Combine(destPath, fileName);
                    exportDoc.Save(exportPath);
                    exportedCount++;
                }
            }
            output.AppendText($"Exported {exportedCount} things as standalone XML files to {destPath}.\r\n");
        }



        // Export to new schema: SpawnGroup.xml with <GameData><WorldSettings Id="My_Scenario"/><Spawn Id="My_ScenarioThings"><Structure Id="..." HideInStartScreen="true">...</Structure></Spawn></GameData>
        public static void TransformToNewSchema(List<object> things, string destPath, TextBox output)
        {
            if (things.Count == 0)
            {
                output.AppendText("No things to export.\r\n");
                return;
            }

            string scenarioName = "My_Scenario";  // From textbox or user input
            string spawnId = scenarioName + "Things";

            var gameData = BuildGameData(things, scenarioName, spawnId);  // Sub-method for root
            string exportPath = Path.Combine(destPath, "SpawnGroup.xml");
            if (File.Exists(exportPath))
            {
                var result = MessageBox.Show("SpawnGroup.xml already exists. Overwrite?", "Overwrite File?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    output.AppendText("Export cancelled—file not overwritten.\r\n");
                    return;
                }
            }
            gameData.Save(exportPath);
            output.AppendText($"Exported {things.Count} spawn entries to SpawnGroup.xml: {exportPath}.\r\n");
        }

        // Sub-method: Build full <GameData> XDocument with xmlns
        private static XDocument BuildGameData(List<object> things, string scenarioName, string spawnId)
        {
            var spawnEntries = new List<XElement>();
            foreach (var thingObj in things)
            {
                if (thingObj is XElement thingElement)
                {
                    var xsiNs = "http://www.w3.org/2001/XMLSchema-instance";
                    var xsiType = thingElement.Attribute(XName.Get("type", xsiNs))?.Value ?? "Unknown";
                    var cleanId = xsiType.Replace("SaveData", "");
                    var prefabName = thingElement.Element("PrefabName")?.Value ?? cleanId;
                    // Classify tag by type (use prefabName for "Structure..." or "DynamicThing...", specials for edge cases)
                    string tagName = "Item"; // Default
                    if (prefabName.StartsWith("Structure")) tagName = "Structure";
                    else if (prefabName.StartsWith("DynamicThing") || prefabName.Contains("PortableSolarPanel")) tagName = "DynamicThing"; // Special for free floating solar
                    else if (prefabName.Contains("LanderCapsule")) tagName = "Item"; // Capsule as Item
                    else if (prefabName.Contains("Wreckage")) tagName = "Item"; // Wreckage as Item with variant
                    var spawnEntry = new XElement(tagName,
                        new XAttribute("Id", prefabName),
                        new XAttribute("HideInStartScreen", "true")
                    );
                    // Add all child elements from ThingSaveData (as per previous full mapping)
                    AddAllProps(thingElement, spawnEntry); // Sub-method for all props

                    // Add temporary elements for nesting
                    var referenceId = thingElement.Element("ReferenceId")?.Value ?? "0";
                    var parentReferenceId = thingElement.Element("ParentReferenceId")?.Value ?? "0";
                    var parentSlotId = thingElement.Element("ParentSlotId")?.Value ?? "0";
                    spawnEntry.Add(new XElement("TempReferenceId", referenceId));
                    spawnEntry.Add(new XElement("TempParentReferenceId", parentReferenceId));
                    spawnEntry.Add(new XElement("TempParentSlotId", parentSlotId));

                    spawnEntries.Add(spawnEntry);
                }
            }

            // New: Add nesting logic after creating spawnEntries
            var idToSpawn = new Dictionary<string, XElement>();
            foreach (var spawnEntry in spawnEntries)
            {
                var referenceId = spawnEntry.Element("TempReferenceId")?.Value ?? "0";
                idToSpawn[referenceId] = spawnEntry;
            }
            var visited = new HashSet<string>();
            foreach (var spawnEntry in spawnEntries.ToList())
            {
                var parentId = spawnEntry.Element("TempReferenceId")?.Value ?? "0";
                var children = spawnEntries.Where(e => e.Element("TempParentReferenceId")?.Value == parentId).ToList();
                if (children.Any())
                {
                    AddInventory(spawnEntry, children, visited, spawnEntries);
                }
            }

            // Use original spawnEntries for BuildSpawn to ensure all items are included
            return new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("GameData",
                    new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                    new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
                    BuildWorldSettings(scenarioName), // Sub-method
                    BuildSpawn(spawnEntries, spawnId) // Use full spawnEntries list
                )
            );
        }

        private static void AddInventory(XElement parent, List<XElement> children, HashSet<string> visited, List<XElement> spawnEntries)
        {
            foreach (var childSpawn in children)
            {
                var referenceId = childSpawn.Element("TempReferenceId")?.Value ?? "0";
                if (visited.Contains(referenceId))
                {
                    continue; // Skip to prevent cycles
                }
                visited.Add(referenceId);

                var slotId = childSpawn.Element("TempParentSlotId")?.Value ?? "0";
                childSpawn.SetAttributeValue("SlotIndex", slotId);
                // Remove temporary elements if not needed in output
                childSpawn.Element("TempParentReferenceId")?.Remove();
                childSpawn.Element("TempParentSlotId")?.Remove();
                childSpawn.Element("TempReferenceId")?.Remove();

                // Recurse for grandchildren
                var childId = referenceId;
                var grandChildren = spawnEntries.Where(e => e.Element("TempParentReferenceId")?.Value == childId).ToList();
                if (grandChildren.Any())
                {
                    AddInventory(childSpawn, grandChildren, visited, spawnEntries);
                }

                parent.Add(childSpawn);
            }
        }

        // Sub-method: Build self-closing <WorldSettings Id="..."/>
        private static XElement BuildWorldSettings(string scenarioName)
        {
            return new XElement("WorldSettings",
                new XAttribute("Id", scenarioName)
            );
        }

        // Sub-method: Build <Spawn Id="..." > with entries </Spawn>
        private static XElement BuildSpawn(List<XElement> spawnEntries, string spawnId)
        {
            return new XElement("Spawn",
                new XAttribute("Id", spawnId),
                spawnEntries  // All entries as siblings under <Spawn>
            );
        }

        // Sub-method: Add all props (CustomName, DamageState, etc.) - call from main loop
        private static void AddAllProps(XElement thingElement, XElement spawnEntry)
        {
            // CustomName (even if empty)
            var customName = thingElement.Element("CustomName");
            if (customName != null)
            {
                spawnEntry.Add(new XElement("CustomName", customName.Value ?? ""));
            }

            // IsCustomName (bool)
            var isCustomName = thingElement.Element("IsCustomName")?.Value;
            if (isCustomName != null)
            {
                spawnEntry.Add(new XElement("IsCustomName", isCustomName));
            }

            // CustomColorIndex (int) -> <Color Id="ColorName" />
            var customColorIndex = thingElement.Element("CustomColorIndex")?.Value;
            if (customColorIndex != null)
            {
                string colorName = "ColorWhite";  // Default
                int index;
                if (int.TryParse(customColorIndex, out index))
                {
                    if (index == 0) colorName = "ColorBlue";
                    else if (index == 1) colorName = "ColorGray";
                    else if (index == 2) colorName = "ColorGreen";
                    else if (index == 3) colorName = "ColorOrange";
                    else if (index == 4) colorName = "ColorRed";
                    else if (index == 5) colorName = "ColorYellow";
                    else if (index == 6) colorName = "ColorWhite";
                    else if (index == 7) colorName = "ColorBlack";
                    else if (index == 8) colorName = "ColorBrown";
                    else if (index == 9) colorName = "ColorKhaki";
                    else if (index == 10) colorName = "ColorPink";
                    else if (index == 11) colorName = "ColorPurple";
                }
                spawnEntry.Add(new XElement("Color",
                    new XAttribute("Id", colorName)
                ));
            }

            // Indestructable (bool)
            var indestructable = thingElement.Element("Indestructable")?.Value;
            if (indestructable != null)
            {
                spawnEntry.Add(new XElement("Indestructable", indestructable));
            }

            AddDamageState(thingElement, spawnEntry);  // Call sub-method for DamageState

            // CurrentBuildState (int)
            var currentBuildState = thingElement.Element("CurrentBuildState")?.Value;
            if (currentBuildState != null)
            {
                spawnEntry.Add(new XElement("CurrentBuildState", currentBuildState));
            }

            // Add HasSpawnedWreckage (bool)
            var hasSpawnedWreckage = thingElement.Element("HasSpawnedWreckage")?.Value;
            if (hasSpawnedWreckage != null)
            {
                spawnEntry.Add(new XElement("HasSpawnedWreckage", hasSpawnedWreckage));
            }

            // Add NetworkId (specific to type, e.g., CableNetworkId)
            var networkId = thingElement.Element("CableNetworkId")?.Value ?? thingElement.Element("PipeNetworkId")?.Value ?? "0";
            if (networkId != "0")
            {
                spawnEntry.Add(new XElement("NetworkId", networkId));
            }

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
