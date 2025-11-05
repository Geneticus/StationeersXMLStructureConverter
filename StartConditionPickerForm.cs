using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace StationeersStructureXMLConverter
{
    public partial class StartConditionPickerForm : Form
    {
        public string SelectedConditionId { get; private set; }

        private readonly ListBox lstConditions;

        public StartConditionPickerForm(string modPath, string gamePath, List<string> usedIds)
        {
            lstConditions = new ListBox();
            InitializeComponent();
            LoadConditions(modPath, gamePath, usedIds);
        }

        private void InitializeComponent()
        {
            this.Text = "Select Start Condition";
            this.Size = new System.Drawing.Size(340, 460);
            this.StartPosition = FormStartPosition.CenterParent;

            lstConditions.Dock = DockStyle.Fill;
            lstConditions.SelectionMode = SelectionMode.One;
            this.Controls.Add(lstConditions);

            var btnPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 40,
                FlowDirection = FlowDirection.RightToLeft
            };

            var btnOK = new Button { Text = "OK", DialogResult = DialogResult.OK, Width = 80 };
            var btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Width = 80 };

            btnPanel.Controls.Add(btnOK);
            btnPanel.Controls.Add(btnCancel);
            this.Controls.Add(btnPanel);

            btnOK.Click += (s, e) =>
            {
                if (lstConditions.SelectedItem != null)
                {
                    SelectedConditionId = lstConditions.SelectedItem.ToString();
                    this.Close();
                }
            };
        }

        private void LoadConditions(string modPath, string gamePath, List<string> usedIds)
        {
            var allIds = new HashSet<string>(usedIds);

            // Mod
            string modFile = Path.Combine(modPath, "GameData", "startconditions.xml");
            if (File.Exists(modFile))
            {
                var doc = XDocument.Load(modFile);
                foreach (var el in doc.Root?.Elements("StartCondition") ?? Enumerable.Empty<XElement>())
                {
                    var id = el.Attribute("Id")?.Value;
                    if (!string.IsNullOrEmpty(id)) allIds.Add(id);
                }
            }

            // Vanilla
            string vanillaFile = Path.Combine(gamePath, "rocketstation_Data", "StreamingAssets", "Data", "startconditions.xml");
            if (File.Exists(vanillaFile))
            {
                var doc = XDocument.Load(vanillaFile);
                foreach (var el in doc.Root?.Elements("StartCondition") ?? Enumerable.Empty<XElement>())
                {
                    var id = el.Attribute("Id")?.Value;
                    if (!string.IsNullOrEmpty(id)) allIds.Add(id);
                }
            }

            lstConditions.Items.AddRange(allIds.OrderBy(x => x).ToArray());
        }
    }
}
