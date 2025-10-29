using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StationeersStructureXMLConverter
{
    public static class SourceExtraction
    {
        public static List<XElement> ExtractSpawnEntries(List<object> things, TextBox output)
        {
            var spawnEntries = new List<XElement>();
            int exportedCount = 0;
            foreach (var thingObj in things)
            {
                if (thingObj is XElement thingElement)
                {
                    var referenceId = int.Parse(thingElement.Element("ReferenceId")?.Value ?? "0");
                    var parentReferenceId = int.Parse(thingElement.Element("ParentReferenceId")?.Value ?? "0");
                    var parentSlotId = int.Parse(thingElement.Element("ParentSlotId")?.Value ?? "0");
                    var xsiNs = "http://www.w3.org/2001/XMLSchema-instance";
                    var xsiType = thingElement.Attribute(XName.Get("type", xsiNs))?.Value ?? "Unknown";
                    var cleanId = xsiType.Replace("SaveData", "");
                    var prefabName = thingElement.Element("PrefabName")?.Value ?? cleanId;
                    string tagName = ClassifyTagName(prefabName);
                    if (string.IsNullOrEmpty(prefabName) || string.IsNullOrEmpty(xsiType))
                    {
                        output.AppendText($"Warning: Skipping element with missing PrefabName or xsi:type: {thingElement}\r\n");
                        continue;
                    }
                    var spawnEntry = new XElement(tagName,
                        new XAttribute("Id", prefabName),
                        new XAttribute("HideInStartScreen", "true"),
                        new XElement("TempReferenceId", referenceId),
                        new XElement("TempParentReferenceId", parentReferenceId),
                        new XElement("TempParentSlotId", parentSlotId)
                    );
                    Console.WriteLine($"Added {tagName} with TempReferenceId={referenceId}, TempParentReferenceId={parentReferenceId}");
                    AddCoreProps(thingElement, spawnEntry);
                    AddBuildState(thingElement, spawnEntry);
                    AddDamageState(thingElement, spawnEntry);
                    AddSpawnPositionAndReagents(thingElement, spawnEntry);
                    AddStates(thingElement, spawnEntry);
                    AddHealthCurrentForDynamicThings(thingElement, spawnEntry);
                    // Tank linking (port from Phase 4)
                    AddTankContentsFromAtmosphere(thingElement, spawnEntry, output); // Stub for full doc access; adjust as needed
                    spawnEntries.Add(spawnEntry);
                    exportedCount++;
                }
            }
            output.AppendText($"Extracted {exportedCount} spawn entries, {spawnEntries.Count(s => s.Name.LocalName == "Structure")} Structures, {spawnEntries.Count(s => s.Name.LocalName == "Item")} Items.\r\n");
            return spawnEntries;
        }

        private static string ClassifyTagName(string prefabName)
        {
            string tagName = "Item"; // Default
            if (prefabName.StartsWith("Structure")) tagName = "Structure";
            else if (prefabName == "DynamicGasTankAdvanced" || prefabName == "DynamicMKIILiquidCanisterEmpty" ||
                     prefabName == "CrateMkII" || prefabName == "DynamicGasCanisterEmpty" ||
                     prefabName == "DynamicLiquidCanisterEmpty" || prefabName == "LanderCapsuleSmall") tagName = "DynamicThing";
            else if (prefabName.Contains("LanderCapsule")) tagName = "Item";
            else if (prefabName.Contains("Wreckage")) tagName = "Item";
            return tagName;
        }

        private static void AddCoreProps(XElement thingElement, XElement spawnEntry)
        {
            var customName = thingElement.Element("CustomName");
            if (customName != null)
            {
                spawnEntry.Add(new XElement("CustomName", customName.Value ?? ""));
            }
            var isCustomName = thingElement.Element("IsCustomName")?.Value;
            if (!string.IsNullOrEmpty(isCustomName))
            {
                spawnEntry.Add(new XElement("IsCustomName", isCustomName));
            }
            var customColorIndex = thingElement.Element("CustomColorIndex")?.Value;
            if (!string.IsNullOrEmpty(customColorIndex) && int.TryParse(customColorIndex, out int colorIndex) && GetColorName(colorIndex) is string colorName)
            {
                spawnEntry.Add(new XElement("Color", new XAttribute("Id", colorName)));
            }
            var indestructable = thingElement.Element("Indestructable")?.Value;
            if (!string.IsNullOrEmpty(indestructable))
            {
                spawnEntry.Add(new XElement("Indestructable", indestructable));
            }
        }

        private static string GetColorName(int index)
        {
            switch (index)
            {
                case 0: return "ColorBlue";
                case 1: return "ColorGray";
                case 2: return "ColorGreen";
                case 3: return "ColorOrange";
                case 4: return "ColorRed";
                case 5: return "ColorYellow";
                case 6: return "ColorWhite";
                case 7: return "ColorBlack";
                case 8: return "ColorBrown";
                case 9: return "ColorKhaki";
                case 10: return "ColorPink";
                case 11: return "ColorPurple";
                default: return null;
            }
        }

        private static void AddBuildState(XElement thingElement, XElement spawnEntry)
        {
            var currentBuildState = thingElement.Element("CurrentBuildState")?.Value;
            if (currentBuildState != null && int.TryParse(currentBuildState, out int index))
            {
                spawnEntry.Add(new XElement("BuildState", new XAttribute("Index", index.ToString())));
            }
            var hasSpawnedWreckage = thingElement.Element("HasSpawnedWreckage")?.Value;
            if (!string.IsNullOrEmpty(hasSpawnedWreckage))
            {
                spawnEntry.Add(new XElement("HasSpawnedWreckage", hasSpawnedWreckage));
            }
        }

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
                        damageEntry.Add(new XElement(damageType.Name, damageType.Value));
                    }
                    spawnEntry.Add(damageEntry);
                }
            }
        }

        private static void AddSpawnPositionAndReagents(XElement thingElement, XElement spawnEntry)
        {
            var spawnPosition = BuildSpawnPosition(thingElement, spawnEntry, null);
            spawnEntry.Add(spawnPosition);
            var reagents = thingElement.Element("Reagents");
            if (reagents != null)
            {
                var transformedReagents = new XElement("Reagents");
                foreach (var reagent in reagents.Elements())
                {
                    if (double.TryParse(reagent.Value, out double value) && value > 0)
                    {
                        transformedReagents.Add(new XElement(reagent.Name, value.ToString("F2")));
                    }
                }
                if (transformedReagents.HasElements)
                {
                    spawnEntry.Add(transformedReagents);
                }
            }
        }

        private static XElement BuildSpawnPosition(XElement thingElement, XElement spawnEntry, TextBox output)
        {
            var worldPos = thingElement.Element("WorldPosition");
            var offsetX = worldPos?.Element("x")?.Value ?? "0";
            var offsetY = worldPos?.Element("y")?.Value ?? "0";
            var offsetZ = worldPos?.Element("z")?.Value ?? "0";
            double pitch = 0, yaw = 0, roll = 0;
            var worldRot = thingElement.Element("WorldRotation");
            var euler = worldRot?.Element("eulerAngles");
            if (euler != null)
            {
                pitch = double.Parse(euler.Element("x")?.Value ?? "0");
                yaw = double.Parse(euler.Element("y")?.Value ?? "0");
                roll = double.Parse(euler.Element("z")?.Value ?? "0");
            }
            else
            {
                var rotX = double.Parse(worldRot?.Element("x")?.Value ?? "0");
                var rotY = double.Parse(worldRot?.Element("y")?.Value ?? "0");
                var rotZ = double.Parse(worldRot?.Element("z")?.Value ?? "0");
                var rotW = double.Parse(worldRot?.Element("w")?.Value ?? "1");
                double length = Math.Sqrt(rotX * rotX + rotY * rotY + rotZ * rotZ + rotW * rotW);
                if (length > 0)
                {
                    rotX /= length;
                    rotY /= length;
                    rotZ /= length;
                    rotW /= length;
                }
                double sinr_cosp = 2 * (rotW * rotX + rotY * rotZ);
                double cosr_cosp = 1 - 2 * (rotX * rotX + rotY * rotY);
                pitch = Math.Atan2(sinr_cosp, cosr_cosp) * (180 / Math.PI);
                double sinp = Math.Min(Math.Max(2 * (rotW * rotY - rotZ * rotX), -1), 1);
                yaw = Math.Asin(sinp) * (180 / Math.PI);
                double siny_cosp = 2 * (rotW * rotZ + rotX * rotY);
                double cosy_cosp = 1 - 2 * (rotY * rotY + rotZ * rotZ);
                roll = Math.Atan2(siny_cosp, cosy_cosp) * (180 / Math.PI);
                if (Math.Abs(sinp) > 0.9999)
                {
                    pitch = 0;
                    roll = Math.Atan2(2 * (rotX * rotW + rotY * rotZ), 1 - 2 * (rotX * rotX + rotZ * rotZ)) * (180 / Math.PI);
                }
                if (output != null)
                {
                    output.AppendText($"Warning: No eulerAngles for {thingElement.Element("PrefabName")?.Value ?? "Unknown"}, using default rotation (0,0,0)\r\n");
                }
            }
            pitch = (pitch + 360) % 360;
            yaw = (yaw + 360) % 360;
            roll = (roll + 360) % 360;
            if (spawnEntry.Name.LocalName == "Structure")
            {
                pitch = Math.Round(pitch / 90) * 90 % 360;
                yaw = Math.Round(yaw / 90) * 90 % 360;
                roll = Math.Round(roll / 90) * 90 % 360;
            }
            return new XElement("SpawnPosition",
                new XAttribute("Rule", "Explicit"),
                new XElement("Offset",
                    new XAttribute("x", offsetX),
                    new XAttribute("y", offsetY),
                    new XAttribute("z", offsetZ)
                ),
                new XElement("Rotation",
                    new XAttribute("x", pitch.ToString("F4")),
                    new XAttribute("y", yaw.ToString("F4")),
                    new XAttribute("z", roll.ToString("F4"))
                )
            );
        }

        private static void AddStates(XElement thingElement, XElement spawnEntry)
        {
            var states = thingElement.Element("States");
            if (states != null)
            {
                var statesElement = new XElement("States");
                foreach (var state in states.Elements("State"))
                {
                    var stateName = state.Element("StateName")?.Value;
                    var stateValue = state.Element("State")?.Value;
                    if (stateName != null && stateValue != null && int.TryParse(stateValue, out _))
                    {
                        statesElement.Add(new XElement("State",
                            new XAttribute("Name", stateName),
                            new XText(stateValue)
                        ));
                    }
                }
                if (statesElement.HasElements)
                {
                    spawnEntry.Add(statesElement);
                }
            }
        }

        private static void AddHealthCurrentForDynamicThings(XElement thingElement, XElement spawnEntry)
        {
            var xsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var xsiType = thingElement.Attribute(XName.Get("type", xsiNs))?.Value;
            if (xsiType != null && xsiType.Contains("DynamicThing"))
            {
                var healthCurrent = thingElement.Element("HealthCurrent")?.Value;
                if (healthCurrent != null && int.TryParse(healthCurrent, out _))
                {
                    spawnEntry.Add(new XElement("HealthCurrent", healthCurrent));
                }
            }
        }

        // Tank linking (Phase 4)
        private static void AddTankContentsFromAtmosphere(XElement thingElement, XElement spawnEntry, TextBox output)
        {
            // Assume doc is accessible or passed; stub for now
            // var atmospheres = doc.Root?.Element("Atmospheres")?.Elements("AtmosphereSaveData")?.ToList() ?? new List<XElement>();
            // var atmosphereByThingId = atmospheres.ToDictionary(a => int.Parse(a.Element("ThingReferenceId")?.Value ?? "0"), a => a);
            // var refId = int.Parse(thingElement.Element("ReferenceId")?.Value ?? "0");
            // if (atmosphereByThingId.TryGetValue(refId, out var atm))
            // {
            //     var contentElements = new List<XElement>();
            //     double totalMoles = 0;
            //     double celsius = 20;
            //     foreach (var child in atm.Elements().Where(el => double.TryParse(el.Value, out double moles) && moles > 0 && el.Name.LocalName != "Energy" && el.Name.LocalName != "Volume"))
            //     {
            //         totalMoles += moles;
            //         string attrName = child.Name.LocalName.StartsWith("Liquid") ? "Litres" : "Moles";
            //         contentElements.Add(new XElement("Gas",
            //             new XAttribute("Type", child.Name.LocalName),
            //             new XAttribute(attrName, moles.ToString("F2")),
            //             new XAttribute("Celsius", celsius.ToString("F2"))
            //         ));
            //     }
            //     if (contentElements.Any())
            //     {
            //         foreach (var elem in contentElements)
            //         {
            //             spawnEntry.Add(elem);
            //         }
            //         output.AppendText($"Added {contentElements.Count} gases to tank {refId}: {totalMoles:F2} total moles at {celsius:F2}°C\r\n");
            //     }
            // }
        }
    }
}