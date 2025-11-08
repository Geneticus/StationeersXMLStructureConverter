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
        private XElement world;
        private bool isEditingLocation = false;
        private bool isEditingObjective = false;
        private Form activeLocationEditor = null;

        public WorldEditorUserControl()
        {
            InitializeComponent();
            InitializeListViews();
            //this.AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void InitializeListViews()
        {
            // Configure dgvStartLocations
            dgvStartLocations.Columns.Clear();
            var nameColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Name = "Name",
                Width = 320  // ← WIDER
            };
            dgvStartLocations.Columns.Add(nameColumn);
            dgvStartLocations.Columns.Add("X", "X");
            dgvStartLocations.Columns.Add("Y", "Y");
            var editColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvStartLocations.Columns.Add(editColumn);

            dgvStartLocations.CellContentClick += DgvStartLocations_CellContentClick; ;

            // Configure dgvObjectives
            dgvObjectives.Columns.Clear();
            dgvObjectives.Columns.Clear();

            var idColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Id",
                Name = "Id",
                Width = 220
            };
            dgvObjectives.Columns.Add(idColumn);

            var objecivesNameColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Name = "Name",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvObjectives.Columns.Add(objecivesNameColumn);

            dgvObjectives.CellContentClick += DgvObjectives_CellContentClick;

        }

        private void DgvStartLocations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isEditingLocation) return;
            if (e.RowIndex < 0 || e.ColumnIndex != 3) return;

            isEditingLocation = true;
            try
            {
                var row = dgvStartLocations.Rows[e.RowIndex];
                var result = OpenStartLocationEditor((XElement)row.Tag, row);
                if (result == DialogResult.OK)
                {
                    // OK logic (already in method)
                }
            }
            finally
            {
                isEditingLocation = false;
            }
        }

        private void DgvObjectives_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isEditingObjective) return;
            if (e.RowIndex < 0 || e.ColumnIndex != 3) return;

            isEditingObjective = true;
            try
            {
                var row = dgvObjectives.Rows[e.RowIndex];
                var obj = (XElement)row.Tag;
                OpenObjectiveEditor(obj, row);
            }
            finally
            {
                isEditingObjective = false;
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

        //Populate the Form and load child controls. 
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
                dgvStartLocations.Invalidate(true);
                dgvStartLocations.PerformLayout();
                
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
            txtSummaryKey.Text = world.Element("SummaryText")?.Attribute("Key")?.Value ?? "";

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
            txtSummary.Text = GetValueForKey(txtSummaryKey.Text);
            description = txtDescValue.Text;
            summary = txtShortDescValue.Text;


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
            dgvStartLocations.Rows.Clear();
            foreach (var loc in world.Elements("StartLocation"))
            {
                var nameKey = loc.Element("Name")?.Attribute("Key")?.Value ?? "";
                var nameValue = GetValueForKey(nameKey);
                var x = loc.Element("Position")?.Attribute("x")?.Value ?? "0";
                var y = loc.Element("Position")?.Attribute("y")?.Value ?? "0";

                var rowIndex = dgvStartLocations.Rows.Add(nameValue, x, y);
                dgvStartLocations.Rows[rowIndex].Tag = loc;
            }

            // === POPULATE OBJECTIVES ===
            dgvObjectives.Rows.Clear();

            var usedGroupIds = world.Elements("WorldObjective")
                .Select(e => e.Attribute("Id")?.Value)
                .Where(id => !string.IsNullOrEmpty(id))
                .ToHashSet();

            var allGroups = new Dictionary<string, string>();

            // Vanilla
            string vanillaPath = Path.Combine(StationeersPath, "rocketstation_Data", "StreamingAssets", "Data", "WorldObjectives.xml");
            if (File.Exists(vanillaPath))
            {
                var doc = XDocument.Load(vanillaPath);
                foreach (var group in doc.Root.Elements("WorldObjective"))
                {
                    var id = group.Attribute("Id")?.Value;
                    if (string.IsNullOrEmpty(id)) continue;
                    var name = group.Element("Name")?.Attribute("Value")?.Value ?? id;
                    allGroups[id] = name;
                }
            }

            // Mod
            string modPath = Path.Combine(newModPath, "GameData", "WorldObjectives.xml");
            if (File.Exists(modPath))
            {
                var doc = XDocument.Load(modPath);
                foreach (var group in doc.Root.Elements("WorldObjective"))
                {
                    var id = group.Attribute("Id")?.Value;
                    if (string.IsNullOrEmpty(id)) continue;
                    var name = group.Element("Name")?.Attribute("Value")?.Value ?? id;
                    allGroups[id] = name;  // Mod overrides vanilla
                }
            }

            // Show only USED groups
            foreach (var kvp in allGroups)
            {
                if (!usedGroupIds.Contains(kvp.Key)) continue;
                dgvObjectives.Rows.Add(kvp.Key, kvp.Value);
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
            if (clbStartConditions.SelectedItems.Count == 0) return;

            var selectedItem = clbStartConditions.SelectedItems[0];
            string id = selectedItem.ToString();

            clbStartConditions.Items.Remove(selectedItem);
            WorldStartConditions.Remove(id);
        }

        private DialogResult OpenStartLocationEditor(XElement loc = null, DataGridViewRow row = null)
        {
            bool isEdit = loc != null;
            string title = isEdit ? "Edit Start Location" : "Add Start Location";

            using (var dialog = new Form())
            {
                dialog.Text = title;
                dialog.FormBorderStyle = FormBorderStyle.Sizable;
                dialog.Size = new Size(700, 550);
                dialog.MinimumSize = new Size(600, 400);
                dialog.StartPosition = FormStartPosition.CenterParent;

                var table = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 2,
                    RowCount = 8,
                    Padding = new Padding(10),
                    AutoScroll = true
                };
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                for (int i = 0; i < 8; i++) table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                // ID
                table.Controls.Add(new Label { Text = "ID:", Dock = DockStyle.Fill }, 0, 0);
                var txtId = new TextBox { Dock = DockStyle.Fill, Text = isEdit ? loc.Attribute("Id")?.Value ?? "" : "NewLocation" };
                table.Controls.Add(txtId, 1, 0);

                // Name Key
                table.Controls.Add(new Label { Text = "Name Key:", Dock = DockStyle.Fill }, 0, 1);
                var txtNameKey = new TextBox { Dock = DockStyle.Fill, Text = isEdit ? loc.Element("Name")?.Attribute("Key")?.Value ?? "" : "NewLocation_Name" };
                table.Controls.Add(txtNameKey, 1, 1);

                // Name Value
                table.Controls.Add(new Label { Text = "Name:", Dock = DockStyle.Fill }, 0, 2);
                var txtNameValue = new TextBox { Dock = DockStyle.Fill, Text = isEdit ? GetValueForKey(txtNameKey.Text) : "New Location" };
                table.Controls.Add(txtNameValue, 1, 2);

                // Desc Key
                table.Controls.Add(new Label { Text = "Desc Key:", Dock = DockStyle.Fill }, 0, 3);
                var txtDescKey = new TextBox { Dock = DockStyle.Fill, Text = isEdit ? loc.Element("Description")?.Attribute("Key")?.Value ?? "" : "NewLocation_Desc" };
                table.Controls.Add(txtDescKey, 1, 3);

                // Description
                table.Controls.Add(new Label { Text = "Description:", Dock = DockStyle.Fill }, 0, 4);
                var txtDescValue = new TextBox
                {
                    Dock = DockStyle.Fill,
                    Multiline = true,
                    ScrollBars = ScrollBars.Vertical,
                    AcceptsReturn = true,
                    WordWrap = true,
                    Height = 120
                };
                txtDescValue.Text = isEdit ? GetValueForKey(txtDescKey.Text) : "Description here...";
                table.Controls.Add(txtDescValue, 1, 4);
                table.SetRowSpan(txtDescValue, 2);

                // X, Y, Radius
                var panel = new FlowLayoutPanel { Dock = DockStyle.Fill, Height = 40, FlowDirection = FlowDirection.LeftToRight };
                panel.Controls.Add(new Label { Text = "X:", Width = 30 });
                var txtX = new TextBox { Width = 80, Text = isEdit ? loc.Element("Position")?.Attribute("x")?.Value ?? "0" : "0" };
                panel.Controls.Add(txtX);
                panel.Controls.Add(new Label { Text = "Y:", Width = 30 });
                var txtY = new TextBox { Width = 80, Text = isEdit ? loc.Element("Position")?.Attribute("y")?.Value ?? "0" : "0" };
                panel.Controls.Add(txtY);
                panel.Controls.Add(new Label { Text = "Radius:", Width = 50 });
                var txtRadius = new TextBox { Width = 80, Text = isEdit ? loc.Element("SpawnRadius")?.Attribute("Value")?.Value ?? "10" : "10" };
                panel.Controls.Add(txtRadius);
                table.Controls.Add(panel, 1, 6);

                // Buttons
                var btnOK = new Button { Text = "OK", DialogResult = DialogResult.OK, Width = 80 };
                var btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Width = 80 };
                dialog.CancelButton = btnCancel;

                var btnPanel = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 50, FlowDirection = FlowDirection.RightToLeft };
                btnPanel.Controls.Add(btnCancel);
                btnPanel.Controls.Add(btnOK);

                dialog.Controls.Add(table);
                dialog.Controls.Add(btnPanel);

                DialogResult result = dialog.ShowDialog();  // ← ONE CALL, STORE RESULT

                if (result == DialogResult.OK)
                {
                    if (!isEdit)
                    {
                        loc = new XElement("StartLocation");
                        world.Add(loc);
                        row = dgvStartLocations.Rows[dgvStartLocations.Rows.Add()];
                        row.Tag = loc;
                    }

                    loc.SetAttributeValue("Id", txtId.Text);
                    loc.Element("Name")?.Remove();
                    loc.Add(new XElement("Name", new XAttribute("Key", txtNameKey.Text)));
                    loc.Element("Description")?.Remove();
                    loc.Add(new XElement("Description", new XAttribute("Key", txtDescKey.Text)));

                    var pos = loc.Element("Position") ?? new XElement("Position");
                    pos.SetAttributeValue("x", txtX.Text);
                    pos.SetAttributeValue("y", txtY.Text);
                    loc.Element("Position")?.Remove();
                    loc.Add(pos);

                    loc.Element("SpawnRadius")?.Remove();
                    loc.Add(new XElement("SpawnRadius", new XAttribute("Value", txtRadius.Text)));

                    row.Cells[0].Value = txtNameValue.Text;
                    row.Cells[1].Value = txtX.Text;
                    row.Cells[2].Value = txtY.Text;
                    row.Tag = loc;

                    SaveLanguageEntry(txtNameKey.Text, txtNameValue.Text);
                    SaveLanguageEntry(txtDescKey.Text, txtDescValue.Text);
                }

                return result;  // ← RETURN RESULT
            }
        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            OpenStartLocationEditor(null, null);  // ← Called with no parameters
        }

        private void btnDeleteLocation_Click(object sender, EventArgs e)
        {
            if (dgvStartLocations.SelectedRows.Count == 0) return;

            var selectedRow = dgvStartLocations.SelectedRows[0];
            var loc = (XElement)selectedRow.Tag;

            loc.Remove(); // Remove from XML
            dgvStartLocations.Rows.Remove(selectedRow); // Remove from grid
        }

        private void btnAddObjective_Click(object sender, EventArgs e)
        {
            var usedIds = dgvObjectives.Rows
                .Cast<DataGridViewRow>()
                .Select(r => r.Cells[0].Value?.ToString())
                .Where(id => !string.IsNullOrEmpty(id))
                .ToHashSet();

            var pickerItems = new List<(string Id, string Name)>();

            // Vanilla + Mod
            foreach (var path in new[] {
        Path.Combine(StationeersPath, "rocketstation_Data", "StreamingAssets", "Data", "WorldObjectives.xml"),
        Path.Combine(newModPath, "GameData", "WorldObjectives.xml")
    })
            {
                if (!File.Exists(path)) continue;
                var doc = XDocument.Load(path);
                foreach (var group in doc.Root.Elements("WorldObjective"))
                {
                    var id = group.Attribute("Id")?.Value;
                    if (string.IsNullOrEmpty(id) || usedIds.Contains(id)) continue;
                    var name = group.Element("Name")?.Attribute("Value")?.Value ?? id;
                    pickerItems.Add((id, name));
                }
            }

            // Show picker
            using (var form = new Form { Text = "Add Objective Group", Size = new Size(400, 300) })
            {
                var clb = new CheckedListBox { Dock = DockStyle.Fill };
                foreach (var item in pickerItems)
                    clb.Items.Add($"{item.Name} ({item.Id})");

                form.Controls.Add(clb);
                var okBtn = new Button { Text = "OK", DialogResult = DialogResult.OK, Dock = DockStyle.Bottom };
                form.Controls.Add(okBtn);
                form.AcceptButton = okBtn;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    foreach (int i in clb.CheckedIndices)
                    {
                        var id = pickerItems[i].Id;
                        var name = pickerItems[i].Name;
                        world.Add(new XElement("WorldObjective", new XAttribute("Id", id)));
                        dgvObjectives.Rows.Add(id, name);
                    }
                }
            }
        }

        private void OpenObjectiveEditor(XElement obj = null, DataGridViewRow row = null)
        {
            bool isEdit = obj != null;
            string title = isEdit ? "Edit Objective" : "Add Objective";

            using (var dialog = new Form())
            {
                dialog.Text = title;
                dialog.FormBorderStyle = FormBorderStyle.Sizable;
                dialog.Size = new Size(600, 400);
                dialog.MinimumSize = new Size(500, 300);
                dialog.StartPosition = FormStartPosition.CenterParent;

                var table = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 4, Padding = new Padding(10) };
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

                // ID
                table.Controls.Add(new Label { Text = "ID:" }, 0, 0);
                var txtId = new TextBox { Dock = DockStyle.Fill, Text = isEdit ? obj.Attribute("Id")?.Value ?? "" : "NewObjective" };
                table.Controls.Add(txtId, 1, 0);

                // Description
                table.Controls.Add(new Label { Text = "Description:" }, 0, 1);
                var txtDesc = new TextBox { Dock = DockStyle.Fill, Multiline = true, Height = 80, Text = isEdit ? obj.Element("Description")?.Value ?? "" : "" };
                table.Controls.Add(txtDesc, 1, 1);

                // Info Key
                table.Controls.Add(new Label { Text = "Info Key:" }, 0, 2);
                var txtInfoKey = new TextBox { Dock = DockStyle.Fill, Text = isEdit ? obj.Element("Info")?.Attribute("Key")?.Value ?? "" : "" };
                table.Controls.Add(txtInfoKey, 1, 2);

                // Buttons
                var btnOK = new Button { Text = "OK", DialogResult = DialogResult.OK, Width = 80 };
                var btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Width = 80 };
                dialog.CancelButton = btnCancel;

                var btnPanel = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 50, FlowDirection = FlowDirection.RightToLeft };
                btnPanel.Controls.Add(btnCancel);
                btnPanel.Controls.Add(btnOK);

                dialog.Controls.Add(table);
                dialog.Controls.Add(btnPanel);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (!isEdit)
                    {
                        obj = new XElement("WorldObjective");
                        objectivesDoc.Root.Add(obj);
                        row = dgvObjectives.Rows[dgvObjectives.Rows.Add()];
                        row.Tag = obj;
                    }

                    obj.SetAttributeValue("Id", txtId.Text);
                    obj.Element("Description")?.Remove();
                    obj.Add(new XElement("Description", txtDesc.Text));
                    obj.Element("Info")?.Remove();
                    if (!string.IsNullOrEmpty(txtInfoKey.Text))
                        obj.Add(new XElement("Info", new XAttribute("Key", txtInfoKey.Text)));

                    row.Cells[0].Value = txtId.Text;
                    row.Cells[1].Value = txtDesc.Text;
                    row.Cells[2].Value = txtInfoKey.Text;
                    row.Tag = obj;
                }
            }
        }

        private void btnDeleteObjective_Click(object sender, EventArgs e)
        {
            if (dgvObjectives.SelectedRows.Count == 0) return;

            var row = dgvObjectives.SelectedRows[0];
            var id = row.Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(id)) return;

            // Remove from world.xml
            world.Elements("WorldObjective")
                .FirstOrDefault(e => e.Attribute("Id")?.Value == id)?
                .Remove();

            // Remove from grid
            dgvObjectives.Rows.Remove(row);
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
            world.Elements("StartLocation").Remove();
 
            // === Save world.xml ===
            worldDoc.Save(worldXmlPath);
            conversionUserControl.AppendLog($"Saved world settings to {worldXmlPath}");

            // === Save Objectives ===
            objectivesDoc.Root?.Elements("WorldObjective").Remove();
            
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
                            UpdateOrAddRecord(interfaceElement, txtDescKey.Text, txtDescValue.Text);
                            UpdateOrAddRecord(interfaceElement, txtShortDescKey.Text, txtShortDescValue.Text);
                            UpdateOrAddRecord(interfaceElement, txtSummaryKey.Text, txtSummary.Text);

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

        private string GetValueForKey(string key)
        {
            if (string.IsNullOrEmpty(key)) return "";

            string value = null;

            // MOD
            string modLangPath = Path.Combine(newModPath, "GameData", "Language");
            if (Directory.Exists(modLangPath))
            {
                value = LoadFromLanguageFile(modLangPath, key);
            }

            // VANILLA
            if (string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(StationeersPath))
            {
                string vanillaLangPath = Path.Combine(StationeersPath, "rocketstation_Data", "StreamingAssets", "Language");
                if (Directory.Exists(vanillaLangPath))
                {
                    value = LoadFromLanguageFile(vanillaLangPath, key);
                }
            }

            return value ?? "";
        }

        private string LoadFromLanguageFile(string folder, string key)
        {
            foreach (var file in Directory.GetFiles(folder, "*.xml"))
            {
                try
                {
                    var doc = XDocument.Load(file);
                    var record = doc.Root?.Element("Interface")?
                        .Elements("Record")
                        .FirstOrDefault(r => r.Element("Key")?.Value == key);

                    if (record != null)
                    {
                        return record.Element("Value")?.Value ?? "";
                    }
                }
                catch { }
            }
            return null;
        }

        private void SaveLanguageEntry(string key, string value)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value)) return;

            string langPath = Path.Combine(newModPath, "GameData", "Language");
            Directory.CreateDirectory(langPath);
            string file = Path.Combine(langPath, "english.xml");

            XDocument doc;
            if (File.Exists(file))
            {
                doc = XDocument.Load(file);
            }
            else
            {
                doc = new XDocument(new XElement("Language",
                    new XElement("Name", "English"),
                    new XElement("Code", "EN"),
                    new XElement("Font", "font_english"),
                    new XElement("Interface")
                ));
            }

            var interfaceEl = doc.Root.Element("Interface");
            var record = interfaceEl?.Elements("Record")
                .FirstOrDefault(r => r.Element("Key")?.Value == key);

            if (record != null)
            {
                record.SetElementValue("Value", value);
            }
            else
            {
                interfaceEl?.Add(new XElement("Record",
                    new XElement("Key", key),
                    new XElement("Value", value)
                ));
            }

            doc.Save(file);
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