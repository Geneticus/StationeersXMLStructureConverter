using StationeersSpawnXML;
using StationeersStructureXMLConverter;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using WinForms = System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace StationeersStructureXMLConverter
{
    public partial class Main_Form : Form
    {
        private XDocument worldDoc;
        private string worldXmlPath;
        private XDocument objectivesDoc;
        private string objectivesPath;
        private string newModPath;
        private string _originalTitle;

        public Main_Form()
        {
            InitializeComponent();
            conversionUserControl.chkCheckAll_CheckedChanged += chkCheckAll_CheckedChanged;
            conversionUserControl.CheckBox_CheckedChanged += Filter_CheckedChanged;
            conversionUserControl.Convert_Click += Convert_Click;
            conversionUserControl.CheckBox_CheckedChanged += CheckBox_CheckedChanged;
            conversionUserControl.WorldSelection_ComboBox_SelectedIndexChanged += WorldSelection_ComboBox_SelectedIndexChanged;
            worldEditorUserControl.ConversionUserControl = conversionUserControl;
            toolsUserControl.ConversionUserControl = conversionUserControl;
            conversionUserControl.StationeersPath = worldEditorUserControl.StationeersPath = toolsUserControl.StationeersPath = conversionUserControl.StationeersPath;
            conversionUserControl.OutputPath = toolsUserControl.OutputPath = conversionUserControl.OutputPath;
            conversionUserControl.SpawnID = conversionUserControl.SpawnID;
            conversionUserControl.ModName = worldEditorUserControl.ModName = conversionUserControl.ModName;
            conversionUserControl.WorldName = worldEditorUserControl.WorldName = conversionUserControl.WorldName;
            conversionUserControl.Description = worldEditorUserControl.Description = conversionUserControl.Description;
            conversionUserControl.Summary = worldEditorUserControl.Summary = conversionUserControl.Summary;
            worldEditorUserControl.WorldDoc = worldDoc;
            worldEditorUserControl.WorldXmlPath = worldXmlPath;
            worldEditorUserControl.ObjectivesDoc = objectivesDoc;
            worldEditorUserControl.ObjectivesPath = objectivesPath;
            worldEditorUserControl.NewModPath = newModPath;
            conversionUserControl.WorldSelectionItems.Add("Select a world...");
            conversionUserControl.WorldSelectionIndex = 0; 
            conversionUserControl.WorldSelectionEnabled = false;
            //this.AutoScaleMode = AutoScaleMode.Dpi;
            _originalTitle = this.Text;
            // === DPI DEBUG IN TITLE BAR ===
            this.Load += (s, e) => UpdateDebugTitle();
            this.DpiChanged += (s, e) => UpdateDebugTitle();
            this.SizeChanged += (s, e) => UpdateDebugTitle(); 
            
        }
        private Size _originalSize;

        

        private void UpdateDebugTitle()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                float scale = this.CurrentAutoScaleDimensions.Width / 96f;
                string debugInfo = $"[DPI: {this.DeviceDpi} ({(this.DeviceDpi / 96.0 * 100):F0}%) | Scale: {scale:F2}x | Size: {this.ClientSize.Width}x{this.ClientSize.Height}]";
                this.Text = _originalTitle + " " + debugInfo;
            }
            else
            {
                this.Text = _originalTitle;
            }
        }        

        private void Convert_Click(object sender, EventArgs e)
        {
            string worldFolder = "";
            string destWorldPath = "";
            string newModPath = "";
            conversionUserControl.AppendLog("----------------");
            conversionUserControl.AppendLog($"Save File: {conversionUserControl.InputPath}");
            string destPath = conversionUserControl.NoneChecked ? Path.Combine(conversionUserControl.OutputPath ?? "", "SpawnGroup.xml") : null;
            conversionUserControl.AppendLog($"Destination File: {destPath ?? "To be determined from world selection"}");
            conversionUserControl.AppendLog($"Output options: {(conversionUserControl.NoneChecked ? "None" : conversionUserControl.VanillaWorldChecked ? "Vanilla" : conversionUserControl.LocalModChecked ? "LocalMod" : "None")}");
            conversionUserControl.AppendLog("----------------");
            conversionUserControl.LogTextBox.Text = "";
            conversionUserControl.AppendLog("Reading Save File... (Step 1 of 6)");
            if (string.IsNullOrEmpty(conversionUserControl.InputPath) || !File.Exists(conversionUserControl.InputPath))
            {
                conversionUserControl.AppendLog("Invalid source .save file path: " + conversionUserControl.InputPath);
                return;
            }
            if (conversionUserControl.NoneChecked && string.IsNullOrEmpty(conversionUserControl.OutputPath))
            {
                conversionUserControl.AppendLog("No output folder selected for SpawnGroup.xml.");
                return;
            }
            if ((conversionUserControl.VanillaWorldChecked || conversionUserControl.LocalModChecked) && conversionUserControl.WorldSelectionIndex <= 0)
            {
                conversionUserControl.AppendLog("No world selected in WorldSelection_ComboBox. Please select a world.");
                return;
            }
            if (conversionUserControl.VanillaWorldChecked || conversionUserControl.LocalModChecked)
            {
                string selectedWorld = conversionUserControl.SelectedWorld;
                if (string.IsNullOrEmpty(selectedWorld) || selectedWorld == "Select a world...")
                {
                    conversionUserControl.AppendLog("Invalid world selection. Please select a valid world.");
                    return;
                }
                if (conversionUserControl.VanillaWorldChecked && conversionUserControl.StationeersPath != null)
                {
                    destPath = Path.Combine(conversionUserControl.StationeersPath, "rocketstation_Data", "StreamingAssets", "Worlds", selectedWorld, "SpawnGroup.xml");
                }
                else if (conversionUserControl.LocalModChecked)
                {
                    string basePath = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers");
                    destPath = Path.Combine(basePath, "mods", selectedWorld, "SpawnGroup.xml");
                }
                if (!Directory.Exists(Path.GetDirectoryName(destPath)))
                {
                    conversionUserControl.AppendLog($"Selected world folder not found: {Path.GetDirectoryName(destPath)}");
                    return;
                }
            }
            string directory = Path.GetDirectoryName(destPath);
            conversionUserControl.AppendLog($"Creating directory: {directory}");
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }
            conversionUserControl.AppendLog("Examining Data... (Step 2 of 6)");
            try
            {
                XDocument doc;
                using (ZipArchive archive = ZipFile.OpenRead(conversionUserControl.InputPath))
                {
                    ZipArchiveEntry entry = archive.GetEntry("world.xml");
                    if (entry == null)
                    {
                        conversionUserControl.AppendLog("No 'world.xml' found in the .save archive.");
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
                    conversionUserControl.AppendLog("No root <WorldData> found.");
                    return;
                }
                var allThingsNode = root.Element("AllThings");
                if (allThingsNode == null)
                {
                    conversionUserControl.AppendLog("No <AllThings> found.");
                    return;
                }
                var thingElements = allThingsNode.Elements("ThingSaveData").ToList();
                if (thingElements.Count == 0)
                {
                    conversionUserControl.AppendLog("Warning: No <ThingSaveData> elements found.");
                    return;
                }
                var things = new List<object>();
                foreach (var element in thingElements)
                {
                    things.Add(element);
                }
                int thingCount = thingElements.Count;
                conversionUserControl.AppendLog($"Found {thingCount} of Things to extract... (Step 3 of 6)");
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    var uniquePrefabNames = thingElements
                        .Select(t => t.Element("PrefabName")?.Value ?? "Unknown")
                        .Distinct()
                        .ToList();
                    conversionUserControl.AppendLog("Items Found:");
                    foreach (var prefab in uniquePrefabNames)
                    {
                        conversionUserControl.AppendLog(prefab);
                    }
                    conversionUserControl.AppendLog("");
                }
                conversionUserControl.AppendLog($"Extracted {things.Count} Things... (Step 4 of 6)");
                conversionUserControl.AppendLog("Transforming Things to Spawn Items... (Step 5 of 6)");
                var spawnEntries = SourceExtraction.ExtractSpawnEntries(things, conversionUserControl.LogTextBox, doc);
                if ((conversionUserControl.VanillaWorldChecked || conversionUserControl.LocalModChecked) && conversionUserControl.WorldSelectionIndex > 0 && string.IsNullOrEmpty(conversionUserControl.ModName))
                {
                    conversionUserControl.AppendLog("Error: Mod name is not set. Please configure file outputs.");
                    return;
                }
                string destSpawnGroupPath = null;
                if (!string.IsNullOrEmpty(conversionUserControl.ModName))
                {
                    conversionUserControl.AppendLog("Creating new mod... (Step 6 of 7)");
                    string modsBasePath = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers\\mods");
                    newModPath = Path.Combine(modsBasePath, conversionUserControl.ModName);
                    try
                    {
                        string exampleModZip = Path.Combine(conversionUserControl.StationeersPath ?? @"C:\Program Files (x86)\Steam\steamapps\common\Stationeers", "rocketstation_Data", "StreamingAssets", "ExampleMod.zip");
                        if (!File.Exists(exampleModZip))
                        {
                            conversionUserControl.AppendLog($"Error: ExampleMod.zip not found at {exampleModZip}.");
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
                        conversionUserControl.AppendLog($"Extracted About/ from ExampleMod.zip to temp: {tempExtractPath}");
                        string selectedWorld = conversionUserControl.SelectedWorld;
                        string sourceWorldPath;
                        bool overwriteFiles = true;
                        if (conversionUserControl.VanillaWorldChecked && conversionUserControl.StationeersPath != null)
                        {
                            sourceWorldPath = Path.Combine(conversionUserControl.StationeersPath, "rocketstation_Data", "StreamingAssets", "Worlds", selectedWorld);
                            destWorldPath = Path.Combine(newModPath, "GameData", "Worlds", selectedWorld);
                            overwriteFiles = false;
                        }
                        else
                        {
                            sourceWorldPath = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers"), "mods", selectedWorld);
                            destWorldPath = newModPath;
                        }
                        if (!Directory.Exists(sourceWorldPath))
                        {
                            conversionUserControl.AppendLog($"Error: Source world folder not found at {sourceWorldPath}.");
                            return;
                        }
                        DirectoryCopy(sourceWorldPath, destWorldPath, true, overwriteFiles);
                        conversionUserControl.AppendLog($"Copied source from {sourceWorldPath} to {destWorldPath}");
                        string sourceLanguagePath = Path.Combine(newModPath, "Language");
                        string destLanguagePath = Path.Combine(newModPath, "GameData", "Language");
                        if (Directory.Exists(sourceLanguagePath))
                        {
                            if (!Directory.Exists(destLanguagePath))
                            {
                                Directory.CreateDirectory(destLanguagePath);
                            }
                            DirectoryCopy(sourceLanguagePath, destLanguagePath, true, true);
                            Directory.Delete(sourceLanguagePath, true);
                            conversionUserControl.AppendLog("Moved root Language/ to GameData/Language/ for standard mod structure.");
                        }
                        else
                        {
                            conversionUserControl.AppendLog("No root Language/ found in source; assuming already in GameData/ or not present (non-critical).");
                        }
                        string cleanAboutPath = Path.Combine(tempExtractPath, "About");
                        if (Directory.Exists(cleanAboutPath))
                        {
                            string destAboutPath = Path.Combine(newModPath, "About");
                            Directory.CreateDirectory(destAboutPath);
                            DirectoryCopy(cleanAboutPath, destAboutPath, true, true);
                            conversionUserControl.AppendLog("Overwrote About/ with clean version from ExampleMod to prevent Workshop ID conflicts.");
                        }
                        else
                        {
                            conversionUserControl.AppendLog("Warning: No About/ found in ExampleMod extract; no overwrite applied.");
                        }
                        Directory.Delete(tempExtractPath, true);
                        string destGameDataPath = Path.Combine(newModPath, "GameData");
                        destSpawnGroupPath = Path.Combine(destGameDataPath, "SpawnGroup.xml");
                        Directory.CreateDirectory(destGameDataPath);
                    }
                    catch (Exception ex)
                    {
                        conversionUserControl.AppendLog($"Error during mod setup: {ex.Message}");
                        conversionUserControl.AppendLog($"Inner: {ex.InnerException?.Message ?? "N/A"}");
                        conversionUserControl.AppendLog($"Stack: {ex.StackTrace}");
                        return;
                    }
                }
                else if (conversionUserControl.NoneChecked)
                {
                    destSpawnGroupPath = Path.Combine(conversionUserControl.OutputPath ?? "", "SpawnGroup.xml");
                    Directory.CreateDirectory(Path.GetDirectoryName(destSpawnGroupPath));
                }
                else
                {
                    conversionUserControl.AppendLog("Error: No output destination set (world or folder not selected).");
                    return;
                }
                //DestinationExport.TransformToNewSchema(things, destSpawnGroupPath, conversionUserControl.LogTextBox, conversionUserControl);

                if (!File.Exists(destSpawnGroupPath))
                {
                    conversionUserControl.AppendLog($"Error: Failed to create '{destSpawnGroupPath}'. Check permissions or path.");
                    return;
                }
                if (!string.IsNullOrEmpty(conversionUserControl.ModName))
                {
                    string selectedWorld = conversionUserControl.SelectedWorld;
                    if (string.IsNullOrEmpty(selectedWorld) || selectedWorld == "Select a world...")
                    {
                        conversionUserControl.AppendLog("Error: Invalid world selection for mod creation.");
                        return;
                    }
                    worldFolder = Path.Combine(newModPath, "GameData", "Worlds", selectedWorld);
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
                        conversionUserControl.AppendLog($"Error: No WorldSettingData XML with <World> found in {worldFolder}.");
                        return;
                    }
                    worldXmlPath = worldXmlFiles.First();
                    worldDoc = XDocument.Load(worldXmlPath);
                    var worldSettings = worldDoc.Root;
                    if (worldSettings == null)
                    {
                        conversionUserControl.AppendLog($"Error: Invalid WorldSettingData in {worldXmlPath}.");
                        return;
                    }
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
                    var worldElement = worldSettings.Element("World");
                    if (worldElement != null)
                    {
                        worldElement.SetAttributeValue("Id", string.IsNullOrEmpty(conversionUserControl.WorldName) ? $"{conversionUserControl.ModName}_World" : conversionUserControl.WorldName);
                    }
                    else
                    {
                        worldSettings.Add(new XElement("World",
                            new XAttribute("Id", string.IsNullOrEmpty(conversionUserControl.WorldName) ? $"{conversionUserControl.ModName}_World" : conversionUserControl.WorldName)
                        ));
                    }
                    if (!string.IsNullOrEmpty(conversionUserControl.Description))
                    {
                        var descriptionElement = worldSettings.Element("Description");
                        if (descriptionElement != null)
                        {
                            descriptionElement.SetAttributeValue("Key", $"{conversionUserControl.ModName}_Description");
                        }
                        else
                        {
                            worldSettings.Add(new XElement("Description", new XAttribute("Key", $"{conversionUserControl.ModName}_Description")));
                        }
                    }
                    if (!string.IsNullOrEmpty(conversionUserControl.Summary))
                    {
                        var summaryElement = worldSettings.Element("SummaryText");
                        if (summaryElement != null)
                        {
                            summaryElement.SetAttributeValue("Key", $"{conversionUserControl.ModName}_Summary");
                        }
                        else
                        {
                            worldSettings.Add(new XElement("SummaryText", new XAttribute("Key", $"{conversionUserControl.ModName}_Summary")));
                        }
                    }
                    worldDoc.Save(worldXmlPath);
                    conversionUserControl.AppendLog($"Updated {worldXmlPath} with Spawn reference and World Id: {(string.IsNullOrEmpty(conversionUserControl.WorldName) ? $"{conversionUserControl.ModName}_World" : conversionUserControl.WorldName)}");
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
                                        var worldNameEntry = interfaceElement.Elements("Record").FirstOrDefault(r => r.Element("Key")?.Value == $"{conversionUserControl.ModName}_World");
                                        if (worldNameEntry != null)
                                        {
                                            worldNameEntry.SetElementValue("Value", string.IsNullOrEmpty(conversionUserControl.WorldName) ? conversionUserControl.ModName : conversionUserControl.WorldName);
                                        }
                                        else
                                        {
                                            interfaceElement.Add(new XElement("Record",
                                                new XElement("Key", $"{conversionUserControl.ModName}_World"),
                                                new XElement("Value", string.IsNullOrEmpty(conversionUserControl.WorldName) ? conversionUserControl.ModName : conversionUserControl.WorldName)
                                            ));
                                        }
                                        if (!string.IsNullOrEmpty(conversionUserControl.Description))
                                        {
                                            var descEntry = interfaceElement.Elements("Record").FirstOrDefault(r => r.Element("Key")?.Value == $"{conversionUserControl.ModName}_Description");
                                            if (descEntry != null)
                                            {
                                                descEntry.SetElementValue("Value", conversionUserControl.Description);
                                            }
                                            else
                                            {
                                                interfaceElement.Add(new XElement("Record",
                                                    new XElement("Key", $"{conversionUserControl.ModName}_Description"),
                                                    new XElement("Value", conversionUserControl.Description)
                                                ));
                                            }
                                        }
                                        if (!string.IsNullOrEmpty(conversionUserControl.Summary))
                                        {
                                            var summaryEntry = interfaceElement.Elements("Record").FirstOrDefault(r => r.Element("Key")?.Value == $"{conversionUserControl.ModName}_Summary");
                                            if (summaryEntry != null)
                                            {
                                                summaryEntry.SetElementValue("Value", conversionUserControl.Summary);
                                            }
                                            else
                                            {
                                                interfaceElement.Add(new XElement("Record",
                                                    new XElement("Key", $"{conversionUserControl.ModName}_Summary"),
                                                    new XElement("Value", conversionUserControl.Summary)
                                                ));
                                            }
                                        }
                                        langDoc.Save(langFile);
                                        conversionUserControl.AppendLog($"Updated language file {langFile} with WorldName, Description, and Summary");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    conversionUserControl.AppendLog($"Warning: Failed to update language file {langFile}: {ex.Message} (non-critical, continuing)");
                                }
                            }
                        }
                        else
                        {
                            conversionUserControl.AppendLog("No valid language files found in GameData/Language/ (non-critical, skipping updates)");
                        }
                    }
                    else
                    {
                        conversionUserControl.AppendLog("No GameData/Language/ folder found (non-critical, skipping language updates)");
                    }
                    conversionUserControl.AppendLog("Mod creation completed successfully! (Step 7 of 7)");
                    worldEditorUserControl.WorldDoc = worldDoc;
                    worldEditorUserControl.WorldXmlPath = worldXmlPath;
                    worldEditorUserControl.ObjectivesDoc = objectivesDoc;
                    worldEditorUserControl.ObjectivesPath = objectivesPath;
                    worldEditorUserControl.NewModPath = newModPath;
                    worldEditorUserControl.ModName = conversionUserControl.ModName;
                    worldEditorUserControl.WorldName = conversionUserControl.WorldName;
                    worldEditorUserControl.Description = conversionUserControl.Description;
                    worldEditorUserControl.Summary = conversionUserControl.Summary;
                    worldEditorUserControl.LoadWorldSettings();
                    tabControlMain.SelectedTab = tabWorldEditor;
                }
                else
                {
                    destSpawnGroupPath = Path.Combine(conversionUserControl.OutputPath ?? "", "SpawnGroup.xml");
                    Directory.CreateDirectory(Path.GetDirectoryName(destSpawnGroupPath));
                    DestinationExport.TransformToNewSchema(spawnEntries.Cast<object>().ToList(), destSpawnGroupPath, conversionUserControl.LogTextBox, conversionUserControl);
                    conversionUserControl.AppendLog("Conversion completed successfully! (Step 6 of 6)");
                    tabControlMain.SelectedTab = tabConversion;
                }
            }
            catch (Exception ex)
            {
                conversionUserControl.AppendLog($"Error: {ex.Message}");
                conversionUserControl.AppendLog($"Inner: {ex.InnerException?.Message ?? "N/A\r\n"}");
                conversionUserControl.AppendLog($"Stack: {ex.StackTrace}");
            }
        }


        private bool _ignoreCheckAllChange = false;

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (_ignoreCheckAllChange) return;

            bool check = conversionUserControl.CheckAll;
            conversionUserControl.FilterLanderCapsule = check;
            conversionUserControl.FilterCharacter = check;
            conversionUserControl.FilterSupplyLander = check;
            conversionUserControl.FilterOre = check;
            conversionUserControl.FilterItemKit = check;
        }

        private void Filter_CheckedChanged(object sender, EventArgs e)
        {
            bool allChecked = conversionUserControl.FilterLanderCapsule &&
                              conversionUserControl.FilterCharacter &&
                              conversionUserControl.FilterSupplyLander &&
                              conversionUserControl.FilterOre &&
                              conversionUserControl.FilterItemKit;

            _ignoreCheckAllChange = true;
            conversionUserControl.CheckAll = allChecked;
            _ignoreCheckAllChange = false;
        }



        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox changedBox = (System.Windows.Forms.CheckBox)sender;
            if (changedBox == conversionUserControl.VanillaWorldCheckBox)
            {
                conversionUserControl.LocalModChecked = false;
                conversionUserControl.NoneChecked = false;
                if (changedBox.Checked && conversionUserControl.StationeersPath == null)
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
                            conversionUserControl.StationeersPath = defaultPath;
                            worldEditorUserControl.StationeersPath = defaultPath;
                            toolsUserControl.StationeersPath = defaultPath;
                            conversionUserControl.AppendLog($"Stationeers path set to: {defaultPath}");
                        }
                        else
                        {
                            SetStationeersPath();
                            if (conversionUserControl.StationeersPath == null)
                            {
                                conversionUserControl.VanillaWorldChecked = false;
                                conversionUserControl.VanillaWorldCheckBox.Enabled = true;
                                conversionUserControl.ConfigureOutputsEnabled = false;
                                return;
                            }
                        }
                    }
                    else
                    {
                        SetStationeersPath();
                        if (conversionUserControl.StationeersPath == null)
                        {
                            conversionUserControl.VanillaWorldChecked = false;
                            conversionUserControl.VanillaWorldCheckBox.Enabled = true;
                            conversionUserControl.ConfigureOutputsEnabled = false;
                            return;
                        }
                    }
                }
            }
            else if (changedBox == conversionUserControl.LocalModCheckBox)
            {
                conversionUserControl.VanillaWorldChecked = false;
                conversionUserControl.NoneChecked = false;
            }
            else if (changedBox == conversionUserControl.NoneCheckBox)
            {
                conversionUserControl.VanillaWorldChecked = false;
                conversionUserControl.LocalModChecked = false;
                if (changedBox.Checked)
                {
                    using (OpenFileDialog folderDialog = new OpenFileDialog())
                    {
                        folderDialog.ValidateNames = false;
                        folderDialog.CheckFileExists = false;
                        folderDialog.CheckPathExists = true;
                        folderDialog.FileName = "Select Folder";
                        folderDialog.Filter = "Folders|*.*";
                        folderDialog.InitialDirectory = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers\\mods");
                        folderDialog.Title = "Select folder for the transformed SpawnGroup.xml";
                        if (folderDialog.ShowDialog() == DialogResult.OK)
                        {
                            conversionUserControl.OutputPath = Path.GetDirectoryName(folderDialog.FileName);
                            toolsUserControl.OutputPath = conversionUserControl.OutputPath;
                            conversionUserControl.AppendLog($"Output folder for SpawnGroup.xml set to: {conversionUserControl.OutputPath}");
                        }
                        else
                        {
                            conversionUserControl.OutputPath = null;
                            toolsUserControl.OutputPath = null;
                            conversionUserControl.AppendLog("No output folder selected for SpawnGroup.xml.");
                        }
                    }
                }
                else
                {
                    conversionUserControl.OutputPath = null;
                    toolsUserControl.OutputPath = null;
                }
            }
            if (conversionUserControl.VanillaWorldChecked || conversionUserControl.LocalModChecked)
            {
                if (!conversionUserControl.WorldSelectionItems.Contains("Select a world..."))
                {
                    conversionUserControl.WorldSelectionItems.Add("Select a world...");
                }
                conversionUserControl.WorldSelectionIndex = 0;
                conversionUserControl.WorldSelectionEnabled = true;
                conversionUserControl.PopulateWorldDropdown();
                VerifySelectedWorld();
                conversionUserControl.ConfigureOutputsEnabled = conversionUserControl.WorldSelectionIndex > 0;
            }
            else
            {
                conversionUserControl.WorldSelectionItems.Clear();
                conversionUserControl.WorldSelectionItems.Add("Select a world...");
                conversionUserControl.WorldSelectionIndex = 0;
                conversionUserControl.WorldSelectionEnabled = false;
                conversionUserControl.ConfigureOutputsEnabled = false;
            }
            conversionUserControl.VanillaWorldCheckBox.Enabled = true;
            conversionUserControl.Label1.Enabled = true;
            conversionUserControl.InputPathEnabled = true;
        }

        private void WorldSelection_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            conversionUserControl.ConfigureOutputsEnabled = conversionUserControl.WorldSelectionIndex > 0;
            VerifySelectedWorld();
        }

        private void SetStationeersPath()
        {
            using (OpenFileDialog folderDialog = new OpenFileDialog())
            {
                folderDialog.ValidateNames = false;
                folderDialog.CheckFileExists = false;
                folderDialog.CheckPathExists = true;
                folderDialog.FileName = "Select Folder";
                folderDialog.Filter = "Folders|*.*";
                folderDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                folderDialog.Title = "Select the Stationeers installation folder (containing 'rocketstation_Data')";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = Path.GetDirectoryName(folderDialog.FileName);
                    if (Directory.Exists(Path.Combine(selectedPath, "rocketstation_Data", "StreamingAssets", "Worlds")))
                    {
                        conversionUserControl.StationeersPath = selectedPath;
                        worldEditorUserControl.StationeersPath = selectedPath;
                        toolsUserControl.StationeersPath = selectedPath;
                        conversionUserControl.AppendLog($"Stationeers path set to: {selectedPath}");
                    }
                    else
                    {
                        MessageBox.Show("The selected folder does not contain a valid Stationeers installation. Please select the folder containing 'rocketstation_Data'.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conversionUserControl.StationeersPath = null;
                        worldEditorUserControl.StationeersPath = null;
                        toolsUserControl.StationeersPath = null;
                        conversionUserControl.AppendLog("Invalid Stationeers path selected. Please try again.");
                    }
                }
                else
                {
                    conversionUserControl.AppendLog("No Stationeers path selected. Vanilla world selection remains available.");
                }
            }
        }

        private List<object> GetThingSaveDataList(WorldData worldData)
        {
            var things = new List<object>();
            conversionUserControl.AppendLog("Direct extraction for WorldData (matches log properties; robust to nulls)");
            var thingsProp = worldData.GetType().GetProperty("AllThings") ?? worldData.GetType().GetProperty("Things");
            if (thingsProp == null)
            {
                conversionUserControl.AppendLog("No AllThings/Things array found on WorldData.\n");
                return things;
            }
            var thingArray = (Array)thingsProp.GetValue(worldData);
            if (thingArray == null)
            {
                conversionUserControl.AppendLog($"{thingsProp.Name} array is null (blank template?).\n");
                return things;
            }
            conversionUserControl.AppendLog($"Found {thingsProp.Name} array on WorldData (length: {thingArray.Length}, type: {thingArray.GetType().GetElementType().Name}).\n");
            if (thingArray.Length == 0)
            {
                conversionUserControl.AppendLog($"{thingsProp.Name} array is empty—no structures in save.\n");
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
                    conversionUserControl.AppendLog($"Skipped non-SaveData item [{i}]: {item?.GetType().Name}\n");
                }
            }
            conversionUserControl.AppendLog($"Added {itemCount} valid SaveData items.\n");
            return things;
        }

        private void VerifySelectedWorld()
        {
            if (conversionUserControl.WorldSelectionIndex > 0 && !conversionUserControl.NoneChecked)
            {
                string selectedFolder = conversionUserControl.SelectedWorld;
            }
        }

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs, bool excludeAboutXml)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            if (!dir.Exists)
            {
                conversionUserControl.AppendLog($"Error: Source directory does not exist: {sourceDirName}");
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


    }
}