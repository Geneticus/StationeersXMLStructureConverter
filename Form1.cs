using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static StationeersStructureXMLConverter.SaveFileClass;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                //destinationFile_TextBox.Text = saveFileDialog1.InitialDirectory += saveFileDialog1.FileName;
                
            }
            
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sourceFile_TextBox.Text))
            {
                sourceFile_TextBox.Text = "C:\\Users\\Geneticus\\Documents\\My Games\\Stationeers\\saves\\Loulanish_8\\manualsave\\Loulan Scenario Template\\10-25-World.xml";
                //sourceFile_TextBox.Text = "U:\\Repos\\StationeersStructureXMLConverter\\ThingsTest.xml";
            }

            if (string.IsNullOrEmpty(destinationFile_TextBox.Text))
            {
                destinationFile_TextBox.Text = "C:\\Users\\Geneticus\\Documents\\My Games\\Stationeers\\saves\\Loulanish_8\\manualsave\\Loulan Scenario Template\\Things.json";
                //if (saveFileDialog1.FileName != null && openFileDialog1.FileName != null)
            }


            if (sourceFile_TextBox.Text != null)
            {
                string xmlPath = sourceFile_TextBox.Text.Trim();  // Use textBox value (your form's default)

                if (string.IsNullOrEmpty(xmlPath) || !File.Exists(xmlPath))
                {
                    MessageBox.Show($"Invalid XML path: {xmlPath}", "Error");
                    return;
                }

                try
                {
                    var serializer = new XmlSerializer(typeof(World));
                    using (var reader = new StreamReader(xmlPath))
                    {
                        var worldObj = serializer.Deserialize(reader);
                        var world = worldObj as World ?? new World();  // Deserialized data in objects

                        MessageBox.Show($"Deserialized {world.AllThings.Count} things.", "Success");

                        // Transform using objects (with adjustments)
                        TransformToNewSchema(world);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error");
                }
            }
                        
        }

        private void TransformToNewSchema(World world)
        {
            // New Spawn object from Drive XSD
            var spawn = new Spawn();

            // Map <AllThings> to <item><Item />
            foreach (var thing in world.AllThings)
            {
                var item = new Item
                {
                    Category = MapCategory(thing.Type),  // e.g., map "Gas" to "AtmosphereItem"
                    Id = thing.Id
                };

                // Example adjustments
                item.Properties = new ItemProperties
                {
                    Color = ConvertColorIndex(thing.Properties.ColorIndex),  // Int to string, e.g., 1 -> "Red"
                    Mass = thing.Properties.Mass * 1.1,  // Adjust number (e.g., scale by 10%)
                    Pressure = (thing.Properties.Pressure > 0) ? thing.Properties.Pressure : 101.3  // Default if null
                };

                // Discard unneeded data (e.g., skip thing.SomeUnusedField)

                spawn.Items.Add(item);
            }

            // Serialize to new XML (use new schema when defined)
            var newSerializer = new XmlSerializer(typeof(Spawn));
            using (var writer = new StreamWriter("output-spawn.xml"))
            {
                newSerializer.Serialize(writer, spawn);
            }

            MessageBox.Show("Transformation complete: output-spawn.xml", "Transformation");
        }

        // Helper: Map category from Drive enums
        private string MapCategory(string sourceType)
        {
            // From Drive source files (expand with decompile if needed)
            if (sourceType.Contains("Gas")) return "AtmosphereItem";
            // Add more mappings
            return "Unknown";
        }

        // Helper: Convert color index to name
        private string ConvertColorIndex(int index)
        {
            switch (index)
            {
                case 1: return "Red";
                case 2: return "Blue";
                // Add from Stationeers decompile
                default: return "Default";
            }
        }
        private void output_textBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
