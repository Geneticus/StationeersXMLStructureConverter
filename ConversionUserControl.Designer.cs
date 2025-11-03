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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConversionUserControl));
            tableLayoutPanel1 = new TableLayoutPanel();
            labelInstructions = new Label();
            tableLayoutPanelPaths = new TableLayoutPanel();
            label1 = new Label();
            textBox1 = new TextBox();
            button2 = new Button();
            ItemFilters_TableLayout = new TableLayoutPanel();
            WorldTypeOptions_GroupBox = new GroupBox();
            WorldTypeOptions_MainPanel = new TableLayoutPanel();
            WorldSelection_UpperPanel = new TableLayoutPanel();
            VanillaWorld_CheckBox = new CheckBox();
            WorldSelection_ComboBox = new ComboBox();
            LocalMod_CheckBox = new CheckBox();
            comboBoxLabel = new Label();
            WorldSelection_LowerPanel = new TableLayoutPanel();
            None_CheckBox = new CheckBox();
            txtSpawnId = new TextBox();
            lblSpawnId = new Label();
            ItemFilters_GroupBox = new GroupBox();
            itemFiltersPanel = new TableLayoutPanel();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            Filter5_CheckBox = new CheckBox();
            Filter6_CheckBox = new CheckBox();
            chkCheckAll = new CheckBox();
            Right_GroupBox = new GroupBox();
            configureOutputsButton = new Button();
            configureOutputsLabel = new Label();
            label3 = new Label();
            groupBox2 = new GroupBox();
            textBox3 = new TextBox();
            tableLayoutPanelButtons = new TableLayoutPanel();
            button1 = new Button();
            button4 = new Button();
            toolTip1 = new ToolTip(components);
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanelPaths.SuspendLayout();
            ItemFilters_TableLayout.SuspendLayout();
            WorldTypeOptions_GroupBox.SuspendLayout();
            WorldTypeOptions_MainPanel.SuspendLayout();
            WorldSelection_UpperPanel.SuspendLayout();
            WorldSelection_LowerPanel.SuspendLayout();
            ItemFilters_GroupBox.SuspendLayout();
            itemFiltersPanel.SuspendLayout();
            Right_GroupBox.SuspendLayout();
            groupBox2.SuspendLayout();
            tableLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(labelInstructions, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanelPaths, 0, 1);
            tableLayoutPanel1.Controls.Add(ItemFilters_TableLayout, 0, 2);
            tableLayoutPanel1.Controls.Add(label3, 0, 3);
            tableLayoutPanel1.Controls.Add(groupBox2, 0, 4);
            tableLayoutPanel1.Controls.Add(tableLayoutPanelButtons, 0, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(5, 6, 5, 6);
            tableLayoutPanel1.MaximumSize = new Size(2133, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 422F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(2133, 1681);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // labelInstructions
            // 
            labelInstructions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelInstructions.AutoSize = true;
            labelInstructions.Location = new Point(0, 19);
            labelInstructions.Margin = new Padding(0, 19, 0, 19);
            labelInstructions.Name = "labelInstructions";
            labelInstructions.Size = new Size(2133, 25);
            labelInstructions.TabIndex = 0;
            labelInstructions.Text = resources.GetString("labelInstructions.Text");
            labelInstructions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelPaths
            // 
            tableLayoutPanelPaths.ColumnCount = 3;
            tableLayoutPanelPaths.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tableLayoutPanelPaths.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            tableLayoutPanelPaths.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanelPaths.Controls.Add(label1, 0, 0);
            tableLayoutPanelPaths.Controls.Add(textBox1, 1, 0);
            tableLayoutPanelPaths.Controls.Add(button2, 2, 0);
            tableLayoutPanelPaths.Dock = DockStyle.Fill;
            tableLayoutPanelPaths.Location = new Point(5, 69);
            tableLayoutPanelPaths.Margin = new Padding(5, 6, 5, 6);
            tableLayoutPanelPaths.Name = "tableLayoutPanelPaths";
            tableLayoutPanelPaths.RowCount = 1;
            tableLayoutPanelPaths.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelPaths.Size = new Size(2123, 96);
            tableLayoutPanelPaths.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 10);
            label1.Margin = new Padding(17, 10, 0, 10);
            label1.Name = "label1";
            label1.Size = new Size(150, 25);
            label1.TabIndex = 0;
            label1.Text = "Saved Game Path";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(250, 10);
            textBox1.Margin = new Padding(0, 10, 7, 10);
            textBox1.MinimumSize = new Size(497, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(1204, 31);
            textBox1.TabIndex = 1;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.Location = new Point(1478, 10);
            button2.Margin = new Padding(17, 10, 0, 10);
            button2.Name = "button2";
            button2.Size = new Size(215, 35);
            button2.TabIndex = 2;
            button2.Text = "Browse Saves";
            toolTip1.SetToolTip(button2, "Select the .save file to convert.");
            button2.Click += BrowseInput_Click;
            // 
            // ItemFilters_TableLayout
            // 
            ItemFilters_TableLayout.ColumnCount = 3;
            ItemFilters_TableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 842F));
            ItemFilters_TableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 685F));
            ItemFilters_TableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ItemFilters_TableLayout.Controls.Add(WorldTypeOptions_GroupBox, 0, 0);
            ItemFilters_TableLayout.Controls.Add(ItemFilters_GroupBox, 1, 0);
            ItemFilters_TableLayout.Controls.Add(Right_GroupBox, 2, 0);
            ItemFilters_TableLayout.Location = new Point(0, 177);
            ItemFilters_TableLayout.Margin = new Padding(0, 6, 5, 6);
            ItemFilters_TableLayout.Name = "ItemFilters_TableLayout";
            ItemFilters_TableLayout.RowCount = 1;
            ItemFilters_TableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            ItemFilters_TableLayout.Size = new Size(2128, 385);
            ItemFilters_TableLayout.TabIndex = 6;
            // 
            // WorldTypeOptions_GroupBox
            // 
            WorldTypeOptions_GroupBox.Controls.Add(WorldTypeOptions_MainPanel);
            WorldTypeOptions_GroupBox.Dock = DockStyle.Fill;
            WorldTypeOptions_GroupBox.Location = new Point(7, 10);
            WorldTypeOptions_GroupBox.Margin = new Padding(7, 10, 7, 10);
            WorldTypeOptions_GroupBox.Name = "WorldTypeOptions_GroupBox";
            WorldTypeOptions_GroupBox.Padding = new Padding(7, 10, 7, 10);
            WorldTypeOptions_GroupBox.Size = new Size(828, 365);
            WorldTypeOptions_GroupBox.TabIndex = 4;
            WorldTypeOptions_GroupBox.TabStop = false;
            WorldTypeOptions_GroupBox.Text = "World Type Options";
            // 
            // WorldTypeOptions_MainPanel
            // 
            WorldTypeOptions_MainPanel.AutoSize = true;
            WorldTypeOptions_MainPanel.ColumnCount = 1;
            WorldTypeOptions_MainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            WorldTypeOptions_MainPanel.Controls.Add(WorldSelection_UpperPanel, 0, 0);
            WorldTypeOptions_MainPanel.Controls.Add(WorldSelection_LowerPanel, 0, 1);
            WorldTypeOptions_MainPanel.Dock = DockStyle.Fill;
            WorldTypeOptions_MainPanel.Location = new Point(7, 34);
            WorldTypeOptions_MainPanel.Name = "WorldTypeOptions_MainPanel";
            WorldTypeOptions_MainPanel.RowCount = 2;
            WorldTypeOptions_MainPanel.RowStyles.Add(new RowStyle());
            WorldTypeOptions_MainPanel.RowStyles.Add(new RowStyle());
            WorldTypeOptions_MainPanel.Size = new Size(814, 321);
            WorldTypeOptions_MainPanel.TabIndex = 0;
            // 
            // WorldSelection_UpperPanel
            // 
            WorldSelection_UpperPanel.AutoSize = true;
            WorldSelection_UpperPanel.ColumnCount = 2;
            WorldSelection_UpperPanel.ColumnStyles.Add(new ColumnStyle());
            WorldSelection_UpperPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            WorldSelection_UpperPanel.Controls.Add(VanillaWorld_CheckBox, 0, 0);
            WorldSelection_UpperPanel.Controls.Add(WorldSelection_ComboBox, 1, 0);
            WorldSelection_UpperPanel.Controls.Add(LocalMod_CheckBox, 0, 1);
            WorldSelection_UpperPanel.Controls.Add(comboBoxLabel, 1, 1);
            WorldSelection_UpperPanel.Dock = DockStyle.Top;
            WorldSelection_UpperPanel.Location = new Point(10, 10);
            WorldSelection_UpperPanel.Margin = new Padding(10, 10, 10, 0);
            WorldSelection_UpperPanel.Name = "WorldSelection_UpperPanel";
            WorldSelection_UpperPanel.RowCount = 2;
            WorldSelection_UpperPanel.RowStyles.Add(new RowStyle());
            WorldSelection_UpperPanel.RowStyles.Add(new RowStyle());
            WorldSelection_UpperPanel.Size = new Size(794, 102);
            WorldSelection_UpperPanel.TabIndex = 0;
            // 
            // VanillaWorld_CheckBox
            // 
            VanillaWorld_CheckBox.AutoSize = true;
            VanillaWorld_CheckBox.Location = new Point(7, 10);
            VanillaWorld_CheckBox.Margin = new Padding(7, 10, 7, 10);
            VanillaWorld_CheckBox.Name = "VanillaWorld_CheckBox";
            VanillaWorld_CheckBox.Size = new Size(141, 29);
            VanillaWorld_CheckBox.TabIndex = 0;
            VanillaWorld_CheckBox.Text = "Vanilla World";
            VanillaWorld_CheckBox.UseVisualStyleBackColor = true;
            // 
            // WorldSelection_ComboBox
            // 
            WorldSelection_ComboBox.FormattingEnabled = true;
            WorldSelection_ComboBox.Location = new Point(162, 10);
            WorldSelection_ComboBox.Margin = new Padding(7, 10, 7, 10);
            WorldSelection_ComboBox.Name = "WorldSelection_ComboBox";
            WorldSelection_ComboBox.Size = new Size(331, 33);
            WorldSelection_ComboBox.TabIndex = 3;
            toolTip1.SetToolTip(WorldSelection_ComboBox, "Select a world folder to copy for the new world linked to SpawnGroup.xml.");
            // 
            // LocalMod_CheckBox
            // 
            LocalMod_CheckBox.AutoSize = true;
            LocalMod_CheckBox.Location = new Point(7, 63);
            LocalMod_CheckBox.Margin = new Padding(7, 10, 7, 10);
            LocalMod_CheckBox.Name = "LocalMod_CheckBox";
            LocalMod_CheckBox.Size = new Size(121, 29);
            LocalMod_CheckBox.TabIndex = 1;
            LocalMod_CheckBox.Text = "Local Mod";
            LocalMod_CheckBox.UseVisualStyleBackColor = true;
            // 
            // comboBoxLabel
            // 
            comboBoxLabel.AutoSize = true;
            comboBoxLabel.Location = new Point(160, 53);
            comboBoxLabel.Margin = new Padding(5, 0, 5, 0);
            comboBoxLabel.Name = "comboBoxLabel";
            comboBoxLabel.Size = new Size(617, 25);
            comboBoxLabel.TabIndex = 4;
            comboBoxLabel.Text = "^This is the world that will be used as the base for the new Scenario/Tutorial.";
            // 
            // WorldSelection_LowerPanel
            // 
            WorldSelection_LowerPanel.ColumnCount = 2;
            WorldSelection_LowerPanel.ColumnStyles.Add(new ColumnStyle());
            WorldSelection_LowerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            WorldSelection_LowerPanel.Controls.Add(None_CheckBox, 0, 0);
            WorldSelection_LowerPanel.Controls.Add(txtSpawnId, 1, 0);
            WorldSelection_LowerPanel.Controls.Add(lblSpawnId, 1, 1);
            WorldSelection_LowerPanel.Location = new Point(10, 122);
            WorldSelection_LowerPanel.Margin = new Padding(10, 10, 10, 0);
            WorldSelection_LowerPanel.Name = "WorldSelection_LowerPanel";
            WorldSelection_LowerPanel.RowCount = 2;
            WorldSelection_LowerPanel.RowStyles.Add(new RowStyle());
            WorldSelection_LowerPanel.RowStyles.Add(new RowStyle());
            WorldSelection_LowerPanel.Size = new Size(794, 94);
            WorldSelection_LowerPanel.TabIndex = 1;
            // 
            // None_CheckBox
            // 
            None_CheckBox.Location = new Point(7, 10);
            None_CheckBox.Margin = new Padding(7, 10, 7, 10);
            None_CheckBox.Name = "None_CheckBox";
            None_CheckBox.Size = new Size(150, 29);
            None_CheckBox.TabIndex = 2;
            None_CheckBox.Text = "None";
            None_CheckBox.UseVisualStyleBackColor = true;
            // 
            // txtSpawnId
            // 
            txtSpawnId.Location = new Point(167, 3);
            txtSpawnId.Name = "txtSpawnId";
            txtSpawnId.Size = new Size(333, 31);
            txtSpawnId.TabIndex = 1;
            // 
            // lblSpawnId
            // 
            lblSpawnId.AutoSize = true;
            lblSpawnId.Location = new Point(167, 49);
            lblSpawnId.Name = "lblSpawnId";
            lblSpawnId.Size = new Size(444, 25);
            lblSpawnId.TabIndex = 3;
            lblSpawnId.Text = "Custom Spawn ID (If None is checked. Default if blank)";
            // 
            // ItemFilters_GroupBox
            // 
            ItemFilters_GroupBox.Controls.Add(itemFiltersPanel);
            ItemFilters_GroupBox.Dock = DockStyle.Fill;
            ItemFilters_GroupBox.Location = new Point(849, 5);
            ItemFilters_GroupBox.Margin = new Padding(7, 5, 7, 5);
            ItemFilters_GroupBox.Name = "ItemFilters_GroupBox";
            ItemFilters_GroupBox.Padding = new Padding(7, 5, 7, 5);
            ItemFilters_GroupBox.Size = new Size(671, 375);
            ItemFilters_GroupBox.TabIndex = 5;
            ItemFilters_GroupBox.TabStop = false;
            ItemFilters_GroupBox.Text = "Item Filters";
            // 
            // itemFiltersPanel
            // 
            itemFiltersPanel.AutoSize = true;
            itemFiltersPanel.ColumnCount = 1;
            itemFiltersPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            itemFiltersPanel.Controls.Add(checkBox1, 0, 0);
            itemFiltersPanel.Controls.Add(checkBox2, 0, 1);
            itemFiltersPanel.Controls.Add(checkBox3, 0, 2);
            itemFiltersPanel.Controls.Add(Filter5_CheckBox, 0, 3);
            itemFiltersPanel.Controls.Add(Filter6_CheckBox, 0, 4);
            itemFiltersPanel.Controls.Add(chkCheckAll, 0, 5);
            itemFiltersPanel.Dock = DockStyle.Fill;
            itemFiltersPanel.Location = new Point(7, 29);
            itemFiltersPanel.Margin = new Padding(10, 15, 10, 5);
            itemFiltersPanel.Name = "itemFiltersPanel";
            itemFiltersPanel.RowCount = 6;
            itemFiltersPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            itemFiltersPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            itemFiltersPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            itemFiltersPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            itemFiltersPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            itemFiltersPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            itemFiltersPanel.Size = new Size(657, 341);
            itemFiltersPanel.TabIndex = 0;
            // 
            // checkBox1
            // 
            checkBox1.Location = new Point(0, 0);
            checkBox1.Margin = new Padding(0, 0, 0, 2);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(260, 29);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Exclude LanderCapsuleSmall";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.Location = new Point(0, 40);
            checkBox2.Margin = new Padding(0, 0, 0, 2);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(176, 29);
            checkBox2.TabIndex = 1;
            checkBox2.Text = "Exclude Character";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.Location = new Point(0, 80);
            checkBox3.Margin = new Padding(0, 0, 0, 2);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(223, 29);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "Exclude Supply Landers";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // Filter5_CheckBox
            // 
            Filter5_CheckBox.Location = new Point(0, 120);
            Filter5_CheckBox.Margin = new Padding(0, 0, 0, 2);
            Filter5_CheckBox.Name = "Filter5_CheckBox";
            Filter5_CheckBox.Size = new Size(228, 29);
            Filter5_CheckBox.TabIndex = 3;
            Filter5_CheckBox.Text = "Exclude loose Ore Items";
            Filter5_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Filter6_CheckBox
            // 
            Filter6_CheckBox.Location = new Point(0, 160);
            Filter6_CheckBox.Margin = new Padding(0, 0, 0, 2);
            Filter6_CheckBox.Name = "Filter6_CheckBox";
            Filter6_CheckBox.Size = new Size(214, 29);
            Filter6_CheckBox.TabIndex = 4;
            Filter6_CheckBox.Text = "Exclude loose ItemKits";
            Filter6_CheckBox.UseVisualStyleBackColor = true;
            // 
            // chkCheckAll
            // 
            chkCheckAll.AutoSize = true;
            chkCheckAll.Location = new Point(0, 200);
            chkCheckAll.Margin = new Padding(0, 0, 0, 2);
            chkCheckAll.Name = "chkCheckAll";
            chkCheckAll.Size = new Size(110, 29);
            chkCheckAll.TabIndex = 5;
            chkCheckAll.Text = "Check All";
            // 
            // Right_GroupBox
            // 
            Right_GroupBox.Controls.Add(configureOutputsButton);
            Right_GroupBox.Controls.Add(configureOutputsLabel);
            Right_GroupBox.Location = new Point(1534, 10);
            Right_GroupBox.Margin = new Padding(7, 10, 7, 10);
            Right_GroupBox.MinimumSize = new Size(767, 365);
            Right_GroupBox.Name = "Right_GroupBox";
            Right_GroupBox.Padding = new Padding(7, 10, 12, 10);
            Right_GroupBox.Size = new Size(767, 365);
            Right_GroupBox.TabIndex = 6;
            Right_GroupBox.TabStop = false;
            Right_GroupBox.Text = "Mod Creation Options";
            // 
            // configureOutputsButton
            // 
            configureOutputsButton.AutoSize = true;
            configureOutputsButton.Enabled = false;
            configureOutputsButton.Location = new Point(20, 44);
            configureOutputsButton.Margin = new Padding(3, 6, 3, 6);
            configureOutputsButton.Name = "configureOutputsButton";
            configureOutputsButton.Size = new Size(230, 35);
            configureOutputsButton.TabIndex = 0;
            configureOutputsButton.Text = "Configure File Outputs";
            toolTip1.SetToolTip(configureOutputsButton, "Open a form to configure mod creation settings.");
            configureOutputsButton.UseVisualStyleBackColor = true;
            configureOutputsButton.Click += ConfigureOutputs_Click;
            // 
            // configureOutputsLabel
            // 
            configureOutputsLabel.AutoSize = true;
            configureOutputsLabel.Location = new Point(20, 106);
            configureOutputsLabel.Margin = new Padding(3, 6, 3, 6);
            configureOutputsLabel.Name = "configureOutputsLabel";
            configureOutputsLabel.Size = new Size(443, 25);
            configureOutputsLabel.TabIndex = 1;
            configureOutputsLabel.Text = "(Only applies if Vanilla World or Local Mod is checked.)";
            toolTip1.SetToolTip(configureOutputsLabel, "This button is enabled only when Vanilla World or Local Mod is selected.");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 593);
            label3.Margin = new Padding(7, 0, 7, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 25);
            label3.TabIndex = 9;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox3);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(7, 628);
            groupBox2.Margin = new Padding(7, 10, 7, 10);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(7, 10, 7, 10);
            groupBox2.Size = new Size(2119, 969);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Conversion Log";
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(7, 34);
            textBox3.Margin = new Padding(7, 10, 7, 10);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ScrollBars = ScrollBars.Vertical;
            textBox3.Size = new Size(2105, 925);
            textBox3.TabIndex = 0;
            // 
            // tableLayoutPanelButtons
            // 
            tableLayoutPanelButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tableLayoutPanelButtons.ColumnCount = 2;
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelButtons.Controls.Add(button1, 0, 0);
            tableLayoutPanelButtons.Controls.Add(button4, 1, 0);
            tableLayoutPanelButtons.Location = new Point(1773, 1613);
            tableLayoutPanelButtons.Margin = new Padding(5, 6, 5, 6);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelButtons.Size = new Size(355, 62);
            tableLayoutPanelButtons.TabIndex = 13;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Location = new Point(7, 10);
            button1.Margin = new Padding(7, 10, 7, 10);
            button1.Name = "button1";
            button1.Size = new Size(163, 42);
            button1.TabIndex = 7;
            button1.Text = "Convert";
            toolTip1.SetToolTip(button1, "Convert the input XML to the output format.");
            // 
            // button4
            // 
            button4.AutoSize = true;
            button4.Location = new Point(184, 10);
            button4.Margin = new Padding(7, 10, 17, 10);
            button4.Name = "button4";
            button4.Size = new Size(154, 42);
            button4.TabIndex = 12;
            button4.Text = "Close";
            toolTip1.SetToolTip(button4, "Close the application.");
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 100;
            // 
            // ConversionUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(5, 6, 5, 6);
            Name = "ConversionUserControl";
            Size = new Size(2133, 1681);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanelPaths.ResumeLayout(false);
            tableLayoutPanelPaths.PerformLayout();
            ItemFilters_TableLayout.ResumeLayout(false);
            WorldTypeOptions_GroupBox.ResumeLayout(false);
            WorldTypeOptions_GroupBox.PerformLayout();
            WorldTypeOptions_MainPanel.ResumeLayout(false);
            WorldTypeOptions_MainPanel.PerformLayout();
            WorldSelection_UpperPanel.ResumeLayout(false);
            WorldSelection_UpperPanel.PerformLayout();
            WorldSelection_LowerPanel.ResumeLayout(false);
            WorldSelection_LowerPanel.PerformLayout();
            ItemFilters_GroupBox.ResumeLayout(false);
            ItemFilters_GroupBox.PerformLayout();
            itemFiltersPanel.ResumeLayout(false);
            itemFiltersPanel.PerformLayout();
            Right_GroupBox.ResumeLayout(false);
            Right_GroupBox.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            tableLayoutPanelButtons.ResumeLayout(false);
            tableLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
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
        private TableLayoutPanel WorldTypeOptions_MainPanel;
        private TableLayoutPanel WorldSelection_UpperPanel;
        private TableLayoutPanel WorldSelection_LowerPanel;
        private TextBox txtSpawnId;
        private Label lblSpawnId;
        private System.Windows.Forms.CheckBox chkCheckAll;
        private TableLayoutPanel itemFiltersPanel;
    }
}