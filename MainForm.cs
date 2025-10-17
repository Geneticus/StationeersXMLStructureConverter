using StationeersSpawnXML;
using StationeersStructureXMLConverter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabConversion;
        private System.Windows.Forms.TabPage tabWorldEditor;
        private System.Windows.Forms.TabPage tabTools;
        private System.Windows.Forms.Button btnRunXsdGenerator;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelInstructions;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPaths;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel ItemFilters_TableLayout;
        private System.Windows.Forms.GroupBox WorldTypeOptions_GroupBox;
        private System.Windows.Forms.Label comboBoxLabel;
        private System.Windows.Forms.CheckBox VanillaWorld_CheckBox;
        private System.Windows.Forms.CheckBox LocalMod_CheckBox;
        private System.Windows.Forms.CheckBox None_CheckBox;
        private System.Windows.Forms.ComboBox WorldSelection_ComboBox;
        private System.Windows.Forms.GroupBox ItemFilters_GroupBox;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox Filter5_CheckBox;
        private System.Windows.Forms.CheckBox Filter6_CheckBox;
        private System.Windows.Forms.GroupBox Right_GroupBox;
        private System.Windows.Forms.Button configureOutputsButton;
        private System.Windows.Forms.Label configureOutputsLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel worldEditorTableLayout;
        private System.Windows.Forms.TextBox txtWorldId;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.CheckBox chkHidden;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtShortDesc;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.CheckedListBox clbStartConditions;
        private System.Windows.Forms.ListView lvStartLocations;
        private System.Windows.Forms.Button btnAddLocation;
        private System.Windows.Forms.Button btnEditLocation;
        private System.Windows.Forms.Button btnDeleteLocation;
        private System.Windows.Forms.ListView lvObjectives;
        private System.Windows.Forms.Button btnAddObjective;
        private System.Windows.Forms.Button btnEditObjective;
        private System.Windows.Forms.Button btnDeleteObjective;
        private System.Windows.Forms.Button btnSaveWorldSettings;
        private string newModPath;
        private XDocument worldDoc;
        private string worldXmlPath;
        private XDocument objectivesDoc;
        private string objectivesPath;
        private string stationeersPath = null;
        private string outputPath;
        private string modName = "";
        private string worldName = "";
        private string description = "";
        private string summary = "";

        public Main_Form()
        {
            InitializeComponent();
            if (configureOutputsButton != null)
            {
                configureOutputsButton.Enabled = false; // Ensure disabled by default
                configureOutputsButton.Visible = true;
            }
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
            Right_GroupBox.PerformLayout();
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
            string worldFolder = "";
            string destWorldPath = "";
            string newModPath = "";
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
                // Verify mod configuration for world selection
                if ((VanillaWorld_CheckBox.Checked || LocalMod_CheckBox.Checked) && WorldSelection_ComboBox.SelectedIndex > 0 && string.IsNullOrEmpty(modName))
                {
                    AppendLog("Error: Mod name is not set. Please configure file outputs.");
                    return;
                }

                string destSpawnGroupPath = null;
                if (!string.IsNullOrEmpty(modName))
                {
                    AppendLog("Creating new mod... (Step 6 of 7)");
                    string modsBasePath = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers\\mods");
                    newModPath = Path.Combine(modsBasePath, modName);
                    try
                    {
                        // Extract only About/ from ExampleMod.zip to a temp path
                        string exampleModZip = Path.Combine(stationeersPath ?? @"C:\Program Files (x86)\Steam\steamapps\common\Stationeers", "rocketstation_Data", "StreamingAssets", "ExampleMod.zip");
                        if (!File.Exists(exampleModZip))
                        {
                            AppendLog($"Error: ExampleMod.zip not found at {exampleModZip}.");
                            return;
                        }
                        string tempExtractPath = Path.Combine(Path.GetTempPath(), "StationeersExampleMod_" + Guid.NewGuid().ToString());
                        Directory.CreateDirectory(tempExtractPath);
                        using (ZipArchive archive = ZipFile.OpenRead(exampleModZip))
                        {
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {
                                if (entry.FullName.StartsWith("About/", StringComparison.OrdinalIgnoreCase) || entry.FullName == "About.xml" || entry.FullName.StartsWith("About\\"))
                                {
                                    string destFile = Path.Combine(tempExtractPath, entry.FullName);
                                    Directory.CreateDirectory(Path.GetDirectoryName(destFile));
                                    entry.ExtractToFile(destFile, true);
                                }
                            }
                        }
                        AppendLog($"Extracted About/ from ExampleMod.zip to temp: {tempExtractPath}");

                        // Copy source world/mod first to establish base structure
                        string selectedWorld = WorldSelection_ComboBox.SelectedItem?.ToString();
                        string sourceWorldPath;                        
                        bool overwriteFiles = true; // Merge/overwrite most files
                        if (VanillaWorld_CheckBox.Checked && stationeersPath != null)
                        {
                            sourceWorldPath = Path.Combine(stationeersPath, "rocketstation_Data", "StreamingAssets", "Worlds", selectedWorld);
                            destWorldPath = Path.Combine(newModPath, "GameData", "Worlds", selectedWorld);
                            overwriteFiles = false; // Vanilla: No extras to overwrite
                        }
                        else // Local mod: Merge full contents to root
                        {
                            sourceWorldPath = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers"), "mods", selectedWorld);
                            destWorldPath = newModPath;
                        }
                        if (!Directory.Exists(sourceWorldPath))
                        {
                            AppendLog($"Error: Source world folder not found at {sourceWorldPath}.");
                            return;
                        }
                        DirectoryCopy(sourceWorldPath, destWorldPath, true, overwriteFiles);
                        AppendLog($"Copied source from {sourceWorldPath} to {destWorldPath}");

                        // Handle Language/ merge if at root (move to GameData/Language/)
                        string sourceLanguagePath = Path.Combine(newModPath, "Language");
                        string destLanguagePath = Path.Combine(newModPath, "GameData", "Language");
                        if (Directory.Exists(sourceLanguagePath))
                        {
                            if (!Directory.Exists(destLanguagePath))
                            {
                                Directory.CreateDirectory(destLanguagePath);
                            }
                            DirectoryCopy(sourceLanguagePath, destLanguagePath, true, true); // Merge/overwrite
                            Directory.Delete(sourceLanguagePath, true); // Remove root Language/
                            AppendLog("Moved root Language/ to GameData/Language/ for standard mod structure.");
                        }
                        else
                        {
                            AppendLog("No root Language/ found in source; assuming already in GameData/ or not present (non-critical).");
                        }
                        // Overwrite with clean About/ from ExampleMod
                        string cleanAboutPath = Path.Combine(tempExtractPath, "About");
                        if (Directory.Exists(cleanAboutPath))
                        {
                            string destAboutPath = Path.Combine(newModPath, "About");
                            Directory.CreateDirectory(destAboutPath);
                            DirectoryCopy(cleanAboutPath, destAboutPath, true, true); // Overwrite any from source
                            AppendLog("Overwrote About/ with clean version from ExampleMod to prevent Workshop ID conflicts.");
                        }
                        else
                        {
                            AppendLog("Warning: No About/ found in ExampleMod extract; no overwrite applied.");
                        }
                        // Clean up temp
                        Directory.Delete(tempExtractPath, true);

                        // Prepare SpawnGroup.xml path
                        string destGameDataPath = Path.Combine(newModPath, "GameData");
                        destSpawnGroupPath = Path.Combine(destGameDataPath, "SpawnGroup.xml");
                        Directory.CreateDirectory(destGameDataPath);

                    }
                    catch (Exception ex)
                    {
                        AppendLog($"Error during mod setup: {ex.Message}");
                        AppendLog($"Inner: {ex.InnerException?.Message ?? "N/A"}");
                        AppendLog($"Stack: {ex.StackTrace}");
                        return;
                    }
                }
                else if (None_CheckBox.Checked)
                {
                    destSpawnGroupPath = Path.Combine(outputPath ?? "", "SpawnGroup.xml");
                    Directory.CreateDirectory(Path.GetDirectoryName(destSpawnGroupPath));
                }
                else
                {
                    AppendLog("Error: No output destination set (world or folder not selected).");
                    return;
                }
                DestinationExport.TransformToNewSchema(things, destSpawnGroupPath, textBox3);
                int landerCapsuleRemovedCount = 0;
                int characterRemovedCount = 0;
                int supplyLanderRemovedCount = 0;
                int oreRemovedCount = 0;
                int itemKitRemovedCount = 0;
                if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || Filter5_CheckBox.Checked || Filter6_CheckBox.Checked)
                {
                    var outputDoc = XDocument.Load(destSpawnGroupPath);
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
                        outputDoc.Save(destSpawnGroupPath);
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
                if (!File.Exists(destSpawnGroupPath))
                {
                    AppendLog($"Error: Failed to create '{destSpawnGroupPath}'. Check permissions or path.");
                    return;
                }


                // Proceed with mod creation if modName is set
                if (!string.IsNullOrEmpty(modName))
                {
                    string selectedWorld = WorldSelection_ComboBox.SelectedItem?.ToString();
                    if (string.IsNullOrEmpty(selectedWorld) || selectedWorld == "Select a world...")
                    {
                        AppendLog("Error: Invalid world selection for mod creation.");
                        return;
                    }
                    worldFolder = Path.Combine(newModPath, "GameData", "Worlds", selectedWorld); // Moved here, in scope
                    var worldXmlFiles = Directory.GetFiles(worldFolder, "*.xml").Where(file =>
                    {
                        try
                        {
                            var docNext = XDocument.Load(file);
                            return docNext.Root?.Name.LocalName == "WorldSettingData" && docNext.Root.Element("World") != null;
                        }
                        catch
                        {
                            return false;
                        }
                    }).ToList();
                    if (worldXmlFiles.Count == 0)
                    {
                        AppendLog($"Error: No WorldSettingData XML with <World> found in {worldFolder}.");
                        return;
                    }
                    string worldXmlPath = worldXmlFiles.First();
                    var worldDoc = XDocument.Load(worldXmlPath);
                    var worldSettings = worldDoc.Root;
                    if (worldSettings == null)
                    {
                        AppendLog($"Error: Invalid WorldSettingData in {worldXmlPath}.");
                        return;
                    }
                    // Add Spawn reference
                    var existingSpawn = worldSettings.Element("Spawn");
                    if (existingSpawn != null)
                    {
                        existingSpawn.Remove();
                    }
                    worldSettings.Add(new XElement("Spawn",
                        new XAttribute("Id", "My_ScenarioThings"),
                        new XAttribute("Event", "NewWorld"),
                        new XAttribute("HideInStartScreen", "false")
                    ));
                    // Update World Id
                    var worldElement = worldSettings.Element("World");
                    if (worldElement != null)
                    {
                        worldElement.SetAttributeValue("Id", string.IsNullOrEmpty(worldName) ? $"{modName}_World" : worldName);
                    }
                    else
                    {
                        worldSettings.Add(new XElement("World",
                            new XAttribute("Id", string.IsNullOrEmpty(worldName) ? $"{modName}_World" : worldName)
                        ));
                    }
                    // Optional: Update Description and SummaryText
                    if (!string.IsNullOrEmpty(description))
                    {
                        var descriptionElement = worldSettings.Element("Description");
                        if (descriptionElement != null)
                        {
                            descriptionElement.SetAttributeValue("Key", $"{modName}_Description");
                        }
                        else
                        {
                            worldSettings.Add(new XElement("Description", new XAttribute("Key", $"{modName}_Description")));
                        }
                    }
                    if (!string.IsNullOrEmpty(summary))
                    {
                        var summaryElement = worldSettings.Element("SummaryText");
                        if (summaryElement != null)
                        {
                            summaryElement.SetAttributeValue("Key", $"{modName}_Summary");
                        }
                        else
                        {
                            worldSettings.Add(new XElement("SummaryText", new XAttribute("Key", $"{modName}_Summary")));
                        }
                    }
                    worldDoc.Save(worldXmlPath);
                    AppendLog($"Updated {worldXmlPath} with Spawn reference and World Id: {(string.IsNullOrEmpty(worldName) ? $"{modName}_World" : worldName)}");

                    // Optional: Update all language files in GameData/Language/
                    string languageFolder = Path.Combine(newModPath, "GameData", "Language");
                    if (Directory.Exists(languageFolder))
                    {
                        var languageFiles = Directory.GetFiles(languageFolder, "*.xml").Where(file =>
                        {
                            try
                            {
                                var languageDoc = XDocument.Load(file);
                                return languageDoc.Root?.Element("Interface") != null;
                            }
                            catch
                            {
                                return false;
                            }
                        }).ToList();
                        if (languageFiles.Any())
                        {
                            foreach (var langFile in languageFiles)
                            {
                                try
                                {
                                    var langDoc = XDocument.Load(langFile);
                                    var interfaceElement = langDoc.Root?.Element("Interface");
                                    if (interfaceElement != null)
                                    {
                                        // Update or add WorldName
                                        var worldNameEntry = interfaceElement.Elements("Record").FirstOrDefault(r => r.Element("Key")?.Value == $"{modName}_World");
                                        if (worldNameEntry != null)
                                        {
                                            worldNameEntry.SetElementValue("Value", string.IsNullOrEmpty(worldName) ? modName : worldName);
                                        }
                                        else
                                        {
                                            interfaceElement.Add(new XElement("Record",
                                                new XElement("Key", $"{modName}_World"),
                                                new XElement("Value", string.IsNullOrEmpty(worldName) ? modName : worldName)
                                            ));
                                        }
                                        // Update or add Description
                                        if (!string.IsNullOrEmpty(description))
                                        {
                                            var descEntry = interfaceElement.Elements("Record").FirstOrDefault(r => r.Element("Key")?.Value == $"{modName}_Description");
                                            if (descEntry != null)
                                            {
                                                descEntry.SetElementValue("Value", description);
                                            }
                                            else
                                            {
                                                interfaceElement.Add(new XElement("Record",
                                                    new XElement("Key", $"{modName}_Description"),
                                                    new XElement("Value", description)
                                                ));
                                            }
                                        }
                                        // Update or add Summary
                                        if (!string.IsNullOrEmpty(summary))
                                        {
                                            var summaryEntry = interfaceElement.Elements("Record").FirstOrDefault(r => r.Element("Key")?.Value == $"{modName}_Summary");
                                            if (summaryEntry != null)
                                            {
                                                summaryEntry.SetElementValue("Value", summary);
                                            }
                                            else
                                            {
                                                interfaceElement.Add(new XElement("Record",
                                                    new XElement("Key", $"{modName}_Summary"),
                                                    new XElement("Value", summary)
                                                ));
                                            }
                                        }
                                        langDoc.Save(langFile);
                                        AppendLog($"Updated language file {langFile} with WorldName, Description, and Summary");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    AppendLog($"Warning: Failed to update language file {langFile}: {ex.Message} (non-critical, continuing)");
                                }
                            }
                        }
                        else
                        {
                            AppendLog("No valid language files found in GameData/Language/ (non-critical, skipping updates)");
                        }
                    }
                    else
                    {
                        AppendLog("No GameData/Language/ folder found (non-critical, skipping language updates)");
                    }
                    AppendLog("Mod creation completed successfully! (Step 7 of 7)");
                    LoadWorldSettings(); // Load settings into editor
                    tabControlMain.SelectedTab = tabWorldEditor;

                }
                else
                {
                    destSpawnGroupPath = Path.Combine(outputPath ?? "", "SpawnGroup.xml");
                    Directory.CreateDirectory(Path.GetDirectoryName(destSpawnGroupPath));
                    DestinationExport.TransformToNewSchema(things, destSpawnGroupPath, textBox3);
                    AppendLog("Conversion completed successfully! (Step 6 of 6)");
                    tabControlMain.SelectedTab = tabConversion;
                }

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
                                if (configureOutputsButton != null)
                                {
                                    configureOutputsButton.Enabled = false;
                                }
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
                            if (configureOutputsButton != null)
                            {
                                configureOutputsButton.Enabled = false;
                            }
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
                configureOutputsButton.Enabled = WorldSelection_ComboBox.SelectedIndex > 0; // Enable if valid world selected
            }
            else
            {
                WorldSelection_ComboBox.Items.Clear();
                WorldSelection_ComboBox.Items.Add("Select a world...");
                WorldSelection_ComboBox.SelectedIndex = 0;
                WorldSelection_ComboBox.Enabled = false;
                configureOutputsButton.Enabled = false; // Disable button
            }

            VanillaWorld_CheckBox.Enabled = true;
            label1.Enabled = true;
            textBox1.Enabled = true;
        }

        // Add ConfigureOutputs_Click handler (after CheckBox_CheckedChanged, around line 350)
        private void ConfigureOutputs_Click(object sender, EventArgs e)
        {
            using (var configForm = new ModConfigForm())
            {
                if (configForm.ShowDialog() == DialogResult.OK)
                {
                    modName = configForm.ModName;
                    worldName = configForm.WorldName;
                    description = configForm.Description;
                    summary = configForm.Summary;
                    AppendLog("Mod configuration set:");
                    AppendLog($"  Mod Name: {modName}");
                    AppendLog($"  World Name: {worldName}");
                    AppendLog($"  Description: {description}");
                    AppendLog($"  Summary: {summary}");
                }
                else
                {
                    AppendLog("Mod configuration cancelled.");
                }
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

        // Add DirectoryCopy method (after VerifySelectedWorld, around line 400)
        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, bool excludeAboutXml)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                AppendLog($"Error: Source directory does not exist: {sourceDirName}");
                return;
            }
            Directory.CreateDirectory(destDirName);
            foreach (FileInfo file in dir.GetFiles())
            {
                if (excludeAboutXml && file.Name.Equals("About.xml", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dir.GetDirectories())
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs, excludeAboutXml);
                }
            }
        }

        private void WorldSelection_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (configureOutputsButton != null)
            {
                configureOutputsButton.Enabled = WorldSelection_ComboBox.SelectedIndex > 0;
            }
            VerifySelectedWorld();
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

        private void LoadWorldSettings()
        {
            if (string.IsNullOrEmpty(newModPath))
            {
                MessageBox.Show("Create a mod first.");
                return;
            }
            string selectedWorld = WorldSelection_ComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedWorld) || selectedWorld == "Select a world...")
            {
                MessageBox.Show("Invalid world selection.");
                return;
            }
            string worldFolder = Path.Combine(newModPath, "GameData", "Worlds", selectedWorld);
            var worldXmlFiles = Directory.GetFiles(worldFolder, "*.xml").Where(f =>
            {
                try
                {
                    var doc = XDocument.Load(f);
                    return doc.Root?.Name.LocalName == "WorldSettingData" && doc.Root.Element("World") != null;
                }
                catch
                {
                    return false;
                }
            }).ToList();
            if (worldXmlFiles.Any())
            {
                worldXmlPath = worldXmlFiles.First();
                worldDoc = XDocument.Load(worldXmlPath);
                var settings = worldDoc.Root;
                txtWorldId.Text = settings.Element("World")?.Attribute("Id")?.Value ?? (string.IsNullOrEmpty(worldName) ? $"{modName}_World" : worldName);
                txtPriority.Text = settings.Element("World")?.Attribute("Priority")?.Value ?? "2";
                chkHidden.Checked = bool.TryParse(settings.Element("World")?.Attribute("Hidden")?.Value, out bool hidden) && hidden;
                txtName.Text = settings.Element("Name")?.Value ?? (string.IsNullOrEmpty(worldName) ? modName : worldName);
                txtDescription.Text = settings.Element("Description")?.Attribute("Key")?.Value ?? $"{modName}_Description";
                txtShortDesc.Text = settings.Element("ShortDescription")?.Attribute("Key")?.Value ?? $"{modName}_ShortDesc";
                txtSummary.Text = settings.Element("SummaryText")?.Attribute("Key")?.Value ?? $"{modName}_Summary";

                clbStartConditions.Items.Clear();
                List<string> conditionIds = new List<string>();
                string vanillaConditions = Path.Combine(stationeersPath ?? @"C:\Program Files (x86)\Steam\steamapps\common\Stationeers", "rocketstation_Data", "StreamingAssets", "Data", "startconditions.xml");
                if (File.Exists(vanillaConditions))
                {
                    var vanDoc = XDocument.Load(vanillaConditions);
                    conditionIds.AddRange(vanDoc.Root?.Elements("StartConditionData").Select(e => e.Attribute("Id")?.Value ?? "") ?? Enumerable.Empty<string>());
                }
                string sourceConditions = Path.Combine(newModPath, "GameData", "startconditions.xml");
                if (File.Exists(sourceConditions))
                {
                    var srcDoc = XDocument.Load(sourceConditions);
                    conditionIds.AddRange(srcDoc.Root?.Elements("StartConditionData").Select(e => e.Attribute("Id")?.Value ?? "") ?? Enumerable.Empty<string>());
                }
                clbStartConditions.Items.AddRange(conditionIds.Distinct().ToArray());
                var currentConditions = settings.Element("StartConditions")?.Elements("StartCondition").Select(e => e.Attribute("Id")?.Value ?? "").ToList();
                foreach (var id in currentConditions)
                {
                    int index = clbStartConditions.Items.IndexOf(id);
                    if (index >= 0) clbStartConditions.SetItemChecked(index, true);
                }

                lvStartLocations.Items.Clear();
                foreach (var loc in settings.Elements("startlocation"))
                {
                    var pos = loc.Element("Position");
                    var item = new ListViewItem(pos?.Element("x")?.Value ?? "0");
                    item.SubItems.Add(pos?.Element("y")?.Value ?? "0");
                    item.SubItems.Add(pos?.Element("z")?.Value ?? "0");
                    item.Tag = loc;
                    lvStartLocations.Items.Add(item);
                }
            }
            else
            {
                AppendLog("No world.xml found; using defaults.");
                worldDoc = new XDocument(new XElement("WorldSettingData"));
                worldXmlPath = Path.Combine(worldFolder, "world.xml");
                txtWorldId.Text = string.IsNullOrEmpty(worldName) ? $"{modName}_World" : worldName;
                txtPriority.Text = "2";
                chkHidden.Checked = false;
                txtName.Text = string.IsNullOrEmpty(worldName) ? modName : worldName;
                txtDescription.Text = $"{modName}_Description";
                txtShortDesc.Text = $"{modName}_ShortDesc";
                txtSummary.Text = $"{modName}_Summary";
            }

            objectivesPath = Path.Combine(newModPath, "GameData", "WorldObjectives.xml");
            if (File.Exists(objectivesPath))
            {
                objectivesDoc = XDocument.Load(objectivesPath);
                lvObjectives.Items.Clear();
                foreach (var obj in objectivesDoc.Root?.Elements("WorldObjective") ?? Enumerable.Empty<XElement>())
                {
                    var item = new ListViewItem(obj.Attribute("Id")?.Value ?? "Unknown");
                    item.SubItems.Add(obj.Element("Description")?.Value ?? "");
                    item.SubItems.Add(obj.Element("Info")?.Attribute("Key")?.Value ?? "");
                    item.Tag = obj;
                    lvObjectives.Items.Add(item);
                }
            }
            else
            {
                objectivesDoc = new XDocument(new XElement("WorldObjectivesData"));
            }
        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            using (var dialog = new Form())
            {
                dialog.Text = "Add/Edit Start Location";
                var txtX = new TextBox { Location = new System.Drawing.Point(20, 20), Width = 100, Text = "0" };
                var txtY = new TextBox { Location = new System.Drawing.Point(20, 50), Width = 100, Text = "0" };
                var txtZ = new TextBox { Location = new System.Drawing.Point(20, 80), Width = 100, Text = "0" };
                var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(20, 110), DialogResult = DialogResult.OK };
                dialog.Controls.AddRange(new Control[] {
                    new Label { Text = "X:", Location = new System.Drawing.Point(0, 20) }, txtX,
                    new Label { Text = "Y:", Location = new System.Drawing.Point(0, 50) }, txtY,
                    new Label { Text = "Z:", Location = new System.Drawing.Point(0, 80) }, txtZ, btnOk });
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var item = new ListViewItem(txtX.Text);
                    item.SubItems.Add(txtY.Text);
                    item.SubItems.Add(txtZ.Text);
                    var locElement = new XElement("startlocation", new XElement("Position",
                        new XElement("x", txtX.Text), new XElement("y", txtY.Text), new XElement("z", txtZ.Text)));
                    item.Tag = locElement;
                    lvStartLocations.Items.Add(item);
                }
            }
        }

        private void btnEditLocation_Click(object sender, EventArgs e)
        {
            if (lvStartLocations.SelectedItems.Count == 0) return;
            var item = lvStartLocations.SelectedItems[0];
            using (var dialog = new Form())
            {
                dialog.Text = "Edit Start Location";
                var txtX = new TextBox { Location = new System.Drawing.Point(20, 20), Width = 100, Text = item.Text };
                var txtY = new TextBox { Location = new System.Drawing.Point(20, 50), Width = 100, Text = item.SubItems[1].Text };
                var txtZ = new TextBox { Location = new System.Drawing.Point(20, 80), Width = 100, Text = item.SubItems[2].Text };
                var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(20, 110), DialogResult = DialogResult.OK };
                dialog.Controls.AddRange(new Control[] {
                    new Label { Text = "X:", Location = new System.Drawing.Point(0, 20) }, txtX,
                    new Label { Text = "Y:", Location = new System.Drawing.Point(0, 50) }, txtY,
                    new Label { Text = "Z:", Location = new System.Drawing.Point(0, 80) }, txtZ, btnOk });
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    item.Text = txtX.Text;
                    item.SubItems[1].Text = txtY.Text;
                    item.SubItems[2].Text = txtZ.Text;
                    var locElement = (XElement)item.Tag;
                    locElement.Element("Position").Element("x").Value = txtX.Text;
                    locElement.Element("Position").Element("y").Value = txtY.Text;
                    locElement.Element("Position").Element("z").Value = txtZ.Text;
                }
            }
        }

        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            if (lvStartLocations.SelectedItems.Count == 0) return;
            lvStartLocations.Items.Remove(lvStartLocations.SelectedItems[0]);
        }

        private void btnAddObjective_Click(object sender, EventArgs e)
        {
            using (var dialog = new Form())
            {
                dialog.Text = "Add/Edit Objective";
                var txtId = new TextBox { Location = new System.Drawing.Point(20, 20), Width = 200, Text = "Objective" + (lvObjectives.Items.Count + 1) };
                var txtDesc = new TextBox { Location = new System.Drawing.Point(20, 50), Width = 200, Text = "" };
                var txtInfoKey = new TextBox { Location = new System.Drawing.Point(20, 80), Width = 200, Text = $"{modName}_Objective{lvObjectives.Items.Count + 1}" };
                var clbConditions = new CheckedListBox { Location = new System.Drawing.Point(20, 110), Width = 200, Height = 100 };
                // Simplified conditions; extend with XSD schema
                clbConditions.Items.AddRange(new[] { "ThingPrefabCondition:StructureSolarPanel:1", "BuildStateCondition:StructureBase:Built" });
                var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(20, 220), DialogResult = DialogResult.OK };
                dialog.Controls.AddRange(new Control[] {
                    new Label { Text = "Objective ID:", Location = new System.Drawing.Point(0, 20) }, txtId,
                    new Label { Text = "Description:", Location = new System.Drawing.Point(0, 50) }, txtDesc,
                    new Label { Text = "Info Key:", Location = new System.Drawing.Point(0, 80) }, txtInfoKey,
                    new Label { Text = "Conditions:", Location = new System.Drawing.Point(0, 110) }, clbConditions, btnOk });
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var item = new ListViewItem(txtId.Text);
                    item.SubItems.Add(txtDesc.Text);
                    item.SubItems.Add(txtInfoKey.Text);
                    var objElement = new XElement("WorldObjective",
                        new XAttribute("Id", txtId.Text),
                        new XElement("Description", txtDesc.Text),
                        new XElement("Info", new XAttribute("Key", txtInfoKey.Text)));
                    foreach (var cond in clbConditions.CheckedItems)
                    {
                        var parts = cond.ToString().Split(':');
                        if (parts[0] == "ThingPrefabCondition")
                            objElement.Add(new XElement("ThingPrefabCondition",
                                new XAttribute("PrefabName", parts[1]),
                                new XAttribute("Count", parts[2])));
                        // Add other condition types
                    }
                    item.Tag = objElement;
                    lvObjectives.Items.Add(item);
                }
            }
        }

        private void btnEditObjective_Click(object sender, EventArgs e)
        {
            if (lvObjectives.SelectedItems.Count == 0) return;
            var item = lvObjectives.SelectedItems[0];
            var objElement = (XElement)item.Tag;
            using (var dialog = new Form())
            {
                dialog.Text = "Edit Objective";
                var txtId = new TextBox { Location = new System.Drawing.Point(20, 20), Width = 200, Text = item.Text };
                var txtDesc = new TextBox { Location = new System.Drawing.Point(20, 50), Width = 200, Text = item.SubItems[1].Text };
                var txtInfoKey = new TextBox { Location = new System.Drawing.Point(20, 80), Width = 200, Text = item.SubItems[2].Text };
                var clbConditions = new CheckedListBox { Location = new System.Drawing.Point(20, 110), Width = 200, Height = 100 };
                clbConditions.Items.AddRange(new[] { "ThingPrefabCondition:StructureSolarPanel:1", "BuildStateCondition:StructureBase:Built" });
                var currentConditions = objElement.Elements().Where(el => el.Name.LocalName != "Description" && el.Name.LocalName != "Info").Select(el => $"{el.Name.LocalName}:{el.Attribute("PrefabName")?.Value}:{el.Attribute("Count")?.Value ?? el.Attribute("State")?.Value}");
                foreach (var cond in currentConditions)
                {
                    int index = clbConditions.Items.IndexOf(cond);
                    if (index >= 0) clbConditions.SetItemChecked(index, true);
                }
                var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(20, 220), DialogResult = DialogResult.OK };
                dialog.Controls.AddRange(new Control[] {
                    new Label { Text = "Objective ID:", Location = new System.Drawing.Point(0, 20) }, txtId,
                    new Label { Text = "Description:", Location = new System.Drawing.Point(0, 50) }, txtDesc,
                    new Label { Text = "Info Key:", Location = new System.Drawing.Point(0, 80) }, txtInfoKey,
                    new Label { Text = "Conditions:", Location = new System.Drawing.Point(0, 110) }, clbConditions, btnOk });
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    item.Text = txtId.Text;
                    item.SubItems[1].Text = txtDesc.Text;
                    item.SubItems[2].Text = txtInfoKey.Text;
                    objElement.SetAttributeValue("Id", txtId.Text);
                    objElement.Element("Description").Value = txtDesc.Text;
                    objElement.Element("Info")?.SetAttributeValue("Key", txtInfoKey.Text);
                    objElement.Elements().Where(el => el.Name.LocalName != "Description" && el.Name.LocalName != "Info").Remove();
                    foreach (var cond in clbConditions.CheckedItems)
                    {
                        var parts = cond.ToString().Split(':');
                        if (parts[0] == "ThingPrefabCondition")
                            objElement.Add(new XElement("ThingPrefabCondition",
                                new XAttribute("PrefabName", parts[1]),
                                new XAttribute("Count", parts[2])));
                        // Add other condition types
                    }
                }
            }
        }

        private void btnDeleteObjective_Click(object sender, EventArgs e)
        {
            if (lvObjectives.SelectedItems.Count == 0) return;
            lvObjectives.Items.Remove(lvObjectives.SelectedItems[0]);
        }

        private void btnSaveWorldSettings_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(newModPath))
            {
                MessageBox.Show("No mod created.");
                return;
            }
            var settings = worldDoc.Root;
            settings.Element("World")?.Remove();
            settings.Add(new XElement("World",
                new XAttribute("Id", txtWorldId.Text),
                new XAttribute("Priority", txtPriority.Text),
                new XAttribute("Hidden", chkHidden.Checked.ToString().ToLower())
            ));
            if (settings.Element("Name") != null) settings.Element("Name").Remove();
            settings.Add(new XElement("Name", txtName.Text));
            if (settings.Element("Description") != null) settings.Element("Description").Remove();
            settings.Add(new XElement("Description", new XAttribute("Key", txtDescription.Text)));
            if (settings.Element("ShortDescription") != null) settings.Element("ShortDescription").Remove();
            settings.Add(new XElement("ShortDescription", new XAttribute("Key", txtShortDesc.Text)));
            if (settings.Element("SummaryText") != null) settings.Element("SummaryText").Remove();
            settings.Add(new XElement("SummaryText", new XAttribute("Key", txtSummary.Text)));

            settings.Element("StartConditions")?.Remove();
            var startConditions = new XElement("StartConditions");
            foreach (var item in clbStartConditions.CheckedItems)
            {
                startConditions.Add(new XElement("StartCondition", new XAttribute("Id", item.ToString())));
            }
            settings.Add(startConditions);

            settings.Elements("startlocation").Remove();
            foreach (ListViewItem item in lvStartLocations.Items)
            {
                settings.Add((XElement)item.Tag);
            }

            worldDoc.Save(worldXmlPath);
            AppendLog($"Saved world settings to {worldXmlPath}");

            objectivesDoc.Root?.Elements("WorldObjective").Remove();
            foreach (ListViewItem item in lvObjectives.Items)
            {
                objectivesDoc.Root?.Add((XElement)item.Tag);
            }
            objectivesDoc.Save(objectivesPath);
            AppendLog($"Saved objectives to {objectivesPath}");

            string aboutXmlPath = Path.Combine(newModPath, "About", "About.xml");
            if (File.Exists(aboutXmlPath))
            {
                try
                {
                    var aboutDoc = XDocument.Load(aboutXmlPath);
                    var modElement = aboutDoc.Root?.Element("Mod");
                    if (modElement != null)
                    {
                        var nameElement = modElement.Element("Name");
                        if (nameElement != null)
                            nameElement.Value = txtName.Text;
                        else
                            modElement.Add(new XElement("Name", txtName.Text));
                        var descElement = modElement.Element("Description");
                        if (descElement != null && !string.IsNullOrEmpty(description))
                            descElement.Value = description;
                        else if (!string.IsNullOrEmpty(description))
                            modElement.Add(new XElement("Description", description));
                        aboutDoc.Save(aboutXmlPath);
                        AppendLog($"Updated {aboutXmlPath} with Name and Description");
                    }
                }
                catch (Exception ex)
                {
                    AppendLog($"Failed to update About.xml: {ex.Message}");
                }
            }

            string languageFolder = Path.Combine(newModPath, "GameData", "Language");
            if (Directory.Exists(languageFolder))
            {
                var languageFiles = Directory.GetFiles(languageFolder, "*.xml").Where(f =>
                {
                    try
                    {
                        var doc = XDocument.Load(f);
                        return doc.Root?.Element("Interface") != null;
                    }
                    catch
                    {
                        return false;
                    }
                }).ToList();
                foreach (var langFile in languageFiles)
                {
                    try
                    {
                        var langDoc = XDocument.Load(langFile);
                        var interfaceElement = langDoc.Root?.Element("Interface");
                        if (interfaceElement != null)
                        {
                            var worldNameEntry = interfaceElement.Elements("Record").FirstOrDefault(r => r.Element("Key")?.Value == txtWorldId.Text);
                            if (worldNameEntry != null)
                                worldNameEntry.SetElementValue("Value", txtName.Text);
                            else
                                interfaceElement.Add(new XElement("Record",
                                    new XElement("Key", txtWorldId.Text),
                                    new XElement("Value", txtName.Text)
                                ));

                            var descEntry = interfaceElement.Elements("Record").FirstOrDefault(r => r.Element("Key")?.Value == txtDescription.Text);
                            if (descEntry != null)
                                descEntry.SetElementValue("Value", description);
                            else if (!string.IsNullOrEmpty(description))
                                interfaceElement.Add(new XElement("Record",
                                    new XElement("Key", txtDescription.Text),
                                    new XElement("Value", description)
                                ));

                            var shortDescEntry = interfaceElement.Elements("Record").FirstOrDefault(r => r.Element("Key")?.Value == txtShortDesc.Text);
                            if (shortDescEntry != null)
                                shortDescEntry.SetElementValue("Value", summary);
                            else if (!string.IsNullOrEmpty(summary))
                                interfaceElement.Add(new XElement("Record",
                                    new XElement("Key", txtShortDesc.Text),
                                    new XElement("Value", summary)
                                ));

                            var summaryEntry = interfaceElement.Elements("Record").FirstOrDefault(r => r.Element("Key")?.Value == txtSummary.Text);
                            if (summaryEntry != null)
                                summaryEntry.SetElementValue("Value", summary);
                            else if (!string.IsNullOrEmpty(summary))
                                interfaceElement.Add(new XElement("Record",
                                    new XElement("Key", txtSummary.Text),
                                    new XElement("Value", summary)
                                ));

                            langDoc.Save(langFile);
                            AppendLog($"Updated language file {langFile} with WorldName, Description, ShortDescription, Summary");
                        }
                    }
                    catch (Exception ex)
                    {
                        AppendLog($"Failed to update {langFile}: {ex.Message}");
                    }
                }
            }
        }

        private void btnRunXsdGenerator_Click(object sender, EventArgs e)
        {
            try
            {
                string generatorPath = Path.Combine(Application.StartupPath, "StationeersXsdGenerator.exe");
                if (!File.Exists(generatorPath))
                {
                    AppendLog("XSD generator not found.");
                    return;
                }
                string assemblyPath = Path.Combine(stationeersPath ?? @"C:\Program Files (x86)\Steam\steamapps\common\Stationeers", "rocketstation.exe");
                Process.Start(generatorPath, $"--assembly \"{assemblyPath}\" --output \"{outputPath}\"");
                AppendLog("Running XSD generator...");
            }
            catch (Exception ex)
            {
                AppendLog($"Error running XSD generator: {ex.Message}");
            }
        }
    }

}