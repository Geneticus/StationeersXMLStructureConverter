using System.Drawing;
using System.Windows.Forms;

namespace StationeersStructureXMLConverter
{
    partial class WorldEditorUserControl
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
            scrollPanel = new Panel();
            outerTableLayout = new TableLayoutPanel();
            modPathTableLayout = new TableLayoutPanel();
            labelModPath = new Label();
            txtModPath = new TextBox();
            btnBrowseMod = new Button();
            innerTableLayout = new TableLayoutPanel();
            column0TableLayout = new TableLayoutPanel();
            worldSettingsGroupBox = new GroupBox();
            worldSettingsTableLayout = new TableLayoutPanel();
            labelWorldId = new Label();
            txtWorldId = new TextBox();
            labelPriority = new Label();
            nudPriority = new NumericUpDown();
            labelNameKey = new Label();
            txtNameKey = new TextBox();
            labelName = new Label();
            txtNameValue = new TextBox();
            labelDescKey = new Label();
            txtDescKey = new TextBox();
            labelDescription = new Label();
            txtDescValue = new TextBox();
            labelShortDescKey = new Label();
            txtShortDescKey = new TextBox();
            labelShortDesc = new Label();
            txtShortDescValue = new TextBox();
            labelSummaryKey = new Label();
            txtSummaryKey = new TextBox();
            labelSummary = new Label();
            txtSummary = new TextBox();
            column1TableLayout = new TableLayoutPanel();
            startConditionsGroupBox = new GroupBox();
            startConditionsTableLayout = new TableLayoutPanel();
            startConditionsButtonPanel = new FlowLayoutPanel();
            btnAddCondition = new Button();
            btnDeleteCondition = new Button();
            clbStartConditions = new ListBox();
            startLocationsGroupBox = new GroupBox();
            startLocationsTableLayout = new TableLayoutPanel();
            startLocationsButtonPanel = new FlowLayoutPanel();
            btnAddLocation = new Button();
            btnDeleteLocation = new Button();
            lvStartLocations = new ListView();
            objectivesGroupBox = new GroupBox();
            objectivesTableLayout = new TableLayoutPanel();
            objectivesButtonPanel = new FlowLayoutPanel();
            btnAddObjective = new Button();
            btnDeleteObjective = new Button();
            lvObjectives = new ListView();
            tableLayoutPanelButtons = new TableLayoutPanel();
            btnClearAll = new Button();
            btnSaveWorldSettings = new Button();
            toolTip1 = new ToolTip(components);
            scrollPanel.SuspendLayout();
            outerTableLayout.SuspendLayout();
            modPathTableLayout.SuspendLayout();
            innerTableLayout.SuspendLayout();
            column0TableLayout.SuspendLayout();
            worldSettingsGroupBox.SuspendLayout();
            worldSettingsTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPriority).BeginInit();
            column1TableLayout.SuspendLayout();
            startConditionsGroupBox.SuspendLayout();
            startConditionsTableLayout.SuspendLayout();
            startConditionsButtonPanel.SuspendLayout();
            startLocationsGroupBox.SuspendLayout();
            startLocationsTableLayout.SuspendLayout();
            startLocationsButtonPanel.SuspendLayout();
            objectivesGroupBox.SuspendLayout();
            objectivesTableLayout.SuspendLayout();
            objectivesButtonPanel.SuspendLayout();
            tableLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // scrollPanel
            // 
            scrollPanel.AutoScroll = true;
            scrollPanel.Controls.Add(outerTableLayout);
            scrollPanel.Dock = DockStyle.Fill;
            scrollPanel.Location = new Point(0, 0);
            scrollPanel.Margin = new Padding(17, 19, 17, 19);
            scrollPanel.Name = "scrollPanel";
            scrollPanel.Size = new Size(2133, 1500);
            scrollPanel.TabIndex = 0;
            // 
            // outerTableLayout
            // 
            outerTableLayout.AutoSize = true;
            outerTableLayout.ColumnCount = 1;
            outerTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            outerTableLayout.Controls.Add(modPathTableLayout, 0, 0);
            outerTableLayout.Controls.Add(innerTableLayout, 0, 1);
            outerTableLayout.Controls.Add(tableLayoutPanelButtons, 0, 2);
            outerTableLayout.Location = new Point(17, 19);
            outerTableLayout.Margin = new Padding(17, 19, 17, 19);
            outerTableLayout.Name = "outerTableLayout";
            outerTableLayout.RowCount = 3;
            outerTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            outerTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            outerTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 94F));
            outerTableLayout.Size = new Size(2168, 2231);
            outerTableLayout.TabIndex = 1;
            // 
            // modPathTableLayout
            // 
            modPathTableLayout.ColumnCount = 3;
            modPathTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 112F));
            modPathTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            modPathTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            modPathTableLayout.Controls.Add(labelModPath, 0, 0);
            modPathTableLayout.Controls.Add(txtModPath, 1, 0);
            modPathTableLayout.Controls.Add(btnBrowseMod, 2, 0);
            modPathTableLayout.Dock = DockStyle.Fill;
            modPathTableLayout.Location = new Point(3, 4);
            modPathTableLayout.Margin = new Padding(3, 4, 3, 4);
            modPathTableLayout.Name = "modPathTableLayout";
            modPathTableLayout.RowCount = 1;
            modPathTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            modPathTableLayout.Size = new Size(2162, 54);
            modPathTableLayout.TabIndex = 0;
            // 
            // labelModPath
            // 
            labelModPath.AutoSize = true;
            labelModPath.Location = new Point(3, 0);
            labelModPath.Name = "labelModPath";
            labelModPath.Size = new Size(93, 25);
            labelModPath.TabIndex = 0;
            labelModPath.Text = "Mod Path:";
            // 
            // txtModPath
            // 
            txtModPath.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtModPath.Location = new Point(115, 11);
            txtModPath.Margin = new Padding(3, 4, 3, 4);
            txtModPath.Name = "txtModPath";
            txtModPath.Size = new Size(1429, 31);
            txtModPath.TabIndex = 1;
            // 
            // btnBrowseMod
            // 
            btnBrowseMod.Location = new Point(1550, 4);
            btnBrowseMod.Margin = new Padding(3, 4, 3, 4);
            btnBrowseMod.Name = "btnBrowseMod";
            btnBrowseMod.Size = new Size(112, 46);
            btnBrowseMod.TabIndex = 2;
            btnBrowseMod.Text = "Browse";
            btnBrowseMod.UseVisualStyleBackColor = true;
            btnBrowseMod.Click += btnBrowseMod_Click;
            // 
            // innerTableLayout
            // 
            innerTableLayout.AutoSize = true;
            innerTableLayout.ColumnCount = 2;
            innerTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 667F));
            innerTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            innerTableLayout.Controls.Add(column0TableLayout, 0, 0);
            innerTableLayout.Controls.Add(column1TableLayout, 1, 0);
            innerTableLayout.Location = new Point(3, 66);
            innerTableLayout.Margin = new Padding(3, 4, 3, 4);
            innerTableLayout.Name = "innerTableLayout";
            innerTableLayout.RowCount = 1;
            innerTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            innerTableLayout.Size = new Size(2158, 1976);
            innerTableLayout.TabIndex = 1;
            // 
            // column0TableLayout
            // 
            column0TableLayout.AutoSize = true;
            column0TableLayout.ColumnCount = 1;
            column0TableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            column0TableLayout.Controls.Add(worldSettingsGroupBox, 0, 0);
            column0TableLayout.Location = new Point(3, 4);
            column0TableLayout.Margin = new Padding(3, 4, 3, 4);
            column0TableLayout.Name = "column0TableLayout";
            column0TableLayout.RowCount = 1;
            column0TableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            column0TableLayout.Size = new Size(656, 1517);
            column0TableLayout.TabIndex = 2;
            // 
            // worldSettingsGroupBox
            // 
            worldSettingsGroupBox.AutoSize = true;
            worldSettingsGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            worldSettingsGroupBox.Controls.Add(worldSettingsTableLayout);
            worldSettingsGroupBox.Location = new Point(3, 4);
            worldSettingsGroupBox.Margin = new Padding(3, 4, 3, 4);
            worldSettingsGroupBox.Name = "worldSettingsGroupBox";
            worldSettingsGroupBox.Padding = new Padding(3, 4, 3, 4);
            worldSettingsGroupBox.Size = new Size(650, 1509);
            worldSettingsGroupBox.TabIndex = 4;
            worldSettingsGroupBox.TabStop = false;
            worldSettingsGroupBox.Text = "World Settings";
            // 
            // worldSettingsTableLayout
            // 
            worldSettingsTableLayout.AutoSize = true;
            worldSettingsTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            worldSettingsTableLayout.ColumnCount = 2;
            worldSettingsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 232F));
            worldSettingsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            worldSettingsTableLayout.Controls.Add(labelWorldId, 0, 0);
            worldSettingsTableLayout.Controls.Add(txtWorldId, 1, 0);
            worldSettingsTableLayout.Controls.Add(labelPriority, 0, 1);
            worldSettingsTableLayout.Controls.Add(nudPriority, 1, 1);
            worldSettingsTableLayout.Controls.Add(labelNameKey, 0, 2);
            worldSettingsTableLayout.Controls.Add(txtNameKey, 1, 2);
            worldSettingsTableLayout.Controls.Add(labelName, 0, 3);
            worldSettingsTableLayout.Controls.Add(txtNameValue, 1, 3);
            worldSettingsTableLayout.Controls.Add(labelDescKey, 0, 4);
            worldSettingsTableLayout.Controls.Add(txtDescKey, 1, 4);
            worldSettingsTableLayout.Controls.Add(labelDescription, 0, 5);
            worldSettingsTableLayout.Controls.Add(txtDescValue, 1, 5);
            worldSettingsTableLayout.Controls.Add(labelShortDescKey, 0, 6);
            worldSettingsTableLayout.Controls.Add(txtShortDescKey, 1, 6);
            worldSettingsTableLayout.Controls.Add(labelShortDesc, 0, 7);
            worldSettingsTableLayout.Controls.Add(txtShortDescValue, 1, 7);
            worldSettingsTableLayout.Controls.Add(labelSummaryKey, 0, 8);
            worldSettingsTableLayout.Controls.Add(txtSummaryKey, 1, 8);
            worldSettingsTableLayout.Controls.Add(labelSummary, 0, 9);
            worldSettingsTableLayout.Controls.Add(txtSummary, 1, 9);
            worldSettingsTableLayout.Dock = DockStyle.Fill;
            worldSettingsTableLayout.Location = new Point(3, 28);
            worldSettingsTableLayout.Margin = new Padding(3, 4, 3, 4);
            worldSettingsTableLayout.Name = "worldSettingsTableLayout";
            worldSettingsTableLayout.RowCount = 10;
            worldSettingsTableLayout.RowStyles.Add(new RowStyle());
            worldSettingsTableLayout.RowStyles.Add(new RowStyle());
            worldSettingsTableLayout.RowStyles.Add(new RowStyle());
            worldSettingsTableLayout.RowStyles.Add(new RowStyle());
            worldSettingsTableLayout.RowStyles.Add(new RowStyle());
            worldSettingsTableLayout.RowStyles.Add(new RowStyle());
            worldSettingsTableLayout.RowStyles.Add(new RowStyle());
            worldSettingsTableLayout.RowStyles.Add(new RowStyle());
            worldSettingsTableLayout.RowStyles.Add(new RowStyle());
            worldSettingsTableLayout.RowStyles.Add(new RowStyle());
            worldSettingsTableLayout.Size = new Size(644, 1673);
            worldSettingsTableLayout.TabIndex = 5;
            
            // 
            // labelWorldId
            // 
            labelWorldId.AutoSize = true;
            labelWorldId.Location = new Point(25, 38);
            labelWorldId.Margin = new Padding(25, 38, 25, 38);
            labelWorldId.Name = "labelWorldId";
            labelWorldId.Size = new Size(87, 25);
            labelWorldId.TabIndex = 6;
            labelWorldId.Text = "World ID:";
            toolTip1.SetToolTip(labelWorldId, "Must be Unique or Vanilla settings may be merged into your scenario or your scenario might alter the Vanilla world.");
            // 
            // txtWorldId
            // 
            txtWorldId.Location = new Point(257, 38);
            txtWorldId.Margin = new Padding(25, 38, 25, 38);
            txtWorldId.Name = "txtWorldId";
            txtWorldId.Size = new Size(362, 31);
            txtWorldId.TabIndex = 7;
            toolTip1.SetToolTip(txtWorldId, "Must be Unique or Vanilla settings may be merged into your scenario or your scenario might alter the Vanilla world.");
            // 
            // labelPriority
            // 
            labelPriority.AutoSize = true;
            labelPriority.Location = new Point(25, 145);
            labelPriority.Margin = new Padding(25, 38, 25, 38);
            labelPriority.Name = "labelPriority";
            labelPriority.Size = new Size(202, 50);
            labelPriority.TabIndex = 8;
            labelPriority.Text = "Priority (World List Order):";
            toolTip1.SetToolTip(labelPriority, "Number should be set so that your scenario appears first or last. Other numbers may result in random sorting.");
            // 
            // nudPriority
            // 
            nudPriority.Location = new Point(277, 145);
            nudPriority.Margin = new Padding(25, 38, 25, 38);
            nudPriority.Name = "nudPriority";
            nudPriority.Size = new Size(200, 31);
            nudPriority.TabIndex = 9;
            toolTip1.SetToolTip(nudPriority, "Number should be set so that your scenario appears first or last. Other numbers may result in random sorting.");
            // 
            // labelNameKey
            // 
            labelNameKey.AutoSize = true;
            labelNameKey.Location = new Point(25, 271);
            labelNameKey.Margin = new Padding(25, 38, 25, 38);
            labelNameKey.Name = "labelNameKey";
            labelNameKey.Size = new Size(96, 25);
            labelNameKey.TabIndex = 10;
            labelNameKey.Text = "Name Key:";
            toolTip1.SetToolTip(labelNameKey, "This key links the World Settings to your full text in your Language file(s).");
            // 
            // txtNameKey
            // 
            txtNameKey.Location = new Point(257, 271);
            txtNameKey.Margin = new Padding(25, 38, 25, 38);
            txtNameKey.Name = "txtNameKey";
            txtNameKey.Size = new Size(331, 31);
            txtNameKey.TabIndex = 11;
            toolTip1.SetToolTip(txtNameKey, "This key links the World Settings to your full text in your Language file(s).");
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(25, 378);
            labelName.Margin = new Padding(25, 38, 25, 38);
            labelName.Name = "labelName";
            labelName.Size = new Size(63, 25);
            labelName.TabIndex = 12;
            labelName.Text = "Name:";
            // 
            // txtNameValue
            // 
            txtNameValue.AcceptsReturn = true;
            txtNameValue.Location = new Point(257, 378);
            txtNameValue.Margin = new Padding(25, 38, 25, 38);
            txtNameValue.Multiline = true;
            txtNameValue.Name = "txtNameValue";
            txtNameValue.ScrollBars = ScrollBars.Vertical;
            txtNameValue.Size = new Size(362, 150);
            txtNameValue.TabIndex = 13;
            // 
            // labelDescKey
            // 
            labelDescKey.AutoSize = true;
            labelDescKey.Location = new Point(25, 604);
            labelDescKey.Margin = new Padding(25, 38, 25, 38);
            labelDescKey.Name = "labelDescKey";
            labelDescKey.Size = new Size(139, 25);
            labelDescKey.TabIndex = 14;
            labelDescKey.Text = "Description Key:";
            toolTip1.SetToolTip(labelDescKey, "This key links the World Settings to your full text in your Language file(s).");
            // 
            // txtDescKey
            // 
            txtDescKey.Location = new Point(257, 604);
            txtDescKey.Margin = new Padding(25, 38, 25, 38);
            txtDescKey.Name = "txtDescKey";
            txtDescKey.Size = new Size(331, 31);
            txtDescKey.TabIndex = 15;
            toolTip1.SetToolTip(txtDescKey, "This key links the World Settings to your full text in your Language file(s).");
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(25, 711);
            labelDescription.Margin = new Padding(25, 38, 25, 38);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(106, 25);
            labelDescription.TabIndex = 16;
            labelDescription.Text = "Description:";
            // 
            // txtDescValue
            // 
            txtDescValue.AcceptsReturn = true;
            txtDescValue.Location = new Point(257, 711);
            txtDescValue.Margin = new Padding(25, 38, 25, 38);
            txtDescValue.Multiline = true;
            txtDescValue.Name = "txtDescValue";
            txtDescValue.ScrollBars = ScrollBars.Vertical;
            txtDescValue.Size = new Size(362, 150);
            txtDescValue.TabIndex = 17;
            // 
            // labelShortDescKey
            // 
            labelShortDescKey.AutoSize = true;
            labelShortDescKey.Location = new Point(25, 937);
            labelShortDescKey.Margin = new Padding(25, 38, 25, 38);
            labelShortDescKey.Name = "labelShortDescKey";
            labelShortDescKey.Size = new Size(155, 50);
            labelShortDescKey.TabIndex = 18;
            labelShortDescKey.Text = "Short Description Key:";
            toolTip1.SetToolTip(labelShortDescKey, "This key links the World Settings to your full text in your Language file(s).");
            // 
            // txtShortDescKey
            // 
            txtShortDescKey.Location = new Point(257, 937);
            txtShortDescKey.Margin = new Padding(25, 38, 25, 38);
            txtShortDescKey.Name = "txtShortDescKey";
            txtShortDescKey.Size = new Size(331, 31);
            txtShortDescKey.TabIndex = 19;
            toolTip1.SetToolTip(txtShortDescKey, "This key links the World Settings to your full text in your Language file(s).");
            // 
            // labelShortDesc
            // 
            labelShortDesc.AutoSize = true;
            labelShortDesc.Location = new Point(25, 1063);
            labelShortDesc.Margin = new Padding(25, 38, 25, 38);
            labelShortDesc.Name = "labelShortDesc";
            labelShortDesc.Size = new Size(154, 25);
            labelShortDesc.TabIndex = 20;
            labelShortDesc.Text = "Short Description:";
            // 
            // txtShortDescValue
            // 
            txtShortDescValue.AcceptsReturn = true;
            txtShortDescValue.Location = new Point(257, 1063);
            txtShortDescValue.Margin = new Padding(25, 38, 25, 38);
            txtShortDescValue.Multiline = true;
            txtShortDescValue.Name = "txtShortDescValue";
            txtShortDescValue.ScrollBars = ScrollBars.Vertical;
            txtShortDescValue.Size = new Size(362, 150);
            txtShortDescValue.TabIndex = 21;
            // 
            // labelSummaryKey
            // 
            labelSummaryKey.AutoSize = true;
            labelSummaryKey.Location = new Point(25, 1289);
            labelSummaryKey.Margin = new Padding(25, 38, 25, 38);
            labelSummaryKey.Name = "labelSummaryKey";
            labelSummaryKey.Size = new Size(87, 25);
            labelSummaryKey.TabIndex = 22;
            labelSummaryKey.Text = "Summary Key:";
            
            // 
            // txtSummaryKey
            // 
            txtSummaryKey.Location = new Point(257, 1289);
            txtSummaryKey.Margin = new Padding(25, 38, 25, 38);
            txtSummaryKey.Name = "txtSummaryKey";
            txtSummaryKey.Size = new Size(362, 31);
            txtSummaryKey.TabIndex = 23;
            

            // 
            // labelSummary
            // 
            labelSummary.AutoSize = true;
            labelSummary.Location = new Point(25, 1515);
            labelSummary.Margin = new Padding(25, 38, 25, 38);
            labelSummary.Name = "labelSummary";
            labelSummary.Size = new Size(125, 25);
            labelSummary.TabIndex = 24;
            labelSummary.Text = "Summary:";
            // 
            // txtSummary
            // 
            txtSummary.AcceptsReturn = true;
            txtSummary.Location = new Point(257, 1515);
            txtSummary.Margin = new Padding(25, 38, 25, 38);
            txtSummary.Multiline = true;
            txtSummary.Name = "txtSummary";
            txtSummary.ScrollBars = ScrollBars.Vertical;
            txtSummary.Size = new Size(362, 150);
            txtSummary.TabIndex = 25;
            // 
            // column1TableLayout
            // 
            column1TableLayout.AutoSize = true;
            column1TableLayout.ColumnCount = 1;
            column1TableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            column1TableLayout.Controls.Add(startConditionsGroupBox, 0, 0);
            column1TableLayout.Controls.Add(startLocationsGroupBox, 0, 1);
            column1TableLayout.Controls.Add(objectivesGroupBox, 0, 2);
            column1TableLayout.Location = new Point(670, 4);
            column1TableLayout.Margin = new Padding(3, 4, 3, 4);
            column1TableLayout.Name = "column1TableLayout";
            column1TableLayout.RowCount = 3;
            column1TableLayout.RowStyles.Add(new RowStyle());
            column1TableLayout.RowStyles.Add(new RowStyle());
            column1TableLayout.RowStyles.Add(new RowStyle());
            column1TableLayout.Size = new Size(1485, 1968);
            column1TableLayout.TabIndex = 3;
            // 
            // startConditionsGroupBox
            // 
            startConditionsGroupBox.AutoSize = true;
            startConditionsGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            startConditionsGroupBox.Controls.Add(startConditionsTableLayout);
            startConditionsGroupBox.Location = new Point(3, 4);
            startConditionsGroupBox.Margin = new Padding(3, 4, 3, 4);
            startConditionsGroupBox.Name = "startConditionsGroupBox";
            startConditionsGroupBox.Padding = new Padding(3, 4, 3, 4);
            startConditionsGroupBox.Size = new Size(1479, 636);
            startConditionsGroupBox.TabIndex = 0;
            startConditionsGroupBox.TabStop = false;
            startConditionsGroupBox.Text = "Start Conditions";
            // 
            // startConditionsTableLayout
            // 
            startConditionsTableLayout.AutoSize = true;
            startConditionsTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            startConditionsTableLayout.ColumnCount = 2;
            startConditionsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117F));
            startConditionsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            startConditionsTableLayout.Controls.Add(startConditionsButtonPanel, 0, 0);
            startConditionsTableLayout.Controls.Add(clbStartConditions, 1, 0);
            startConditionsTableLayout.Dock = DockStyle.Fill;
            startConditionsTableLayout.Location = new Point(3, 28);
            startConditionsTableLayout.Margin = new Padding(3, 4, 3, 4);
            startConditionsTableLayout.Name = "startConditionsTableLayout";
            startConditionsTableLayout.RowCount = 1;
            startConditionsTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            startConditionsTableLayout.Size = new Size(1473, 604);
            startConditionsTableLayout.TabIndex = 0;
            // 
            // startConditionsButtonPanel
            // 
            startConditionsButtonPanel.AutoSize = true;
            startConditionsButtonPanel.Controls.Add(btnAddCondition);
            startConditionsButtonPanel.Controls.Add(btnDeleteCondition);
            startConditionsButtonPanel.FlowDirection = FlowDirection.TopDown;
            startConditionsButtonPanel.Location = new Point(3, 4);
            startConditionsButtonPanel.Margin = new Padding(3, 4, 3, 4);
            startConditionsButtonPanel.Name = "startConditionsButtonPanel";
            startConditionsButtonPanel.Size = new Size(60, 140);
            startConditionsButtonPanel.TabIndex = 0;
            // 
            // btnAddCondition
            // 
            btnAddCondition.Location = new Point(5, 6);
            btnAddCondition.Margin = new Padding(5, 6, 5, 6);
            btnAddCondition.Name = "btnAddCondition";
            btnAddCondition.Size = new Size(50, 58);
            btnAddCondition.TabIndex = 21;
            btnAddCondition.Text = "+";
            btnAddCondition.UseVisualStyleBackColor = true;
            btnAddCondition.Click += btnAddCondition_Click;
            // 
            // btnDeleteCondition
            // 
            btnDeleteCondition.Location = new Point(5, 76);
            btnDeleteCondition.Margin = new Padding(5, 6, 5, 6);
            btnDeleteCondition.Name = "btnDeleteCondition";
            btnDeleteCondition.Size = new Size(50, 58);
            btnDeleteCondition.TabIndex = 22;
            btnDeleteCondition.Text = "🗑";
            btnDeleteCondition.UseVisualStyleBackColor = true;
            btnDeleteCondition.Click += btnDeleteCondition_Click;
            // 
            // clbStartConditions
            // 
            clbStartConditions.Location = new Point(122, 6);
            clbStartConditions.Margin = new Padding(5, 6, 5, 6);
            clbStartConditions.Name = "clbStartConditions";
            clbStartConditions.Size = new Size(1346, 592);
            clbStartConditions.TabIndex = 23;
            // 
            // startLocationsGroupBox
            // 
            startLocationsGroupBox.AutoSize = true;
            startLocationsGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            startLocationsGroupBox.Controls.Add(startLocationsTableLayout);
            startLocationsGroupBox.Location = new Point(3, 648);
            startLocationsGroupBox.Margin = new Padding(3, 4, 3, 4);
            startLocationsGroupBox.Name = "startLocationsGroupBox";
            startLocationsGroupBox.Padding = new Padding(3, 4, 3, 4);
            startLocationsGroupBox.Size = new Size(1479, 654);
            startLocationsGroupBox.TabIndex = 24;
            startLocationsGroupBox.TabStop = false;
            startLocationsGroupBox.Text = "Start Locations";
            // 
            // startLocationsTableLayout
            // 
            startLocationsTableLayout.AutoSize = true;
            startLocationsTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            startLocationsTableLayout.ColumnCount = 2;
            startLocationsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117F));
            startLocationsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            startLocationsTableLayout.Controls.Add(startLocationsButtonPanel, 0, 0);
            startLocationsTableLayout.Controls.Add(lvStartLocations, 1, 0);
            startLocationsTableLayout.Dock = DockStyle.Fill;
            startLocationsTableLayout.Location = new Point(3, 28);
            startLocationsTableLayout.Margin = new Padding(3, 4, 3, 4);
            startLocationsTableLayout.Name = "startLocationsTableLayout";
            startLocationsTableLayout.RowCount = 1;
            startLocationsTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            startLocationsTableLayout.Size = new Size(1473, 622);
            startLocationsTableLayout.TabIndex = 25;
            // 
            // startLocationsButtonPanel
            // 
            startLocationsButtonPanel.AutoSize = true;
            startLocationsButtonPanel.Controls.Add(btnAddLocation);
            startLocationsButtonPanel.Controls.Add(btnDeleteLocation);
            startLocationsButtonPanel.FlowDirection = FlowDirection.TopDown;
            startLocationsButtonPanel.Location = new Point(3, 4);
            startLocationsButtonPanel.Margin = new Padding(3, 4, 3, 4);
            startLocationsButtonPanel.Name = "startLocationsButtonPanel";
            startLocationsButtonPanel.Size = new Size(60, 140);
            startLocationsButtonPanel.TabIndex = 26;
            // 
            // btnAddLocation
            // 
            btnAddLocation.Location = new Point(5, 6);
            btnAddLocation.Margin = new Padding(5, 6, 5, 6);
            btnAddLocation.Name = "btnAddLocation";
            btnAddLocation.Size = new Size(50, 58);
            btnAddLocation.TabIndex = 27;
            btnAddLocation.Text = "+";
            btnAddLocation.UseVisualStyleBackColor = true;
            btnAddLocation.Click += btnAddLocation_Click;
            // 
            // btnDeleteLocation
            // 
            btnDeleteLocation.Location = new Point(5, 76);
            btnDeleteLocation.Margin = new Padding(5, 6, 5, 6);
            btnDeleteLocation.Name = "btnDeleteLocation";
            btnDeleteLocation.Size = new Size(50, 58);
            btnDeleteLocation.TabIndex = 28;
            btnDeleteLocation.Text = "🗑";
            btnDeleteLocation.UseVisualStyleBackColor = true;
            btnDeleteLocation.Click += btnDeleteLocation_Click;
            // 
            // lvStartLocations
            // 
            lvStartLocations.Location = new Point(122, 6);
            lvStartLocations.Margin = new Padding(5, 6, 5, 6);
            lvStartLocations.Name = "lvStartLocations";
            lvStartLocations.Size = new Size(1346, 610);
            lvStartLocations.TabIndex = 29;
            lvStartLocations.UseCompatibleStateImageBehavior = false;
            lvStartLocations.View = View.Details;
            // 
            // objectivesGroupBox
            // 
            objectivesGroupBox.AutoSize = true;
            objectivesGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            objectivesGroupBox.Controls.Add(objectivesTableLayout);
            objectivesGroupBox.Location = new Point(3, 1310);
            objectivesGroupBox.Margin = new Padding(3, 4, 3, 4);
            objectivesGroupBox.Name = "objectivesGroupBox";
            objectivesGroupBox.Padding = new Padding(3, 4, 3, 4);
            objectivesGroupBox.Size = new Size(1479, 654);
            objectivesGroupBox.TabIndex = 30;
            objectivesGroupBox.TabStop = false;
            objectivesGroupBox.Text = "Objectives";
            // 
            // objectivesTableLayout
            // 
            objectivesTableLayout.AutoSize = true;
            objectivesTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            objectivesTableLayout.ColumnCount = 2;
            objectivesTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117F));
            objectivesTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            objectivesTableLayout.Controls.Add(objectivesButtonPanel, 0, 0);
            objectivesTableLayout.Controls.Add(lvObjectives, 1, 0);
            objectivesTableLayout.Dock = DockStyle.Fill;
            objectivesTableLayout.Location = new Point(3, 28);
            objectivesTableLayout.Margin = new Padding(3, 4, 3, 4);
            objectivesTableLayout.Name = "objectivesTableLayout";
            objectivesTableLayout.RowCount = 1;
            objectivesTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            objectivesTableLayout.Size = new Size(1473, 622);
            objectivesTableLayout.TabIndex = 31;
            // 
            // objectivesButtonPanel
            // 
            objectivesButtonPanel.AutoSize = true;
            objectivesButtonPanel.Controls.Add(btnAddObjective);
            objectivesButtonPanel.Controls.Add(btnDeleteObjective);
            objectivesButtonPanel.FlowDirection = FlowDirection.TopDown;
            objectivesButtonPanel.Location = new Point(3, 4);
            objectivesButtonPanel.Margin = new Padding(3, 4, 3, 4);
            objectivesButtonPanel.Name = "objectivesButtonPanel";
            objectivesButtonPanel.Size = new Size(60, 140);
            objectivesButtonPanel.TabIndex = 32;
            // 
            // btnAddObjective
            // 
            btnAddObjective.Location = new Point(5, 6);
            btnAddObjective.Margin = new Padding(5, 6, 5, 6);
            btnAddObjective.Name = "btnAddObjective";
            btnAddObjective.Size = new Size(50, 58);
            btnAddObjective.TabIndex = 33;
            btnAddObjective.Text = "+";
            btnAddObjective.UseVisualStyleBackColor = true;
            btnAddObjective.Click += btnAddObjective_Click;
            // 
            // btnDeleteObjective
            // 
            btnDeleteObjective.Location = new Point(5, 76);
            btnDeleteObjective.Margin = new Padding(5, 6, 5, 6);
            btnDeleteObjective.Name = "btnDeleteObjective";
            btnDeleteObjective.Size = new Size(50, 58);
            btnDeleteObjective.TabIndex = 34;
            btnDeleteObjective.Text = "🗑";
            btnDeleteObjective.UseVisualStyleBackColor = true;
            btnDeleteObjective.Click += btnDeleteObjective_Click;
            // 
            // lvObjectives
            // 
            lvObjectives.Location = new Point(122, 6);
            lvObjectives.Margin = new Padding(5, 6, 5, 6);
            lvObjectives.Name = "lvObjectives";
            lvObjectives.Size = new Size(1346, 610);
            lvObjectives.TabIndex = 35;
            lvObjectives.UseCompatibleStateImageBehavior = false;
            lvObjectives.View = View.Details;
            // 
            // tableLayoutPanelButtons
            // 
            tableLayoutPanelButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            tableLayoutPanelButtons.ColumnCount = 2;
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelButtons.Controls.Add(btnClearAll, 0, 0);
            tableLayoutPanelButtons.Controls.Add(btnSaveWorldSettings, 1, 0);
            tableLayoutPanelButtons.Location = new Point(1638, 2142);
            tableLayoutPanelButtons.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelButtons.Size = new Size(527, 85);
            tableLayoutPanelButtons.TabIndex = 2;
            // 
            // btnClearAll
            // 
            btnClearAll.AutoSize = true;
            btnClearAll.Location = new Point(10, 15);
            btnClearAll.Margin = new Padding(10, 15, 10, 15);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(243, 54);
            btnClearAll.TabIndex = 0;
            btnClearAll.Text = "Clear All";
            btnClearAll.UseVisualStyleBackColor = true;
            btnClearAll.Click += btnClearAll_Click;
            // 
            // btnSaveWorldSettings
            // 
            btnSaveWorldSettings.AutoSize = true;
            btnSaveWorldSettings.Location = new Point(273, 15);
            btnSaveWorldSettings.Margin = new Padding(10, 15, 25, 15);
            btnSaveWorldSettings.Name = "btnSaveWorldSettings";
            btnSaveWorldSettings.Size = new Size(228, 54);
            btnSaveWorldSettings.TabIndex = 1;
            btnSaveWorldSettings.Text = "Save";
            btnSaveWorldSettings.UseVisualStyleBackColor = true;
            btnSaveWorldSettings.Click += btnSaveWorldSettings_Click;
            // 
            // WorldEditorUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(scrollPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "WorldEditorUserControl";
            Size = new Size(2133, 1500);
            scrollPanel.ResumeLayout(false);
            scrollPanel.PerformLayout();
            outerTableLayout.ResumeLayout(false);
            outerTableLayout.PerformLayout();
            modPathTableLayout.ResumeLayout(false);
            modPathTableLayout.PerformLayout();
            innerTableLayout.ResumeLayout(false);
            innerTableLayout.PerformLayout();
            column0TableLayout.ResumeLayout(false);
            column0TableLayout.PerformLayout();
            worldSettingsGroupBox.ResumeLayout(false);
            worldSettingsGroupBox.PerformLayout();
            worldSettingsTableLayout.ResumeLayout(false);
            worldSettingsTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPriority).EndInit();
            column1TableLayout.ResumeLayout(false);
            column1TableLayout.PerformLayout();
            startConditionsGroupBox.ResumeLayout(false);
            startConditionsGroupBox.PerformLayout();
            startConditionsTableLayout.ResumeLayout(false);
            startConditionsTableLayout.PerformLayout();
            startConditionsButtonPanel.ResumeLayout(false);
            startLocationsGroupBox.ResumeLayout(false);
            startLocationsGroupBox.PerformLayout();
            startLocationsTableLayout.ResumeLayout(false);
            startLocationsTableLayout.PerformLayout();
            startLocationsButtonPanel.ResumeLayout(false);
            objectivesGroupBox.ResumeLayout(false);
            objectivesGroupBox.PerformLayout();
            objectivesTableLayout.ResumeLayout(false);
            objectivesTableLayout.PerformLayout();
            objectivesButtonPanel.ResumeLayout(false);
            tableLayoutPanelButtons.ResumeLayout(false);
            tableLayoutPanelButtons.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel scrollPanel;
        private System.Windows.Forms.TableLayoutPanel outerTableLayout;
        private System.Windows.Forms.TableLayoutPanel modPathTableLayout;
        private System.Windows.Forms.Label labelModPath;
        private System.Windows.Forms.TextBox txtModPath;
        private System.Windows.Forms.Button btnBrowseMod;
        private System.Windows.Forms.TableLayoutPanel innerTableLayout;
        private System.Windows.Forms.TableLayoutPanel column0TableLayout;
        private System.Windows.Forms.GroupBox worldSettingsGroupBox;
        private System.Windows.Forms.TableLayoutPanel worldSettingsTableLayout;
        private System.Windows.Forms.Label labelWorldId;
        private System.Windows.Forms.TextBox txtWorldId;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.NumericUpDown nudPriority;
        private System.Windows.Forms.Label labelNameKey;
        private System.Windows.Forms.TextBox txtNameKey;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox txtNameValue;
        private System.Windows.Forms.Label labelDescKey;
        private System.Windows.Forms.TextBox txtDescKey;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox txtDescValue;
        private System.Windows.Forms.Label labelShortDescKey;
        private System.Windows.Forms.TextBox txtShortDescKey;
        private System.Windows.Forms.Label labelShortDesc;
        private System.Windows.Forms.TextBox txtShortDescValue;
        private System.Windows.Forms.Label labelSummaryKey;
        private System.Windows.Forms.TextBox txtSummaryKey;
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.TableLayoutPanel column1TableLayout;
        private System.Windows.Forms.GroupBox startConditionsGroupBox;
        private System.Windows.Forms.TableLayoutPanel startConditionsTableLayout;
        private System.Windows.Forms.FlowLayoutPanel startConditionsButtonPanel;
        private System.Windows.Forms.Button btnAddCondition;
        private System.Windows.Forms.Button btnDeleteCondition;
        private System.Windows.Forms.ListBox clbStartConditions;
        private System.Windows.Forms.GroupBox startLocationsGroupBox;
        private System.Windows.Forms.TableLayoutPanel startLocationsTableLayout;
        private System.Windows.Forms.FlowLayoutPanel startLocationsButtonPanel;
        private System.Windows.Forms.Button btnAddLocation;
        private System.Windows.Forms.Button btnDeleteLocation;
        private System.Windows.Forms.ListView lvStartLocations;
        private System.Windows.Forms.GroupBox objectivesGroupBox;
        private System.Windows.Forms.TableLayoutPanel objectivesTableLayout;
        private System.Windows.Forms.FlowLayoutPanel objectivesButtonPanel;
        private System.Windows.Forms.Button btnAddObjective;
        private System.Windows.Forms.Button btnDeleteObjective;
        private System.Windows.Forms.ListView lvObjectives;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnSaveWorldSettings;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}