using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StationeersStructureXMLConverter
{
    public static class SourceExtraction
    {
        public static List<XElement> ExtractSpawnEntries(List<object> things, TextBox output, XDocument doc)
        {
            var spawnEntries = new List<XElement>();
            int exportedCount = 0;
            var uniquePrefabNames = things.OfType<XElement>().Select(t => t.Element("PrefabName")?.Value ?? "Unknown").Distinct().ToList();
            output.AppendText("Items Found:");
            foreach (var prefab in uniquePrefabNames)
            {
                output.AppendText(prefab + "\r\n");
            }
            output.AppendText("\r\n");
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
                    var prefabName = thingElement.Element("PrefabName")?.Value;
                    if (string.IsNullOrEmpty(prefabName))
                    {
                        prefabName = cleanId;
                        
                    }
                    string tagName = ClassifyTagName(thingElement);                    
                    var spawnEntry = new XElement(tagName,
                        new XAttribute("Id", prefabName),
                        new XAttribute("HideInStartScreen", "true"),
                        new XElement("TempReferenceId", referenceId),
                        new XElement("TempParentReferenceId", parentReferenceId),
                        new XElement("TempParentSlotId", parentSlotId)
                    );
                    spawnEntry.SetAttributeValue("Id", prefabName);
                    //Console.WriteLine($"Added {tagName} with TempReferenceId={referenceId}, TempParentReferenceId={parentReferenceId}");
                    AddCoreProps(thingElement, spawnEntry);
                    AddBuildState(thingElement, spawnEntry);
                    AddDamageState(thingElement, spawnEntry);
                    AddSpawnPositionAndReagents(thingElement, spawnEntry);
                    AddStates(thingElement, spawnEntry);
                    AddHealthCurrentForDynamicThings(thingElement, spawnEntry);
                    spawnEntries.Add(spawnEntry);
                    exportedCount++;
                    
                }
            }
            AugmentTankContents(spawnEntries, doc, output); // Augment with gases; doc from MainForm
            output.AppendText($"Extracted {exportedCount} spawn entries, {spawnEntries.Count(s => s.Name.LocalName == "Structure")} Structures, {spawnEntries.Count(s => s.Name.LocalName == "Item")} Items.\r\n");
            return spawnEntries;
        }

        private static string ClassifyTagName(XElement thingElement)
        {
            var xsiType = thingElement.Attribute(
                XName.Get("type", "http://www.w3.org/2001/XMLSchema-instance"))?.Value ?? "";
            var prefabName = thingElement.Element("PrefabName")?.Value ?? "";

            // 1. Structures via xsi:type
            if (xsiType.Contains("StructureSaveData"))
                return "Structure";

            // 2. Structures via PrefabName (e.g., StructureSolarPanel45)
            if (prefabName.StartsWith("Structure", StringComparison.OrdinalIgnoreCase))
                return "Structure";

            // 3. DynamicThing via xsi:type or known prefabs
            if (xsiType.Contains("DynamicThingSaveData") ||
                prefabName == "LanderCapsuleSmall" ||
                prefabName == "DynamicGasTankAdvanced" ||
                prefabName == "CrateMkII" ||
                prefabName == "Rover_MkI")
                return "DynamicThing";

            // 4. Wreckage and LanderCapsule (not DynamicThing)
            if (prefabName.Contains("Wreckage") || prefabName.Contains("LanderCapsule"))
                return "Item";

            return "Item"; // Default
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
            AddConsumableSpecificProps(thingElement, spawnEntry);
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
        private static void AugmentTankContents(List<XElement> spawnEntries, XDocument doc, TextBox output)
        {
            var allAtmospheres = doc?.Root?.Element("Atmospheres")?.Elements("AtmosphereSaveData")?.ToList() ?? new List<XElement>();
            var atmospheres = allAtmospheres.Where(a => int.TryParse(a.Element("ThingReferenceId")?.Value, out int refId) && refId != 0).ToList();
            if (!atmospheres.Any()) return;
            var atmosphereGroup = atmospheres.GroupBy(a => int.Parse(a.Element("ThingReferenceId")?.Value ?? "0"));
            var atmosphereByThingId = atmosphereGroup.ToDictionary(g => g.Key, g => g.First());
            int duplicateCount = atmosphereGroup.Count(g => g.Count() > 1);
            if (duplicateCount > 0)
            {
                var duplicateIds = atmosphereGroup.Where(g => g.Count() > 1).Select(g => g.Key).ToList();
                output.AppendText($"Duplicate IDs: {string.Join(", ", duplicateIds)} (e.g., tank {duplicateIds.First()} has {atmosphereGroup.First(g => g.Key == duplicateIds.First()).Count()} AtmosphereSaveData).\r\n");
                output.AppendText($"Warning: {duplicateCount} duplicate ThingReferenceId in Atmospheres (using first, skipping extras).\r\n");

            }
            var cvDict = new Dictionary<string, double>
                {
                    {"Oxygen", 21.1},
                    {"Nitrogen", 20.6},
                    {"CarbonDioxide", 28.2},
                    {"Volatiles", 20.4},
                    {"Chlorine", 25.2},
                    {"Water", 72.0},
                    {"PollutedWater", 72.0},
                    {"NitrousOxide", 37.2},
                    {"LiquidNitrogen", 56.0},
                    {"LiquidOxygen", 54.0},
                    {"LiquidVolatiles", 70.0},
                    {"Steam", 33.6},
                    {"LiquidCarbonDioxide", 75.0},
                    {"LiquidPollutant", 72.0},
                    {"LiquidNitrousOxide", 80.0},
                    {"Hydrogen", 20.5},
                    {"LiquidHydrogen", 28.0}
                };
            int tankCount = 0;
            foreach (var entry in spawnEntries)
            {
                var prefab = entry.Attribute("Id")?.Value ?? "";
                if (prefab.Contains("GasCanister") || prefab.Contains("LiquidCanister") ||
                    prefab.Contains("GasTank") || prefab.Contains("LiquidTank") ||
                    prefab == "DynamicGasTankBasic" || prefab == "DynamicGasTankAdvanced" ||
                    prefab == "DynamicLiquidTankBasic" || prefab == "DynamicLiquidTankAdvanced" ||
                    prefab == "StructureGasTankBasic" || prefab == "StructureGasTankAdvanced" ||
                    prefab == "StructureLiquidTankBasic" || prefab == "StructureLiquidTankAdvanced")
                {
                    var refIdStr = entry.Element("TempReferenceId")?.Value ?? "0";
                    if (int.TryParse(refIdStr, out int refId) && atmosphereByThingId.TryGetValue(refId, out var atm))
                    {
                        double totalMoles = 0;
                        double totalCvWeighted = 0;
                        if (double.TryParse(atm.Element("Energy")?.Value, out double energy) && energy > 0)
                        {
                            var contentElements = new List<XElement>();
                            foreach (var child in atm.Elements())
                            {
                                string name = child.Name.LocalName;
                                double moles;
                                if (name != "Energy" &&
                                    name != "Volume" &&
                                    name != "ThingReferenceId" &&
                                    name != "ReferenceId" &&
                                    double.TryParse(child.Value, out moles) &&
                                    moles > 0)
                                {
                                    totalMoles += moles;
                                    double cv;
                                    if (cvDict.TryGetValue(name, out cv))
                                    {
                                        totalCvWeighted += moles * cv;
                                    }
                                    else
                                    {
                                        cv = 20.8;
                                        totalCvWeighted += moles * cv;
                                    }
                                    string unit = name.StartsWith("Liquid") ? "Litres" : "Moles";
                                    contentElements.Add(new XElement("Gas",
                                        new XAttribute("Type", name),
                                        new XAttribute(unit, moles.ToString("F2")),
                                        new XAttribute("Celsius", "20.00") // Placeholder; backfill below
                                    ));
                                }
                            }
                            if (contentElements.Any())
                            {
                                double celsius = 20.0;
                                if (totalMoles > 0)
                                {
                                    double weightedCv = totalCvWeighted / totalMoles;
                                    double tK = energy / (totalMoles * weightedCv);
                                    celsius = Math.Max(Math.Min(tK - 273.15, 150), -200);
                                }
                                foreach (var gas in contentElements)
                                {
                                    gas.SetAttributeValue("Celsius", celsius.ToString("F2"));
                                }
                                foreach (var elem in contentElements)
                                {
                                    entry.Add(elem);
                                }
                                tankCount++;
                            }
                        }
                    }
                }
            }
            if (tankCount > 0)
            {
                output.AppendText($"Augmented {tankCount} tanks with gas properties.\r\n");
            }
        }

        private static void AddConsumableSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var prefab = spawnEntry.Attribute("Id")?.Value ?? thingElement.Element("PrefabName")?.Value ?? "";
            if (prefab.Contains("ItemWaterBottle") || prefab.Contains("ItemCerealBar") || prefab.Contains("ItemGasCanisterEmpty"))
            {
                var quantity = thingElement.Element("Quantity")?.Value;
                if (quantity != null && float.TryParse(quantity, out float qValue) && qValue > 0)
                {
                    var maxCapacities = new Dictionary<string, float>
            {
                {"ItemWaterBottle", 1.5f},
                {"ItemCerealBar", 1.0f},
                {"ItemGasCanisterEmpty", 1.0f}
            }; // Add more as needed
                    float maxCapacity = 1.0f;
                    if (maxCapacities.TryGetValue(prefab, out float value))
                    {
                        maxCapacity = value;
                    }
                    int percent = (int)Math.Min((qValue / maxCapacity) * 100, 100);
                    spawnEntry.Add(new XElement("Percent", new XAttribute("Value", percent.ToString())));
                }
            }
        }
    }
}