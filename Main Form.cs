using StationeersStructureXMLConverter;
using System;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Linq;

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

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label labelInstructions; // New control
        private System.Windows.Forms.Button button4; // New control
        private System.Windows.Forms.ToolTip toolTip1; // New control
        private System.Windows.Forms.Label progressBarPlaceholder; // New
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPaths;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
        private System.Windows.Forms.Panel progressBarOutline;
        private System.Windows.Forms.Label labelProgressBar;
        public Main_Form()
        {
            InitializeComponent();
        }

        private void BrowseInput_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openFileDialog.FileName;
                }
            }
        }

        private void BrowseOutput_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = saveFileDialog.FileName;
                }
            }
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || !System.IO.File.Exists(textBox1.Text))
            {
                MessageBox.Show("Please select a valid input XML file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please select an output path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            label3.Text = "Status: Converting...";
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee; // Set Marquee style here
            progressBar1.MarqueeAnimationSpeed = 30;
            textBox3.Text = "Starting conversion...\r\n";

            try
            {
                var doc = XDocument.Load(textBox1.Text);
                var things = doc.Descendants("ThingSaveData").Cast<object>().ToList();
                DestinationExport.TransformToNewSchema(things, textBox2.Text, textBox3);
                textBox3.AppendText("Conversion completed successfully.\r\n");
            }
            catch (Exception ex)
            {
                textBox3.AppendText($"Error: {ex.Message}\r\n");
            }

            label3.Text = "Status: Ready";
            progressBar1.Style = ProgressBarStyle.Continuous; // Reset style
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Visible = false; // Hide after completion
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close(); // Closes the form
            Application.Exit(); // Ensures the application terminates
        }
    }

}
