using System;
using System.Drawing;
using System.Windows.Forms;

namespace StationeersStructureXMLConverter
{
    public partial class ModConfigForm : Form
    {
        private System.Windows.Forms.TextBox modNameTextBox;
        private System.Windows.Forms.TextBox worldNameTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox summaryTextBox;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.ToolTip toolTip;
        public string ModName => modNameTextBox.Text.Trim();
        public string WorldName => worldNameTextBox.Text.Trim();
        public string Description => descriptionTextBox.Text.Trim();
        public string Summary => summaryTextBox.Text.Trim();

        private System.Windows.Forms.Button configureOutputsButton;
        private string modName = "";
        private string worldName = "";
        private string description = "";
        private string summary = "";

        public ModConfigForm()
        {
            InitializeComponent();
            this.doneButton.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
        }



    }
}
