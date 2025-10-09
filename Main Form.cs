using StationeersSpawnXML;
using StationeersStructureXMLConverter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace StationeersStructureXMLConverter
{
    public partial class Main_Form : Form
    {
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        //private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label labelInstructions;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPaths;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
        private System.Windows.Forms.GroupBox ItemFilters_GroupBox; // Moved to Center_GroupBox
        private System.Windows.Forms.TableLayoutPanel ItemFilters_TableLayout;
        private System.Windows.Forms.GroupBox Center_GroupBox; // Now contains ItemFilters_GroupBox
        // Removed: private System.Windows.Forms.TableLayoutPanel Center_TableLayout;
        private System.Windows.Forms.GroupBox Right_GroupBox;
        // Removed: private System.Windows.Forms.TableLayoutPanel Right_TableLayout;
        private System.Windows.Forms.GroupBox WorldTypeOptions_GroupBox; // Moved to leftmost
        private System.Windows.Forms.CheckBox VanillaWorld_CheckBox;
        private System.Windows.Forms.CheckBox LocalMod_CheckBox;
        private System.Windows.Forms.CheckBox None_CheckBox;
        private System.Windows.Forms.ComboBox WorldSelection_ComboBox;
        private string stationeersPath = null;

        public Main_Form()
        {
            InitializeComponent();

            // Transfer output textbox configuration
            textBox3.WordWrap = true; // Wrap long lines
            textBox3.ReadOnly = true; // Prevent edits
            textBox3.Font = new Font("Consolas", 9F); // Monospace for alignment
            textBox3.AcceptsReturn = true; // Allow \r\n breaks
            VanillaWorld_CheckBox.CheckedChanged += CheckBox_CheckedChanged;
            LocalMod_CheckBox.CheckedChanged += CheckBox_CheckedChanged;
            None_CheckBox.CheckedChanged += CheckBox_CheckedChanged;
            WorldSelection_ComboBox.SelectedIndexChanged += WorldSelection_ComboBox_SelectedIndexChanged;
            // Set default state
            None_CheckBox.Checked = true;
            WorldSelection_ComboBox.Enabled = false;
            SetStationeersPath();


            // Set default paths based on debug/release mode
            bool isDebug = System.Diagnostics.Debugger.IsAttached;
            string defaultRoot = Environment.ExpandEnvironmentVariables("%userprofile%\\documents\\My Games\\Stationeers");
            if (isDebug)
            {
                textBox1.Text = "C:\\Users\\Geneticus\\Documents\\My Games\\Stationeers\\saves\\Loulanish_8\\manualsave\\Loulan Scenario Template\\10-25-World.xml";
                textBox2.Text = "C:\\Users\\Geneticus\\Documents\\My Games\\Stationeers\\saves\\Loulanish_8\\manualsave\\Loulan Scenario Template\\SpawnGroup.xml";
            }
            else
            {
                textBox1.Text = Path.Combine(defaultRoot, "saves\\default\\world.xml");
                textBox2.Text = Path.Combine(defaultRoot, "saves\\default\\SpawnGroup.xml");
            }
        }

        private void AppendLog(string message)
        {
            textBox3.AppendText(message + "\r\n");
            textBox3.Refresh(); // Force redraw for breaks
            textBox3.SelectionStart = textBox3.Text.Length;
            textBox3.ScrollToCaret(); // Auto-scroll
        }

        private List<object> GetThingSaveDataList(WorldData worldData)
        {
            var things = new List<object>();
            AppendLog("Direct extraction for WorldData (matches log properties; robust to nulls)");

            // Find AllThings or Things array
            var thingsProp = worldData.GetType().GetProperty("AllThings") ?? worldData.GetType().GetProperty("Things");
            if (thingsProp == null)
            {
                AppendLog("No AllThings/Things array found on WorldData.\n");
                return things;
            }
            var thingArray = (Array)thingsProp.GetValue(worldData);
            if (thingArray == null)
            {
                AppendLog($"{thingsProp.Name} array is null (blank template?).\n");
                return things;
            }
            AppendLog($"Found {thingsProp.Name} array on WorldData (length: {thingArray.Length}, type: {thingArray.GetType().GetElementType().Name}).\n");
            if (thingArray.Length == 0)
            {
                AppendLog($"{thingsProp.Name} array is empty—no structures in save.\n");
                return things;
            }
            int itemCount = 0;
            for (int i = 0; i < thingArray.Length; i++)
            {
                var item = thingArray.GetValue(i);
                if (item != null && item.GetType().Name.Contains("SaveData"))
                {
                    things.Add(item);
                    itemCount++;
                }
                else
                {
                    AppendLog($"Skipped non-SaveData item [{i}]: {item?.GetType().Name}\n");
                }
            }
            AppendLog($"Added {itemCount} valid SaveData items.\n");
            return things;
        }

        private void BrowseInput_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers\\saves");
                openFileDialog.Filter = ".save files (*.save)|*.save|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openFileDialog.FileName;
                }
            }
        }

        private void BrowseOutput_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.ExpandEnvironmentVariables("%userprofile%\\documents\\My Games\\Stationeers");
                openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FileName = "SpawnGroup.xml"; // Default filename
                openFileDialog.CheckFileExists = false; // Allow non-existent files
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = openFileDialog.FileName;
                    AppendLog($"Setting output path to: {selectedPath}"); // Diagnostic log
                    textBox2.Text = selectedPath; // Use full path including filename
                }
            }
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            // Header with separators
            AppendLog("----------------");
            AppendLog($"Save File: {textBox1.Text}");
            AppendLog($"Destination File: {textBox2.Text}");
            AppendLog("Output options: None"); // To be updated with checkbox options later
            AppendLog("----------------");
            // Step-by-step logging
            textBox3.Text = ""; // Clear for fresh run
            AppendLog("Reading Save File... (Step 1 of 6)");
            if (string.IsNullOrEmpty(textBox1.Text) || !File.Exists(textBox1.Text))
            {
                AppendLog("Invalid source .save file path: " + textBox1.Text);
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                AppendLog("Invalid destination path.");
                return;
            }
            string directory = Path.GetDirectoryName(textBox2.Text);
            AppendLog($"Creating directory: {directory}"); // Diagnostic log
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory); // Create only the parent directory
            }
            AppendLog("Examining Data... (Step 2 of 6)");
            try
            {
                // Extract world.xml from the .save zip archive in memory
                XDocument doc;
                using (ZipArchive archive = ZipFile.OpenRead(textBox1.Text))
                {
                    ZipArchiveEntry entry = archive.GetEntry("world.xml");
                    if (entry == null)
                    {
                        AppendLog("No 'world.xml' found in the .save archive.");
                        return;
                    }
                    using (Stream stream = entry.Open())
                    {
                        doc = XDocument.Load(stream);
                    }
                }
                var root = doc.Root;
                if (root == null)
                {
                    AppendLog("No root <WorldData> found.");
                    return;
                }
                var allThingsNode = root.Element("AllThings");
                if (allThingsNode == null)
                {
                    AppendLog("No <AllThings> found.");
                    return;
                }
                var thingElements = allThingsNode.Elements("ThingSaveData").ToList();
                if (thingElements.Count == 0)
                {
                    AppendLog("Warning: No <ThingSaveData> elements found.");
                    return;
                }
                var things = new List<object>();
                foreach (var element in thingElements)
                {
                    things.Add(element);
                }
                int thingCount = thingElements.Count;
                AppendLog($"Found {thingCount} of Things to extract... (Step 3 of 6)");
                if (System.Diagnostics.Debugger.IsAttached) // Debug mode
                {
                    var uniquePrefabNames = thingElements
                        .Select(t => t.Element("PrefabName")?.Value ?? "Unknown")
                        .Distinct()
                        .ToList();
                    AppendLog("Items Found:");
                    foreach (var prefab in uniquePrefabNames)
                    {
                        AppendLog(prefab);
                    }
                    AppendLog(""); // Blank line after unique object
                }
                AppendLog($"Extracted {things.Count} Things... (Step 4 of 6)");
                AppendLog("Transforming Things to Spawn Items... (Step 5 of 6)");
                var spawnEntries = SourceExtraction.ExtractSpawnEntries(things, textBox3);
                DestinationExport.TransformToNewSchema(things, textBox2.Text, textBox3);
                // Prune LanderCapsuleSmall and Characters if excluded
                int landerRemovedCount = 0;
                int characterRemovedCount = 0;
                if (checkBox1.Checked || checkBox2.Checked)
                {
                    var outputDoc = XDocument.Load(textBox2.Text);
                    var nodesToPrune = new List<XElement>();
                    if (checkBox1.Checked)
                    {
                        var landerNodes = outputDoc.Descendants()
                            .Where(n => n.Attribute("Id")?.Value == "LanderCapsuleSmall")
                            .ToList();
                        nodesToPrune.AddRange(landerNodes);
                        landerRemovedCount = landerNodes.Count;
                    }
                    if (checkBox2.Checked)
                    {
                        var characterNodes = outputDoc.Descendants()
                            .Where(n => n.Attribute("Id")?.Value == "Character")
                            .ToList();
                        nodesToPrune.AddRange(characterNodes);
                        characterRemovedCount = characterNodes.Count;
                    }
                    if (nodesToPrune.Any())
                    {
                        foreach (var node in nodesToPrune)
                        {
                            node.Remove();
                        }
                        outputDoc.Save(textBox2.Text);
                        // Debug: Log children removed, counting only Structure/Item/DynamicThing
                        int totalChildrenRemoved = nodesToPrune.Sum(n => n.Descendants().Count());
                        int landerSpawnableChildrenRemoved = checkBox1.Checked ? nodesToPrune.Where(n => n.Attribute("Id")?.Value == "LanderCapsuleSmall").Sum(n => n.Descendants().Count(d => d.Name.LocalName == "Structure" || d.Name.LocalName == "Item" || d.Name.LocalName == "DynamicThing")) : 0;
                        int characterSpawnableChildrenRemoved = checkBox2.Checked ? nodesToPrune.Where(n => n.Attribute("Id")?.Value == "Character").Sum(n => n.Descendants().Count(d => d.Name.LocalName == "Structure" || d.Name.LocalName == "Item" || d.Name.LocalName == "DynamicThing")) : 0;
                        string logMessage = "";
                        if (landerRemovedCount > 0) logMessage += $"Removed {landerRemovedCount} LanderCapsuleSmall node(s) and {landerSpawnableChildrenRemoved} of children";
                        if (characterRemovedCount > 0)
                        {
                            if (logMessage.Length > 0) logMessage += ", ";
                            logMessage += $"Removed {characterRemovedCount} Character node(s) and {characterSpawnableChildrenRemoved} of children";
                        }
                        AppendLog(logMessage + ".");
                        AppendLog($"Debug: Removed {totalChildrenRemoved} total child nodes.");
                    }
                }
                if (!File.Exists(textBox2.Text)) // Check if the file was created
                {
                    AppendLog($"Error: Failed to create '{textBox2.Text}'. Check permissions or path.");
                    return;
                }
                // Recalculate remaining spawn items after pruning
                var prunedDoc = XDocument.Load(textBox2.Text);
                int initialSpawnCount = prunedDoc.Descendants().Count(n => n.Name.LocalName == "Structure" || n.Name.LocalName == "Item" || n.Name.LocalName == "DynamicThing");
                int expectedInitialCount = thingCount; // Use the actual extracted count
                if (initialSpawnCount == expectedInitialCount - 1 && !checkBox1.Checked && !checkBox2.Checked)
                {
                    AppendLog($"Note: Initial count ({initialSpawnCount}) is 1 less than extracted count ({expectedInitialCount}) without pruning. Transformation may deduplicate 1 item.");
                }
                if ((checkBox1.Checked || checkBox2.Checked) && initialSpawnCount < expectedInitialCount)
                {
                    int transformReduction = expectedInitialCount - initialSpawnCount - (landerRemovedCount + characterRemovedCount);
                    if (transformReduction == 1)
                    {
                        AppendLog($"Note: Initial count ({initialSpawnCount}) is 1 less than extracted count ({expectedInitialCount}) due to transformation deduplication.");
                    }
                    else if (transformReduction > 0)
                    {
                        AppendLog($"Note: Initial count ({initialSpawnCount}) is {transformReduction} less than extracted count ({expectedInitialCount}) due to transformation deduplication of {transformReduction} item(s).");
                    }
                    AppendLog($"Note: Adjusted count ({initialSpawnCount - (landerRemovedCount + characterRemovedCount)}) reflects removal of {landerRemovedCount + characterRemovedCount} node(s) (LanderCapsuleSmall or Character).");
                }
                int remainingSpawnItems = initialSpawnCount - (checkBox1.Checked || checkBox2.Checked ? (landerRemovedCount + characterRemovedCount) : 0);
                if (remainingSpawnItems < 0) remainingSpawnItems = 0; // Prevent negative count
                AppendLog($"Debug: Initial <Spawn> nodes (Structure/Item/DynamicThing): {initialSpawnCount}");
                AppendLog($"Debug: Adjusted remaining spawn items: {remainingSpawnItems}");
                AppendLog($"Writing {remainingSpawnItems} Spawn Items... (Step 6 of 6)");
                AppendLog("Conversion completed successfully!");
            }
            catch (Exception ex)
            {
                AppendLog($"Error: {ex.Message}");
                AppendLog($"Inner: {ex.InnerException?.Message ?? "N/A\r\n"}");
                AppendLog($"Stack: {ex.StackTrace}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                if (sender == VanillaWorld_CheckBox) { LocalMod_CheckBox.Checked = false; None_CheckBox.Checked = false; }
                else if (sender == LocalMod_CheckBox) { VanillaWorld_CheckBox.Checked = false; None_CheckBox.Checked = false; }
                else if (sender == None_CheckBox) { VanillaWorld_CheckBox.Checked = false; LocalMod_CheckBox.Checked = false; }
                // Update ComboBox state
                if (VanillaWorld_CheckBox.Checked || LocalMod_CheckBox.Checked)
                {
                    WorldSelection_ComboBox.Enabled = true;
                    PopulateWorldDropdown();
                }
                else if (None_CheckBox.Checked)
                {
                    WorldSelection_ComboBox.Items.Clear();
                    WorldSelection_ComboBox.Enabled = false;
                }
                VerifySelectedWorld();
            }
        }

        private void PopulateWorldDropdown()
        {
            WorldSelection_ComboBox.Items.Clear();
            if (VanillaWorld_CheckBox.Checked && stationeersPath != null)
            {
                string worldsPath = Path.Combine(stationeersPath, "rocketstation_Data", "StreamingAssets", "Worlds");
                if (Directory.Exists(worldsPath))
                {
                    var worldFolders = Directory.GetDirectories(worldsPath)
                        .Select(Path.GetFileName)
                        .ToArray();
                    WorldSelection_ComboBox.Items.AddRange(worldFolders);
                }
                else
                {
                    AppendLog($"Warning: Worlds directory not found at {worldsPath}.");
                }
            }
            else if (LocalMod_CheckBox.Checked)
            {
                string basePath = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers");
                string modsPath = Path.Combine(basePath, "mods");
                if (Directory.Exists(modsPath))
                {
                    var modFolders = Directory.GetDirectories(modsPath)
                        .Where(d => !d.Contains("Tutorial") && !d.Contains("SharedTextures"))
                        .Select(Path.GetFileName)
                        .ToArray();
                    WorldSelection_ComboBox.Items.AddRange(modFolders);
                }
                else
                {
                    AppendLog("Warning: 'mods' directory not found at " + modsPath + ". No local mod worlds available.");
                }
            }
            // None_CheckBox.Checked leaves it empty
            WorldSelection_ComboBox.SelectedIndex = -1; // Clear selection
        }

        private void VerifySelectedWorld()
        {
            if (WorldSelection_ComboBox.SelectedIndex != -1 && !None_CheckBox.Checked)
            {
                string selectedFolder = WorldSelection_ComboBox.SelectedItem.ToString();
                string fullPath = "";

                if (VanillaWorld_CheckBox.Checked && stationeersPath != null)
                {
                    string worldsPath = Path.Combine(stationeersPath, "rocketstation_Data", "StreamingAssets", "Worlds", selectedFolder);
                    fullPath = Path.Combine(worldsPath, "world.xml");
                    if (!File.Exists(fullPath))
                    {
                        AppendLog($"Warning: 'world.xml' not found in {selectedFolder}.");
                        WorldSelection_ComboBox.SelectedIndex = -1;
                    }
                }
                else if (LocalMod_CheckBox.Checked)
                {
                    string basePath = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers");
                    string modsPath = Path.Combine(basePath, "mods", selectedFolder);
                    if (Directory.Exists(modsPath))
                    {
                        string[] subFolders = Directory.GetDirectories(modsPath, "*", SearchOption.AllDirectories);
                        bool worldFound = false;
                        foreach (string folder in subFolders)
                        {
                            string[] xmlFiles = Directory.GetFiles(folder, "*.xml");
                            foreach (string xmlFile in xmlFiles)
                            {
                                try
                                {
                                    XDocument doc = XDocument.Load(xmlFile);
                                    if (doc.Root != null && doc.Root.Name.LocalName == "WorldSettings")
                                    {
                                        fullPath = xmlFile;
                                        worldFound = true;
                                        break;
                                    }
                                }
                                catch (XmlException)
                                {
                                    // Skip invalid XML files
                                    continue;
                                }
                            }
                            if (worldFound) break;
                        }
                        if (!worldFound)
                        {
                            AppendLog($"Warning: No WorldSettings XML file found in {selectedFolder} or its subfolders.");
                            WorldSelection_ComboBox.SelectedIndex = -1;
                        }
                    }
                    else
                    {
                        AppendLog($"Warning: Mod folder {selectedFolder} not found at {modsPath}.");
                        WorldSelection_ComboBox.SelectedIndex = -1;
                    }
                }
            }
        }

        private void WorldSelection_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!None_CheckBox.Checked) VerifySelectedWorld();
        }

        private void SetStationeersPath()
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                folderBrowser.Description = "Please select the Stationeers installation folder (e.g., containing rocketstation_Data).";
                folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer;
                folderBrowser.ShowNewFolderButton = false;
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderBrowser.SelectedPath;
                    if (Directory.Exists(Path.Combine(selectedPath, "rocketstation_Data", "StreamingAssets", "Worlds")))
                    {
                        stationeersPath = selectedPath;
                        AppendLog($"Stationeers path set to: {stationeersPath}");
                    }
                    else
                    {
                        MessageBox.Show("The selected folder does not contain a valid Stationeers installation. Please select the folder containing 'rocketstation_Data'.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        SetStationeersPath(); // Recursive call to prompt again
                    }
                }
                else
                {
                    stationeersPath = null;
                    AppendLog("No Stationeers path selected. Vanilla world selection will be disabled.");
                    VanillaWorld_CheckBox.Enabled = false;
                }
            }
        }

    }
}