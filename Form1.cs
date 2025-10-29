//using StationeersSpawnXML;
//using StationeersStructureXMLConverter;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Xml;
//using System.Xml.Linq;
//using System.Xml.Serialization;
//using WinFormsTextBox = System.Windows.Forms.TextBox;

//namespace StationeersStructureXMLConverter
//{

//    public partial class Form1 : Form
//    {
     
//        public static string parsingErrors;

//        public Form1()
//        {
//            InitializeComponent();
//            if (string.IsNullOrEmpty(sourceFile_TextBox.Text))
//            {
//                sourceFile_TextBox.Text = "C:\\Users\\Geneticus\\Documents\\My Games\\Stationeers\\saves\\Loulanish_8\\manualsave\\Loulan Scenario Template\\10-25-World.xml";

//            }

//            if (string.IsNullOrEmpty(destinationFile_TextBox.Text))
//            {
//                destinationFile_TextBox.Text = "C:\\Users\\Geneticus\\Documents\\My Games\\Stationeers\\saves\\Loulanish_8\\manualsave\\Loulan Scenario Template\\";
//                //if (saveFileDialog1.FileName != null && openFileDialog1.FileName != null)
//            }

//            output_textBox.WordWrap = true;  // Wrap long lines
//            output_textBox.ReadOnly = true;  // Prevent edits
//            output_textBox.Font = new Font("Consolas", 9F);  // Monospace for alignment
//            output_textBox.AcceptsReturn = true;  // Allow \r\n breaks
//        }
//        // Helper for readable logging ( \r\n + refresh for line breaks)
//        private void AppendLog(string message)
//        {
//            output_textBox.AppendText(message + "\r\n");
//            output_textBox.Refresh();  // Force redraw for breaks
//            output_textBox.SelectionStart = output_textBox.Text.Length;
//            output_textBox.ScrollToCaret();  // Auto-scroll
//        }
//        private void sourceButton_Click_1(object sender, EventArgs e)
//        {
//            if (openFileDialog1.ShowDialog() == DialogResult.OK)
//            {
//                sourceFile_TextBox.Text = openFileDialog1.InitialDirectory += openFileDialog1.FileName;                
//            }
//        }

//        private void DestinationButton_Click(object sender, EventArgs e)
//        {
//            //if(saveFileDialog1.ShowDialog() == DialogResult.OK)
//            //{
//            //    destinationFile_TextBox.Text = saveFileDialog1.InitialDirectory += saveFileDialog1.FileName;

//            //}
//            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
//            folderBrowserDialog.Description = "Select Destination Folder";

//            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
//            {
//                destinationFile_TextBox.Text = folderBrowserDialog.SelectedPath;
//            }

//        }
//        private void Convert_Click(object sender, EventArgs e)
//        {
//            string xmlPath = sourceFile_TextBox.Text.Trim();
//            string destPath = destinationFile_TextBox.Text.Trim();
//            string reportPath = output_textBox.Text.Trim();

//            if (string.IsNullOrEmpty(xmlPath) || !File.Exists(xmlPath))
//            {
//                AppendLog($"Invalid source XML path: {xmlPath}");
//                return;
//            }
//            if (string.IsNullOrEmpty(destPath))
//            {
//                AppendLog("Invalid destination path.");
//                return;
//            }

//            Directory.CreateDirectory(destPath);
//            output_textBox.Text = "";  // Clear for fresh run
//            AppendLog("Starting XML traversal...");

//            try
//            {
//                var doc = XDocument.Load(xmlPath);
//                var root = doc.Root;
//                if (root == null)
//                {
//                    AppendLog("No root <WorldData> found.");
//                    return;
//                }
//                AppendLog($"Root <WorldData> found (line 1, depth 0).");

//                // Step 1: Traverse to <AllThings> (top level)
//                var allThingsNode = root.Element("AllThings");
//                if (allThingsNode == null)
//                {
//                    AppendLog("No <AllThings> at depth 1.");
//                    return;
//                }
//                AppendLog($"<AllThings> found (line ~100, depth 1, attributes: {allThingsNode.Attributes().Count()}).");

//                // Step 2: Verify/extract <ThingSaveData> children (depth 2)
//                var thingElements = allThingsNode.Elements("ThingSaveData").ToList();
//                int thingCount = thingElements.Count;
//                AppendLog($"Found {thingCount} <ThingSaveData> at depth 2.");

