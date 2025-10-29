using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace StationeersStructureXMLConverter
{
    public static class DestinationExport
    {
        private static void TransformToBatch(List<object> things, string destPath, TextBox output)
        {
            int exportedCount = 0;
            foreach (var thingObj in things)
            {
                if (thingObj is XElement thingElement)
                {
                    var xsiType = thingElement.Attribute(XName.Get("type", "http://www.w3.org/2001/XMLSchema-instance"))?.Value ?? "Unknown";
                    var exportDoc = new XDocument(
                        new XElement("Thing",
                            new XAttribute("type", xsiType),
                            thingElement.Elements()
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

        public static void TransformToNewSchema(List<object> things, string destPath, TextBox output)
        {
            if (things.Count == 0)
            {
                output.AppendText("No things to export.\r\n");
                return;
            }
            output.AppendText($"Processing {things.Count} input things.\r\n");
            string scenarioName = "My_Scenario";
            string spawnId = scenarioName + "Things";
            var gameData = BuildGameData(things, scenarioName, spawnId, output);
            output.AppendText($"Attempting to write to: {destPath}\r\n");
            try
            {
                var preparedPath = PrepareOutputPath(destPath, output);
                if (string.IsNullOrEmpty(preparedPath))
                {
                    return;
                }
                string fullPath = preparedPath;

                using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    gameData.Save(fs);
                }
                output.AppendText($"Exported {things.Count} spawn entries to {Path.GetDirectoryName(fullPath)}\r\n");
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                output.AppendText($"Error: Access denied to '{destPath}'. Please run as administrator or choose a writable directory.\r\n");
                return;
            }
            catch (IOException ex)
            {
                output.AppendText($"Error: Unable to write to '{destPath}'. The file may be in use or the directory is read-only. Try a different location.\r\n");
                return;
            }
            catch (Exception ex)
            {
                output.AppendText($"Error: An unexpected issue occurred while saving '{destPath}': {ex.Message}\r\n");
                return;
            }
        }

        private static string PrepareOutputPath(string destPath, TextBox output)
        {
            if (string.IsNullOrEmpty(destPath))
            {
                output.AppendText("Error: No destination path provided.\r\n");
                return string.Empty;
            }
            string fullPath = Path.GetFullPath(destPath.TrimEnd('\\'));
            if (Path.GetExtension(fullPath).Length == 0)
            {
                output.AppendText($"Error: '{fullPath}' requires a file extension (e.g., .xml).\r\n");
                return string.Empty;
            }
            string directory = Path.GetDirectoryName(fullPath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return fullPath;
        }

        private static XDocument BuildGameData(List<object> things, string scenarioName, string spawnId, TextBox output)
        {
            var spawnEntries = ProcessThingsToSpawnEntries(things, output);
            var nestedHierarchy = BuildNestedHierarchy(spawnEntries, output);
            return new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("GameData",
                    new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                    new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
                    BuildWorldSettings(scenarioName),
                    BuildSpawn(nestedHierarchy, spawnId)
                )
            );
        }

        private static List<XElement> ProcessThingsToSpawnEntries(List<object> things, TextBox output)
        {
            var spawnEntries = new List<XElement>();
            foreach (var thingObj in things)
            {
                if (thingObj is XElement thingElement)
                {
                    var spawnEntry = CreateSpawnEntryFromThing(thingElement, output);
                    if (spawnEntry != null)
                    {
                        spawnEntries.Add(spawnEntry);
                    }
                }
            }
            return spawnEntries;
        }

        private static XElement CreateSpawnEntryFromThing(XElement thingElement, TextBox output)
        {
            var xsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var xsiType = thingElement.Attribute(XName.Get("type", xsiNs))?.Value ?? "Unknown";
            var cleanId = xsiType.Replace("SaveData", "");
            var prefabName = thingElement.Element("PrefabName")?.Value ?? cleanId;
            Console.WriteLine($"Processing {prefabName}: ReferenceId={thingElement.Element("ReferenceId")?.Value}, ParentReferenceId={thingElement.Element("ParentReferenceId")?.Value}");
            // tagName already set in prepped entry; skip re-classify
            string tagName = "Item"; // Fallback for raw inputs
            var spawnEntry = new XElement(tagName,
                new XAttribute("Id", prefabName),
                new XAttribute("HideInStartScreen", "true")
            );
            var referenceId = thingElement.Element("ReferenceId")?.Value ?? "0";
            if (string.IsNullOrEmpty(referenceId)) Console.WriteLine($"Warning: Missing ReferenceId for {prefabName}");
            var parentReferenceId = thingElement.Element("ParentReferenceId")?.Value ?? "0";
            var parentSlotId = thingElement.Element("ParentSlotId")?.Value ?? "0";
            spawnEntry.Add(new XElement("TempReferenceId", referenceId));
            spawnEntry.Add(new XElement("TempParentReferenceId", parentReferenceId));
            spawnEntry.Add(new XElement("TempParentSlotId", parentSlotId));
            Console.WriteLine($"Added {tagName} with TempReferenceId={referenceId}, TempParentReferenceId={parentReferenceId}");
            AddAllProps(thingElement, spawnEntry, output); // Device-specific only
            return spawnEntry;
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

        private static List<XElement> BuildNestedHierarchy(List<XElement> spawnEntries, TextBox output)
        {
            var nestedHierarchy = new List<XElement>();
            var idToSpawn = new Dictionary<string, XElement>();
            var nestedIds = new HashSet<string>();
            PopulateIdToSpawnDictionary(spawnEntries, idToSpawn);
            var visited = new HashSet<string>();
            var rootEntries = spawnEntries.Where(e => e.Element("TempParentReferenceId")?.Value == "0").ToList();
            foreach (var spawnEntry in rootEntries)
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
                nestedIds.Add(parentId);
            }
            Console.WriteLine($"Final nestedHierarchy count: {nestedHierarchy.Count}");
            CleanupTemporaryElements(nestedHierarchy);
            return nestedHierarchy;
        }

        private static void PopulateIdToSpawnDictionary(List<XElement> spawnEntries, Dictionary<string, XElement> idToSpawn)
        {
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
        }

        private static void CleanupTemporaryElements(List<XElement> entries)
        {
            foreach (var entry in entries)
            {
                entry.Element("TempReferenceId")?.Remove();
                entry.Element("TempParentReferenceId")?.Remove();
                entry.Element("TempParentSlotId")?.Remove();
            }
        }

        private static XElement DeepCopyXElement(XElement element)
        {
            var copy = new XElement(element.Name);
            copy.ReplaceAttributes(element.Attributes());
            copy.Add(element.Nodes().Select(n => n is XElement e ? DeepCopyXElement(e) : n));
            return copy;
        }

        private static void AddInventory(XElement parent, List<XElement> children, HashSet<string> visited, List<XElement> spawnEntries, HashSet<string> nestedIds)
        {
            foreach (var childSpawn in children)
            {
                var referenceId = childSpawn.Element("TempReferenceId")?.Value ?? "0";
                if (visited.Contains(referenceId))
                {
                    continue;
                }
                visited.Add(referenceId);
                nestedIds.Add(referenceId);
                var slotId = childSpawn.Element("TempParentSlotId")?.Value ?? "0";
                childSpawn.SetAttributeValue("SlotIndex", slotId);
                childSpawn.Element("TempParentReferenceId")?.Remove();
                childSpawn.Element("TempParentSlotId")?.Remove();
                childSpawn.Element("TempReferenceId")?.Remove();
                var childId = referenceId;
                var grandChildren = spawnEntries.Where(e => e.Element("TempParentReferenceId")?.Value == childId).ToList();
                if (grandChildren.Any())
                {
                    AddInventory(childSpawn, grandChildren, visited, spawnEntries, nestedIds);
                }
                parent.Add(DeepCopyXElement(childSpawn));
                Console.WriteLine($"Nested {childSpawn.Attribute("Id")?.Value} under {parent.Attribute("Id")?.Value} with SlotIndex={slotId}");
            }
        }

        private static XElement BuildWorldSettings(string scenarioName)
        {
            return new XElement("WorldSettings",
                new XAttribute("Id", scenarioName)
            );
        }

        private static XElement BuildSpawn(List<XElement> spawnEntries, string spawnId)
        {
            return new XElement("Spawn",
                new XAttribute("Id", spawnId),
                spawnEntries
            );
        }

        private static void AddAllProps(XElement thingElement, XElement spawnEntry, TextBox output)
        {
            // Basics now in SourceExtraction—skip here

            // Device-specific only
            AddOreSpecificProps(thingElement, spawnEntry);
            AddSolarPanelSpecificProps(thingElement, spawnEntry);
            AddDoorSpecificProps(thingElement, spawnEntry);
            AddBatterySpecificProps(thingElement, spawnEntry);
            AddInteractionProps(thingElement, spawnEntry);
            AddSimpleFabricatorSpecificProps(thingElement, spawnEntry);
            AddDeviceImportExport2SpecificProps(thingElement, spawnEntry);
            AddSorterSpecificProps(thingElement, spawnEntry);
            AddDynamicComposterSpecificProps(thingElement, spawnEntry);
            AddOutputDeviceSpecificProps(thingElement, spawnEntry);
            AddHydroponicsTraySpecificProps(thingElement, spawnEntry);
            AddLogicWriterSpecificProps(thingElement, spawnEntry);
            AddLogicBatchSlotReaderSpecificProps(thingElement, spawnEntry);
            AddLogicReagentReaderSpecificProps(thingElement, spawnEntry);
            AddLogicSlotReaderSpecificProps(thingElement, spawnEntry);
            AddLogicMirrorSpecificProps(thingElement, spawnEntry);
            AddLogicPidControllerSpecificProps(thingElement, spawnEntry);
            AddLogicGateSpecificProps(thingElement, spawnEntry);
            AddCircuitHousingSpecificProps(thingElement, spawnEntry);
            AddAirlockControlSpecificProps(thingElement, spawnEntry);
            AddSuitSpecificProps(thingElement, spawnEntry);
            AddDuctTapeSpecificProps(thingElement, spawnEntry);
            AddProximitySensorSpecificProps(thingElement, spawnEntry);
            AddStirlingEngineSpecificProps(thingElement, spawnEntry);
            AddDynamicGasCanisterSpecificProps(thingElement, spawnEntry);
            AddSeedBagSpecificProps(thingElement, spawnEntry);
            AddFertilizedEggSpecificProps(thingElement, spawnEntry);
        }

        private static void AddOreSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var xsiNs = "http://www.w3.org/2001/XMLSchema-instance";
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
        }

        private static void AddSolarPanelSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var xsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var xsiTypeValue = thingElement.Attribute(XName.Get("type", xsiNs))?.Value;
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
        }

        private static void AddDoorSpecificProps(XElement thingElement, XElement spawnEntry)
        {
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
        }

        private static void AddBatterySpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var batteryXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var batteryXsiTypeValue = thingElement.Attribute(XName.Get("type", batteryXsiNs))?.Value;
            if (batteryXsiTypeValue != null && (batteryXsiTypeValue.Contains("BatterySaveData") || batteryXsiTypeValue.Contains("ItemBatteryCellSaveData")))
            {
                var powerStored = thingElement.Element("PowerStored")?.Value;
                if (powerStored != null && float.TryParse(powerStored, out float chargeValue))
                {
                    bool isFull = chargeValue >= 0; // Placeholder; adjust
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
        }

        private static void AddInteractionProps(XElement thingElement, XElement spawnEntry)
        {
            var interactXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var interactXsiTypeValue = thingElement.Attribute(XName.Get("type", interactXsiNs))?.Value;
            if (interactXsiTypeValue != null && interactXsiTypeValue.Contains("SaveData"))
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
        }

        private static void AddSimpleFabricatorSpecificProps(XElement thingElement, XElement spawnEntry)
        {
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
        }

        private static void AddDeviceImportExport2SpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var fabricatorXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
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
                if (logicStack != null) spawnEntry.Add(logicStack);
            }
        }

        private static void AddSorterSpecificProps(XElement thingElement, XElement spawnEntry)
        {
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
                if (filters != null) spawnEntry.Add(filters);
            }
        }

        private static void AddDynamicComposterSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var fabricatorXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
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
        }

        private static void AddOutputDeviceSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var fabricatorXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var outputDeviceXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (outputDeviceXsiTypeValue != null && (outputDeviceXsiTypeValue.Contains("DynamicGasCanisterSaveData") || outputDeviceXsiTypeValue.Contains("TransformerSaveData") ||
                outputDeviceXsiTypeValue.Contains("StirlingEngineSaveData") || outputDeviceXsiTypeValue.Contains("StructurePortablesConnector")))
            {
                var outputSetting = thingElement.Element("OutputSetting")?.Value;
                if (outputSetting != null && float.TryParse(outputSetting, out _)) spawnEntry.Add(new XElement("OutputSetting", outputSetting));
            }
        }

        private static void AddHydroponicsTraySpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var fabricatorXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var hydroponicsXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (hydroponicsXsiTypeValue != null && hydroponicsXsiTypeValue.Contains("StructureHydroponicsTray"))
            {
                var damageRecord = thingElement.Element("DamageRecord")?.Value;
                if (damageRecord != null) spawnEntry.Add(new XElement("DamageRecord", damageRecord));
            }
        }

        private static void AddLogicWriterSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var fabricatorXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
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
        }

        private static void AddLogicBatchSlotReaderSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var fabricatorXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
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
        }

        private static void AddLogicReagentReaderSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var fabricatorXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
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
        }

        private static void AddLogicSlotReaderSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var fabricatorXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
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
        }

        private static void AddLogicMirrorSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var fabricatorXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var mirrorXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (mirrorXsiTypeValue != null && mirrorXsiTypeValue.Contains("StructureLogicMirror"))
            {
                var currentDeviceId = thingElement.Element("CurrentDeviceId")?.Value;
                if (currentDeviceId != null && int.TryParse(currentDeviceId, out _)) spawnEntry.Add(new XElement("CurrentDeviceId", currentDeviceId));
            }
        }

        private static void AddLogicPidControllerSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var fabricatorXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
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
        }

        private static void AddLogicGateSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var fabricatorXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
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
        }

        private static void AddCircuitHousingSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var fabricatorXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
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
        }

        private static void AddAirlockControlSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var fabricatorXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var airlockControlXsiTypeValue = thingElement.Attribute(XName.Get("type", fabricatorXsiNs))?.Value;
            if (airlockControlXsiTypeValue != null && airlockControlXsiTypeValue.Contains("CircuitboardAirlockControl"))
            {
                var linkedDeviceReferences = thingElement.Element("LinkedDeviceReferences");
                if (linkedDeviceReferences != null) spawnEntry.Add(linkedDeviceReferences);
                var flag = thingElement.Element("Flag")?.Value;
                if (flag != null && int.TryParse(flag, out _)) spawnEntry.Add(new XElement("Flag", flag));
                var masterMotherboard = thingElement.Element("MasterMotherboard")?.Value;
                if (masterMotherboard != null && int.TryParse(masterMotherboard, out _)) spawnEntry.Add(new XElement("MasterMotherboard", masterMotherboard));
                var lastIndex = thingElement.Element("LastIndex")?.Value;
                if (lastIndex != null && int.TryParse(lastIndex, out _)) spawnEntry.Add(new XElement("LastIndex", lastIndex));
            }
        }

        private static void AddSuitSpecificProps(XElement thingElement, XElement spawnEntry)
        {
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
        }

        private static void AddDuctTapeSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var suitXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var ductTapeXsiTypeValue = thingElement.Attribute(XName.Get("type", suitXsiNs))?.Value;
            if (ductTapeXsiTypeValue != null && ductTapeXsiTypeValue.Contains("ItemDuctTapeSaveData"))
            {
                var quantity = thingElement.Element("Quantity")?.Value;
                if (quantity != null && float.TryParse(quantity, out _)) spawnEntry.Add(new XElement("Quantity", quantity));
            }
        }

        private static void AddProximitySensorSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var suitXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var proximityXsiTypeValue = thingElement.Attribute(XName.Get("type", suitXsiNs))?.Value;
            if (proximityXsiTypeValue != null && proximityXsiTypeValue.Contains("ProximitySensorSaveData"))
            {
                var setting = thingElement.Element("Setting")?.Value;
                if (setting != null && int.TryParse(setting, out _)) spawnEntry.Add(new XElement("Setting", setting));
            }
        }

        private static void AddStirlingEngineSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var suitXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var stirlingXsiTypeValue = thingElement.Attribute(XName.Get("type", suitXsiNs))?.Value;
            if (stirlingXsiTypeValue != null && stirlingXsiTypeValue.Contains("StirlingEngineSaveData"))
            {
                var outputSetting = thingElement.Element("OutputSetting")?.Value;
                if (outputSetting != null && int.TryParse(outputSetting, out _)) spawnEntry.Add(new XElement("OutputSetting", outputSetting));
                var hotInputAtmosphere = thingElement.Element("HotInputAtmosphere");
                if (hotInputAtmosphere != null) spawnEntry.Add(hotInputAtmosphere);
                var hotSideAtmosphere = thingElement.Element("HotSideAtmosphere");
                if (hotSideAtmosphere != null) spawnEntry.Add(hotSideAtmosphere);
                var coldSideAtmosphere = thingElement.Element("ColdSideAtmosphere");
                if (coldSideAtmosphere != null) spawnEntry.Add(coldSideAtmosphere);
            }
        }

        private static void AddDynamicGasCanisterSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var suitXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var gasCanisterXsiTypeValue = thingElement.Attribute(XName.Get("type", suitXsiNs))?.Value;
            if (gasCanisterXsiTypeValue != null && gasCanisterXsiTypeValue.Contains("DynamicGasCanisterSaveData"))
            {
                var outputSetting = thingElement.Element("OutputSetting")?.Value;
                if (outputSetting != null && float.TryParse(outputSetting, out _)) spawnEntry.Add(new XElement("OutputSetting", outputSetting));
            }
        }

        private static void AddSeedBagSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var suitXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var seedBagXsiTypeValue = thingElement.Attribute(XName.Get("type", suitXsiNs))?.Value;
            if (seedBagXsiTypeValue != null && seedBagXsiTypeValue.Contains("SeedBag_SoybeanSaveData"))
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
                if (stackedGeneCollections != null) spawnEntry.Add(stackedGeneCollections);
                var plantRecord = thingElement.Element("PlantRecord");
                if (plantRecord != null) spawnEntry.Add(plantRecord);
                var aggregateStates = thingElement.Element("AggregateStates");
                if (aggregateStates != null) spawnEntry.Add(aggregateStates);
                var currentStates = thingElement.Element("CurrentStates");
                if (currentStates != null) spawnEntry.Add(currentStates);
            }
        }

        private static void AddFertilizedEggSpecificProps(XElement thingElement, XElement spawnEntry)
        {
            var suitXsiNs = "http://www.w3.org/2001/XMLSchema-instance";
            var eggXsiTypeValue = thingElement.Attribute(XName.Get("type", suitXsiNs))?.Value;
            if (eggXsiTypeValue != null && eggXsiTypeValue.Contains("ItemFertilizedEggSaveData"))
            {
                var eggHatchTime = thingElement.Element("EggHatchTime")?.Value;
                if (eggHatchTime != null && int.TryParse(eggHatchTime, out _)) spawnEntry.Add(new XElement("EggHatchTime", eggHatchTime));
                var viable = thingElement.Element("Viable")?.Value;
                if (viable != null) spawnEntry.Add(new XElement("Viable", viable));
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

        private static void AddReagents(XElement thingElement, XElement spawnEntry)
        {
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
                    if (!string.IsNullOrEmpty(stateName) && !string.IsNullOrEmpty(stateValue) && int.TryParse(stateValue, out _))
                    {
                        statesElement.Add(new XElement("State",
                            new XAttribute("Name", stateName),
                            stateValue
                        ));
                    }
                }
                if (statesElement.HasElements)
                {
                    spawnEntry.Add(statesElement);
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
    }
}