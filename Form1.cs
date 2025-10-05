using StationeersXMLStructureConverter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static StationeersStructureXMLConverter.SaveFileClass;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WinFormsTextBox = System.Windows.Forms.TextBox;

namespace StationeersStructureXMLConverter
{

    public partial class Form1 : Form
    {

        private bool convertComplete = false;
        private string results;
        public static string parsingErrors;
        private WorldData serialObject = new WorldData();


        //public static parseWorldData DeserializeXMLFileToObject<parseWorldData>(string XmlFilename)
        //{
        //    parseWorldData returnObject = default(parseWorldData);
        //    if (string.IsNullOrEmpty(XmlFilename)) return default(parseWorldData);

        //    try
        //    {

        //        StreamReader xmlStream = new StreamReader(XmlFilename);
        //        XmlSerializer serializer = new XmlSerializer(typeof(WorldData));
        //        returnObject = (parseWorldData)serializer.Deserialize(xmlStream);
        //    }
        //    catch (Exception ex)
        //    {
        //        parsingErrors += "/n " + ex.Message + " , " + ex.InnerException;
        //    }
        //    return returnObject;
        //}
        public static WorldData DeserializeXMLFileToObject(string XmlFilename)
        {
            WorldData returnObject = default(WorldData);
            if (!File.Exists(XmlFilename))
            {
                throw new FileNotFoundException($"The file {XmlFilename} was not found.");
            }

            
                using (StreamReader xmlStream = new StreamReader(XmlFilename))
                {
                    // Create an XmlReader to manually step through the XML
                    XmlReaderSettings settings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Parse };
                    using (XmlReader reader = XmlReader.Create(xmlStream, settings))
                    {
                        using (StreamReader sr = new StreamReader(XmlFilename))
                        {
                            string xmlContent = sr.ReadToEnd();
                            Console.WriteLine("XML Content:");
                            Console.WriteLine(xmlContent);
                        }
                        while (reader.Read())
                        {
                            Console.WriteLine(value: $"Node Type: {reader.NodeType}, Name: {reader.Name}, Value: {reader.Value} , Line: {((IXmlLineInfo)reader).LineNumber}");
                            // Manually step through and break if needed
                        }
                    try
                    {
                        // Set a breakpoint here to monitor deserialization progress
                        XmlSerializer serializer = new XmlSerializer(typeof(WorldData));
                        serializer.UnknownElement += (sender, e) =>
                        {
                            Console.WriteLine($"Unknown element: {e.Element.Name}");
                        };
                        WorldData result = null;
                        using (StreamReader file = new StreamReader(XmlFilename))
                        {
                            result = (WorldData)serializer.Deserialize(file);
                        }  // Step into this to see the details
                        Console.WriteLine($"Deserialized result: {result}");
                        if (result != null)
                        {
                            Console.WriteLine("Deserialization successful.");
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Deserialization failed: {ex.Message}");
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                        }
                    }
                }
                }
            
            
            return returnObject;
        }



