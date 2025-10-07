using StationeersSpawnXML;
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
                destinationFile_TextBox.Text = "C:\\Users\\Geneticus\\Documents\\My Games\\Stationeers\\saves\\Loulanish_8\\manualsave\\Loulan Scenario Template\\";
                //if (saveFileDialog1.FileName != null && openFileDialog1.FileName != null)
            }

            // Readability fixes for output_textBox
            output_textBox.WordWrap = true;  // Wrap long lines
            output_textBox.ReadOnly = true;  // Prevent edits
            output_textBox.Font = new Font("Consolas", 9F);  // Monospace for alignment
            output_textBox.AcceptsReturn = true;  // Allow \r\n breaks
        }
        // Helper for readable logging ( \r\n + refresh for line breaks)
        private void AppendLog(string message)
        {
            output_textBox.AppendText(message + "\r\n");
            output_textBox.Refresh();  // Force redraw for breaks
            output_textBox.SelectionStart = output_textBox.Text.Length;
            output_textBox.ScrollToCaret();  // Auto-scroll
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
            string reportPath = Path.Combine(destPath, "ConversionLog.txt");  // Safe fixed name in destPath

            if (string.IsNullOrEmpty(xmlPath) || !File.Exists(xmlPath))
            {
                AppendLog($"Invalid source XML path: {xmlPath}");
                return;
            }
            if (string.IsNullOrEmpty(destPath))
            {
                AppendLog("Invalid destination path.");
                return;
            }

            Directory.CreateDirectory(destPath);
            output_textBox.Text = "";  // Clear for fresh run
            AppendLog("Starting XML traversal...");

            try
            {
                var doc = XDocument.Load(xmlPath);
                var root = doc.Root;
                if (root == null)
                {
                    AppendLog("No root <WorldData> found.");
                    return;
                }
                AppendLog($"Root <WorldData> found (line 1, depth 0).");

                // Step 1: Traverse to <AllThings> (top level)
                var allThingsNode = root.Element("AllThings");
                if (allThingsNode == null)
                {
                    AppendLog("No <AllThings> at depth 1.");
                    return;
                }
                AppendLog($"<AllThings> found (line ~100, depth 1, attributes: {allThingsNode.Attributes().Count()}).");

                // Step 2: Verify/extract <ThingSaveData> children (depth 2)
                var thingElements = allThingsNode.Elements("ThingSaveData").ToList();
                int thingCount = thingElements.Count;
                AppendLog($"Found {thingCount} <ThingSaveData> at depth 2.");

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
                    AppendLog(sampleLog);

                    var things = new List<object>();
                    for (int i = 0; i < thingCount; i++)
                    {
                        things.Add(thingElements[i]);  // Raw XElement for processing
                    }
                    AppendLog($"Extracted {things.Count} ThingSaveData nodes.");

                    TransformToNewSchema(things, destPath, output_textBox);
                    AppendLog("Transformation complete.");

                    // Optional: Dump log to report file
                    if (!string.IsNullOrEmpty(reportPath))
                    {
                        File.WriteAllText(reportPath, output_textBox.Text);
                    }
                }
                else
                {
                    AppendLog("0 <ThingSaveData> in <AllThings>.");
                }
            }
            catch (Exception ex)
            {
                AppendLog($"Error: {ex.Message}");
                AppendLog($"Inner: {ex.InnerException?.Message ?? "N/A"}");
                AppendLog($"Stack: {ex.StackTrace}");
            }
        }

        // Helper for auto-scroll to bottom after AppendText
        private void ScrollToBottom()
        {
            output_textBox.SelectionStart = output_textBox.Text.Length;
            output_textBox.ScrollToCaret();
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
            output.AppendText($"Exported {exportedCount} things as standalone XML files to {destPath}.\r\n");
        }


        
        // Export to new schema: worldsettings.xml with <GameData><WorldSettings Id="My_Scenario"/><Spawn Id="My_ScenarioThings"><Structure Id="..." HideInStartScreen="true"><CustomName /><IsCustomName>false</IsCustomName><CustomColorIndex>4</CustomColorIndex><Indestructable>false</Indestructable><DamageState><Brute>0</Brute>...</DamageState><CurrentBuildState>1</CurrentBuildState><MothershipReferenceId>0</MothershipReferenceId><HasSpawnedWreckage>false</HasSpawnedWreckage><RegisteredWorldPosition><x>-75</x><y>148</y><z>-25</z></RegisteredWorldPosition><RegisteredWorldRotation><x>-1.02910758E-06</x><y>0.707106769</y><z>0.7071068</z><w>1.059845E-06</w></RegisteredWorldRotation><SpawnPosition Rule="Explicit"><Offset x="-75" y="148" z="-25"/><Rotation x="-1.02910758E-06" y="0.707106769" z="0.7071068" w="1.059845E-06"/></SpawnPosition><Reagents>...</Reagents></Structure></Spawn></GameData>
        private void TransformToNewSchema(List<object> things, string destPath, TextBox output)
        {
            if (things.Count == 0)
            {
                output.AppendText("No things to export.\n");
                return;
            }

            string scenarioName = "My_Scenario";  // From textbox or user input
            string spawnId = scenarioName + "Things";

            var spawnEntries = new List<XElement>();
            int exportedCount = 0;
            foreach (var thingObj in things)
            {
                if (thingObj is XElement thingElement)
                {
                    var xsiNs = "http://www.w3.org/2001/XMLSchema-instance";
                    var xsiType = thingElement.Attribute(XName.Get("type", xsiNs))?.Value ?? "Unknown";
                    var cleanId = xsiType.Replace("SaveData", "");  // "SolarPanelSaveData" → "SolarPanel"
                    var prefabName = thingElement.Element("PrefabName")?.Value ?? cleanId;  // Prefer PrefabName

                    // Classify tag by type
                    string tagName = "Item";  // Default
                    if (xsiType.StartsWith("Structure")) tagName = "Structure";
                    else if (xsiType.StartsWith("DynamicThing")) tagName = "DynamicThing";

                    var spawnEntry = new XElement(tagName,
                        new XAttribute("Id", prefabName),
                        new XAttribute("HideInStartScreen", "true")
                    );

                    // Add CustomName (even if empty)
                    var customName = thingElement.Element("CustomName");
                    if (customName != null)
                    {
                        spawnEntry.Add(new XElement("CustomName", customName.Value ?? ""));
                    }

                    // Add IsCustomName (bool)
                    var isCustomName = thingElement.Element("IsCustomName")?.Value;
                    if (isCustomName != null)
                    {
                        spawnEntry.Add(new XElement("IsCustomName", isCustomName));
                    }

                    // Add CustomColorIndex (int)
                    var customColorIndex = thingElement.Element("CustomColorIndex")?.Value;
                    if (customColorIndex != null)
                    {
                        spawnEntry.Add(new XElement("CustomColorIndex", customColorIndex));
                    }

                    // Add Indestructable (bool)
                    var indestructable = thingElement.Element("Indestructable")?.Value;
                    if (indestructable != null)
                    {
                        spawnEntry.Add(new XElement("Indestructable", indestructable));
                    }

                    // Add DamageState (nested, copy if present)
                    var damageState = thingElement.Element("DamageState");
                    if (damageState != null)
                    {
                        var damageEntry = new XElement("DamageState");
                        damageEntry.Add(damageState.Elements());  // Copy <Brute>0</Brute><Burn>0</Burn>...
                        spawnEntry.Add(damageEntry);
                    }

                    // Add CurrentBuildState (int)
                    var currentBuildState = thingElement.Element("CurrentBuildState")?.Value;
                    if (currentBuildState != null)
                    {
                        spawnEntry.Add(new XElement("CurrentBuildState", currentBuildState));
                    }

                    // Add MothershipReferenceId (long)
                    var mothershipReferenceId = thingElement.Element("MothershipReferenceId")?.Value;
                    if (mothershipReferenceId != null)
                    {
                        spawnEntry.Add(new XElement("MothershipReferenceId", mothershipReferenceId));
                    }

                    // Add HasSpawnedWreckage (bool)
                    var hasSpawnedWreckage = thingElement.Element("HasSpawnedWreckage")?.Value;
                    if (hasSpawnedWreckage != null)
                    {
                        spawnEntry.Add(new XElement("HasSpawnedWreckage", hasSpawnedWreckage));
                    }

                    // Add RegisteredWorldPosition (nested <x/y/z>)
                    var registeredPos = thingElement.Element("RegisteredWorldPosition");
                    if (registeredPos != null)
                    {
                        var regX = registeredPos.Element("x")?.Value ?? "0";
                        var regY = registeredPos.Element("y")?.Value ?? "0";
                        var regZ = registeredPos.Element("z")?.Value ?? "0";
                        spawnEntry.Add(new XElement("RegisteredWorldPosition",
                            new XElement("x", regX),
                            new XElement("y", regY),
                            new XElement("z", regZ)
                        ));
                    }

                    // Add RegisteredWorldRotation (nested <x/y/z/w>)
                    var registeredRot = thingElement.Element("RegisteredWorldRotation");
                    if (registeredRot != null)
                    {
                        var regRotX = registeredRot.Element("x")?.Value ?? "0";
                        var regRotY = registeredRot.Element("y")?.Value ?? "0";
                        var regRotZ = registeredRot.Element("z")?.Value ?? "0";
                        var regRotW = registeredRot.Element("w")?.Value ?? "1";
                        spawnEntry.Add(new XElement("RegisteredWorldRotation",
                            new XElement("x", regRotX),
                            new XElement("y", regRotY),
                            new XElement("z", regRotZ),
                            new XElement("w", regRotW)
                        ));
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

                    spawnEntries.Add(spawnEntry);
                    exportedCount++;
                }
            }
            output_textBox.Text += $"Extracted {exportedCount} spawn entries.\n";
            return;
        }

        // Sub-method: Extract <Structure>/<Item> from ThingSaveData
        private List<XElement> ExtractSpawnEntries(List<object> things, TextBox output)
        {
            var spawnEntries = new List<XElement>();
            int exportedCount = 0;
            int debugCount = 0;
            int maxDebug = 5;  // Limit debug to first 5
            foreach (var thingObj in things)
            {
                if (thingObj is XElement thingElement)
                {
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
                        output_textBox.Text += $"Debug: xsiType='{xsiType}' → tagName='{tagName}', prefabName='{prefabName}'.\n";
                        debugCount++;
                    }

                    var spawnEntry = new XElement(tagName,
                        new XAttribute("Id", prefabName),
                        new XAttribute("HideInStartScreen", "true")
                    );

                    AddBasicProps(thingElement, spawnEntry);  // Sub-method
                    AddDamageState(thingElement, spawnEntry);  // Sub-method
                    AddBuildState(thingElement, spawnEntry);  // Sub-method
                    AddRegisteredProps(thingElement, spawnEntry);  // Sub-method
                    AddNetworkProps(thingElement, spawnEntry);  // Sub-method
                    AddSpawnPositionAndReagents(thingElement, spawnEntry);  // Sub-method

                    spawnEntries.Add(spawnEntry);
                    exportedCount++;
                }
            }
            output_textBox.Text += $"Extracted {exportedCount} spawn entries.\n";
            return spawnEntries;
        }

        // Sub-method: Add basic props (CustomName, IsCustomName, CustomColorIndex, Indestructable)
        private void AddBasicProps(XElement thingElement, XElement spawnEntry)
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

        // Sub-method: Add DamageState (nested copy)
        private void AddDamageState(XElement thingElement, XElement spawnEntry)
        {
            var damageState = thingElement.Element("DamageState");
            if (damageState != null)
            {
                var damageEntry = new XElement("DamageState");
                damageEntry.Add(damageState.Elements());  // Copy <Brute>0</Brute><Burn>0</Burn>...
                spawnEntry.Add(damageEntry);
            }
        }

        // Sub-method: Add build state props (CurrentBuildState, MothershipReferenceId, HasSpawnedWreckage)
        private void AddBuildState(XElement thingElement, XElement spawnEntry)
        {
            var currentBuildState = thingElement.Element("CurrentBuildState")?.Value;
            if (currentBuildState != null)
            {
                spawnEntry.Add(new XElement("CurrentBuildState", currentBuildState));
            }

            var mothershipReferenceId = thingElement.Element("MothershipReferenceId")?.Value;
            if (mothershipReferenceId != null)
            {
                spawnEntry.Add(new XElement("MothershipReferenceId", mothershipReferenceId));
            }

            var hasSpawnedWreckage = thingElement.Element("HasSpawnedWreckage")?.Value;
            if (hasSpawnedWreckage != null)
            {
                spawnEntry.Add(new XElement("HasSpawnedWreckage", hasSpawnedWreckage));
            }
        }

        // Sub-method: Add registered props (RegisteredWorldPosition/Rotation)
        private void AddRegisteredProps(XElement thingElement, XElement spawnEntry)
        {
            var registeredPos = thingElement.Element("RegisteredWorldPosition");
            if (registeredPos != null)
            {
                var regX = registeredPos.Element("x")?.Value ?? "0";
                var regY = registeredPos.Element("y")?.Value ?? "0";
                var regZ = registeredPos.Element("z")?.Value ?? "0";
                spawnEntry.Add(new XElement("RegisteredWorldPosition",
                    new XElement("x", regX),
                    new XElement("y", regY),
                    new XElement("z", regZ)
                ));
            }

            var registeredRot = thingElement.Element("RegisteredWorldRotation");
            if (registeredRot != null)
            {
                var regRotX = registeredRot.Element("x")?.Value ?? "0";
                var regRotY = registeredRot.Element("y")?.Value ?? "0";
                var regRotZ = registeredRot.Element("z")?.Value ?? "0";
                var regRotW = registeredRot.Element("w")?.Value ?? "1";
                spawnEntry.Add(new XElement("RegisteredWorldRotation",
                    new XElement("x", regRotX),
                    new XElement("y", regRotY),
                    new XElement("z", regRotZ),
                    new XElement("w", regRotW)
                ));
            }
        }

        // Sub-method: Add network props (NetworkId)
        private void AddNetworkProps(XElement thingElement, XElement spawnEntry)
        {
            var networkId = thingElement.Element("CableNetworkId")?.Value ?? thingElement.Element("PipeNetworkId")?.Value ?? "0";
            if (networkId != "0")
            {
                spawnEntry.Add(new XElement("NetworkId", networkId));
            }
        }

        // Sub-method: Add SpawnPosition and Reagents
        private void AddSpawnPositionAndReagents(XElement thingElement, XElement spawnEntry)
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
        private XElement BuildSpawnPosition(XElement thingElement)
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

        // Sub-method: Build full export XDocument
        private XDocument BuildExportDoc(List<XElement> spawnEntries, string scenarioName, string spawnId)
        {
            return new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement("GameData",
                    new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"),
                    new XAttribute(XNamespace.Xmlns + "xsd", "http://www.w3.org/2001/XMLSchema"),
                    new XElement("WorldSettings",
                        new XAttribute("Id", scenarioName)
                    ),
                    new XElement("Spawn",
                        new XAttribute("Id", spawnId),
                        spawnEntries  // All entries as siblings under <Spawn>
                    )
                )
            );
        }
    }
}