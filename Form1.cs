using StationeersStructureXMLConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WinFormsTextBox = System.Windows.Forms.TextBox;

namespace StationeersStructureXMLConverter
{

    public partial class Form1 : Form
    {
     
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
        //private void browseButton_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
        //    openFileDialog.Title = "Select World.xml";

        //    if (openFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        sourceFile_TextBox.Text = openFileDialog.FileName;
        //    }
        //}
        private void DestinationButton_Click(object sender, EventArgs e)
        {
            //if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    destinationFile_TextBox.Text = saveFileDialog1.InitialDirectory += saveFileDialog1.FileName;

            //}
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select Destination Folder";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                destinationFile_TextBox.Text = folderBrowserDialog.SelectedPath;
            }

        }
        private void Convert_Click(object sender, EventArgs e)
        {
            string xmlPath = sourceFile_TextBox.Text.Trim();
            string destPath = destinationFile_TextBox.Text.Trim();
            string reportPath = output_textBox.Text.Trim();

            if (string.IsNullOrEmpty(xmlPath) || !File.Exists(xmlPath))
            {
                output_textBox.Text = $"Invalid source XML path: {xmlPath}";
                return;
            }
            if (string.IsNullOrEmpty(destPath))
            {
                output_textBox.Text = "Invalid destination path.";
                return;
            }

            Directory.CreateDirectory(destPath);

            output_textBox.Text = "Starting XML traversal...\n";
            try
            {
                var doc = XDocument.Load(xmlPath);
                var root = doc.Root;
                if (root == null)
                {
                    output_textBox.Text += "No root <WorldData> found.\n";
                    return;
                }
                output_textBox.Text += $"Root <WorldData> found (line 1, depth 0).\n";

                // Step 1: Traverse to <AllThings> (top level)
                var allThingsNode = root.Element("AllThings");
                if (allThingsNode == null)
                {
                    output_textBox.Text += "No <AllThings> at depth 1.\n";
                    return;
                }
                output_textBox.Text += $"<AllThings> found (line ~100, depth 1, attributes: {allThingsNode.Attributes().Count()}).\n";

                // Step 2: Verify/extract <ThingSaveData> children (depth 2)
                var thingElements = allThingsNode.Elements("ThingSaveData").ToList();
                int thingCount = thingElements.Count;
                output_textBox.Text += $"Found {thingCount} <ThingSaveData> at depth 2.\n";

                if (thingCount > 0)
                {
                    // Log sample nodes (first 3, with xsi:type and sample attr like Position)
                    var sampleLog = "Sample ThingSaveData:\n";
                    for (int i = 0; i < Math.Min(3, thingCount); i++)
                    {
                        var thing = thingElements[i];
                        var xsiNs = "http://www.w3.org/2001/XMLSchema-instance";
                        var xsiType = thing.Attribute(XName.Get("type", xsiNs))?.Value ?? "Unknown";
                        var position = thing.Element("Position")?.Value ?? "N/A";
                        sampleLog += $"[{i}] xsi:type='{xsiType}' (Position: {position}, line ~{thing.Elements().Count() * i + 100}, depth 3).\n";
                    }
                    output_textBox.Text += sampleLog;

                    var things = new List<object>();
                    for (int i = 0; i < thingCount; i++)
                    {
                        things.Add(thingElements[i]);  // Raw XElement for processing
                    }
                    output_textBox.Text += $"Extracted {things.Count} ThingSaveData nodes.\n";

                    TransformToNewSchema(things, destPath, output_textBox);
                    output_textBox.Text += "Transformation complete.\n";

                    // Optional: Dump log to report file
                    if (!string.IsNullOrEmpty(reportPath))
                    {
                        File.WriteAllText(reportPath, output_textBox.Text);
                    }
                }
                else
                {
                    output_textBox.Text += "0 <ThingSaveData> in <AllThings>.\n";
                }
            }
            catch (Exception ex)
            {
                output_textBox.Text += $"Error: {ex.Message}\nInner: {ex.InnerException?.Message ?? "N/A"}\nStack: {ex.StackTrace}\n";
            }
        }
        // Direct extraction for WorldData (matches log properties; robust to nulls)
        private List<object> GetThingSaveDataList(WorldData worldData)
        {
            var things = new List<object>();
            var output = output_textBox;  // For logging

            // Find AllThings or Things array (prioritize AllThings from populated XML)
            var thingsProp = worldData.GetType().GetProperty("AllThings") ?? worldData.GetType().GetProperty("Things");
            if (thingsProp == null)
            {
                output_textBox.Text += "No AllThings/Things array found on WorldData.\n";
                return things;
            }
            var thingArray = (Array)thingsProp.GetValue(worldData);
            if (thingArray == null)
            {
                output_textBox.Text += $"{thingsProp.Name} array is null (blank template?).\n";
                return things;
            }
            output_textBox.Text += $"Found {thingsProp.Name} array on WorldData (length: {thingArray.Length}, type: {thingArray.GetType().GetElementType().Name}).\n";

            if (thingArray.Length == 0)
            {
                output_textBox.Text += "{thingsProp.Name} array is empty—no structures in save.\n";
                return things;
            }

            // Log first few items for debug (types like SolarPanelSaveData, CableSaveData from populated XML)
            var itemLog = "Sample items:\n";
            for (int i = 0; i < Math.Min(5, thingArray.Length); i++)  // Show 5 for populated file
            {
                var item = thingArray.GetValue(i);
                itemLog += $"[{i}] {item?.GetType().Name} (Type: {GetItemProperty(item, "xsi:type")} , Position: {GetItemProperty(item, "Position")})\n";
            }
            if (thingArray.Length > 5) itemLog += $"... (total {thingArray.Length} items)\n";
            output_textBox.Text += itemLog;

            // Add all items (filter polymorphs by SaveData name)
            int itemCount = 0;
            for (int i = 0; i < thingArray.Length; i++)
            {
                var item = thingArray.GetValue(i);
                if (item != null && item.GetType().Name.Contains("SaveData"))  // Matches ThingSaveData, SolarPanelSaveData, etc.
                {
                    things.Add(item);
                    itemCount++;
                }
                else
                {
                    output_textBox.Text += $"Skipped non-SaveData item [{i}]: {item?.GetType().Name}\n";
                }
            }
            output_textBox.Text += $"Added {itemCount} valid SaveData items.\n";

            return things;
        }

