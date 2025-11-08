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
                components.Dispose();
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
            dgvStartLocations = new DataGridView();
            objectivesGroupBox = new GroupBox();
            objectivesTableLayout = new TableLayoutPanel();
            objectivesButtonPanel = new FlowLayoutPanel();
            btnAddObjective = new Button();
            btnDeleteObjective = new Button();
            dgvObjectives = new DataGridView();
            tableLayoutPanelButtons = new TableLayoutPanel();
            btnClearAll = new Button();
            btnSaveWorldSettings = new Button();
            toolTip1 = new ToolTip(components);
            txtDescValue.TextChanged += (s, e) => description = txtDescValue.Text;
            txtShortDescValue.TextChanged += (s, e) => summary = txtShortDescValue.Text;

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

            // scrollPanel
            scrollPanel.AutoScroll = true;
            scrollPanel.Controls.Add(outerTableLayout);
            scrollPanel.Dock = DockStyle.Fill;
            scrollPanel.Location = new Point(0, 0);
            scrollPanel.Margin = new Padding(17, 19, 17, 19);
            scrollPanel.Name = "scrollPanel";
            scrollPanel.Size = new Size(2133, 1500);
            scrollPanel.TabIndex = 0;

            // outerTableLayout — 2 ROWS (buttons now in column1)
            outerTableLayout.AutoSize = false;
            outerTableLayout.Dock = DockStyle.Fill;
            outerTableLayout.ColumnCount = 1;
            outerTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            outerTableLayout.RowCount = 2;
            outerTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));     // Row 0: Mod Path
            outerTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F)); // Row 1: Inner Layout

            outerTableLayout.Controls.Add(modPathTableLayout, 0, 0);
            outerTableLayout.Controls.Add(innerTableLayout, 0, 1);

            outerTableLayout.Location = new Point(17, 19);
            outerTableLayout.Margin = new Padding(17, 19, 17, 19);
            outerTableLayout.Name = "outerTableLayout";
            outerTableLayout.Size = new Size(2168, 1342);
            outerTableLayout.TabIndex = 1;

            // modPathTableLayout
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

            labelModPath.AutoSize = true;
            labelModPath.Location = new Point(3, 0);
            labelModPath.Name = "labelModPath";
            labelModPath.Size = new Size(93, 25);
            labelModPath.TabIndex = 0;
            labelModPath.Text = "Mod Path:";

            txtModPath.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtModPath.Location = new Point(115, 11);
            txtModPath.Margin = new Padding(3, 4, 3, 4);
            txtModPath.Name = "txtModPath";
            txtModPath.Size = new Size(1429, 31);
            txtModPath.TabIndex = 1;

            btnBrowseMod.Location = new Point(1550, 4);
            btnBrowseMod.Margin = new Padding(3, 4, 3, 4);
            btnBrowseMod.Name = "btnBrowseMod";
            btnBrowseMod.Size = new Size(112, 46);
            btnBrowseMod.TabIndex = 2;
            btnBrowseMod.Text = "Browse";
            btnBrowseMod.UseVisualStyleBackColor = true;
            btnBrowseMod.Click += btnBrowseMod_Click;

            // innerTableLayout
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
            innerTableLayout.Size = new Size(1646, 1178);
            innerTableLayout.TabIndex = 1;

            // column0TableLayout — World Settings
            column0TableLayout.AutoSize = true;
            column0TableLayout.ColumnCount = 1;
            column0TableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            column0TableLayout.Controls.Add(worldSettingsGroupBox, 0, 0);
            column0TableLayout.Location = new Point(3, 4);
            column0TableLayout.Margin = new Padding(3, 4, 3, 4);
            column0TableLayout.Name = "column0TableLayout";
            column0TableLayout.RowCount = 1;
            column0TableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            column0TableLayout.Size = new Size(644, 240);
            column0TableLayout.TabIndex = 2;

            worldSettingsGroupBox.AutoSize = true;
            worldSettingsGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            worldSettingsGroupBox.Controls.Add(worldSettingsTableLayout);
            worldSettingsGroupBox.Location = new Point(3, 4);
            worldSettingsGroupBox.Margin = new Padding(3, 4, 3, 4);
            worldSettingsGroupBox.Name = "worldSettingsGroupBox";
            worldSettingsGroupBox.Padding = new Padding(3, 4, 3, 4);
            worldSettingsGroupBox.Size = new Size(638, 232);
            worldSettingsGroupBox.TabIndex = 4;
            worldSettingsGroupBox.TabStop = false;
            worldSettingsGroupBox.Text = "World Settings";

            worldSettingsTableLayout.AutoSize = true;
            worldSettingsTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            worldSettingsTableLayout.ColumnCount = 2;
            worldSettingsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280F));
            worldSettingsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            worldSettingsTableLayout.Dock = DockStyle.Fill;
            worldSettingsTableLayout.Location = new Point(3, 28);
            worldSettingsTableLayout.Margin = new Padding(3, 4, 3, 4);
            worldSettingsTableLayout.Name = "worldSettingsTableLayout";
            worldSettingsTableLayout.RowCount = 10;
            worldSettingsTableLayout.TabIndex = 5;

            // ALL ROWS AutoSize
            worldSettingsTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            worldSettingsTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            worldSettingsTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            worldSettingsTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            worldSettingsTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            worldSettingsTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            worldSettingsTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            worldSettingsTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            worldSettingsTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            worldSettingsTableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // World Settings Controls — 120px multiline
            labelWorldId.AutoSize = true;
            labelWorldId.Location = new Point(12, 8);
            labelWorldId.Margin = new Padding(12, 8, 12, 8);
            labelWorldId.Name = "labelWorldId";
            labelWorldId.Size = new Size(87, 4);
            labelWorldId.TabIndex = 6;
            labelWorldId.Text = "World ID:";

            txtWorldId.Location = new Point(286, 8);
            txtWorldId.Margin = new Padding(6, 8, 6, 8);
            txtWorldId.Name = "txtWorldId";
            txtWorldId.Size = new Size(340, 31);
            txtWorldId.TabIndex = 7;

            labelPriority.Location = new Point(12, 28);
            labelPriority.Margin = new Padding(12, 8, 12, 8);
            labelPriority.Name = "labelPriority";
            labelPriority.Size = new Size(256, 25);
            labelPriority.TabIndex = 8;
            labelPriority.Text = "Priority (World List Order):";

            nudPriority.Location = new Point(305, 58);
            nudPriority.Margin = new Padding(25, 38, 25, 38);
            nudPriority.Name = "nudPriority";
            nudPriority.Size = new Size(200, 31);
            nudPriority.TabIndex = 9;

            labelNameKey.AutoSize = true;
            labelNameKey.Location = new Point(12, 48);
            labelNameKey.Margin = new Padding(12, 8, 12, 8);
            labelNameKey.Name = "labelNameKey";
            labelNameKey.Size = new Size(96, 25);
            labelNameKey.TabIndex = 10;
            labelNameKey.Text = "Name Key:";

            txtNameKey.Location = new Point(286, 48);
            txtNameKey.Margin = new Padding(6, 8, 6, 8);
            txtNameKey.Name = "txtNameKey";
            txtNameKey.Size = new Size(340, 31);
            txtNameKey.TabIndex = 11;

            labelName.AutoSize = true;
            labelName.Location = new Point(12, 68);
            labelName.Margin = new Padding(12, 8, 12, 8);
            labelName.Name = "labelName";
            labelName.Size = new Size(63, 25);
            labelName.TabIndex = 12;
            labelName.Text = "Name:";

            txtNameValue.AcceptsReturn = true;
            txtNameValue.Location = new Point(286, 68);
            txtNameValue.Margin = new Padding(6, 8, 6, 8);
            txtNameValue.Multiline = true;
            txtNameValue.Name = "txtNameValue";
            txtNameValue.ScrollBars = ScrollBars.Vertical;
            txtNameValue.Size = new Size(340, 120);
            txtNameValue.TabIndex = 13;

            labelDescKey.AutoSize = true;
            labelDescKey.Location = new Point(12, 88);
            labelDescKey.Margin = new Padding(12, 8, 12, 8);
            labelDescKey.Name = "labelDescKey";
            labelDescKey.Size = new Size(139, 25);
            labelDescKey.TabIndex = 14;
            labelDescKey.Text = "Description Key:";

            txtDescKey.Location = new Point(286, 88);
            txtDescKey.Margin = new Padding(6, 8, 6, 8);
            txtDescKey.Name = "txtDescKey";
            txtDescKey.Size = new Size(340, 31);
            txtDescKey.TabIndex = 15;

            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(12, 108);
            labelDescription.Margin = new Padding(12, 8, 12, 8);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(106, 25);
            labelDescription.TabIndex = 16;
            labelDescription.Text = "Description:";

            txtDescValue.AcceptsReturn = true;
            txtDescValue.Location = new Point(286, 108);
            txtDescValue.Margin = new Padding(6, 8, 6, 8);
            txtDescValue.Multiline = true;
            txtDescValue.Name = "txtDescValue";
            txtDescValue.ScrollBars = ScrollBars.Vertical;
            txtDescValue.Size = new Size(340, 180);
            txtDescValue.TabIndex = 17;

            labelShortDescKey.AutoSize = true;
            labelShortDescKey.Location = new Point(12, 128);
            labelShortDescKey.Margin = new Padding(12, 8, 12, 8);
            labelShortDescKey.Name = "labelShortDescKey";
            labelShortDescKey.Size = new Size(187, 25);
            labelShortDescKey.TabIndex = 18;
            labelShortDescKey.Text = "Short Description Key:";

            txtShortDescKey.Location = new Point(286, 128);
            txtShortDescKey.Margin = new Padding(6, 8, 6, 8);
            txtShortDescKey.Name = "txtShortDescKey";
            txtShortDescKey.Size = new Size(340, 31);
            txtShortDescKey.TabIndex = 19;

            labelShortDesc.AutoSize = true;
            labelShortDesc.Location = new Point(12, 148);
            labelShortDesc.Margin = new Padding(12, 8, 12, 8);
            labelShortDesc.Name = "labelShortDesc";
            labelShortDesc.Size = new Size(154, 25);
            labelShortDesc.TabIndex = 20;
            labelShortDesc.Text = "Short Description:";

            txtShortDescValue.AcceptsReturn = true;
            txtShortDescValue.Location = new Point(286, 148);
            txtShortDescValue.Margin = new Padding(6, 8, 6, 8);
            txtShortDescValue.Multiline = true;
            txtShortDescValue.Name = "txtShortDescValue";
            txtShortDescValue.ScrollBars = ScrollBars.Vertical;
            txtShortDescValue.Size = new Size(340, 180);
            txtShortDescValue.TabIndex = 21;

            labelSummaryKey.AutoSize = true;
            labelSummaryKey.Location = new Point(12, 168);
            labelSummaryKey.Margin = new Padding(12, 8, 12, 8);
            labelSummaryKey.Name = "labelSummaryKey";
            labelSummaryKey.Size = new Size(125, 25);
            labelSummaryKey.TabIndex = 22;
            labelSummaryKey.Text = "Summary Key:";

            txtSummaryKey.Location = new Point(286, 168);
            txtSummaryKey.Margin = new Padding(6, 8, 6, 8);
            txtSummaryKey.Name = "txtSummaryKey";
            txtSummaryKey.Size = new Size(340, 31);
            txtSummaryKey.TabIndex = 23;

            labelSummary.AutoSize = true;
            labelSummary.Location = new Point(12, 188);
            labelSummary.Margin = new Padding(12, 8, 12, 8);
            labelSummary.Name = "labelSummary";
            labelSummary.Size = new Size(92, 25);
            labelSummary.TabIndex = 24;
            labelSummary.Text = "Summary:";

            txtSummary.AcceptsReturn = true;
            txtSummary.Location = new Point(286, 188);
            txtSummary.Margin = new Padding(6, 8, 6, 8);
            txtSummary.Multiline = true;
            txtSummary.Name = "txtSummary";
            txtSummary.ScrollBars = ScrollBars.Vertical;
            txtSummary.Size = new Size(340, 180);
            txtSummary.TabIndex = 25;

            // Add to worldSettingsTableLayout
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

            // column1TableLayout — RIGHT COLUMN + BUTTONS
            column1TableLayout.AutoSize = true;
            column1TableLayout.ColumnCount = 1;
            column1TableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            column1TableLayout.Controls.Add(startConditionsGroupBox, 0, 0);
            column1TableLayout.Controls.Add(startLocationsGroupBox, 0, 1);
            column1TableLayout.Controls.Add(objectivesGroupBox, 0, 2);
            column1TableLayout.Controls.Add(tableLayoutPanelButtons, 0, 3); // BUTTONS HERE
            column1TableLayout.Location = new Point(670, 4);
            column1TableLayout.Margin = new Padding(3, 4, 3, 4);
            column1TableLayout.Name = "column1TableLayout";
            column1TableLayout.RowCount = 4;
            column1TableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 390F));
            column1TableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 390F));
            column1TableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 390F));
            column1TableLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Buttons
            column1TableLayout.Size = new Size(973, 1170);
            column1TableLayout.TabIndex = 3;

            // Start Conditions
            startConditionsGroupBox.AutoSize = true;
            startConditionsGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            startConditionsGroupBox.Controls.Add(startConditionsTableLayout);
            startConditionsGroupBox.Location = new Point(3, 4);
            startConditionsGroupBox.Margin = new Padding(3, 4, 3, 4);
            startConditionsGroupBox.Name = "startConditionsGroupBox";
            startConditionsGroupBox.Padding = new Padding(3, 4, 3, 4);
            startConditionsGroupBox.Size = new Size(967, 371);
            startConditionsGroupBox.TabIndex = 0;
            startConditionsGroupBox.TabStop = false;
            startConditionsGroupBox.Text = "Start Conditions";

            startConditionsTableLayout.AutoSize = true;
            startConditionsTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            startConditionsTableLayout.ColumnCount = 2;
            startConditionsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            startConditionsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            startConditionsTableLayout.Controls.Add(startConditionsButtonPanel, 0, 0);
            startConditionsTableLayout.Controls.Add(clbStartConditions, 1, 0);
            startConditionsTableLayout.Dock = DockStyle.Fill;
            startConditionsTableLayout.Location = new Point(3, 28);
            startConditionsTableLayout.Margin = new Padding(3, 4, 3, 4);
            startConditionsTableLayout.Name = "startConditionsTableLayout";
            startConditionsTableLayout.RowCount = 1;
            startConditionsTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            startConditionsTableLayout.Size = new Size(961, 339);
            startConditionsTableLayout.TabIndex = 0;

            startConditionsButtonPanel.AutoSize = true;
            startConditionsButtonPanel.Controls.Add(btnAddCondition);
            startConditionsButtonPanel.Controls.Add(btnDeleteCondition);
            startConditionsButtonPanel.FlowDirection = FlowDirection.TopDown;
            startConditionsButtonPanel.Location = new Point(3, 4);
            startConditionsButtonPanel.Margin = new Padding(3, 4, 3, 4);
            startConditionsButtonPanel.Name = "startConditionsButtonPanel";
            startConditionsButtonPanel.Size = new Size(54, 140);
            startConditionsButtonPanel.TabIndex = 0;

            btnAddCondition.Font = new Font("Microsoft Sans Serif", 18F);
            btnAddCondition.Location = new Point(5, 6);
            btnAddCondition.Margin = new Padding(5, 6, 5, 6);
            btnAddCondition.Name = "btnAddCondition";
            btnAddCondition.Size = new Size(50, 58);
            btnAddCondition.TabIndex = 21;
            btnAddCondition.Text = "+";
            btnAddCondition.UseVisualStyleBackColor = true;
            btnAddCondition.Click += btnAddCondition_Click;

            btnDeleteCondition.Font = new Font("Segoe UI Emoji", 14F);
            btnDeleteCondition.Location = new Point(5, 76);
            btnDeleteCondition.Margin = new Padding(5, 6, 5, 6);
            btnDeleteCondition.Name = "btnDeleteCondition";
            btnDeleteCondition.Size = new Size(50, 58);
            btnDeleteCondition.TabIndex = 22;
            btnDeleteCondition.Text = "\uD83D\uDDD1";
            btnDeleteCondition.UseVisualStyleBackColor = true;
            btnDeleteCondition.Click += btnDeleteCondition_Click;

            clbStartConditions.ItemHeight = 25;
            clbStartConditions.Location = new Point(64, 4);
            clbStartConditions.Margin = new Padding(4);
            clbStartConditions.Name = "clbStartConditions";
            clbStartConditions.Size = new Size(893, 329);
            clbStartConditions.TabIndex = 23;

            // Start Locations
            startLocationsGroupBox.AutoSize = true;
            startLocationsGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            startLocationsGroupBox.Controls.Add(startLocationsTableLayout);
            startLocationsGroupBox.Location = new Point(3, 394);
            startLocationsGroupBox.Margin = new Padding(3, 4, 3, 4);
            startLocationsGroupBox.Name = "startLocationsGroupBox";
            startLocationsGroupBox.Padding = new Padding(3, 4, 3, 4);
            startLocationsGroupBox.Size = new Size(967, 371);
            startLocationsGroupBox.TabIndex = 24;
            startLocationsGroupBox.TabStop = false;
            startLocationsGroupBox.Text = "Start Locations";

            startLocationsTableLayout.AutoSize = true;
            startLocationsTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            startLocationsTableLayout.ColumnCount = 2;
            startLocationsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            startLocationsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            startLocationsTableLayout.Controls.Add(startLocationsButtonPanel, 0, 0);
            startLocationsTableLayout.Controls.Add(dgvStartLocations, 1, 0);
            startLocationsTableLayout.Dock = DockStyle.Fill;
            startLocationsTableLayout.Location = new Point(3, 28);
            startLocationsTableLayout.Margin = new Padding(3, 4, 3, 4);
            startLocationsTableLayout.Name = "startLocationsTableLayout";
            startLocationsTableLayout.RowCount = 1;
            startLocationsTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            startLocationsTableLayout.Size = new Size(961, 339);
            startLocationsTableLayout.TabIndex = 25;

            startLocationsButtonPanel.AutoSize = true;
            startLocationsButtonPanel.Controls.Add(btnAddLocation);
            startLocationsButtonPanel.Controls.Add(btnDeleteLocation);
            startLocationsButtonPanel.FlowDirection = FlowDirection.TopDown;
            startLocationsButtonPanel.Location = new Point(3, 4);
            startLocationsButtonPanel.Margin = new Padding(3, 4, 3, 4);
            startLocationsButtonPanel.Name = "startLocationsButtonPanel";
            startLocationsButtonPanel.Size = new Size(54, 140);
            startLocationsButtonPanel.TabIndex = 26;

            btnAddLocation.Font = new Font("Microsoft Sans Serif", 18F);
            btnAddLocation.Location = new Point(5, 6);
            btnAddLocation.Margin = new Padding(5, 6, 5, 6);
            btnAddLocation.Name = "btnAddLocation";
            btnAddLocation.Size = new Size(50, 58);
            btnAddLocation.TabIndex = 27;
            btnAddLocation.Text = "+";
            btnAddLocation.UseVisualStyleBackColor = true;
            btnAddLocation.Click += btnAddLocation_Click;

            btnDeleteLocation.Font = new Font("Segoe UI Emoji", 14F);
            btnDeleteLocation.Location = new Point(5, 76);
            btnDeleteLocation.Margin = new Padding(5, 6, 5, 6);
            btnDeleteLocation.Name = "btnDeleteLocation";
            btnDeleteLocation.Size = new Size(50, 58);
            btnDeleteLocation.TabIndex = 28;
            btnDeleteLocation.Text = "\uD83D\uDDD1";
            btnDeleteLocation.UseVisualStyleBackColor = true;
            btnDeleteLocation.Click += btnDeleteLocation_Click;

            
            dgvStartLocations.Location = new Point(64, 4);
            dgvStartLocations.Margin = new Padding(4);
            dgvStartLocations.Name = "dgvStartLocations";
            dgvStartLocations.Size = new Size(893, 331);
            dgvStartLocations.TabIndex = 29;
           

            // Objectives
            objectivesGroupBox.AutoSize = true;
            objectivesGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            objectivesGroupBox.Controls.Add(objectivesTableLayout);
            objectivesGroupBox.Location = new Point(3, 784);
            objectivesGroupBox.Margin = new Padding(3, 4, 3, 4);
            objectivesGroupBox.Name = "objectivesGroupBox";
            objectivesGroupBox.Padding = new Padding(3, 4, 3, 4);
            objectivesGroupBox.Size = new Size(967, 371);
            objectivesGroupBox.TabIndex = 30;
            objectivesGroupBox.TabStop = false;
            objectivesGroupBox.Text = "Objectives";

            objectivesTableLayout.AutoSize = true;
            objectivesTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            objectivesTableLayout.ColumnCount = 2;
            objectivesTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            objectivesTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            objectivesTableLayout.Controls.Add(objectivesButtonPanel, 0, 0);
            objectivesTableLayout.Controls.Add(dgvObjectives, 1, 0);
            objectivesTableLayout.Dock = DockStyle.Fill;
            objectivesTableLayout.Location = new Point(3, 28);
            objectivesTableLayout.Margin = new Padding(3, 4, 3, 4);
            objectivesTableLayout.Name = "objectivesTableLayout";
            objectivesTableLayout.RowCount = 1;
            objectivesTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            objectivesTableLayout.Size = new Size(961, 339);
            objectivesTableLayout.TabIndex = 31;

            objectivesButtonPanel.AutoSize = true;
            objectivesButtonPanel.Controls.Add(btnAddObjective);
            objectivesButtonPanel.Controls.Add(btnDeleteObjective);
            objectivesButtonPanel.FlowDirection = FlowDirection.TopDown;
            objectivesButtonPanel.Location = new Point(3, 4);
            objectivesButtonPanel.Margin = new Padding(3, 4, 3, 4);
            objectivesButtonPanel.Name = "objectivesButtonPanel";
            objectivesButtonPanel.Size = new Size(54, 140);
            objectivesButtonPanel.TabIndex = 32;

            btnAddObjective.Font = new Font("Microsoft Sans Serif", 18F);
            btnAddObjective.Location = new Point(5, 6);
            btnAddObjective.Margin = new Padding(5, 6, 5, 6);
            btnAddObjective.Name = "btnAddObjective";
            btnAddObjective.Size = new Size(50, 58);
            btnAddObjective.TabIndex = 33;
            btnAddObjective.Text = "+";
            btnAddObjective.UseVisualStyleBackColor = true;
            btnAddObjective.Click += btnAddObjective_Click;

            btnDeleteObjective.Font = new Font("Segoe UI Emoji", 14F);
            btnDeleteObjective.Location = new Point(5, 76);
            btnDeleteObjective.Margin = new Padding(5, 6, 5, 6);
            btnDeleteObjective.Name = "btnDeleteObjective";
            btnDeleteObjective.Size = new Size(50, 58);
            btnDeleteObjective.TabIndex = 34;
            btnDeleteObjective.Text = "\uD83D\uDDD1";
            btnDeleteObjective.UseVisualStyleBackColor = true;
            btnDeleteObjective.Click += btnDeleteObjective_Click;

            dgvObjectives.Location = new Point(64, 4);
            dgvObjectives.Margin = new Padding(4);
            dgvObjectives.Name = "dgvObjectives";
            dgvObjectives.Size = new Size(893, 331);
            dgvObjectives.TabIndex = 35;
            

            tableLayoutPanelButtons.ColumnCount = 2;
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanelButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanelButtons.Controls.Add(btnClearAll, 0, 0);
            tableLayoutPanelButtons.Controls.Add(btnSaveWorldSettings, 1, 0);
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelButtons.Dock = DockStyle.Right;           // FLUSH RIGHT
            tableLayoutPanelButtons.AutoSize = true;
            tableLayoutPanelButtons.Margin = new Padding(0, 10, 10, 10);  // 10px from right
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.TabIndex = 2;

            btnClearAll.AutoSize = false;
            btnClearAll.Location = new Point(10, 15);
            btnClearAll.Margin = new Padding(10, 15, 5, 15);  // Tight gap
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(200, 54);
            btnClearAll.TabIndex = 0;
            btnClearAll.Text = "Clear All";
            btnClearAll.UseVisualStyleBackColor = true;
            btnClearAll.Click += btnClearAll_Click;

            btnSaveWorldSettings.AutoSize = false;
            btnSaveWorldSettings.Location = new Point(215, 15);  // 200 + 15 gap
            btnSaveWorldSettings.Margin = new Padding(5, 15, 10, 15);
            btnSaveWorldSettings.Name = "btnSaveWorldSettings";
            btnSaveWorldSettings.Size = new Size(200, 54);
            btnSaveWorldSettings.TabIndex = 1;
            btnSaveWorldSettings.Text = "Save";
            btnSaveWorldSettings.UseVisualStyleBackColor = true;
            btnSaveWorldSettings.Click += btnSaveWorldSettings_Click;

            // UserControl
            this.AutoScaleDimensions = new SizeF(10F, 25F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(scrollPanel);
            this.Margin = new Padding(3, 4, 3, 4);
            this.Name = "WorldEditorUserControl";
            this.Size = new Size(2133, 1500);

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

        // Controls
        private Panel scrollPanel;
        private TableLayoutPanel outerTableLayout;
        private TableLayoutPanel modPathTableLayout;
        private Label labelModPath;
        private TextBox txtModPath;
        private Button btnBrowseMod;
        private TableLayoutPanel innerTableLayout;
        private TableLayoutPanel column0TableLayout;
        private GroupBox worldSettingsGroupBox;
        private TableLayoutPanel worldSettingsTableLayout;
        private Label labelWorldId;
        private TextBox txtWorldId;
        private Label labelPriority;
        private NumericUpDown nudPriority;
        private Label labelNameKey;
        private TextBox txtNameKey;
        private Label labelName;
        private TextBox txtNameValue;
        private Label labelDescKey;
        private TextBox txtDescKey;
        private Label labelDescription;
        private TextBox txtDescValue;
        private Label labelShortDescKey;
        private TextBox txtShortDescKey;
        private Label labelShortDesc;
        private TextBox txtShortDescValue;
        private Label labelSummaryKey;
        private TextBox txtSummaryKey;
        private Label labelSummary;
        private TextBox txtSummary;
        private TableLayoutPanel column1TableLayout;
        private GroupBox startConditionsGroupBox;
        private TableLayoutPanel startConditionsTableLayout;
        private FlowLayoutPanel startConditionsButtonPanel;
        private Button btnAddCondition;
        private Button btnDeleteCondition;
        private ListBox clbStartConditions;
        private GroupBox startLocationsGroupBox;
        private TableLayoutPanel startLocationsTableLayout;
        private FlowLayoutPanel startLocationsButtonPanel;
        private Button btnAddLocation;
        private Button btnDeleteLocation;
        private DataGridView dgvStartLocations;
        private GroupBox objectivesGroupBox;
        private TableLayoutPanel objectivesTableLayout;
        private FlowLayoutPanel objectivesButtonPanel;
        private Button btnAddObjective;
        private Button btnDeleteObjective;
        private DataGridView dgvObjectives;
        private TableLayoutPanel tableLayoutPanelButtons;
        private Button btnClearAll;
        private Button btnSaveWorldSettings;
        private ToolTip toolTip1;
    }
}