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

        public void LoadWorldSettings()
        {
            if (string.IsNullOrEmpty(newModPath))
            {
                MessageBox.Show("Create a mod first.");
                return;
            }
            string selectedWorld = conversionUserControl.SelectedWorld;
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
                nudPriority.Value = int.TryParse(settings.Element("World")?.Attribute("Priority")?.Value, out int priority) ? priority : 2;
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
                    item.SubItems.Add("Edit");
                    item.Tag = loc;
                    lvStartLocations.Items.Add(item);
                }
            }
            else
            {
                conversionUserControl.AppendLog("No world.xml found; using defaults.");
                worldDoc = new XDocument(new XElement("WorldSettingData"));
                worldXmlPath = Path.Combine(worldFolder, "world.xml");
                txtWorldId.Text = string.IsNullOrEmpty(worldName) ? $"{modName}_World" : worldName;
                nudPriority.Value = 2;
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



        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            using (var dialog = new Form())
            {
                dialog.Text = "Add Start Condition";
                dialog.AutoSize = true;
                dialog.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                var txtConditionId = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 200, Text = $"Condition{clbStartConditions.Items.Count + 1}" };
                var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(120, 60), DialogResult = DialogResult.OK };
                dialog.Controls.AddRange(new Control[] {
                    new Label { Text = "Condition ID:", Location = new System.Drawing.Point(20, 20), Width = 80 },
                    txtConditionId,
                    btnOk
                });
                dialog.MinimumSize = new System.Drawing.Size(300, 120);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    clbStartConditions.Items.Add(txtConditionId.Text, true);
                }
            }
        }

        private void btnDeleteCondition_Click(object sender, EventArgs e)
        {
            if (clbStartConditions.SelectedIndex >= 0)
            {
                clbStartConditions.Items.RemoveAt(clbStartConditions.SelectedIndex);
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
            var settings = worldDoc.Root;
            settings.Element("World")?.Remove();
            settings.Add(new XElement("World",
                new XAttribute("Id", txtWorldId.Text),
                new XAttribute("Priority", nudPriority.Value.ToString()),
                new XAttribute("Hidden", "false")
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
            conversionUserControl.AppendLog($"Saved world settings to {worldXmlPath}");
            objectivesDoc.Root?.Elements("WorldObjective").Remove();
            foreach (ListViewItem item in lvObjectives.Items)
            {
                objectivesDoc.Root?.Add((XElement)item.Tag);
            }
            objectivesDoc.Save(objectivesPath);
            conversionUserControl.AppendLog($"Saved objectives to {objectivesPath}");
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
                        conversionUserControl.AppendLog($"Updated {aboutXmlPath} with Name and Description");
                    }
                }
                catch (Exception ex)
                {
                    conversionUserControl.AppendLog($"Failed to update About.xml: {ex.Message}");
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
                            conversionUserControl.AppendLog($"Updated language file {langFile} with WorldName, Description, ShortDescription, Summary");
                        }
                    }
                    catch (Exception ex)
                    {
                        conversionUserControl.AppendLog($"Failed to update {langFile}: {ex.Message}");
                    }
                }
            }
        }
    }
}