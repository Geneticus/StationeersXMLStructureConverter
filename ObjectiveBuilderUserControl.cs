using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;

namespace StationeersStructureXMLConverter
{
    public partial class ObjectiveBuilderUserControl : UserControl
    {
        private string modPath = "";
        private XDocument doc;

        public ObjectiveBuilderUserControl()
        {
            InitializeComponent();
            WireEvents();
            EnsureGameDataRoot();
        }

        private void WireEvents()
        {
            menuAdd.Click += (s, e) => BtnAdd_Click(s, e);
            menuEdit.Click += (s, e) => BtnEdit_Click(s, e);
            menuDelete.Click += (s, e) => BtnDelete_Click(s, e);
            btnBrowse.Click += BtnBrowse_Click;
            btnReload.Click += BtnReload_Click;
            tvGroups.AfterSelect += TvGroups_AfterSelect;
            dataGridView.SelectionChanged += DataGridView_SelectionChanged;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;
            tvGroups.MouseDown += TvGroups_MouseDown;            
        }

        #region Core

        private void EnsureGameDataRoot()
        {
            if (doc == null)
            {
                doc = new XDocument(new XElement("GameData"));
            }
            if (doc.Root == null)
            {
                doc.Add(new XElement("GameData"));
            }
            PopulateTree();
        }