        // Helper for logging item props (e.g., Position or xsi:type) - class-level method
        private string GetItemProperty(object item, string propName)
        {
            if (item == null) return "N/A";
            var prop = item.GetType().GetProperty(propName);
            var value = prop?.GetValue(item);
            return value?.ToString() ?? "N/A";
        }

        // Export to new schema: Standalone <Thing> XML files for each ThingSaveData (prefab style)
        private void TransformToBatch(List<object> things, string destPath, TextBox output)
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
            output.AppendText($"Exported {exportedCount} things as standalone XML files to {destPath}.\n");
        }
        // Export to new schema: Single XML file with all ThingSaveData as <Things><Thing>...</Thing></Things>
        private void TransformToNewSchema(List<object> things, string destPath, TextBox output)
        {
            if (things.Count == 0)
            {
                output.AppendText("No things to export.\n");
                return;
            }

            var exportDoc = new XDocument(
                new XElement("Things",  // New schema root for collection
                    things.Select((thingObj, i) =>
                    {
                        if (thingObj is XElement thingElement)
                        {
                            var xsiNs = "http://www.w3.org/2001/XMLSchema-instance";
                            var xsiType = thingElement.Attribute(XName.Get("type", xsiNs))?.Value ?? "Unknown";
                            return new XElement("Thing",
                                new XAttribute("type", xsiType),
                                thingElement.Elements()  // Copy child elements (Position, Reagents, etc.)
                            );
                        }
                        return null;
                    }).Where(x => x != null)
                )
            );

            string exportPath = Path.Combine(destPath, "ExportedThings.xml");  // Single file default
            exportDoc.Save(exportPath);
            output.AppendText($"Exported {things.Count} things to single XML file: {exportPath}.\n");
        }
    }
}