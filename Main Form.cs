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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox Filter5_CheckBox; // New
        private System.Windows.Forms.CheckBox Filter6_CheckBox; // New
        private System.Windows.Forms.Label labelInstructions;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPaths;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
        private System.Windows.Forms.GroupBox ItemFilters_GroupBox; // Moved to Center_GroupBox
        private System.Windows.Forms.TableLayoutPanel ItemFilters_TableLayout;
        private System.Windows.Forms.GroupBox Center_GroupBox; // Now contains ItemFilters_GroupBox
        private System.Windows.Forms.GroupBox Right_GroupBox;
        private System.Windows.Forms.GroupBox WorldTypeOptions_GroupBox; // Moved to leftmost
        private System.Windows.Forms.CheckBox VanillaWorld_CheckBox;
        private System.Windows.Forms.CheckBox LocalMod_CheckBox;
        private System.Windows.Forms.CheckBox None_CheckBox;
        private System.Windows.Forms.ComboBox WorldSelection_ComboBox;
        private string stationeersPath = null;
        private string outputPath;

        public Main_Form()
        {
            InitializeComponent();
            textBox3.WordWrap = true;
            textBox3.ReadOnly = true;
            textBox3.Font = new Font("Consolas", 9F);
            textBox3.AcceptsReturn = true;
            VanillaWorld_CheckBox.CheckedChanged += CheckBox_CheckedChanged;
            LocalMod_CheckBox.CheckedChanged += CheckBox_CheckedChanged;
            None_CheckBox.CheckedChanged += CheckBox_CheckedChanged;
            WorldSelection_ComboBox.SelectedIndexChanged += WorldSelection_ComboBox_SelectedIndexChanged;
            WorldSelection_ComboBox.Items.Add("Select a world..."); // Placeholder
            WorldSelection_ComboBox.SelectedIndex = 0; // Set default
            WorldSelection_ComboBox.Enabled = false;
            bool isDebug = System.Diagnostics.Debugger.IsAttached;
            string defaultRoot = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers");
            if (isDebug)
            {
                textBox1.Text = "C:\\Users\\Geneticus\\Documents\\My Games\\Stationeers\\saves\\Loulanish_8\\manualsave\\Loulan Scenario Template.save";
            }
            else
            {
                textBox1.Text = Path.Combine(defaultRoot, "saves\\default\\world.xml");
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


        private void Convert_Click(object sender, EventArgs e)
        {
            AppendLog("----------------");
            AppendLog($"Save File: {textBox1.Text}");
            string destPath = None_CheckBox.Checked ? Path.Combine(outputPath ?? "", "SpawnGroup.xml") : null;
            AppendLog($"Destination File: {destPath ?? "To be determined from world selection"}");
            AppendLog($"Output options: {(None_CheckBox.Checked ? "None" : VanillaWorld_CheckBox.Checked ? "Vanilla" : LocalMod_CheckBox.Checked ? "LocalMod" : "None")}");
            AppendLog("----------------");
            textBox3.Text = "";
            AppendLog("Reading Save File... (Step 1 of 6)");
            if (string.IsNullOrEmpty(textBox1.Text) || !File.Exists(textBox1.Text))
            {
                AppendLog("Invalid source .save file path: " + textBox1.Text);
                return;
            }
            if (None_CheckBox.Checked && string.IsNullOrEmpty(outputPath))
            {
                AppendLog("No output folder selected for SpawnGroup.xml.");
                return;
            }
            if ((VanillaWorld_CheckBox.Checked || LocalMod_CheckBox.Checked) && WorldSelection_ComboBox.SelectedIndex <= 0)
            {
                AppendLog("No world selected in WorldSelection_ComboBox. Please select a world.");
                return;
            }
            if (VanillaWorld_CheckBox.Checked || LocalMod_CheckBox.Checked)
            {
                string selectedWorld = WorldSelection_ComboBox.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedWorld) || selectedWorld == "Select a world...")
                {
                    AppendLog("Invalid world selection. Please select a valid world.");
                    return;
                }
                if (VanillaWorld_CheckBox.Checked && stationeersPath != null)
                {
                    destPath = Path.Combine(stationeersPath, "rocketstation_Data", "StreamingAssets", "Worlds", selectedWorld, "SpawnGroup.xml");
                }
                else if (LocalMod_CheckBox.Checked)
                {
                    string basePath = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers");
                    destPath = Path.Combine(basePath, "mods", selectedWorld, "SpawnGroup.xml");
                }
                if (!Directory.Exists(Path.GetDirectoryName(destPath)))
                {
                    AppendLog($"Selected world folder not found: {Path.GetDirectoryName(destPath)}");
                    return;
                }
            }
            string directory = Path.GetDirectoryName(destPath);
            AppendLog($"Creating directory: {directory}");
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }
            AppendLog("Examining Data... (Step 2 of 6)");
            try
            {
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
                if (System.Diagnostics.Debugger.IsAttached)
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
                    AppendLog("");
                }
                AppendLog($"Extracted {things.Count} Things... (Step 4 of 6)");
                AppendLog("Transforming Things to Spawn Items... (Step 5 of 6)");
                var spawnEntries = SourceExtraction.ExtractSpawnEntries(things, textBox3);
                DestinationExport.TransformToNewSchema(things, destPath, textBox3);
                int landerCapsuleRemovedCount = 0;
                int characterRemovedCount = 0;
                int supplyLanderRemovedCount = 0;
                int oreRemovedCount = 0;
                int itemKitRemovedCount = 0;
                if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || Filter5_CheckBox.Checked || Filter6_CheckBox.Checked)
                {
                    var outputDoc = XDocument.Load(destPath);
                    var spawnRoot = outputDoc.Root?.Element("Spawn");
                    var nodesToPrune = new List<XElement>();
                    if (checkBox1.Checked)
                    {
                        var landerCapsuleNodes = spawnRoot?.Elements()
                            .Where(n => n.Attribute("Id")?.Value == "LanderCapsuleSmall")
                            .ToList() ?? new List<XElement>();
                        nodesToPrune.AddRange(landerCapsuleNodes);
                        landerCapsuleRemovedCount = landerCapsuleNodes.Count;
                    }
                    if (checkBox2.Checked)
                    {
                        var characterNodes = spawnRoot?.Elements()
                            .Where(n => n.Attribute("Id")?.Value == "Character")
                            .ToList() ?? new List<XElement>();
                        nodesToPrune.AddRange(characterNodes);
                        characterRemovedCount = characterNodes.Count;
                    }
                    if (checkBox3.Checked)
                    {
                        var supplyLanderNodes = spawnRoot?.Elements()
                            .Where(n => n.Attribute("Id")?.Value == "Lander" || n.Attribute("Id")?.Value == "LanderMkII")
                            .ToList() ?? new List<XElement>();
                        nodesToPrune.AddRange(supplyLanderNodes);
                        supplyLanderRemovedCount = supplyLanderNodes.Count;
                    }
                    if (Filter5_CheckBox.Checked)
                    {
                        var oreNodes = spawnRoot?.Elements()
                            .Where(n => n.Attribute("Id")?.Value.Contains("Ore") ?? false)
                            .ToList() ?? new List<XElement>();
                        nodesToPrune.AddRange(oreNodes);
                        oreRemovedCount = oreNodes.Count;
                    }
                    if (Filter6_CheckBox.Checked)
                    {
                        var itemKitNodes = spawnRoot?.Elements()
                            .Where(n => n.Attribute("Id")?.Value.Contains("ItemKit") ?? false)
                            .ToList() ?? new List<XElement>();
                        nodesToPrune.AddRange(itemKitNodes);
                        itemKitRemovedCount = itemKitNodes.Count;
                    }
                    if (nodesToPrune.Any())
                    {
                        foreach (var node in nodesToPrune)
                        {
                            node.Remove();
                        }
                        outputDoc.Save(destPath);
                        int totalChildrenRemoved = nodesToPrune.Sum(n => n.Descendants().Count());
                        int landerCapsuleSpawnableChildrenRemoved = checkBox1.Checked ? nodesToPrune.Where(n => n.Attribute("Id")?.Value == "LanderCapsuleSmall").Sum(n => n.Descendants().Count(d => d.Name.LocalName == "Structure" || d.Name.LocalName == "Item" || d.Name.LocalName == "DynamicThing")) : 0;
                        int characterSpawnableChildrenRemoved = checkBox2.Checked ? nodesToPrune.Where(n => n.Attribute("Id")?.Value == "Character").Sum(n => n.Descendants().Count(d => d.Name.LocalName == "Structure" || d.Name.LocalName == "Item" || d.Name.LocalName == "DynamicThing")) : 0;
                        int supplyLanderSpawnableChildrenRemoved = checkBox3.Checked ? nodesToPrune.Where(n => n.Attribute("Id")?.Value == "Lander" || n.Attribute("Id")?.Value == "LanderMkII").Sum(n => n.Descendants().Count(d => d.Name.LocalName == "Structure" || d.Name.LocalName == "Item" || d.Name.LocalName == "DynamicThing")) : 0;
                        int oreSpawnableChildrenRemoved = Filter5_CheckBox.Checked ? nodesToPrune.Where(n => n.Attribute("Id")?.Value.Contains("Ore") ?? false).Sum(n => n.Descendants().Count(d => d.Name.LocalName == "Structure" || d.Name.LocalName == "Item" || d.Name.LocalName == "DynamicThing")) : 0;
                        int itemKitSpawnableChildrenRemoved = Filter6_CheckBox.Checked ? nodesToPrune.Where(n => n.Attribute("Id")?.Value.Contains("ItemKit") ?? false).Sum(n => n.Descendants().Count(d => d.Name.LocalName == "Structure" || d.Name.LocalName == "Item" || d.Name.LocalName == "DynamicThing")) : 0;
                        string logMessage = "";
                        if (landerCapsuleRemovedCount > 0) logMessage += $"Removed {landerCapsuleRemovedCount} LanderCapsuleSmall node(s) and {landerCapsuleSpawnableChildrenRemoved} of children";
                        if (characterRemovedCount > 0)
                        {
                            if (logMessage.Length > 0) logMessage += ", ";
                            logMessage += $"Removed {characterRemovedCount} Character node(s) and {characterSpawnableChildrenRemoved} of children";
                        }
                        if (supplyLanderRemovedCount > 0)
                        {
                            if (logMessage.Length > 0) logMessage += ", ";
                            logMessage += $"Removed {supplyLanderRemovedCount} Lander/LanderMkII node(s) and {supplyLanderSpawnableChildrenRemoved} of children";
                        }
                        if (oreRemovedCount > 0)
                        {
                            if (logMessage.Length > 0) logMessage += ", ";
                            logMessage += $"Removed {oreRemovedCount} Ore node(s) and {oreSpawnableChildrenRemoved} of children";
                        }
                        if (itemKitRemovedCount > 0)
                        {
                            if (logMessage.Length > 0) logMessage += ", ";
                            logMessage += $"Removed {itemKitRemovedCount} ItemKit node(s) and {itemKitSpawnableChildrenRemoved} of children";
                        }
                        AppendLog(logMessage + ".");
                        AppendLog($"Debug: Removed {totalChildrenRemoved} total child nodes.");
                    }
                }
                if (!File.Exists(destPath))
                {
                    AppendLog($"Error: Failed to create '{destPath}'. Check permissions or path.");
                    return;
                }
                var prunedDoc = XDocument.Load(destPath);
                int initialSpawnCount = prunedDoc.Descendants().Count(n => n.Name.LocalName == "Structure" || n.Name.LocalName == "Item" || n.Name.LocalName == "DynamicThing");
                int expectedInitialCount = thingCount;
                if (initialSpawnCount == expectedInitialCount - 1 && !checkBox1.Checked && !checkBox2.Checked)
                {
                    AppendLog($"Note: Initial count ({initialSpawnCount}) is 1 less than extracted count ({expectedInitialCount}) without pruning. Transformation may deduplicate 1 item.");
                }
                if ((checkBox1.Checked || checkBox2.Checked) && initialSpawnCount < expectedInitialCount)
                {
                    int transformReduction = expectedInitialCount - initialSpawnCount - (landerCapsuleRemovedCount + characterRemovedCount + supplyLanderRemovedCount + oreRemovedCount + itemKitRemovedCount);
                    if (transformReduction == 1)
                    {
                        AppendLog($"Note: Initial count ({initialSpawnCount}) is 1 less than extracted count ({expectedInitialCount}) due to transformation deduplication.");
                    }
                    else if (transformReduction > 0)
                    {
                        AppendLog($"Note: Initial count ({initialSpawnCount}) is {transformReduction} less than extracted count ({expectedInitialCount}) due to transformation deduplication of {transformReduction} item(s).");
                    }
                    AppendLog($"Note: Adjusted count ({initialSpawnCount - (landerCapsuleRemovedCount + characterRemovedCount + supplyLanderRemovedCount + oreRemovedCount + itemKitRemovedCount)}) reflects removal of {landerCapsuleRemovedCount + characterRemovedCount + supplyLanderRemovedCount + oreRemovedCount + itemKitRemovedCount} node(s) (LanderCapsuleSmall, Character, Lander/LanderMkII, Ore, or ItemKit).");
                }
                int remainingSpawnItems = initialSpawnCount - (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || Filter5_CheckBox.Checked || Filter6_CheckBox.Checked ? (landerCapsuleRemovedCount + characterRemovedCount + supplyLanderRemovedCount + oreRemovedCount + itemKitRemovedCount) : 0);
                if (remainingSpawnItems < 0) remainingSpawnItems = 0;
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
            CheckBox changedBox = (CheckBox)sender;
            if (changedBox == VanillaWorld_CheckBox)
            {
                LocalMod_CheckBox.Checked = false;
                None_CheckBox.Checked = false;
                if (changedBox.Checked && stationeersPath == null)
                {
                    string defaultPath = @"C:\Program Files (x86)\Steam\steamapps\common\Stationeers";
                    string exePath = Path.Combine(defaultPath, "rocketstation.exe");
                    if (File.Exists(exePath))
                    {
                        DialogResult result = MessageBox.Show(
                            $"Detected Stationeers at {defaultPath}. Use this as the game installation path?",
                            "Confirm Stationeers Path",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );
                        if (result == DialogResult.Yes)
                        {
                            stationeersPath = defaultPath;
                            AppendLog($"Stationeers path set to: {stationeersPath}");
                        }
                        else
                        {
                            SetStationeersPath();
                            if (stationeersPath == null)
                            {
                                VanillaWorld_CheckBox.Checked = false;
                                VanillaWorld_CheckBox.Enabled = true;
                                return;
                            }
                        }
                    }
                    else
                    {
                        SetStationeersPath();
                        if (stationeersPath == null)
                        {
                            VanillaWorld_CheckBox.Checked = false;
                            VanillaWorld_CheckBox.Enabled = true;
                            return;
                        }
                    }
                }
            }
            else if (changedBox == LocalMod_CheckBox)
            {
                VanillaWorld_CheckBox.Checked = false;
                None_CheckBox.Checked = false;
            }
            else if (changedBox == None_CheckBox)
            {
                VanillaWorld_CheckBox.Checked = false;
                LocalMod_CheckBox.Checked = false;
                if (changedBox.Checked)
                {
                    using (OpenFileDialog folderDialog = new OpenFileDialog())
                    {
                        folderDialog.ValidateNames = false;
                        folderDialog.CheckFileExists = false;
                        folderDialog.CheckPathExists = true;
                        folderDialog.FileName = "Select Folder";
                        folderDialog.Filter = "Folders|*.*";
                        folderDialog.InitialDirectory = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers");
                        folderDialog.Title = "Select folder for the transformed SpawnGroup.xml";
                        if (folderDialog.ShowDialog() == DialogResult.OK)
                        {
                            outputPath = Path.GetDirectoryName(folderDialog.FileName);
                            AppendLog($"Output folder for SpawnGroup.xml set to: {outputPath}");
                        }
                        else
                        {
                            outputPath = null;
                            AppendLog("No output folder selected for SpawnGroup.xml.");
                        }
                    }
                }
                else
                {
                    outputPath = null;
                }
            }

            if (VanillaWorld_CheckBox.Checked || LocalMod_CheckBox.Checked)
            {
                if (!WorldSelection_ComboBox.Items.Contains("Select a world..."))
                {
                    WorldSelection_ComboBox.Items.Insert(0, "Select a world...");
                }
                WorldSelection_ComboBox.SelectedIndex = 0;
                WorldSelection_ComboBox.Enabled = true;
                PopulateWorldDropdown();
                VerifySelectedWorld();
            }
            else
            {
                WorldSelection_ComboBox.Items.Clear();
                WorldSelection_ComboBox.Items.Add("Select a world...");
                WorldSelection_ComboBox.SelectedIndex = 0;
                WorldSelection_ComboBox.Enabled = false;
            }

            VanillaWorld_CheckBox.Enabled = true;
            label1.Enabled = true;
            textBox1.Enabled = true;
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
                        .Where(f => !f.Contains("Tutorial") && !f.Equals("SharedTextures", StringComparison.OrdinalIgnoreCase))
                        .ToArray();
                    WorldSelection_ComboBox.Items.AddRange(worldFolders);
                }
                //else
                //{
                //    AppendLog($"Warning: Worlds directory not found at {worldsPath}.");
                //}
            }
            else if (LocalMod_CheckBox.Checked)
            {
                string basePath = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers");
                string modsPath = Path.Combine(basePath, "mods");
                if (Directory.Exists(modsPath))
                {
                    var modFolders = Directory.GetDirectories(modsPath)
                        .Select(Path.GetFileName)
                        .Where(modName =>
                        {
                            string modRootPath = Path.Combine(modsPath, modName);
                            // Search recursively for any "GameData\Worlds" path
                            string[] allSubFolders = Directory.GetDirectories(modRootPath, "*", SearchOption.AllDirectories);
                            bool worldFound = false;
                            foreach (string folder in allSubFolders)
                            {
                                if (folder.EndsWith("\\GameData\\Worlds", StringComparison.OrdinalIgnoreCase))
                                {
                                    string[] subWorldFolders = Directory.GetDirectories(folder, "*", SearchOption.AllDirectories)
                                        .Concat(new[] { folder }) // Include the Worlds folder itself
                                        .ToArray();
                                    foreach (string subFolder in subWorldFolders)
                                    {
                                        string[] xmlFiles = Directory.GetFiles(subFolder, "*.xml");
                                        foreach (string xmlFile in xmlFiles)
                                        {
                                            try
                                            {
                                                XDocument doc = XDocument.Load(xmlFile);
                                                if (doc.Root != null && doc.Root.Name.LocalName == "GameData")
                                                {
                                                    var worldSettings = doc.Descendants("WorldSettings").FirstOrDefault();
                                                    if (worldSettings != null)
                                                    {
                                                        worldFound = true;
                                                        break;
                                                    }
                                                }
                                            }
                                            catch (XmlException)
                                            {
                                                continue;
                                            }
                                        }
                                        if (worldFound) break;
                                    }
                                    if (worldFound) break;
                                }
                            }
                            return worldFound;
                        })
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

        //private void VerifySelectedWorld()
        //{
        //    if (WorldSelection_ComboBox.SelectedIndex > 0 && !None_CheckBox.Checked)
        //    {
        //        string selectedFolder = WorldSelection_ComboBox.SelectedItem.ToString();
        //        string fullPath = "";
        //        if (VanillaWorld_CheckBox.Checked && stationeersPath != null)
        //        {
        //            string worldsPath = Path.Combine(stationeersPath, "rocketstation_Data", "StreamingAssets", "Worlds", selectedFolder);
        //            fullPath = Path.Combine(worldsPath, "world.xml");
        //            if (!File.Exists(fullPath))
        //            {
        //                AppendLog($"Warning: 'world.xml' not found in {selectedFolder}.");
        //                WorldSelection_ComboBox.SelectedIndex = 0;
        //            }
        //        }
        //        else if (LocalMod_CheckBox.Checked)
        //        {
        //            string basePath = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers");
        //            string modsPath = Path.Combine(basePath, "mods", selectedFolder);
        //            if (Directory.Exists(modsPath))
        //            {
        //                string[] subFolders = Directory.GetFiles(modsPath, "*.xml", SearchOption.AllDirectories);
        //                bool worldFound = false;
        //                foreach (string xmlFile in subFolders)
        //                {
        //                    try
        //                    {
        //                        XDocument doc = XDocument.Load(xmlFile);
        //                        if (doc.Root != null && doc.Root.Name.LocalName == "WorldSettings")
        //                        {
        //                            fullPath = xmlFile;
        //                            worldFound = true;
        //                            break;
        //                        }
        //                    }
        //                    catch (XmlException)
        //                    {
        //                        continue;
        //                    }
        //                }
        //                if (!worldFound)
        //                {
        //                    AppendLog($"Warning: No WorldSettings XML file found in {selectedFolder} or its subfolders.");
        //                    WorldSelection_ComboBox.SelectedIndex = 0;
        //                }
        //            }
        //            else
        //            {
        //                AppendLog($"Warning: Mod folder {selectedFolder} not found at {modsPath}.");
        //                WorldSelection_ComboBox.SelectedIndex = 0;
        //            }
        //        }
        //    }
        //}

        private void VerifySelectedWorld()
        {
            if (WorldSelection_ComboBox.SelectedIndex > 0 && !None_CheckBox.Checked)
            {
                string selectedFolder = WorldSelection_ComboBox.SelectedItem.ToString();
                // No file validation at this stage; just ensure folder is selected
            }
        }

        private void WorldSelection_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!None_CheckBox.Checked) VerifySelectedWorld();
        }

        private void SetStationeersPath()
        {
            using (OpenFileDialog folderDialog = new OpenFileDialog())
            {
                folderDialog.ValidateNames = false;
                folderDialog.CheckFileExists = false;
                folderDialog.CheckPathExists = true;
                folderDialog.FileName = "Select Folder"; // Placeholder for folder selection
                folderDialog.Filter = "Folders|*.*";
                folderDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                folderDialog.Title = "Select the Stationeers installation folder (containing 'rocketstation_Data')";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = Path.GetDirectoryName(folderDialog.FileName);
                    if (Directory.Exists(Path.Combine(selectedPath, "rocketstation_Data", "StreamingAssets", "Worlds")))
                    {
                        stationeersPath = selectedPath;
                        AppendLog($"Stationeers path set to: {stationeersPath}");
                    }
                    else
                    {
                        MessageBox.Show("The selected folder does not contain a valid Stationeers installation. Please select the folder containing 'rocketstation_Data'.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        stationeersPath = null;
                        AppendLog("Invalid Stationeers path selected. Please try again.");
                    }
                }
                else
                {
                    AppendLog("No Stationeers path selected. Vanilla world selection remains available.");
                }
            }
        }

    }
}