        private void LoadMod()
        {
            string xmlPath = Path.Combine(modPath, "GameData", "WorldObjectives.xml");
            if (!File.Exists(xmlPath))
            {
                if (MessageBox.Show("WorldObjectives.xml not found. Create new?", "File Missing", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(xmlPath));
                    doc = new XDocument(new XElement("GameData"));
                    doc.Save(xmlPath);
                }
                else
                {
                    return;
                }
            }

            try
            {
                doc = XDocument.Load(xmlPath);
                PopulateTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading XML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Tree & Grid

        private void PopulateTree()
        {
            tvGroups.Nodes.Clear();
            dataGridView.Rows.Clear();

            var root = doc.Root;
            var gameDataNode = tvGroups.Nodes.Add("GameData", "GameData");
            gameDataNode.Tag = root;

            foreach (var group in root.Elements("WorldObjective"))
            {
                string id = group.Attribute("Id")?.Value;
                if (string.IsNullOrEmpty(id)) continue;

                var groupNode = gameDataNode.Nodes.Add(id, id);
                groupNode.Tag = group;

                foreach (var obj in group.Elements("Objective"))
                {
                    string objId = obj.Attribute("Id")?.Value;
                    if (string.IsNullOrEmpty(objId)) continue;

                    var objNode = groupNode.Nodes.Add(objId, objId);
                    objNode.Tag = obj;
                }
            }

            gameDataNode.Expand();
        }

        private void TvGroups_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dataGridView.Rows.Clear();
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;

            if (e.Node.Tag is XElement el)
            {
                string nodeType = el.Name.LocalName;
                PrepareGridColumns(nodeType);

                switch (nodeType)
                {
                    case "WorldObjective":
                        dataGridView.Rows.Add(
                            el.Attribute("Id")?.Value,
                            el.Element("Name")?.Attribute("Value")?.Value
                        );
                        break;

                    case "Objective":
                        dataGridView.Rows.Add(
                            el.Attribute("Id")?.Value,
                            el.Element("Name")?.Attribute("Value")?.Value,
                            el.Element("Trigger")?.Value,
                            el.Element("Notice")?.Attribute("Key")?.Value
                        );
                        break;

                    default:
                        foreach (var child in el.Elements())
                        {
                            if (child.Name == "Name") continue;
                            string type = child.Name.LocalName;
                            string id = child.Attribute("Id")?.Value ?? "";
                            string attrs = string.Join(", ", child.Attributes().Where(a => a.Name != "Id").Select(a => $"{a.Name}={a.Value}"));
                            dataGridView.Rows.Add(type, id, attrs);
                        }
                        break;
                }

                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            btnEdit.Enabled = dataGridView.SelectedRows.Count > 0;
            btnDelete.Enabled = dataGridView.SelectedRows.Count > 0;
        }

        #endregion

        #region Buttons

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            TreeNode selected = tvGroups.SelectedNode;
            if (selected == null) selected = tvGroups.Nodes[0];

            string parentName = selected.Text;
            string parentType = ((XElement)selected.Tag).Name.LocalName;

            using (var form = new Form { Text = $"Add to {parentName} ({parentType})", Width = 300, Height = 200 })
            {
                var cb = new ComboBox { Left = 20, Top = 20, Width = 240 };
                var ok = new Button { Text = "Next", Left = 100, Top = 60, DialogResult = DialogResult.OK };

                if (parentType == "GameData")
                {
                    cb.Items.Add("WorldObjective");
                    cb.Items.Add("Objective");
                }
                else if (parentType == "WorldObjective")
                    cb.Items.Add("Objective");
                else if (parentType == "Objective")
                    cb.Items.AddRange(new[] { "Trigger", "Notice", "Conditions", "CompletePopup" });

                cb.SelectedIndex = 0;
                form.Controls.Add(cb); form.Controls.Add(ok);

                if (form.ShowDialog() == DialogResult.OK && cb.SelectedItem != null)
                {
                    string type = cb.SelectedItem.ToString();
                    AddNode((XElement)selected.Tag, type, selected);
                }
            }
        }

        private void AddNode(XElement parent, string type, TreeNode parentNode)
        {
            string id = Prompt($"Enter {type} ID:");
            if (string.IsNullOrEmpty(id)) return;

            if (IsDuplicateId(parent, id))
            {
                MessageBox.Show($"ID '{id}' already exists at this level.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            XElement el = new XElement(type, new XAttribute("Id", id));
            if (type != "Conditions") el.Add(new XElement("Name", new XAttribute("Value", id)));

            parent.Add(el);

            TreeNode newNode = parentNode.Nodes.Add(id, $"{type}: {id}");
            newNode.Tag = el;

            if (parent.Name == "Objective")
                PopulateConditions(parent);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            TreeNode node = tvGroups.SelectedNode;
            if (node == null || node.Tag is not XElement el) return;

            switch (el.Name.LocalName)
            {
                case "WorldObjective":
                    EditGroup(el, node);
                    break;
                case "Objective":
                    EditObjective(el, node);
                    break;
                case "Trigger":
                case "Notice":
                case "Conditions":
                case "CompletePopup":
                    EditChildNode(el, node);
                    break;
            }
        }

        private void EditNode(XElement el, TreeNode node)
        {
            string current = el.Element("Name")?.Attribute("Value")?.Value ?? el.Attribute("Id").Value;
            string newName = Prompt("Edit Name:", current);
            if (string.IsNullOrEmpty(newName)) return;

            var nameEl = el.Element("Name");
            if (nameEl == null)
            {
                nameEl = new XElement("Name");
                el.Add(nameEl);
            }
            nameEl.SetAttributeValue("Value", newName);
            node.Text = newName;
        }
        
        private void EditChildNode(XElement el, TreeNode node)
        {
            string type = el.Name.LocalName;
            string id = el.Attribute("Id")?.Value ?? "";

            using (var form = new Form { Text = $"Edit {type}: {id}", Width = 400, Height = 300 })
            {
                var props = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.TopDown };

                foreach (var attr in el.Attributes())
                {
                    var tb = new TextBox { Text = attr.Value, Width = 300 };
                    props.Controls.Add(new Label { Text = attr.Name.LocalName + ":" });
                    props.Controls.Add(tb);
                    tb.Tag = attr;
                }

                var btnOK = new Button { Text = "OK", DialogResult = DialogResult.OK, Dock = DockStyle.Bottom };
                form.Controls.Add(props);
                form.Controls.Add(btnOK);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    foreach (Control c in props.Controls)
                    {
                        if (c is TextBox tb && tb.Tag is XAttribute attr)
                        {
                            attr.Value = tb.Text;
                        }
                    }
                    node.Text = $"{type}: {id}";
                }
            }
        }
       
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            TreeNode node = tvGroups.SelectedNode;
            if (node == null || node.Tag is not XElement el) return;

            if (MessageBox.Show($"Delete {el.Name} '{el.Attribute("Id")?.Value}'?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

            el.Remove();
            tvGroups.Nodes.Remove(node);

            if (node.Parent != null && !node.Parent.Nodes.Cast<TreeNode>().Any())
            {
                if (MessageBox.Show("Parent is empty. Delete it?", "Cascade", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    BtnDelete_Click(sender, e);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(modPath)) return;

            string xmlPath = Path.Combine(modPath, "GameData", "WorldObjectives.xml");
            try
            {
                doc.Save(xmlPath);
                MessageBox.Show("Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Save failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TvGroups_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = tvGroups.HitTest(e.X, e.Y);
                if (hit.Node != null)
                {
                    tvGroups.SelectedNode = hit.Node;
                    nodeContextMenu.Show(tvGroups, e.Location);
                }
            }
        }

        private void EditObjective(XElement obj, TreeNode node)
        {
            using (var form = new Form { Text = $"Edit Objective: {obj.Attribute("Id")?.Value}", Width = 600, Height = 500 })
            {
                var tabs = new TabControl { Dock = DockStyle.Fill };

                // Tab: General
                var tabGeneral = new TabPage("General");
                var lblName = new Label { Text = "Name:", Left = 20, Top = 23, AutoSize = true };
                string currentName = obj.Element("Name")?.Attribute("Value")?.Value ?? "";
                var txtName = new TextBox { Text = currentName, Left = 100, Top = 20, Width = 400 };
                tabGeneral.Controls.Add(lblName);
                tabGeneral.Controls.Add(txtName);                
                tabs.TabPages.Add(tabGeneral);

                // Tab: Conditions
                var tabConditions = new TabPage("Conditions");
                var lv = new ListView { Dock = DockStyle.Fill, View = View.Details, FullRowSelect = true };
                lv.Columns.Add("Type", 100); lv.Columns.Add("ID", 150); lv.Columns.Add("Attributes", 200);
                foreach (var cond in obj.Elements().Where(e => e.Name != "Name"))
                {
                    string type = cond.Name.LocalName;
                    string id = cond.Attribute("Id")?.Value ?? "";
                    string attrs = string.Join(", ", cond.Attributes().Where(a => a.Name != "Id").Select(a => $"{a.Name}={a.Value}"));
                    lv.Items.Add(new ListViewItem(new[] { type, id, attrs }) { Tag = cond });
                }
                var btnAddCond = new Button { Text = "+ Add Condition", Dock = DockStyle.Bottom, Height = 35 };
                btnAddCond.Click += (s, ev) => AddConditionToObjective(obj, lv);
                tabConditions.Controls.Add(lv);
                tabConditions.Controls.Add(btnAddCond);
                tabs.TabPages.Add(tabConditions);

                form.Controls.Add(tabs);

                var btnOK = new Button { Text = "OK", DialogResult = DialogResult.OK, Dock = DockStyle.Bottom, Height = 35 };
                form.Controls.Add(btnOK);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    var nameEl = obj.Element("Name") ?? new XElement("Name");
                    nameEl.SetAttributeValue("Value", txtName.Text);
                    if (obj.Element("Name") == null) obj.Add(nameEl);
                    node.Text = txtName.Text;
                }
            }
        }

        private void EditGroup(XElement group, TreeNode node)
        {
            string current = group.Element("Name")?.Attribute("Value")?.Value ?? group.Attribute("Id").Value;
            string newName = Prompt("Edit Group Name:", current);
            if (string.IsNullOrEmpty(newName)) return;

            var nameEl = group.Element("Name") ?? new XElement("Name");
            nameEl.SetAttributeValue("Value", newName);
            if (group.Element("Name") == null) group.Add(nameEl);
            node.Text = newName;
        }
        #endregion

        #region Helpers

        private string Prompt(string message, string defaultValue = "")
        {
            using (var form = new Form { Width = 300, Height = 150, Text = message })
            {
                var tb = new TextBox { Left = 20, Top = 20, Width = 240, Text = defaultValue };
                var ok = new Button { Text = "OK", Left = 100, Top = 60, DialogResult = DialogResult.OK };
                form.Controls.Add(tb);
                form.Controls.Add(ok);
                form.AcceptButton = ok;
                return form.ShowDialog() == DialogResult.OK ? tb.Text : null;
            }
        }

        private void PopulateConditions(XElement objective)
        {
            dataGridView.Rows.Clear();
            foreach (var cond in objective.Elements())
            {
                if (cond.Name == "Name") continue;
                string type = cond.Name.LocalName;
                string id = cond.Attribute("Id")?.Value ?? "";
                dataGridView.Rows.Add(type, id);
            }
        }
        
        private void PrepareGridColumns(string nodeType)
        {
            dataGridView.Columns.Clear();

            switch (nodeType)
            {
                case "WorldObjective":
                    dataGridView.Columns.Add("ID", "ID");
                    dataGridView.Columns.Add("Name", "Name");
                    break;

                case "Objective":
                    dataGridView.Columns.Add("ID", "ID");
                    dataGridView.Columns.Add("Name", "Name");
                    dataGridView.Columns.Add("Trigger", "Trigger");
                    dataGridView.Columns.Add("Notice", "Notice");
                    break;

                case "Condition":
                    dataGridView.Columns.Add("Type", "Type");
                    dataGridView.Columns.Add("ID", "ID");
                    dataGridView.Columns.Add("Attributes", "Attributes");
                    break;

                default:
                    dataGridView.Columns.Add("Property", "Value");
                    break;
            }
        }
        private bool IsDuplicateId(XElement parent, string id)
        {
            return parent.Elements().Any(el => el.Attribute("Id")?.Value == id);
        }

        private void AddConditionToObjective(XElement objective, ListView lv)
        {
            using (var form = new Form { Text = "Add Condition", Width = 400, Height = 180 })
            {
                var lblType = new Label { Text = "Type:", Left = 20, Top = 20, Width = 60, Height = 20 };
                var cbType = new ComboBox { Left = 80, Top = 18, Width = 280 };

                var lblId = new Label { Text = "ID:", Left = 20, Top = 60, Width = 60, Height = 20 };
                var cbId = new ComboBox { Left = 80, Top = 58, Width = 280 };

                // POPULATE FIRST
                cbType.Items.AddRange(new[] { "Prefab", "ThingCount", "Room", "Player" });
                cbType.SelectedIndex = 0;  // ← AFTER AddRange

                cbType.SelectedIndexChanged += (s, ev) =>
                {
                    cbId.Items.Clear();
                    if (cbType.SelectedItem?.ToString() == "Prefab")
                    {
                        cbId.DropDownStyle = ComboBoxStyle.DropDownList;
                        cbId.Items.AddRange(GetPrefabList().ToArray());
                    }
                    else
                    {
                        cbId.DropDownStyle = ComboBoxStyle.DropDown;
                        cbId.Text = "1";
                    }
                };

                var btnOK = new Button { Text = "OK", Left = 150, Top = 100, DialogResult = DialogResult.OK };
                form.Controls.AddRange(new Control[] { lblType, cbType, lblId, cbId, btnOK });
                form.AcceptButton = btnOK;

                if (form.ShowDialog() == DialogResult.OK && cbType.SelectedItem != null)
                {
                    string type = cbType.SelectedItem.ToString();
                    string id = cbId.Text;
                    if (string.IsNullOrEmpty(id)) return;

                    var cond = new XElement(type, new XAttribute("Id", id));
                    objective.Add(cond);
                    lv.Items.Add(new ListViewItem(new[] { type, id, "" }) { Tag = cond });
                }
            }
        }

        private List<string> GetPrefabList()
        {
            // From StreamingAssets/Data/*.xml
            string dataPath = Path.Combine(modPath, "StreamingAssets", "Data");
            if (!Directory.Exists(dataPath)) return new List<string>();

            var prefabs = new HashSet<string>();

            foreach (string file in Directory.GetFiles(dataPath, "*.xml", SearchOption.AllDirectories))
            {
                try
                {
                    var doc = XDocument.Load(file);
                    foreach (var prefab in doc.Root.Elements("Prefab"))
                    {
                        string name = prefab.Attribute("Id")?.Value ?? prefab.Attribute("Name")?.Value;
                        if (!string.IsNullOrEmpty(name))
                            prefabs.Add(name);
                    }
                }
                catch { /* skip */ }
            }

            return prefabs.OrderBy(p => p).ToList();
        }


        #endregion

        #region Path

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtModPath.Text = fbd.SelectedPath;
                    modPath = fbd.SelectedPath;
                    LoadMod();
                }
            }
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(modPath))
                LoadMod();
        }

        #endregion
    }
}