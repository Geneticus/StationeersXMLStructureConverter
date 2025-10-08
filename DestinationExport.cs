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

        private static XElement DeepCopyXElement(XElement element)
        {
            var copy = new XElement(element.Name);
            copy.ReplaceAttributes(element.Attributes());
            copy.Add(element.Nodes().Select(n => n is XElement e ? DeepCopyXElement(e) : n));
            return copy;
        }

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
                    Console.WriteLine($"Processing {prefabName}: ReferenceId={thingElement.Element("ReferenceId")?.Value}, ParentReferenceId={thingElement.Element("ParentReferenceId")?.Value}");
                    // Classify tag by type, targeting specific free-floating DynamicThings
                    string tagName = "Item"; // Default
                    if (prefabName.StartsWith("Structure")) tagName = "Structure";
                    else if (prefabName == "DynamicGasTankAdvanced" || prefabName == "DynamicMKIILiquidCanisterEmpty" ||
                             prefabName == "CrateMkII" || prefabName == "DynamicGasCanisterEmpty" ||
                             prefabName == "DynamicLiquidCanisterEmpty" || prefabName == "LanderCapsuleSmall") tagName = "DynamicThing";
                    else if (prefabName.Contains("LanderCapsule")) tagName = "Item"; // Capsule as Item
                    else if (prefabName.Contains("Wreckage")) tagName = "Item"; // Wreckage as Item with variant
                    var spawnEntry = new XElement(tagName,
                        new XAttribute("Id", prefabName),
                        new XAttribute("HideInStartScreen", "true")
                    );
                    // Add temporary elements for nesting
                    var referenceId = thingElement.Element("ReferenceId")?.Value ?? "0";
                    if (string.IsNullOrEmpty(referenceId)) Console.WriteLine($"Warning: Missing ReferenceId for {prefabName}");
                    var parentReferenceId = thingElement.Element("ParentReferenceId")?.Value ?? "0";
                    var parentSlotId = thingElement.Element("ParentSlotId")?.Value ?? "0";
                    spawnEntry.Add(new XElement("TempReferenceId", referenceId));
                    spawnEntry.Add(new XElement("TempParentReferenceId", parentReferenceId));
                    spawnEntry.Add(new XElement("TempParentSlotId", parentSlotId));
                    Console.WriteLine($"Added {tagName} with TempReferenceId={referenceId}, TempParentReferenceId={parentReferenceId}");
                    // Add all child elements from ThingSaveData
                    AddAllProps(thingElement, spawnEntry); // Sub-method for all props
                    spawnEntries.Add(spawnEntry);
                }
            }

            // Build nested hierarchy from top-level items only
            var nestedHierarchy = new List<XElement>();
            var idToSpawn = new Dictionary<string, XElement>();
            var nestedIds = new HashSet<string>();
            foreach (var spawnEntry in spawnEntries)
            {
                var referenceId = spawnEntry.Element("TempReferenceId")?.Value ?? "0";
                if (!string.IsNullOrEmpty(referenceId))
                {
                    idToSpawn[referenceId] = spawnEntry;
                }
                else
                {
                    Console.WriteLine($"Warning: Skipping entry with no TempReferenceId");
                }
            }
            var visited = new HashSet<string>();
            foreach (var spawnEntry in spawnEntries.Where(e => e.Element("TempParentReferenceId")?.Value == "0"))
            {
                var parentId = spawnEntry.Element("TempReferenceId")?.Value ?? "0";
                Console.WriteLine($"Processing top-level {parentId}");
                var topLevelEntry = DeepCopyXElement(spawnEntry);
                nestedHierarchy.Add(topLevelEntry);
                var children = spawnEntries.Where(e => e.Element("TempParentReferenceId")?.Value == parentId).ToList();
                if (children.Any())
                {
                    Console.WriteLine($"Parent {parentId} has {children.Count} children: {string.Join(", ", children.Select(c => c.Element("TempReferenceId")?.Value ?? "None"))}");
                    AddInventory(topLevelEntry, children, visited, spawnEntries, nestedIds);
                }
                nestedIds.Add(parentId); // Track top-level IDs to avoid reprocessing
            }
            Console.WriteLine($"Final nestedHierarchy count: {nestedHierarchy.Count}");

            // Clean up temporary elements before return
            foreach (var entry in nestedHierarchy)
            {
                entry.Element("TempReferenceId")?.Remove();
                entry.Element("TempParentReferenceId")?.Remove();
                entry.Element("TempParentSlotId")?.Remove();
            }

            return new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("GameData",
                    new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                    new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
                    BuildWorldSettings(scenarioName), // Sub-method
                    BuildSpawn(nestedHierarchy, spawnId) // Sub-method
                )
            );
        }

        private static void AddInventory(XElement parent, List<XElement> children, HashSet<string> visited, List<XElement> spawnEntries, HashSet<string> nestedIds)
        {
            foreach (var childSpawn in children)
            {
                var referenceId = childSpawn.Element("TempReferenceId")?.Value ?? "0";
                if (visited.Contains(referenceId))
                {
                    continue; // Skip to prevent cycles
                }
                visited.Add(referenceId);
                nestedIds.Add(referenceId); // Mark as nested

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
                    AddInventory(childSpawn, grandChildren, visited, spawnEntries, nestedIds);
                }

                parent.Add(DeepCopyXElement(childSpawn)); // Use deep copy to avoid reference issues
                Console.WriteLine($"Nested {childSpawn.Attribute("Id")?.Value} under {parent.Attribute("Id")?.Value} with SlotIndex={slotId}");
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

            // CustomColorIndex (int) -> <Color Id="ColorName" /> only if valid
            var customColorIndex = thingElement.Element("CustomColorIndex")?.Value;
            if (customColorIndex != null)
            {
                int index;
                if (int.TryParse(customColorIndex, out index))
                {
                    string colorName = null;
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
                    else if (index < 0 || index > 11) colorName = null; // Invalid indices, no <Color> tag

                    if (colorName != null)
                    {
                        spawnEntry.Add(new XElement("Color",
                            new XAttribute("Id", colorName)
                        ));
                    }
                }
                // If parsing fails or customColorIndex is null, no <Color> tag is added
            }

            // Indestructable (bool)
            var indestructable = thingElement.Element("Indestructable")?.Value;
            if (indestructable != null)
            {
                spawnEntry.Add(new XElement("Indestructable", indestructable));
            }

            // Add DamageState using sub-method
            AddDamageState(thingElement, spawnEntry); // Call existing sub-method
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
            // Add SpawnPosition
            var spawnPosition = BuildSpawnPosition(thingElement); // Sub-method
            spawnEntry.Add(spawnPosition);
            // Add Reagents if present
            var reagents = thingElement.Element("Reagents");
            if (reagents != null)
            {
                spawnEntry.Add(reagents.Elements());
            }

            // Add States transformation (aligned with WorldSettings.xsd)
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

            // Add HealthCurrent (conditional for dynamic items)
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

            // Add Quantity and QuantitySmelted for OreSaveData
            var xsiTypeValue = thingElement.Attribute(XName.Get("type", xsiNs))?.Value;
            if (xsiTypeValue != null && xsiTypeValue.Contains("OreSaveData"))
            {
                var quantity = thingElement.Element("Quantity")?.Value;
                if (quantity != null && int.TryParse(quantity, out _))
                {
                    spawnEntry.Add(new XElement("Quantity", quantity));
                }
                var quantitySmelted = thingElement.Element("QuantitySmelted")?.Value;
                if (quantitySmelted != null && int.TryParse(quantitySmelted, out _))
                {
                    spawnEntry.Add(new XElement("QuantitySmelted", quantitySmelted));
                }
            }

            // Add Horizontal and Vertical for SolarPanelSaveData
            if (xsiTypeValue != null && xsiTypeValue.Contains("SolarPanelSaveData"))
            {
                var horizontal = thingElement.Element("Horizontal")?.Value;
                if (horizontal != null && int.TryParse(horizontal, out _))
                {
                    spawnEntry.Add(new XElement("Horizontal", horizontal));
                }
                var vertical = thingElement.Element("Vertical")?.Value;
                if (vertical != null && int.TryParse(vertical, out _))
                {
                    spawnEntry.Add(new XElement("Vertical", vertical));
                }
                var targetHorizontal = thingElement.Element("TargetHorizontal")?.Value;
                if (targetHorizontal != null && int.TryParse(targetHorizontal, out _))
                {
                    spawnEntry.Add(new XElement("TargetHorizontal", targetHorizontal));
                }
                var targetVertical = thingElement.Element("TargetVertical")?.Value;
                if (targetVertical != null && int.TryParse(targetVertical, out _))
                {
                    spawnEntry.Add(new XElement("TargetVertical", targetVertical));
                }
            }

            // Add Setting for DoorSaveData
            var doorXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var doorXsiTypeValue = thingElement.Attribute(XName.Get("type", doorXsiNs))?.Value;
            if (doorXsiTypeValue != null && doorXsiTypeValue.Contains("DoorSaveData"))
            {
                var setting = thingElement.Element("Setting")?.Value;
                if (setting != null && int.TryParse(setting, out _))
                {
                    spawnEntry.Add(new XElement("Setting", setting));
                }
            }

            // Add Charge Amount for Batteries (Structural and Portable)
            var batteryXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var batteryXsiTypeValue = thingElement.Attribute(XName.Get("type", batteryXsiNs))?.Value;
            if (batteryXsiTypeValue != null && (batteryXsiTypeValue.Contains("BatterySaveData") || batteryXsiTypeValue.Contains("ItemBatteryCellSaveData")))
            {
                var powerStored = thingElement.Element("PowerStored")?.Value;
                if (powerStored != null && float.TryParse(powerStored, out float chargeValue))
                {
                    // Optional State attribute; default to numeric value unless context suggests "Full"
                    bool isFull = chargeValue >= 0; // Placeholder logic; adjust based on max charge or source state
                    if (isFull)
                    {
                        spawnEntry.Add(new XElement("Charge",
                            new XAttribute("State", "Full"),
                            chargeValue.ToString()
                        ));
                    }
                    else
                    {
                        spawnEntry.Add(new XElement("Charge", chargeValue.ToString()));
                    }
                }
            }

            // Add Interaction Elements for Interactable Items
            var interactXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var interactXsiTypeValue = thingElement.Attribute(XName.Get("type", interactXsiNs))?.Value;
            if (interactXsiTypeValue != null && interactXsiTypeValue.Contains("SaveData")) // Broad check for interactables
            {
                var interactions = thingElement.Elements("Interaction");
                if (interactions.Any())
                {
                    foreach (var interaction in interactions)
                    {
                        var type = interaction.Attribute("Type")?.Value;
                        var value = interaction.Attribute("Value")?.Value;
                        if (type != null && value != null && int.TryParse(value, out _))
                        {
                            spawnEntry.Add(new XElement("Interaction",
                                new XAttribute("Type", type),
                                new XAttribute("Value", value)
                            ));
                        }
                    }
                }
            }

            // Add Device-Specific Properties for SimpleFabricatorSaveData
            var fabricatorXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var fabricatorXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (fabricatorXsiTypeValue != null && fabricatorXsiTypeValue.Contains("SimpleFabricatorSaveData"))
            {
                var importCount = thingElement.Element("ImportCount")?.Value;
                if (importCount != null && int.TryParse(importCount, out _)) spawnEntry.Add(new XElement("ImportCount", importCount));
                var importState = thingElement.Element("ImportState")?.Value;
                if (importState != null && int.TryParse(importState, out _)) spawnEntry.Add(new XElement("ImportState", importState));
                var exportCount = thingElement.Element("ExportCount")?.Value;
                if (exportCount != null && int.TryParse(exportCount, out _)) spawnEntry.Add(new XElement("ExportCount", exportCount));
                var exportState = thingElement.Element("ExportState")?.Value;
                if (exportState != null && int.TryParse(exportState, out _)) spawnEntry.Add(new XElement("ExportState", exportState));
                var fabricatorJob = thingElement.Element("FabricatorJob");
                if (fabricatorJob != null)
                {
                    var quantity = fabricatorJob.Attribute("Quantity")?.Value;
                    if (quantity != null && int.TryParse(quantity, out _))
                    {
                        spawnEntry.Add(new XElement("FabricatorJob", new XAttribute("Quantity", quantity)));
                    }
                }
                var currentIndex = thingElement.Element("CurrentIndex")?.Value;
                if (currentIndex != null && int.TryParse(currentIndex, out _)) spawnEntry.Add(new XElement("CurrentIndex", currentIndex));
            }

            // Add Device-Specific Properties for DeviceImportExport2SaveData
            var importExport2XsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (importExport2XsiTypeValue != null && importExport2XsiTypeValue.Contains("DeviceImportExport2SaveData"))
            {
                var importCount = thingElement.Element("ImportCount")?.Value;
                if (importCount != null && int.TryParse(importCount, out _)) spawnEntry.Add(new XElement("ImportCount", importCount));
                var importState = thingElement.Element("ImportState")?.Value;
                if (importState != null && int.TryParse(importState, out _)) spawnEntry.Add(new XElement("ImportState", importState));
                var exportCount = thingElement.Element("ExportCount")?.Value;
                if (exportCount != null && int.TryParse(exportCount, out _)) spawnEntry.Add(new XElement("ExportCount", exportCount));
                var exportState = thingElement.Element("ExportState")?.Value;
                if (exportState != null && int.TryParse(exportState, out _)) spawnEntry.Add(new XElement("ExportState", exportState));
                var export2State = thingElement.Element("Export2State")?.Value;
                if (export2State != null && int.TryParse(export2State, out _)) spawnEntry.Add(new XElement("Export2State", export2State));
                var logicStack = thingElement.Element("LogicStack");
                if (logicStack != null) spawnEntry.Add(logicStack); // Handle as XML structure if needed
            }

            // Add Device-Specific Properties for SorterSaveData
            var sorterXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var sorterXsiTypeValue = thingElement.Attribute(XName.Get("type", sorterXsiNs))?.Value;
            if (sorterXsiTypeValue != null && sorterXsiTypeValue.Contains("SorterSaveData"))
            {
                var importCount = thingElement.Element("ImportCount")?.Value;
                if (importCount != null && int.TryParse(importCount, out _)) spawnEntry.Add(new XElement("ImportCount", importCount));
                var importState = thingElement.Element("ImportState")?.Value;
                if (importState != null && int.TryParse(importState, out _)) spawnEntry.Add(new XElement("ImportState", importState));
                var exportCount = thingElement.Element("ExportCount")?.Value;
                if (exportCount != null && int.TryParse(exportCount, out _)) spawnEntry.Add(new XElement("ExportCount", exportCount));
                var exportState = thingElement.Element("ExportState")?.Value;
                if (exportState != null && int.TryParse(exportState, out _)) spawnEntry.Add(new XElement("ExportState", exportState));
                var currentOutput = thingElement.Element("CurrentOutput")?.Value;
                if (currentOutput != null && int.TryParse(currentOutput, out _)) spawnEntry.Add(new XElement("CurrentOutput", currentOutput));
                var filters = thingElement.Element("Filters");
                if (filters != null) spawnEntry.Add(filters); // Handle as XML structure if needed
            }

            // Add Device-Specific Properties for DynamicComposterSaveData
            var composterXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (composterXsiTypeValue != null && composterXsiTypeValue.Contains("DynamicComposterSaveData"))
            {
                var unprocessedItems = thingElement.Element("UnprocessedItems")?.Value;
                if (unprocessedItems != null && int.TryParse(unprocessedItems, out _)) spawnEntry.Add(new XElement("UnprocessedItems", unprocessedItems));
                var decayFoodQuantity = thingElement.Element("SavedDecayFoodQuantity")?.Value;
                if (decayFoodQuantity != null && int.TryParse(decayFoodQuantity, out _)) spawnEntry.Add(new XElement("SavedDecayFoodQuantity", decayFoodQuantity));
                var normalFoodQuantity = thingElement.Element("SavedNormalFoodQuantity")?.Value;
                if (normalFoodQuantity != null && int.TryParse(normalFoodQuantity, out _)) spawnEntry.Add(new XElement("SavedNormalFoodQuantity", normalFoodQuantity));
                var biomassQuantity = thingElement.Element("SavedBiomassQuantity")?.Value;
                if (biomassQuantity != null && int.TryParse(biomassQuantity, out _)) spawnEntry.Add(new XElement("SavedBiomassQuantity", biomassQuantity));
            }

            // Add Device-Specific Properties for DynamicGasCanisterSaveData, TransformerSaveData, StirlingEngineSaveData, StructurePortablesConnector
            var outputDeviceXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (outputDeviceXsiTypeValue != null && (outputDeviceXsiTypeValue.Contains("DynamicGasCanisterSaveData") || outputDeviceXsiTypeValue.Contains("TransformerSaveData") ||
                outputDeviceXsiTypeValue.Contains("StirlingEngineSaveData") || outputDeviceXsiTypeValue.Contains("StructurePortablesConnector")))
            {
                var outputSetting = thingElement.Element("OutputSetting")?.Value;
                if (outputSetting != null && float.TryParse(outputSetting, out _)) spawnEntry.Add(new XElement("OutputSetting", outputSetting));
            }

            // Add Device-Specific Properties for StructureHydroponicsTray
            var hydroponicsXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (hydroponicsXsiTypeValue != null && hydroponicsXsiTypeValue.Contains("StructureHydroponicsTray"))
            {
                var damageRecord = thingElement.Element("DamageRecord")?.Value;
                if (damageRecord != null) spawnEntry.Add(new XElement("DamageRecord", damageRecord));
            }

            // Add Device-Specific Properties for StructureLogicWriterSwitch, StructureLogicBatchWriter, StructureLogicWriter
            var logicWriterXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (logicWriterXsiTypeValue != null && (logicWriterXsiTypeValue.Contains("StructureLogicWriterSwitch") || logicWriterXsiTypeValue.Contains("StructureLogicBatchWriter") ||
                logicWriterXsiTypeValue.Contains("StructureLogicWriter")))
            {
                var setting = thingElement.Element("Setting")?.Value;
                if (setting != null && int.TryParse(setting, out _)) spawnEntry.Add(new XElement("Setting", setting));
                var currentOutputId = thingElement.Element("CurrentOutputId")?.Value;
                if (currentOutputId != null && int.TryParse(currentOutputId, out _)) spawnEntry.Add(new XElement("CurrentOutputId", currentOutputId));
                var currentInputId = thingElement.Element("CurrentInputId")?.Value;
                if (currentInputId != null && int.TryParse(currentInputId, out _)) spawnEntry.Add(new XElement("CurrentInputId", currentInputId));
                var logicType = thingElement.Element("LogicType")?.Value;
                if (logicType != null) spawnEntry.Add(new XElement("LogicType", logicType));
                var lastInputId = thingElement.Element("LastInputId")?.Value;
                if (lastInputId != null && int.TryParse(lastInputId, out _)) spawnEntry.Add(new XElement("LastInputId", lastInputId));
                var lastOutputId = thingElement.Element("LastOutputId")?.Value;
                if (lastOutputId != null && int.TryParse(lastOutputId, out _)) spawnEntry.Add(new XElement("LastOutputId", lastOutputId));
                var lastSetting = thingElement.Element("LastSetting")?.Value;
                if (lastSetting != null && int.TryParse(lastSetting, out _)) spawnEntry.Add(new XElement("LastSetting", lastSetting));
            }

            // Add Device-Specific Properties for StructureLogicBatchSlotReader
            var batchSlotReaderXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (batchSlotReaderXsiTypeValue != null && batchSlotReaderXsiTypeValue.Contains("StructureLogicBatchSlotReader"))
            {
                var setting = thingElement.Element("Setting")?.Value;
                if (setting != null && int.TryParse(setting, out _)) spawnEntry.Add(new XElement("Setting", setting));
                var currentInputHash = thingElement.Element("CurrentInputHash")?.Value;
                if (currentInputHash != null && int.TryParse(currentInputHash, out _)) spawnEntry.Add(new XElement("CurrentInputHash", currentInputHash));
                var inputIndex = thingElement.Element("InputIndex")?.Value;
                if (inputIndex != null && int.TryParse(inputIndex, out _)) spawnEntry.Add(new XElement("InputIndex", inputIndex));
                var slotIndex = thingElement.Element("SlotIndex")?.Value;
                if (slotIndex != null && int.TryParse(slotIndex, out _)) spawnEntry.Add(new XElement("SlotIndex", slotIndex));
                var batchMethod = thingElement.Element("BatchMethod")?.Value;
                if (batchMethod != null) spawnEntry.Add(new XElement("BatchMethod", batchMethod));
            }

            // Add Device-Specific Properties for StructureLogicReagentReader
            var reagentReaderXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (reagentReaderXsiTypeValue != null && reagentReaderXsiTypeValue.Contains("StructureLogicReagentReader"))
            {
                var setting = thingElement.Element("Setting")?.Value;
                if (setting != null && int.TryParse(setting, out _)) spawnEntry.Add(new XElement("Setting", setting));
                var currentDeviceId = thingElement.Element("CurrentDeviceId")?.Value;
                if (currentDeviceId != null && int.TryParse(currentDeviceId, out _)) spawnEntry.Add(new XElement("CurrentDeviceId", currentDeviceId));
                var reagentHash = thingElement.Element("ReagentHash")?.Value;
                if (reagentHash != null && int.TryParse(reagentHash, out _)) spawnEntry.Add(new XElement("ReagentHash", reagentHash));
                var modeIndex = thingElement.Element("ModeIndex")?.Value;
                if (modeIndex != null && int.TryParse(modeIndex, out _)) spawnEntry.Add(new XElement("ModeIndex", modeIndex));
            }

            // Add Device-Specific Properties for StructureLogicSlotReader
            var slotReaderXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (slotReaderXsiTypeValue != null && slotReaderXsiTypeValue.Contains("StructureLogicSlotReader"))
            {
                var setting = thingElement.Element("Setting")?.Value;
                if (setting != null && int.TryParse(setting, out _)) spawnEntry.Add(new XElement("Setting", setting));
                var currentDeviceId = thingElement.Element("CurrentDeviceId")?.Value;
                if (currentDeviceId != null && int.TryParse(currentDeviceId, out _)) spawnEntry.Add(new XElement("CurrentDeviceId", currentDeviceId));
                var inputIndex = thingElement.Element("InputIndex")?.Value;
                if (inputIndex != null && int.TryParse(inputIndex, out _)) spawnEntry.Add(new XElement("InputIndex", inputIndex));
                var slotIndex = thingElement.Element("SlotIndex")?.Value;
                if (slotIndex != null && int.TryParse(slotIndex, out _)) spawnEntry.Add(new XElement("SlotIndex", slotIndex));
            }

            // Add Device-Specific Properties for StructureLogicMirror
            var mirrorXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (mirrorXsiTypeValue != null && mirrorXsiTypeValue.Contains("StructureLogicMirror"))
            {
                var currentDeviceId = thingElement.Element("CurrentDeviceId")?.Value;
                if (currentDeviceId != null && int.TryParse(currentDeviceId, out _)) spawnEntry.Add(new XElement("CurrentDeviceId", currentDeviceId));
            }

            // Add Device-Specific Properties for StructureLogicPidController
            var pidControllerXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (pidControllerXsiTypeValue != null && pidControllerXsiTypeValue.Contains("StructureLogicPidController"))
            {
                var setting = thingElement.Element("Setting")?.Value;
                if (setting != null && int.TryParse(setting, out _)) spawnEntry.Add(new XElement("Setting", setting));
                var currentDeviceId = thingElement.Element("CurrentDeviceId")?.Value;
                if (currentDeviceId != null && int.TryParse(currentDeviceId, out _)) spawnEntry.Add(new XElement("CurrentDeviceId", currentDeviceId));
                var inputIndex = thingElement.Element("InputIndex")?.Value;
                if (inputIndex != null && int.TryParse(inputIndex, out _)) spawnEntry.Add(new XElement("InputIndex", inputIndex));
                var setPoint = thingElement.Element("SetPoint")?.Value;
                if (setPoint != null && float.TryParse(setPoint, out _)) spawnEntry.Add(new XElement("SetPoint", setPoint));
                var proportionalGain = thingElement.Element("ProportionalGain")?.Value;
                if (proportionalGain != null && float.TryParse(proportionalGain, out _)) spawnEntry.Add(new XElement("ProportionalGain", proportionalGain));
                var derivativeGain = thingElement.Element("DerivativeGain")?.Value;
                if (derivativeGain != null && float.TryParse(derivativeGain, out _)) spawnEntry.Add(new XElement("DerivativeGain", derivativeGain));
                var integralGain = thingElement.Element("IntegralGain")?.Value;
                if (integralGain != null && float.TryParse(integralGain, out _)) spawnEntry.Add(new XElement("IntegralGain", integralGain));
                var processValue = thingElement.Element("ProcessValue")?.Value;
                if (processValue != null && float.TryParse(processValue, out _)) spawnEntry.Add(new XElement("ProcessValue", processValue));
                var outputMaximum = thingElement.Element("OutputMaximum")?.Value;
                if (outputMaximum != null && float.TryParse(outputMaximum, out _)) spawnEntry.Add(new XElement("OutputMaximum", outputMaximum));
                var outputMinimum = thingElement.Element("OutputMinimum")?.Value;
                if (outputMinimum != null && float.TryParse(outputMinimum, out _)) spawnEntry.Add(new XElement("OutputMinimum", outputMinimum));
            }

            // Add Device-Specific Properties for StructureLogicGate
            var logicGateXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (logicGateXsiTypeValue != null && logicGateXsiTypeValue.Contains("StructureLogicGate"))
            {
                var setting = thingElement.Element("Setting")?.Value;
                if (setting != null && int.TryParse(setting, out _)) spawnEntry.Add(new XElement("Setting", setting));
                var input1 = thingElement.Element("Input1")?.Value;
                if (input1 != null && int.TryParse(input1, out _)) spawnEntry.Add(new XElement("Input1", input1));
                var input2 = thingElement.Element("Input2")?.Value;
                if (input2 != null && int.TryParse(input2, out _)) spawnEntry.Add(new XElement("Input2", input2));
                var input3 = thingElement.Element("Input3")?.Value;
                if (input3 != null && int.TryParse(input3, out _)) spawnEntry.Add(new XElement("Input3", input3));
            }

            // Add Device-Specific Properties for CircuitHousingSaveData
            var circuitHousingXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (circuitHousingXsiTypeValue != null && circuitHousingXsiTypeValue.Contains("CircuitHousingSaveData"))
            {
                var setting = thingElement.Element("Setting")?.Value;
                if (setting != null && int.TryParse(setting, out _)) spawnEntry.Add(new XElement("Setting", setting));
                var deviceIDs = thingElement.Elements("DeviceIDs");
                if (deviceIDs.Any())
                {
                    foreach (var deviceId in deviceIDs)
                    {
                        var value = deviceId.Value;
                        if (value != null && int.TryParse(value, out _))
                        {
                            spawnEntry.Add(new XElement("DeviceID", value));
                        }
                    }
                }
            }

            // Add Device-Specific Properties for CircuitboardAirlockControl
            var airlockControlXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (airlockControlXsiTypeValue != null && airlockControlXsiTypeValue.Contains("CircuitboardAirlockControl"))
            {
                var linkedDeviceReferences = thingElement.Element("LinkedDeviceReferences");
                if (linkedDeviceReferences != null) spawnEntry.Add(linkedDeviceReferences); // Handle as XML structure if needed
                var flag = thingElement.Element("Flag")?.Value;
                if (flag != null && int.TryParse(flag, out _)) spawnEntry.Add(new XElement("Flag", flag));
                var masterMotherboard = thingElement.Element("MasterMotherboard")?.Value;
                if (masterMotherboard != null && int.TryParse(masterMotherboard, out _)) spawnEntry.Add(new XElement("MasterMotherboard", masterMotherboard));
                var lastIndex = thingElement.Element("LastIndex")?.Value;
                if (lastIndex != null && int.TryParse(lastIndex, out _)) spawnEntry.Add(new XElement("LastIndex", lastIndex));
            }

            // Add Device-Specific Properties for SuitSaveData
            var suitXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var suitXsiTypeValue = thingElement.Attribute(XName.Get("type", suitXsiNs))?.Value;
            if (suitXsiTypeValue != null && suitXsiTypeValue.Contains("SuitSaveData"))
            {
                var leakRatio = thingElement.Element("LeakRatio")?.Value;
                if (leakRatio != null && float.TryParse(leakRatio, out _)) spawnEntry.Add(new XElement("LeakRatio", leakRatio));
                var outputSetting = thingElement.Element("OutputSetting")?.Value;
                if (outputSetting != null && float.TryParse(outputSetting, out _)) spawnEntry.Add(new XElement("OutputSetting", outputSetting));
                var outputTemperatureSetting = thingElement.Element("OutputTemperatureSetting")?.Value;
                if (outputTemperatureSetting != null && float.TryParse(outputTemperatureSetting, out _)) spawnEntry.Add(new XElement("OutputTemperatureSetting", outputTemperatureSetting));
            }

            // Add Device-Specific Properties for ItemDuctTape
            var ductTapeXsiTypeValue = thingElement.Attribute(XName.Get("type", suitXsiNs))?.Value;
            if (ductTapeXsiTypeValue != null && ductTapeXsiTypeValue.Contains("ItemDuctTapeSaveData")) // Adjust xsi:type as needed
            {
                var quantity = thingElement.Element("Quantity")?.Value;
                if (quantity != null && float.TryParse(quantity, out _)) spawnEntry.Add(new XElement("Quantity", quantity));
            }

            // Add Device-Specific Properties for ProximitySensorSaveData
            var proximityXsiTypeValue = thingElement.Attribute(XName.Get("type", suitXsiNs))?.Value;
            if (proximityXsiTypeValue != null && proximityXsiTypeValue.Contains("ProximitySensorSaveData"))
            {
                var setting = thingElement.Element("Setting")?.Value;
                if (setting != null && int.TryParse(setting, out _)) spawnEntry.Add(new XElement("Setting", setting));
            }

            // Add Device-Specific Properties for StirlingEngineSaveData
            var stirlingXsiTypeValue = thingElement.Attribute(XName.Get("type", suitXsiNs))?.Value;
            if (stirlingXsiTypeValue != null && stirlingXsiTypeValue.Contains("StirlingEngineSaveData"))
            {
                var outputSetting = thingElement.Element("OutputSetting")?.Value;
                if (outputSetting != null && int.TryParse(outputSetting, out _)) spawnEntry.Add(new XElement("OutputSetting", outputSetting));
                var hotInputAtmosphere = thingElement.Element("HotInputAtmosphere");
                if (hotInputAtmosphere != null) spawnEntry.Add(hotInputAtmosphere); // Handle as XML structure
                var hotSideAtmosphere = thingElement.Element("HotSideAtmosphere");
                if (hotSideAtmosphere != null) spawnEntry.Add(hotSideAtmosphere); // Handle as XML structure
                var coldSideAtmosphere = thingElement.Element("ColdSideAtmosphere");
                if (coldSideAtmosphere != null) spawnEntry.Add(coldSideAtmosphere); // Handle as XML structure
            }

            // Add Device-Specific Properties for DynamicGasCanisterSaveData
            var gasCanisterXsiTypeValue = thingElement.Attribute(XName.Get("type", suitXsiNs))?.Value;
            if (gasCanisterXsiTypeValue != null && gasCanisterXsiTypeValue.Contains("DynamicGasCanisterSaveData"))
            {
                var outputSetting = thingElement.Element("OutputSetting")?.Value;
                if (outputSetting != null && float.TryParse(outputSetting, out _)) spawnEntry.Add(new XElement("OutputSetting", outputSetting));
            }
            
             // Add Device-Specific Properties for SeedBag_Soybean
            var seedBagXsiTypeValue = thingElement.Attribute(XName.Get("type", suitXsiNs))?.Value;
            if (seedBagXsiTypeValue != null && seedBagXsiTypeValue.Contains("SeedBag_SoybeanSaveData")) // Adjust xsi:type as needed
            {
                var quantity = thingElement.Element("Quantity")?.Value;
                if (quantity != null && int.TryParse(quantity, out _)) spawnEntry.Add(new XElement("Quantity", quantity));
                var stageTime = thingElement.Element("StageTime")?.Value;
                if (stageTime != null && int.TryParse(stageTime, out _)) spawnEntry.Add(new XElement("StageTime", stageTime));
                var stage = thingElement.Element("Stage")?.Value;
                if (stage != null && int.TryParse(stage, out _)) spawnEntry.Add(new XElement("Stage", stage));
                var harvestQuantity = thingElement.Element("HarvestQuantity")?.Value;
                if (harvestQuantity != null && int.TryParse(harvestQuantity, out _)) spawnEntry.Add(new XElement("HarvestQuantity", harvestQuantity));
                var seedQuantity = thingElement.Element("SeedQuantity")?.Value;
                if (seedQuantity != null && int.TryParse(seedQuantity, out _)) spawnEntry.Add(new XElement("SeedQuantity", seedQuantity));
                var fertilizerBoost = thingElement.Element("FertilizerBoost")?.Value;
                if (fertilizerBoost != null && float.TryParse(fertilizerBoost, out _)) spawnEntry.Add(new XElement("FertilizerBoost", fertilizerBoost));
                var isFertilized = thingElement.Element("IsFertilized")?.Value;
                if (isFertilized != null) spawnEntry.Add(new XElement("IsFertilized", isFertilized));
                var stackedGeneCollections = thingElement.Element("StackedGeneCollections");
                if (stackedGeneCollections != null) spawnEntry.Add(stackedGeneCollections); // Handle as XML structure
                var plantRecord = thingElement.Element("PlantRecord");
                if (plantRecord != null) spawnEntry.Add(plantRecord); // Handle as XML structure
                var aggregateStates = thingElement.Element("AggregateStates");
                if (aggregateStates != null) spawnEntry.Add(aggregateStates); // Handle as XML structure
                var currentStates = thingElement.Element("CurrentStates");
                if (currentStates != null) spawnEntry.Add(currentStates); // Handle as XML structure
            }

            // Add Device-Specific Properties for ItemFertilizedEgg
            var eggXsiTypeValue = thingElement.Attribute(XName.Get("type", suitXsiNs))?.Value;
            if (eggXsiTypeValue != null && eggXsiTypeValue.Contains("ItemFertilizedEggSaveData")) // Adjust xsi:type as needed
            {
                var eggHatchTime = thingElement.Element("EggHatchTime")?.Value;
                if (eggHatchTime != null && int.TryParse(eggHatchTime, out _)) spawnEntry.Add(new XElement("EggHatchTime", eggHatchTime));
                var viable = thingElement.Element("Viable")?.Value;
                if (viable != null) spawnEntry.Add(new XElement("Viable", viable));
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
