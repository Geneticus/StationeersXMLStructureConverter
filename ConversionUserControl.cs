using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace StationeersStructureXMLConverter
{
    public partial class ConversionUserControl : UserControl
    {
        private string stationeersPath;
        private string outputPath;
        private string modName = "";
        private string worldName = "";
        private string description = "";
        private string summary = "";

        public ConversionUserControl()
        {
            InitializeComponent();
            if (configureOutputsButton != null)
            {
                configureOutputsButton.Enabled = false;
                configureOutputsButton.Visible = true;
            }
            textBox3.WordWrap = true;
            textBox3.ReadOnly = true;
            textBox3.Font = new Font("Consolas", 9F);
            textBox3.AcceptsReturn = true;
            // Wire Convert button to raise public event (pass 'this' or 's'—either works since MainForm doesn't cast for Convert_Click)
            button1.Click += (s, e) => Convert_Click?.Invoke(this, e);

            // Wire checkboxes to raise public event (pass original 's' to preserve CheckBox sender for MainForm cast)
            VanillaWorld_CheckBox.CheckedChanged += (s, e) => CheckBox_CheckedChanged?.Invoke(s, e);
            LocalMod_CheckBox.CheckedChanged += (s, e) => CheckBox_CheckedChanged?.Invoke(s, e);
            None_CheckBox.CheckedChanged += (s, e) => CheckBox_CheckedChanged?.Invoke(s, e);

            // Wire ComboBox to raise public event (pass original 's' for consistency, though MainForm may not cast it)
            WorldSelection_ComboBox.SelectedIndexChanged += (s, e) => WorldSelection_ComboBox_SelectedIndexChanged?.Invoke(s, e);

            bool isDebug = System.Diagnostics.Debugger.IsAttached;
            string defaultRoot = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers");
            if (isDebug)
            {
                textBox1.Text = "C:\\Users\\Geneticus\\Documents\\My Games\\Stationeers\\saves\\Loulanish_8\\Loulanish_8.save";
            }
            else
            {
                textBox1.Text = Path.Combine(defaultRoot, "saves");
            }
            Right_GroupBox.PerformLayout();
        }

        public string InputPath
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }

        public bool VanillaWorldChecked
        {
            get => VanillaWorld_CheckBox.Checked;
            set => VanillaWorld_CheckBox.Checked = value;
        }

        public bool LocalModChecked
        {
            get => LocalMod_CheckBox.Checked;
            set => LocalMod_CheckBox.Checked = value;
        }

        public bool NoneChecked
        {
            get => None_CheckBox.Checked;
            set => None_CheckBox.Checked = value;
        }

        public string SelectedWorld
        {
            get => WorldSelection_ComboBox.SelectedItem?.ToString();
            set => WorldSelection_ComboBox.SelectedItem = value;
        }

        public int WorldSelectionIndex
        {
            get => WorldSelection_ComboBox.SelectedIndex;
            set => WorldSelection_ComboBox.SelectedIndex = value;
        }

        public bool WorldSelectionEnabled
        {
            get => WorldSelection_ComboBox.Enabled;
            set => WorldSelection_ComboBox.Enabled = value;
        }

        public ComboBox.ObjectCollection WorldSelectionItems => WorldSelection_ComboBox.Items;

        public bool ConfigureOutputsEnabled
        {
            get => configureOutputsButton.Enabled;
            set => configureOutputsButton.Enabled = value;
        }

        public bool FilterLanderCapsule
        {
            get => checkBox1.Checked;
        }

        public bool FilterCharacter
        {
            get => checkBox2.Checked;
        }

        public bool FilterSupplyLander
        {
            get => checkBox3.Checked;
        }

        public bool FilterOre
        {
            get => Filter5_CheckBox.Checked;
        }

        public bool FilterItemKit
        {
            get => Filter6_CheckBox.Checked;
        }

        public string StationeersPath
        {
            get => stationeersPath;
            set => stationeersPath = value;
        }

        public string OutputPath
        {
            get => outputPath;
            set => outputPath = value;
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

        public Label Label1 => label1;

        public bool InputPathEnabled
        {
            get => textBox1.Enabled;
            set => textBox1.Enabled = value;
        }
        public CheckBox VanillaWorldCheckBox => this.VanillaWorld_CheckBox;
        public CheckBox LocalModCheckBox => this.LocalMod_CheckBox;
        public CheckBox NoneCheckBox => this.None_CheckBox;
        public TextBox LogTextBox => textBox3;

        public event EventHandler Convert_Click;
        public event EventHandler CheckBox_CheckedChanged;
        public event EventHandler WorldSelection_ComboBox_SelectedIndexChanged;


        public void AppendLog(string message)
        {
            textBox3.AppendText(message + "\r\n");
            textBox3.Refresh();
            textBox3.SelectionStart = textBox3.Text.Length;
            textBox3.ScrollToCaret();
        }

        private void BrowseInput_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents\\My Games\\Stationeers\\saves");
                openFileDialog.Filter = ".save files (*.save)|*.save|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.textBox1.Text = openFileDialog.FileName;
                }
            }
        }

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
                    this.AppendLog("Mod configuration set:");
                    this.AppendLog($"  Mod Name: {modName}");
                    this.AppendLog($"  World Name: {worldName}");
                    this.AppendLog($"  Description: {description}");
                    this.AppendLog($"  Summary: {summary}");
                }
                else
                {
                    this.AppendLog("Mod configuration cancelled.");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
            Application.Exit();
        }

        public void PopulateWorldDropdown()
        {
            this.WorldSelection_ComboBox.Items.Clear();
            if (VanillaWorld_CheckBox.Checked && stationeersPath != null)
            {
                string worldsPath = Path.Combine(stationeersPath, "rocketstation_Data", "StreamingAssets", "Worlds");
                if (Directory.Exists(worldsPath))
                {
                    var worldFolders = Directory.GetDirectories(worldsPath)
                        .Select(Path.GetFileName)
                        .Where(f => !f.Contains("Tutorial") && !f.Equals("SharedTextures", StringComparison.OrdinalIgnoreCase))
                        .ToArray();
                    this.WorldSelection_ComboBox.Items.AddRange(worldFolders);
                }
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
                            string[] allSubFolders = Directory.GetDirectories(modRootPath, "*", SearchOption.AllDirectories);
                            bool worldFound = false;
                            foreach (string folder in allSubFolders)
                            {
                                if (folder.EndsWith("\\GameData\\Worlds", StringComparison.OrdinalIgnoreCase))
                                {
                                    string[] subWorldFolders = Directory.GetDirectories(folder, "*", SearchOption.AllDirectories)
                                        .Concat(new[] { folder })
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
                    this.WorldSelection_ComboBox.Items.AddRange(modFolders);
                }
                else
                {
                    this.AppendLog("Warning: 'mods' directory not found at " + modsPath + ". No local mod worlds available.");
                }
            }
            this.WorldSelection_ComboBox.SelectedIndex = -1;
        }
    }
}