using System.Drawing;
using System.Windows.Forms;
namespace StationeersStructureXMLConverter
{
    partial class ConversionUserControl
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConversionUserControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.tableLayoutPanelPaths = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.ItemFilters_TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.WorldTypeOptions_GroupBox = new System.Windows.Forms.GroupBox();
            this.comboBoxLabel = new System.Windows.Forms.Label();
            this.VanillaWorld_CheckBox = new System.Windows.Forms.CheckBox();
            this.LocalMod_CheckBox = new System.Windows.Forms.CheckBox();
            this.None_CheckBox = new System.Windows.Forms.CheckBox();
            this.WorldSelection_ComboBox = new System.Windows.Forms.ComboBox();
            this.ItemFilters_GroupBox = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.Filter5_CheckBox = new System.Windows.Forms.CheckBox();
            this.Filter6_CheckBox = new System.Windows.Forms.CheckBox();
            this.Right_GroupBox = new System.Windows.Forms.GroupBox();
            this.configureOutputsButton = new System.Windows.Forms.Button();
            this.configureOutputsLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelPaths.SuspendLayout();
            this.ItemFilters_TableLayout.SuspendLayout();
            this.WorldTypeOptions_GroupBox.SuspendLayout();
            this.ItemFilters_GroupBox.SuspendLayout();
            this.Right_GroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelInstructions, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelPaths, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ItemFilters_TableLayout, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelButtons, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MaximumSize = new System.Drawing.Size(1280, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1280, 874);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelInstructions
            // 
            this.labelInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInstructions.AutoSize = true;
            this.labelInstructions.Location = new System.Drawing.Point(0, 10);
            this.labelInstructions.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(1280, 13);
            this.labelInstructions.TabIndex = 0;
            this.labelInstructions.Text = resources.GetString("labelInstructions.Text");
            this.labelInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelPaths
            // 
            this.tableLayoutPanelPaths.ColumnCount = 3;
            this.tableLayoutPanelPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanelPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanelPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelPaths.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelPaths.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanelPaths.Controls.Add(this.button2, 2, 0);
            this.tableLayoutPanelPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPaths.Location = new System.Drawing.Point(3, 36);
            this.tableLayoutPanelPaths.Name = "tableLayoutPanelPaths";
            this.tableLayoutPanelPaths.RowCount = 1;
            this.tableLayoutPanelPaths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPaths.Size = new System.Drawing.Size(1274, 50);
            this.tableLayoutPanelPaths.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saved Game Path";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(150, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0, 5, 4, 5);
            this.textBox1.MinimumSize = new System.Drawing.Size(300, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(723, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(887, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Browse Saves";
            this.toolTip1.SetToolTip(this.button2, "Select the .save file to convert.");
            this.button2.Click += new System.EventHandler(this.BrowseInput_Click);
            // 
            // ItemFilters_TableLayout
            // 
            this.ItemFilters_TableLayout.ColumnCount = 3;
            this.ItemFilters_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 497F));
            this.ItemFilters_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 316F));
            this.ItemFilters_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 467F));
            this.ItemFilters_TableLayout.Controls.Add(this.WorldTypeOptions_GroupBox, 0, 0);
            this.ItemFilters_TableLayout.Controls.Add(this.ItemFilters_GroupBox, 1, 0);
            this.ItemFilters_TableLayout.Controls.Add(this.Right_GroupBox, 2, 0);
            this.ItemFilters_TableLayout.Location = new System.Drawing.Point(0, 92);
            this.ItemFilters_TableLayout.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ItemFilters_TableLayout.Name = "ItemFilters_TableLayout";
            this.ItemFilters_TableLayout.RowCount = 1;
            this.ItemFilters_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ItemFilters_TableLayout.Size = new System.Drawing.Size(1277, 200);
            this.ItemFilters_TableLayout.TabIndex = 6;
            // 
            // WorldTypeOptions_GroupBox
            // 
            this.WorldTypeOptions_GroupBox.Controls.Add(this.comboBoxLabel);
            this.WorldTypeOptions_GroupBox.Controls.Add(this.VanillaWorld_CheckBox);
            this.WorldTypeOptions_GroupBox.Controls.Add(this.LocalMod_CheckBox);
            this.WorldTypeOptions_GroupBox.Controls.Add(this.None_CheckBox);
            this.WorldTypeOptions_GroupBox.Controls.Add(this.WorldSelection_ComboBox);
            this.WorldTypeOptions_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorldTypeOptions_GroupBox.Location = new System.Drawing.Point(4, 5);
            this.WorldTypeOptions_GroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WorldTypeOptions_GroupBox.Name = "WorldTypeOptions_GroupBox";
            this.WorldTypeOptions_GroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WorldTypeOptions_GroupBox.Size = new System.Drawing.Size(489, 190);
            this.WorldTypeOptions_GroupBox.TabIndex = 4;
            this.WorldTypeOptions_GroupBox.TabStop = false;
            this.WorldTypeOptions_GroupBox.Text = "World Type Options";
            // 
            // comboBoxLabel
            // 
            this.comboBoxLabel.AutoSize = true;
            this.comboBoxLabel.Location = new System.Drawing.Point(112, 168);
            this.comboBoxLabel.Name = "comboBoxLabel";
            this.comboBoxLabel.Size = new System.Drawing.Size(370, 13);
            this.comboBoxLabel.TabIndex = 4;
            this.comboBoxLabel.Text = "^This is the world that will be used as the base for the new Scenario/Tutorial.";
            // 
            // VanillaWorld_CheckBox
            // 
            this.VanillaWorld_CheckBox.AutoSize = true;
            this.VanillaWorld_CheckBox.Location = new System.Drawing.Point(12, 25);
            this.VanillaWorld_CheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.VanillaWorld_CheckBox.Name = "VanillaWorld_CheckBox";
            this.VanillaWorld_CheckBox.Size = new System.Drawing.Size(88, 17);
            this.VanillaWorld_CheckBox.TabIndex = 0;
            this.VanillaWorld_CheckBox.Text = "Vanilla World";
            this.VanillaWorld_CheckBox.UseVisualStyleBackColor = true;
            // 
            // LocalMod_CheckBox
            // 
            this.LocalMod_CheckBox.AutoSize = true;
            this.LocalMod_CheckBox.Location = new System.Drawing.Point(12, 55);
            this.LocalMod_CheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LocalMod_CheckBox.Name = "LocalMod_CheckBox";
            this.LocalMod_CheckBox.Size = new System.Drawing.Size(76, 17);
            this.LocalMod_CheckBox.TabIndex = 1;
            this.LocalMod_CheckBox.Text = "Local Mod";
            this.LocalMod_CheckBox.UseVisualStyleBackColor = true;
            // 
            // None_CheckBox
            // 
            this.None_CheckBox.AutoSize = true;
            this.None_CheckBox.Location = new System.Drawing.Point(12, 85);
            this.None_CheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.None_CheckBox.Name = "None_CheckBox";
            this.None_CheckBox.Size = new System.Drawing.Size(52, 17);
            this.None_CheckBox.TabIndex = 2;
            this.None_CheckBox.Text = "None";
            this.None_CheckBox.UseVisualStyleBackColor = true;
            // 
            // WorldSelection_ComboBox
            // 
            this.WorldSelection_ComboBox.FormattingEnabled = true;
            this.WorldSelection_ComboBox.Location = new System.Drawing.Point(115, 142);
            this.WorldSelection_ComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WorldSelection_ComboBox.Name = "WorldSelection_ComboBox";
            this.WorldSelection_ComboBox.Size = new System.Drawing.Size(200, 21);
            this.WorldSelection_ComboBox.TabIndex = 3;
            this.toolTip1.SetToolTip(this.WorldSelection_ComboBox, "Select a world folder to copy for the new world linked to SpawnGroup.xml.");
            // 
            // ItemFilters_GroupBox
            // 
            this.ItemFilters_GroupBox.Controls.Add(this.checkBox2);
            this.ItemFilters_GroupBox.Controls.Add(this.checkBox1);
            this.ItemFilters_GroupBox.Controls.Add(this.checkBox3);
            this.ItemFilters_GroupBox.Controls.Add(this.Filter5_CheckBox);
            this.ItemFilters_GroupBox.Controls.Add(this.Filter6_CheckBox);
            this.ItemFilters_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemFilters_GroupBox.Location = new System.Drawing.Point(501, 5);
            this.ItemFilters_GroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ItemFilters_GroupBox.Name = "ItemFilters_GroupBox";
            this.ItemFilters_GroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ItemFilters_GroupBox.Size = new System.Drawing.Size(308, 190);
            this.ItemFilters_GroupBox.TabIndex = 5;
            this.ItemFilters_GroupBox.TabStop = false;
            this.ItemFilters_GroupBox.Text = "Item Filters";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 62);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(113, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Exclude Character";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 27);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(163, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Exclude LanderCapsuleSmall";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(12, 97);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(140, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Exclude Supply Landers";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // Filter5_CheckBox
            // 
            this.Filter5_CheckBox.AutoSize = true;
            this.Filter5_CheckBox.Location = new System.Drawing.Point(12, 132);
            this.Filter5_CheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Filter5_CheckBox.Name = "Filter5_CheckBox";
            this.Filter5_CheckBox.Size = new System.Drawing.Size(140, 17);
            this.Filter5_CheckBox.TabIndex = 3;
            this.Filter5_CheckBox.Text = "Exclude loose Ore Items";
            this.Filter5_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Filter6_CheckBox
            // 
            this.Filter6_CheckBox.AutoSize = true;
            this.Filter6_CheckBox.Location = new System.Drawing.Point(12, 167);
            this.Filter6_CheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Filter6_CheckBox.Name = "Filter6_CheckBox";
            this.Filter6_CheckBox.Size = new System.Drawing.Size(132, 17);
            this.Filter6_CheckBox.TabIndex = 4;
            this.Filter6_CheckBox.Text = "Exclude loose ItemKits";
            this.Filter6_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Right_GroupBox
            // 
            this.Right_GroupBox.Controls.Add(this.configureOutputsButton);
            this.Right_GroupBox.Controls.Add(this.configureOutputsLabel);
            this.Right_GroupBox.Location = new System.Drawing.Point(817, 5);
            this.Right_GroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Right_GroupBox.MinimumSize = new System.Drawing.Size(460, 190);
            this.Right_GroupBox.Name = "Right_GroupBox";
            this.Right_GroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 7, 5);
            this.Right_GroupBox.Size = new System.Drawing.Size(460, 190);
            this.Right_GroupBox.TabIndex = 6;
            this.Right_GroupBox.TabStop = false;
            this.Right_GroupBox.Text = "Mod Creation Options";
            // 
            // configureOutputsButton
            // 
            this.configureOutputsButton.AutoSize = true;
            this.configureOutputsButton.Enabled = false;
            this.configureOutputsButton.Location = new System.Drawing.Point(12, 23);
            this.configureOutputsButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.configureOutputsButton.Name = "configureOutputsButton";
            this.configureOutputsButton.Size = new System.Drawing.Size(178, 30);
            this.configureOutputsButton.TabIndex = 0;
            this.configureOutputsButton.Text = "Configure File Outputs";
            this.toolTip1.SetToolTip(this.configureOutputsButton, "Open a form to configure mod creation settings.");
            this.configureOutputsButton.UseVisualStyleBackColor = true;
            this.configureOutputsButton.Click += new System.EventHandler(this.ConfigureOutputs_Click);
            // 
            // configureOutputsLabel
            // 
            this.configureOutputsLabel.AutoSize = true;
            this.configureOutputsLabel.Location = new System.Drawing.Point(12, 55);
            this.configureOutputsLabel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.configureOutputsLabel.Name = "configureOutputsLabel";
            this.configureOutputsLabel.Size = new System.Drawing.Size(266, 13);
            this.configureOutputsLabel.TabIndex = 1;
            this.configureOutputsLabel.Text = "(Only applies if Vanilla World or Local Mod is checked.)";
            this.toolTip1.SetToolTip(this.configureOutputsLabel, "This button is enabled only when Vanilla World or Local Mod is selected.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 299);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 317);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1272, 514);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conversion Log";
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(4, 18);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(1264, 491);
            this.textBox3.TabIndex = 0;
            // 
            // tableLayoutPanelButtons
            // 
            this.tableLayoutPanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelButtons.ColumnCount = 2;
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelButtons.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanelButtons.Controls.Add(this.button4, 1, 0);
            this.tableLayoutPanelButtons.Location = new System.Drawing.Point(1064, 839);
            this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            this.tableLayoutPanelButtons.RowCount = 1;
            this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelButtons.Size = new System.Drawing.Size(213, 32);
            this.tableLayoutPanelButtons.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(4, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 22);
            this.button1.TabIndex = 7;
            this.button1.Text = "Convert";
            this.toolTip1.SetToolTip(this.button1, "Convert the input XML to the output format.");
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.Location = new System.Drawing.Point(110, 5);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 10, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 22);
            this.button4.TabIndex = 12;
            this.button4.Text = "Close";
            this.toolTip1.SetToolTip(this.button4, "Close the application.");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // ConversionUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ConversionUserControl";
            this.Size = new System.Drawing.Size(1280, 874);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanelPaths.ResumeLayout(false);
            this.tableLayoutPanelPaths.PerformLayout();
            this.ItemFilters_TableLayout.ResumeLayout(false);
            this.WorldTypeOptions_GroupBox.ResumeLayout(false);
            this.WorldTypeOptions_GroupBox.PerformLayout();
            this.ItemFilters_GroupBox.ResumeLayout(false);
            this.ItemFilters_GroupBox.PerformLayout();
            this.Right_GroupBox.ResumeLayout(false);
            this.Right_GroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanelButtons.ResumeLayout(false);
            this.tableLayoutPanelButtons.PerformLayout();
            this.ResumeLayout(false);

        }
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
    }
}