//                if (thingCount > 0)
//                {
//                    // Log sample nodes (first 3, with xsi:type and sample attr like Position)
//                    var sampleLog = "Sample ThingSaveData:\r\n";
//                    for (int i = 0; i < Math.Min(3, thingCount); i++)
//                    {
//                        var thing = thingElements[i];
//                        var xsiNs = "http://www.w3.org/2001/XMLSchema-instance";
//                        var xsiType = thing.Attribute(XName.Get("type", xsiNs))?.Value ?? "Unknown";
//                        var position = thing.Element("Position")?.Value ?? "N/A";
//                        sampleLog += $"[{i}] xsi:type='{xsiType}' (Position: {position}, line ~{thing.Elements().Count() * i + 100}, depth 3).\r\n";
//                    }
//                    AppendLog(sampleLog);

//                    var things = new List<object>();
//                    for (int i = 0; i < thingCount; i++)
//                    {
//                        things.Add(thingElements[i]);  // Raw XElement for processing
//                    }
//                    AppendLog($"Extracted {things.Count} ThingSaveData nodes.");

//                    var spawnEntries = SourceExtraction.ExtractSpawnEntries(things, output_textBox);  // Add this call to process
//                    AppendLog($"Extracted {spawnEntries.Count} spawn entries.");
//                    DestinationExport.TransformToNewSchema(things, destPath, output_textBox);
//                    AppendLog("Transformation complete.");
                    
//                    // Optional: Dump log to report file
//                    if (!string.IsNullOrEmpty(reportPath))
//                    {
//                        File.WriteAllText(reportPath, output_textBox.Text);
//                    }
//                }
//                else
//                {
//                    AppendLog("0 <ThingSaveData> in <AllThings>.\r\n");
//                }
//            }
//            catch (Exception ex)
//            {
//                AppendLog($"Error: {ex.Message}");
//                AppendLog($"Inner: {ex.InnerException?.Message ?? "N/A\r\n"}");
//                AppendLog($"Stack: {ex.StackTrace}");
//            }
//        }
//        // Helper for auto-scroll to bottom after AppendText
//        private void ScrollToBottom()
//        {
//            output_textBox.SelectionStart = output_textBox.Text.Length;
//            output_textBox.ScrollToCaret();
//        }
//        // Direct extraction for WorldData (matches log properties; robust to nulls)
//        private List<object> GetThingSaveDataList(WorldData worldData)
//        {
//            var things = new List<object>();
//            var output = output_textBox;  // For logging

//            // Find AllThings or Things array (prioritize AllThings from populated XML)
//            var thingsProp = worldData.GetType().GetProperty("AllThings") ?? worldData.GetType().GetProperty("Things");
//            if (thingsProp == null)
//            {
//                output_textBox.Text += "No AllThings/Things array found on WorldData.\n";
//                return things;
//            }
//            var thingArray = (Array)thingsProp.GetValue(worldData);
//            if (thingArray == null)
//            {
//                output_textBox.Text += $"{thingsProp.Name} array is null (blank template?).\n";
//                return things;
//            }
//            output_textBox.Text += $"Found {thingsProp.Name} array on WorldData (length: {thingArray.Length}, type: {thingArray.GetType().GetElementType().Name}).\n";

//            if (thingArray.Length == 0)
//            {
//                output_textBox.Text += "{thingsProp.Name} array is empty—no structures in save.\n";
//                return things;
//            }

//            // Add all items (filter polymorphs by SaveData name)
//            int itemCount = 0;
//            for (int i = 0; i < thingArray.Length; i++)
//            {
//                var item = thingArray.GetValue(i);
//                if (item != null && item.GetType().Name.Contains("SaveData"))  // Matches ThingSaveData, SolarPanelSaveData, etc.
//                {
//                    things.Add(item);
//                    itemCount++;
//                }
//                else
//                {
//                    output_textBox.Text += $"Skipped non-SaveData item [{i}]: {item?.GetType().Name}\n";
//                }
//            }
//            output_textBox.Text += $"Added {itemCount} valid SaveData items.\n";

//            return things;
//        }
//        // Sub-method: Build full export XDocument
//        private XDocument BuildExportDoc(List<XElement> spawnEntries, string scenarioName, string spawnId)
//        {
//            return new XDocument(
//                new XDeclaration("1.0", "utf-8", null),
//                new XElement("GameData",
//                    new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
//                    new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
//                    new XElement("WorldSettings",
//                        new XAttribute("Id", scenarioName)
//                    ),
//                    new XElement("Spawn",
//                        new XAttribute("Id", spawnId),
//                        spawnEntries  // All entries as siblings under <Spawn>
//                    )
//                )
//            );
//        }
//    }
//}