        public Form1()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(sourceFile_TextBox.Text))
            {
                sourceFile_TextBox.Text = "C:\\Users\\Geneticus\\Documents\\My Games\\Stationeers\\saves\\Loulanish_8\\manualsave\\Loulan Scenario Template\\10-25-World.xml";
                //sourceFile_TextBox.Text = "U:\\Repos\\StationeersStructureXMLConverter\\ThingsTest.xml";
            }

            if (string.IsNullOrEmpty(destinationFile_TextBox.Text))
            {
                destinationFile_TextBox.Text = "C:\\Users\\Geneticus\\Documents\\My Games\\Stationeers\\saves\\Loulanish_8\\manualsave\\Loulan Scenario Template\\Things.xml";
                //if (saveFileDialog1.FileName != null && openFileDialog1.FileName != null)
            }
        }

        private void sourceButton_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sourceFile_TextBox.Text = openFileDialog1.InitialDirectory += openFileDialog1.FileName;                
            }
        }

        private void DestinationButton_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                destinationFile_TextBox.Text = saveFileDialog1.InitialDirectory += saveFileDialog1.FileName;

            }

        }

        private void Convert_Click(object sender, EventArgs e)
        {
            string xmlPath = sourceFile_TextBox.Text.Trim();
            string xmlSpawnPath = destinationFile_TextBox.Text.Trim();
            string progressLog = output_textBox.Text.Trim();

            if (string.IsNullOrEmpty(xmlPath) || !File.Exists(xmlPath))
            {
                output_textBox.Text = $"Invalid XML path: {xmlPath}";
                return;
            }

            if (string.IsNullOrEmpty(xmlSpawnPath))
            {
                output_textBox.Text = "Invalid output path.";
                return;
            }

            output_textBox.Text = "Starting deserialization...\n";  // Start logging

            try
            {
                var rootAttr = new XmlRootAttribute("WorldData");
                rootAttr.Namespace = "";
                var serializer = new XmlSerializer(typeof(WorldData), rootAttr);

                var settings = new XmlReaderSettings
                {
                    IgnoreWhitespace = true,
                    ValidationType = ValidationType.None
                };

                using (var streamReader = new StreamReader(xmlPath))
                using (var xmlReader = XmlReader.Create(streamReader, settings))
                {
                    var worldData = (WorldData)serializer.Deserialize(xmlReader);

                    var things = GetThingSaveDataList(worldData);
                    output_textBox.Text += $"Deserialized {things.Count} things.\n";

                    TransformToNewSchema(things, xmlSpawnPath, output_textBox);
                }
            }
            catch (Exception ex)
            {
                output_textBox.Text += $"Error: {ex.Message}\nInner: {ex.InnerException?.Message}";
            }
        }

        // Helper: Get list of ThingSaveDataBase from WorldData.Items
        // Fixed: Extract ThingSaveDataBase from WorldData.Items (direct Items access)
        private List<ThingSaveDataBase> GetThingSaveDataList(WorldData worldData)
        {
            var things = new List<ThingSaveDataBase>();
            if (worldData.Items == null || worldData.ItemsElementName == null || worldData.Items.Length != worldData.ItemsElementName.Length)
                return things;

            var log = "ItemsElementName values: ";
            for (int i = 0; i < worldData.ItemsElementName.Length; i++)
            {
                log += $"{worldData.ItemsElementName[i]} ({(int)worldData.ItemsElementName[i]}) ";
            }
            MessageBox.Show(log, "Debug: Enum Values");  // Run once to see, then remove

            for (int i = 0; i < worldData.Items.Length; i++)
            {
                if ((int)worldData.ItemsElementName[i] == 25)  // AllThings = 25
                {
                    var allThings = worldData.Items[i] as WorldDataThings;
                    if (allThings != null)
                    {
                        var listProperty = allThings.GetType().GetProperty("ThingSaveData") ?? allThings.GetType().GetProperty("Things");
                        if (listProperty != null)
                        {
                            var listValue = listProperty.GetValue(allThings);
                            if (listValue != null)
                            {
                                if (listValue is System.Collections.IEnumerable enumerable)
                                {
                                    foreach (var item in enumerable)
                                    {
                                        if (item is ThingSaveDataBase thing)
                                        {
                                            things.Add(thing);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                }
            }
            return things;
        }

        private void TransformToNewSchema(List<ThingSaveDataBase> things, string outputPath, WinFormsTextBox logTextBox)  // Alias for parameter, no ambiguity
        {
            var spawn = new Spawn();

            logTextBox.Text += "Starting transformation...\n";

            for (int k = 0; k < things.Count; k++)
            {
                var thing = things[k];
                var item = new Item
                {
                    Category = MapCategory(GetPrefabName(thing.Items, thing.ItemsElementName) ?? "Unknown"),
                    Id = GetReferenceId(thing.Items, thing.ItemsElementName).ToString()
                };

                item.Properties = new ItemProperties
                {
                    Color = ConvertColorIndex(GetCustomColorIndex(thing.Items, thing.ItemsElementName)),
                    Mass = GetMass(thing.Items) * 1.1,
                    Pressure = GetPressure(thing.Items) > 0 ? GetPressure(thing.Items) : 101.3
                };

                spawn.Items.Add(item);

                logTextBox.Text += $"Mapped thing {k + 1}: {item.Category} ID {item.Id} (Color: {item.Properties.Color}, Mass: {item.Properties.Mass:F1})\n";
            }

            var newSerializer = new XmlSerializer(typeof(Spawn));
            using (var writer = new StreamWriter(outputPath))
            {
                newSerializer.Serialize(writer, spawn);
            }

            logTextBox.Text += $"Transformation complete: {outputPath}\n";
        }

        // Fixed: Get PrefabName from Items (element in choice, pass ItemsElementName)
        private string GetPrefabName(object[] items, ItemsChoiceType[] itemsElementName)
        {
            if (items == null || itemsElementName == null || items.Length != itemsElementName.Length) return null;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] is string prefabName && itemsElementName[i] == ItemsChoiceType.PrefabName)
                {
                    return prefabName;
                }
            }
            return null;
        }

        // Fixed: Get ReferenceId from Items (int element in choice, pass ItemsElementName)
        private int GetReferenceId(object[] items, ItemsChoiceType[] itemsElementName)
        {
            if (items == null || itemsElementName == null || items.Length != itemsElementName.Length) return 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] is int referenceId && itemsElementName[i] == ItemsChoiceType.ReferenceId)
                {
                    return referenceId;
                }
            }
            return 0;
        }


        private int GetCustomColorIndex(object[] items, ItemsChoiceType[] itemsElementName)
        {
            if (items == null || itemsElementName == null || items.Length != itemsElementName.Length) return 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (itemsElementName[i] == ItemsChoiceType.CustomColorIndex)  
                {
                    var tempItem = items[i];
                    if (tempItem is int colorInt)
                    {
                        return colorInt;
                    }
                    else
                    {
                        int? colorNullable = tempItem as int?;
                        if (colorNullable.HasValue)
                        {
                            return colorNullable.Value;
                        }
                    }
                }
            }
            return 0;
        }

        private double GetMass(object[] items)
        {
            if (items == null) return 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] is double mass)
                {
                    return mass;
                }
            }
            return 0;
        }

        private double GetPressure(object[] items)
        {
            if (items == null) return 0;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] is double pressure)
                {
                    return pressure;
                }
            }
            return 0;
        }

        private string MapCategory(string type)
        {
            // From your subtypes
            if (type.Contains("Atmosphere")) return "AtmosphereItem";
            if (type.Contains("Ore")) return "ResourceItem";
            if (type.Contains("Grenade")) return "WeaponItem";
            if (type.Contains("Jetpack")) return "EquipmentItem";
            if (type.Contains("Plant")) return "PlantItem";
            if (type.Contains("DynamicGasCanister")) return "GasItem";
            if (type.Contains("Battery")) return "PowerItem";
            if (type.Contains("Pipe")) return "PipeItem";
            if (type.Contains("DeviceAtmospheric")) return "AtmosphericDeviceItem";
            if (type.Contains("Transformer")) return "PowerItem";
            if (type.Contains("Chute")) return "ChuteItem";
            if (type.Contains("DeviceImportExport")) return "ImportExportItem";
            if (type.Contains("Stackable")) return "StackableItem";
            if (type.Contains("SimpleFabricator")) return "MachineItem";
            if (type.Contains("Cable")) return "CableItem";
            if (type.Contains("Machine")) return "MachineItem";
            if (type.Contains("Door")) return "StructureItem";
            if (type.Contains("Consumable")) return "ConsumableItem";
            if (type.Contains("BatteryCell")) return "PowerItem";
            if (type.Contains("DynamicThing")) return "DynamicItem";
            if (type.Contains("Structure")) return "StructureItem";
            return "Unknown";
        }

        private string ConvertColorIndex(int index)
        {
            switch (index)
            {
                case 0: return "Default";
                case 1: return "Red";
                case 2: return "Blue";
                case 3: return "Green";
                default: return "Default";
            }
        }
        //private void output_textBox_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}
