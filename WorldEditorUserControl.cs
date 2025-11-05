using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace StationeersStructureXMLConverter
{
    public partial class WorldEditorUserControl : UserControl
    {
        private XDocument worldDoc;
        private string worldXmlPath;
        private XDocument objectivesDoc;
        private string objectivesPath;
        private string newModPath;
        private string modName = "";
        private string worldName = "";
        private string description = "";
        private string summary = "";
        private string stationeersPath;
        private ConversionUserControl conversionUserControl;

        public WorldEditorUserControl()
        {
            InitializeComponent();
            InitializeListViews();
            //this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void InitializeListViews()
        {
            // Configure lvStartLocations
            lvStartLocations.Items.Clear();
            lvStartLocations.Columns.Clear();
            lvStartLocations.Columns.Add("X", 200);
            lvStartLocations.Columns.Add("Y", 200);
            lvStartLocations.Columns.Add("Z", 200);
            lvStartLocations.Columns.Add("Edit", 60);

            // Configure lvObjectives
            lvObjectives.Items.Clear();
            lvObjectives.Columns.Clear();
            lvObjectives.Columns.Add("Id", 250);
            lvObjectives.Columns.Add("Description", 250);
            lvObjectives.Columns.Add("Info Key", 250);
            lvObjectives.Columns.Add("Edit", 60);

            // Enable custom drawing for buttons
            lvStartLocations.OwnerDraw = true;
            lvObjectives.OwnerDraw = true;
            lvStartLocations.DrawSubItem += new DrawListViewSubItemEventHandler(LvStartLocations_DrawSubItem);
            lvObjectives.DrawSubItem += new DrawListViewSubItemEventHandler(LvObjectives_DrawSubItem);
            lvStartLocations.MouseDown += new MouseEventHandler(LvStartLocations_MouseDown);
            lvObjectives.MouseDown += new MouseEventHandler(LvObjectives_MouseDown);
        }

        private void LvStartLocations_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 3) // Edit column
            {
                Rectangle bounds = e.SubItem.Bounds;
                Rectangle buttonBounds = new Rectangle(bounds.X + 5, bounds.Y + 5, 50, 20);
                ButtonRenderer.DrawButton(e.Graphics, buttonBounds, "Edit", SystemFonts.DefaultFont, false, PushButtonState.Normal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void LvObjectives_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 3) // Edit column
            {
                Rectangle bounds = e.SubItem.Bounds;
                Rectangle buttonBounds = new Rectangle(bounds.X + 5, bounds.Y + 5, 50, 20);
                ButtonRenderer.DrawButton(e.Graphics, buttonBounds, "Edit", SystemFonts.DefaultFont, false, PushButtonState.Normal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void LvStartLocations_MouseDown(object sender, MouseEventArgs e)
        {
            var info = lvStartLocations.HitTest(e.Location);
            if (info.SubItem != null && info.Item.SubItems.IndexOf(info.SubItem) == 3)
            {
                btnEditLocation_Click(sender, new EventArgs());
            }
        }

        private void LvObjectives_MouseDown(object sender, MouseEventArgs e)
        {
            var info = lvObjectives.HitTest(e.Location);
            if (info.SubItem != null && info.Item.SubItems.IndexOf(info.SubItem) == 3)
            {
                btnEditObjective_Click(sender, new EventArgs());
            }
        }

        public XDocument WorldDoc
        {
            get => worldDoc;
            set => worldDoc = value;
        }

        public string WorldXmlPath
        {
            get => worldXmlPath;
            set => worldXmlPath = value;
        }

        public XDocument ObjectivesDoc
        {
            get => objectivesDoc;
            set => objectivesDoc = value;
        }

        public string ObjectivesPath
        {
            get => objectivesPath;
            set => objectivesPath = value;
        }

        public string NewModPath
        {
            get => newModPath;
            set => newModPath = value;
        }

        public string ModName
        {
            get => modName;
            set => modName = value;
        }

        public string WorldName
        {
            get => worldName;
            set => worldName = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public string Summary
        {
            get => summary;
            set => summary = value;
        }

        public string StationeersPath
        {
            get => stationeersPath;
            set => stationeersPath = value;
        }

        public ConversionUserControl ConversionUserControl
        {
            get => conversionUserControl;
            set => conversionUserControl = value;
        }

        private List<string> WorldStartConditions = new List<string>();

        private string GetUserLanguageCode()
        {
            string lang = System.Globalization.CultureInfo.CurrentUICulture.Name.ToLower();
            // "cs-CZ" → "czech", "de-DE" → "german", etc.
            return lang.Split('-')[0];
        }

        private string GetLanguageFileName(string code)
        {
            // Common mappings
            var map = new Dictionary<string, string>
    {
        { "en", "english" },
        { "cs", "czech" },
        { "de", "german" },
        { "fr", "french" },
        { "it", "italian" },
        { "hu", "hungarian" },
        { "da", "danish" },
        { "nl", "dutch" }
        // Add more as needed
    };

            return map.TryGetValue(code, out var name) ? name : null;
        }

        private string DetectStationeersPath()
        {
            // 1. Try default path
            string defaultPath = @"C:\Program Files (x86)\Steam\steamapps\common\Stationeers";
            string exePath = Path.Combine(defaultPath, "rocketstation.exe");

            if (File.Exists(exePath))
            {
                return defaultPath;
            }

            // 2. If not found, prompt user
            using (var dialog = new OpenFileDialog())
            {
                dialog.ValidateNames = false;
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;
                dialog.FileName = "Select Folder";
                dialog.Filter = "Folders|*.*";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                dialog.Title = "Select Stationeers installation folder (containing 'rocketstation_Data')";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string selected = Path.GetDirectoryName(dialog.FileName);
                    if (Directory.Exists(Path.Combine(selected, "rocketstation_Data", "StreamingAssets", "Worlds")))
                    {
                        return selected;
                    }
                    else
                    {
                        MessageBox.Show("Invalid Stationeers installation. Please select the folder containing 'rocketstation_Data'.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }
                }
            }

            return null;
        }

        private string LoadFromFile(string filePath, string key)
        {
            if (!File.Exists(filePath)) return null;

            try
            {
                var doc = XDocument.Load(filePath);
                var record = doc.Root?.Element("Interface")?
                    .Elements("Record")
                    .FirstOrDefault(r => r.Element("Key")?.Value == key);

                return record?.Element("Value")?.Value ?? "";
            }
            catch { return null; }
        }

        public void LoadWorldSettings()
        {
            // Ensure we have a mod path
            if (string.IsNullOrEmpty(newModPath))
            {
                conversionUserControl.AppendLog("No mod path set.");
                return;
            }

            // === LOAD worldDoc ===
            if (!string.IsNullOrEmpty(worldXmlPath) && File.Exists(worldXmlPath))
            {
                worldDoc = XDocument.Load(worldXmlPath);
            }
            else
            {
                string selectedWorld = conversionUserControl.SelectedWorld;
                if (string.IsNullOrEmpty(selectedWorld) || selectedWorld == "Select a world...")
                {
                    MessageBox.Show("No world selected in conversion tab.");
                    return;
                }

                string worldFolder = Path.Combine(newModPath, "GameData", "Worlds", selectedWorld);
                if (!Directory.Exists(worldFolder))
                {
                    MessageBox.Show($"World folder not found: {worldFolder}");
                    return;
                }

                var worldXmlFiles = Directory.GetFiles(worldFolder, "*.xml")
                    .Where(f =>
                    {
                        try
                        {
                            var doc = XDocument.Load(f);
                            var ws = doc.Root?.Element("WorldSettings");
                            return ws != null && ws.Element("World") != null;
                        }
                        catch { return false; }
                    }).ToList();

                if (!worldXmlFiles.Any())
                {
                    MessageBox.Show("No valid world.xml found in selected world folder.");
                    return;
                }

                worldXmlPath = worldXmlFiles.First();
                worldDoc = XDocument.Load(worldXmlPath);
            }

            // === PARSE WorldSettings and World ===
            var worldSettings = worldDoc.Root?.Element("WorldSettings");
            var world = worldSettings?.Element("World");
            if (world == null)
            {
                conversionUserControl.AppendLog("No <World> element found.");
                return;
            }

            // === POPULATE KEYS ===
            txtNameKey.Text = world.Element("Name")?.Attribute("Key")?.Value ?? "";
            txtDescKey.Text = world.Element("Description")?.Attribute("Key")?.Value ?? "";
            txtShortDescKey.Text = world.Element("ShortDescription")?.Attribute("Key")?.Value ?? "";
            var summaryKey = world.Element("SummaryText")?.Attribute("Key")?.Value ?? "";

            // === LOAD VALUES: MOD → VANILLA → KEY ===
            string GetValueForKey(string key)
            {
                if (string.IsNullOrEmpty(key)) return "";

                string value = null;

                // 1. MOD
                string modLangPath = Path.Combine(newModPath, "GameData", "Language");
                if (Directory.Exists(modLangPath))
                {
                    // Try user language
                    string userLang = GetLanguageFileName(GetUserLanguageCode());
                    if (userLang != null)
                    {
                        value = LoadFromFile(Path.Combine(modLangPath, $"{userLang}.xml"), key);
                    }
                    // Fallback to english in mod
                    if (string.IsNullOrEmpty(value))
                    {
                        value = LoadFromFile(Path.Combine(modLangPath, "english.xml"), key);
                    }
                }

                // 2. VANILLA
                if (string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(StationeersPath))
                {
                    string vanillaLangPath = Path.Combine(StationeersPath, "rocketstation_Data", "StreamingAssets", "Language");
                    if (Directory.Exists(vanillaLangPath))
                    {
                        string userLang = GetLanguageFileName(GetUserLanguageCode());
                        if (userLang != null)
                        {
                            value = LoadFromFile(Path.Combine(vanillaLangPath, $"{userLang}.xml"), key);
                        }
                        if (string.IsNullOrEmpty(value))
                        {
                            value = LoadFromFile(Path.Combine(vanillaLangPath, "english.xml"), key);
                        }
                    }
                }

                return value ?? "";
            }

            txtNameValue.Text = GetValueForKey(txtNameKey.Text);
            txtDescValue.Text = GetValueForKey(txtDescKey.Text);
            txtShortDescValue.Text = GetValueForKey(txtShortDescKey.Text);
            txtSummary.Text = GetValueForKey(summaryKey);

            // === POPULATE WORLD ID & PRIORITY ===
            txtWorldId.Text = world?.Attribute("Id")?.Value
                              ?? (string.IsNullOrEmpty(worldName) ? $"{modName}_World" : worldName);
            nudPriority.Value = int.TryParse(world?.Attribute("Priority")?.Value, out int priority) ? priority : 2;

            // === POPULATE START CONDITIONS (only those in the world file) ===
            clbStartConditions.Items.Clear();
            WorldStartConditions.Clear();

            var worldConditions = world.Elements("StartCondition")
                .Select(e => e.Attribute("Id")?.Value)
                .Where(id => !string.IsNullOrEmpty(id))
                .ToList() ?? new List<string>();

            foreach (var id in worldConditions)
            {
                clbStartConditions.Items.Add(id);
                WorldStartConditions.Add(id);
            }

            // === POPULATE START LOCATIONS ===
            lvStartLocations.Items.Clear();
            foreach (var loc in world.Elements("Startlocation"))
            {
                var pos = loc.Element("Position");
                var item = new ListViewItem(pos?.Element("x")?.Value ?? "0");
                item.SubItems.Add(pos?.Element("y")?.Value ?? "0");
                item.SubItems.Add(pos?.Element("z")?.Value ?? "0");
                item.SubItems.Add("Edit");
                item.Tag = loc;
                lvStartLocations.Items.Add(item);
            }

            // === POPULATE OBJECTIVES ===
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
                    item.SubItems.Add("Edit");
                    item.Tag = obj;
                    lvObjectives.Items.Add(item);
                }
            }
            else
            {
                objectivesDoc = new XDocument(new XElement("WorldObjectivesData"));
            }
        }

        private string SearchLanguageFiles(string folder, string key)
        {
            foreach (var file in Directory.GetFiles(folder, "*.xml"))
            {
                try
                {
                    var doc = XDocument.Load(file);
                    var record = doc.Root?.Element("Interface")?
                        .Elements("Record")
                        .FirstOrDefault(r =>
                            r.Element("Key")?.Value?.Trim() == key.Trim());

                    if (record != null)
                    {
                        return record.Element("Value")?.Value?.Trim() ?? "";
                    }
                }
                catch { }
            }
            return null;
        }

        private void btnBrowseMod_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog folderDialog = new OpenFileDialog())
            {
                folderDialog.ValidateNames = false;
                folderDialog.CheckFileExists = false;
                folderDialog.CheckPathExists = true;
                folderDialog.FileName = "Select Folder";
                folderDialog.Filter = "Folders|*.*";
                folderDialog.InitialDirectory = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers\\mods");
                folderDialog.Title = "Select your world mod's top level Folder";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string modPath = Path.GetDirectoryName(folderDialog.FileName);
                    if (Directory.Exists(modPath))
                    {
                        txtModPath.Text = modPath;
                        newModPath = modPath;
                        if (string.IsNullOrEmpty(StationeersPath))
                        {
                            StationeersPath = DetectStationeersPath();
                            if (!string.IsNullOrEmpty(StationeersPath))
                            {
                                conversionUserControl.AppendLog($"Auto-detected Stationeers path: {StationeersPath}");
                            }
                            else
                            {
                                conversionUserControl.AppendLog("Stationeers path not found. Vanilla text unavailable.");
                            }
                        }
                        LoadWorldFromModPath(modPath);
                    }
                    else
                    {
                        conversionUserControl.AppendLog("Invalid folder selected.");
                    }
                }
            }
        }

        private void LoadWorldFromModPath(string modPath)
        {
            this.newModPath = modPath;
            string gameDataPath = Path.Combine(modPath, "GameData");
            if (!Directory.Exists(gameDataPath))
            {
                conversionUserControl.AppendLog("No GameData folder found.");
                return;
            }

            string worldsPath = Path.Combine(gameDataPath, "Worlds");
            if (!Directory.Exists(worldsPath))
            {
                conversionUserControl.AppendLog("No Worlds folder found.");
                return;
            }

            var worldFiles = Directory.GetFiles(worldsPath, "*.xml", SearchOption.AllDirectories)
                .Where(f =>
                {
                    try
                    {
                        var doc = XDocument.Load(f);
                        var worldSettings = doc.Root?.Element("WorldSettings");
                        return worldSettings != null && worldSettings.Element("World") != null;
                    }
                    catch { return false; }
                }).ToList();

            if (!worldFiles.Any())
            {
                conversionUserControl.AppendLog("No valid world.xml found in mod.");
                return;
            }

            worldXmlPath = worldFiles.First();
            worldDoc = XDocument.Load(worldXmlPath);
            conversionUserControl.AppendLog($"Loaded: {Path.GetFileName(worldXmlPath)}");

            LoadWorldSettings();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            // Simple acknowledgment that button was pressed
            MessageBox.Show("Clear All button pressed.", "Acknowledgment");
        }

        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            using (var picker = new StartConditionPickerForm(newModPath, StationeersPath, WorldStartConditions))
            {
                if (picker.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(picker.SelectedConditionId))
                {
                    string id = picker.SelectedConditionId;
                    if (!clbStartConditions.Items.Contains(id))
                    {
                        clbStartConditions.Items.Add(id);
                        WorldStartConditions.Add(id);
                    }
                }
            }
        }

        private void btnDeleteCondition_Click(object sender, EventArgs e)
        {
            if (clbStartConditions.SelectedIndex >= 0)
            {
                string id = clbStartConditions.SelectedItem.ToString();
                clbStartConditions.Items.RemoveAt(clbStartConditions.SelectedIndex);
                WorldStartConditions.Remove(id);
            }
        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            using (var dialog = new Form())
            {
                dialog.Text = "Add/Edit Start Location";
                dialog.AutoSize = true;
                dialog.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                var txtX = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 100, Text = "0" };
                var txtY = new TextBox { Location = new System.Drawing.Point(120, 50), Width = 100, Text = "0" };
                var txtZ = new TextBox { Location = new System.Drawing.Point(120, 80), Width = 100, Text = "0" };
                var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(120, 110), DialogResult = DialogResult.OK };
                dialog.Controls.AddRange(new Control[] {
                    new Label { Text = "X:", Location = new System.Drawing.Point(20, 20), Width = 80 },
                    txtX,
                    new Label { Text = "Y:", Location = new System.Drawing.Point(20, 50), Width = 80 },
                    txtY,
                    new Label { Text = "Z:", Location = new System.Drawing.Point(20, 80), Width = 80 },
                    txtZ,
                    btnOk
                });
                dialog.MinimumSize = new System.Drawing.Size(300, 200);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var item = new ListViewItem(txtX.Text);
                    item.SubItems.Add(txtY.Text);
                    item.SubItems.Add(txtZ.Text);
                    item.SubItems.Add("Edit");
                    var locElement = new XElement("startlocation", new XElement("Position",
                        new XElement("x", txtX.Text),
                        new XElement("y", txtY.Text),
                        new XElement("z", txtZ.Text)));
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
                dialog.AutoSize = true;
                dialog.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                var txtX = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 100, Text = item.Text };
                var txtY = new TextBox { Location = new System.Drawing.Point(120, 50), Width = 100, Text = item.SubItems[1].Text };
                var txtZ = new TextBox { Location = new System.Drawing.Point(120, 80), Width = 100, Text = item.SubItems[2].Text };
                var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(120, 110), DialogResult = DialogResult.OK };
                dialog.Controls.AddRange(new Control[] {
                    new Label { Text = "X:", Location = new System.Drawing.Point(20, 20), Width = 80 },
                    txtX,
                    new Label { Text = "Y:", Location = new System.Drawing.Point(20, 50), Width = 80 },
                    txtY,
                    new Label { Text = "Z:", Location = new System.Drawing.Point(20, 80), Width = 80 },
                    txtZ,
                    btnOk
                });
                dialog.MinimumSize = new System.Drawing.Size(300, 200);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    item.Text = txtX.Text;
                    item.SubItems[1].Text = txtY.Text;
                    item.SubItems[2].Text = txtZ.Text;
                    item.SubItems[3].Text = "Edit";
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
                dialog.AutoSize = true;
                dialog.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                var txtId = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200, Text = "Objective" + (lvObjectives.Items.Count + 1) };
                var txtDesc = new TextBox { Location = new System.Drawing.Point(120, 50), Width = 200, Text = "" };
                var txtInfoKey = new TextBox { Location = new System.Drawing.Point(120, 80), Width = 200, Text = $"{modName}_Objective{lvObjectives.Items.Count + 1}" };
                var clbConditions = new CheckedListBox { Location = new System.Drawing.Point(120, 110), Width = 200, Height = 100 };
                clbConditions.Items.AddRange(new[] { "ThingPrefabCondition:StructureSolarPanel:1", "BuildStateCondition:StructureBase:Built" });
                var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(120, 220), DialogResult = DialogResult.OK };
                dialog.Controls.AddRange(new Control[] {
                    new Label { Text = "Objective ID:", Location = new System.Drawing.Point(20, 20), Width = 80 },
                    txtId,
                    new Label { Text = "Description:", Location = new System.Drawing.Point(20, 50), Width = 80 },
                    txtDesc,
                    new Label { Text = "Info Key:", Location = new System.Drawing.Point(20, 80), Width = 80 },
                    txtInfoKey,
                    new Label { Text = "Conditions:", Location = new System.Drawing.Point(20, 110), Width = 80 },
                    clbConditions,
                    btnOk
                });
                dialog.MinimumSize = new System.Drawing.Size(350, 300);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var item = new ListViewItem(txtId.Text);
                    item.SubItems.Add(txtDesc.Text);
                    item.SubItems.Add(txtInfoKey.Text);
                    item.SubItems.Add("Edit");
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
                dialog.AutoSize = true;
                dialog.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                var txtId = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200, Text = item.Text };
                var txtDesc = new TextBox { Location = new System.Drawing.Point(120, 50), Width = 200, Text = item.SubItems[1].Text };
                var txtInfoKey = new TextBox { Location = new System.Drawing.Point(120, 80), Width = 200, Text = item.SubItems[2].Text };
                var clbConditions = new CheckedListBox { Location = new System.Drawing.Point(120, 110), Width = 200, Height = 100 };
                clbConditions.Items.AddRange(new[] { "ThingPrefabCondition:StructureSolarPanel:1", "BuildStateCondition:StructureBase:Built" });
                var currentConditions = objElement.Elements().Where(el => el.Name.LocalName != "Description" && el.Name.LocalName != "Info").Select(el => $"{el.Name.LocalName}:{el.Attribute("PrefabName")?.Value}:{el.Attribute("Count")?.Value ?? el.Attribute("State")?.Value}");
                foreach (var cond in currentConditions)
                {
                    int index = clbConditions.Items.IndexOf(cond);
                    if (index >= 0) clbConditions.SetItemChecked(index, true);
                }
                var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(120, 220), DialogResult = DialogResult.OK };
                dialog.Controls.AddRange(new Control[] {
                    new Label { Text = "Objective ID:", Location = new System.Drawing.Point(20, 20), Width = 80 },
                    txtId,
                    new Label { Text = "Description:", Location = new System.Drawing.Point(20, 50), Width = 80 },
                    txtDesc,
                    new Label { Text = "Info Key:", Location = new System.Drawing.Point(20, 80), Width = 80 },
                    txtInfoKey,
                    new Label { Text = "Conditions:", Location = new System.Drawing.Point(20, 110), Width = 80 },
                    clbConditions,
                    btnOk
                });
                dialog.MinimumSize = new System.Drawing.Size(350, 300);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    item.Text = txtId.Text;
                    item.SubItems[1].Text = txtDesc.Text;
                    item.SubItems[2].Text = txtInfoKey.Text;
                    item.SubItems[3].Text = "Edit";
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

            var worldSettings = worldDoc.Root?.Element("WorldSettings");
            if (worldSettings == null)
            {
                conversionUserControl.AppendLog("No <WorldSettings> found.");
                return;
            }

            var world = worldSettings.Element("World");
            if (world == null)
            {
                world = new XElement("World");
                worldSettings.Add(world);
            }
            else
            {
                world.Remove();
                world = new XElement("World");
                worldSettings.Add(world);
            }

            // === Update World attributes ===
            world.SetAttributeValue("Id", txtWorldId.Text);
            world.SetAttributeValue("Priority", nudPriority.Value.ToString());
            world.SetAttributeValue("Hidden", "false");

            // === Update Name, Description, ShortDescription, SummaryText ===
            world.Element("Name")?.Remove();
            world.Add(new XElement("Name", new XAttribute("Key", txtNameKey.Text)));

            world.Element("Description")?.Remove();
            world.Add(new XElement("Description", new XAttribute("Key", txtDescKey.Text)));

            world.Element("ShortDescription")?.Remove();
            world.Add(new XElement("ShortDescription", new XAttribute("Key", txtShortDescKey.Text)));

            world.Element("SummaryText")?.Remove();
            world.Add(new XElement("SummaryText", new XAttribute("Key", txtSummary.Text)));

            // === Update StartConditions ===
            var startConditionsEl = world.Element("StartConditions");
            if (startConditionsEl == null)
            {
                startConditionsEl = new XElement("StartConditions");
                world.Add(startConditionsEl);
            }
            else
            {
                startConditionsEl.RemoveAll();
            }

            foreach (string id in WorldStartConditions)
            {
                startConditionsEl.Add(new XElement("StartCondition", new XAttribute("Id", id)));
            }

            // === Update Start Locations ===
            world.Elements("startlocation").Remove();
            foreach (ListViewItem item in lvStartLocations.Items)
            {
                world.Add((XElement)item.Tag);
            }

            // === Save world.xml ===
            worldDoc.Save(worldXmlPath);
            conversionUserControl.AppendLog($"Saved world settings to {worldXmlPath}");

            // === Save Objectives ===
            objectivesDoc.Root?.Elements("WorldObjective").Remove();
            foreach (ListViewItem item in lvObjectives.Items)
            {
                objectivesDoc.Root?.Add((XElement)item.Tag);
            }
            objectivesDoc.Save(objectivesPath);
            conversionUserControl.AppendLog($"Saved objectives to {objectivesPath}");

            // === Update About.xml ===
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
                            nameElement.Value = txtNameValue.Text;
                        else
                            modElement.Add(new XElement("Name", txtNameValue.Text));

                        var descElement = modElement.Element("Description");
                        if (descElement != null && !string.IsNullOrEmpty(description))
                            descElement.Value = description;
                        else if (!string.IsNullOrEmpty(description))
                            modElement.Add(new XElement("Description", description));

                        aboutDoc.Save(aboutXmlPath);
                        conversionUserControl.AppendLog($"Updated {aboutXmlPath} with Name and Description");
                    }
                }
                catch (Exception ex)
                {
                    conversionUserControl.AppendLog($"Failed to update About.xml: {ex.Message}");
                }
            }

            // === Update Language Files ===
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
                    catch { return false; }
                }).ToList();

                foreach (var langFile in languageFiles)
                {
                    try
                    {
                        var langDoc = XDocument.Load(langFile);
                        var interfaceElement = langDoc.Root?.Element("Interface");
                        if (interfaceElement != null)
                        {
                            // Update or add entries
                            UpdateOrAddRecord(interfaceElement, txtNameKey.Text, txtNameValue.Text);
                            UpdateOrAddRecord(interfaceElement, txtDescKey.Text, description);
                            UpdateOrAddRecord(interfaceElement, txtShortDescKey.Text, summary);
                            UpdateOrAddRecord(interfaceElement, txtSummary.Text, summary);

                            langDoc.Save(langFile);
                            conversionUserControl.AppendLog($"Updated language file {Path.GetFileName(langFile)}");
                        }
                    }
                    catch (Exception ex)
                    {
                        conversionUserControl.AppendLog($"Failed to update {langFile}: {ex.Message}");
                    }
                }
            }
        }

        // Helper method to update or add a Record
        private void UpdateOrAddRecord(XElement interfaceElement, string key, string value)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value)) return;

            var record = interfaceElement.Elements("Record")
                .FirstOrDefault(r => r.Element("Key")?.Value == key);

            if (record != null)
            {
                record.SetElementValue("Value", value);
            }
            else
            {
                interfaceElement.Add(new XElement("Record",
                    new XElement("Key", key),
                    new XElement("Value", value)
                ));
            }
        }
    }
}