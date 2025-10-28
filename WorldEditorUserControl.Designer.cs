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
            this.components = new System.ComponentModel.Container();
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.outerTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.modPathTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.labelModPath = new System.Windows.Forms.Label();
            this.txtModPath = new System.Windows.Forms.TextBox();
            this.btnBrowseMod = new System.Windows.Forms.Button();
            this.innerTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.column0TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.worldSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.worldSettingsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.labelWorldId = new System.Windows.Forms.Label();
            this.txtWorldId = new System.Windows.Forms.TextBox();
            this.labelPriority = new System.Windows.Forms.Label();
            this.nudPriority = new System.Windows.Forms.NumericUpDown();
            this.labelNameKey = new System.Windows.Forms.Label();
            this.txtNameKey = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.txtNameValue = new System.Windows.Forms.TextBox();
            this.labelDescKey = new System.Windows.Forms.Label();
            this.txtDescKey = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.txtDescValue = new System.Windows.Forms.TextBox();
            this.labelShortDescKey = new System.Windows.Forms.Label();
            this.txtShortDescKey = new System.Windows.Forms.TextBox();
            this.labelShortDesc = new System.Windows.Forms.Label();
            this.txtShortDescValue = new System.Windows.Forms.TextBox();
            this.labelSummary = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.column1TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.startConditionsGroupBox = new System.Windows.Forms.GroupBox();
            this.startConditionsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.startConditionsButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddCondition = new System.Windows.Forms.Button();
            this.btnDeleteCondition = new System.Windows.Forms.Button();
            this.clbStartConditions = new System.Windows.Forms.CheckedListBox();
            this.startLocationsGroupBox = new System.Windows.Forms.GroupBox();
            this.startLocationsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.startLocationsButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddLocation = new System.Windows.Forms.Button();
            this.btnDeleteLocation = new System.Windows.Forms.Button();
            this.lvStartLocations = new System.Windows.Forms.ListView();
            this.objectivesGroupBox = new System.Windows.Forms.GroupBox();
            this.objectivesTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.objectivesButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddObjective = new System.Windows.Forms.Button();
            this.btnDeleteObjective = new System.Windows.Forms.Button();
            this.lvObjectives = new System.Windows.Forms.ListView();
            this.tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnSaveWorldSettings = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);

            this.scrollPanel.SuspendLayout();
            this.outerTableLayout.SuspendLayout();
            this.modPathTableLayout.SuspendLayout();
            this.innerTableLayout.SuspendLayout();
            this.column0TableLayout.SuspendLayout();
            this.worldSettingsGroupBox.SuspendLayout();
            this.worldSettingsTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).BeginInit();
            this.column1TableLayout.SuspendLayout();
            this.startConditionsGroupBox.SuspendLayout();
            this.startConditionsTableLayout.SuspendLayout();
            this.startConditionsButtonPanel.SuspendLayout();
            this.startLocationsGroupBox.SuspendLayout();
            this.startLocationsTableLayout.SuspendLayout();
            this.startLocationsButtonPanel.SuspendLayout();
            this.objectivesGroupBox.SuspendLayout();
            this.objectivesTableLayout.SuspendLayout();
            this.objectivesButtonPanel.SuspendLayout();
            this.tableLayoutPanelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // scrollPanel
            // 
            this.scrollPanel.AutoScroll = true;
            this.scrollPanel.Controls.Add(this.outerTableLayout);
            this.scrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel.Location = new System.Drawing.Point(0, 0);
            this.scrollPanel.Margin = new System.Windows.Forms.Padding(10);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Size = new System.Drawing.Size(1280, 780);
            this.scrollPanel.TabIndex = 0;
            // 
            // outerTableLayout
            // 
            this.outerTableLayout.AutoSize = true;
            this.outerTableLayout.ColumnCount = 1;
            this.outerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outerTableLayout.Controls.Add(this.modPathTableLayout, 0, 0);
            this.outerTableLayout.Controls.Add(this.innerTableLayout, 0, 1);
            this.outerTableLayout.Controls.Add(this.tableLayoutPanelButtons, 0, 2);
            this.outerTableLayout.Location = new System.Drawing.Point(10, 10);
            this.outerTableLayout.Margin = new System.Windows.Forms.Padding(10);
            this.outerTableLayout.Name = "outerTableLayout";
            this.outerTableLayout.RowCount = 3;
            this.outerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.outerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.outerTableLayout.Size = new System.Drawing.Size(1260, 760);
            this.outerTableLayout.TabIndex = 1;
            // 
            // modPathTableLayout
            // 
            this.modPathTableLayout.ColumnCount = 3;
            this.modPathTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.modPathTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.modPathTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.modPathTableLayout.Controls.Add(this.labelModPath, 0, 0);
            this.modPathTableLayout.Controls.Add(this.txtModPath, 1, 0);
            this.modPathTableLayout.Controls.Add(this.btnBrowseMod, 2, 0);
            this.modPathTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modPathTableLayout.Location = new System.Drawing.Point(2, 2);
            this.modPathTableLayout.Margin = new System.Windows.Forms.Padding(2);
            this.modPathTableLayout.Name = "modPathTableLayout";
            this.modPathTableLayout.RowCount = 1;
            this.modPathTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.modPathTableLayout.Size = new System.Drawing.Size(1256, 28);
            this.modPathTableLayout.TabIndex = 0;
            // 
            // labelModPath
            // 
            this.labelModPath.AutoSize = true;
            this.labelModPath.Location = new System.Drawing.Point(2, 0);
            this.labelModPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelModPath.Name = "labelModPath";
            this.labelModPath.Size = new System.Drawing.Size(56, 13);
            this.labelModPath.TabIndex = 0;
            this.labelModPath.Text = "Mod Path:";
            // 
            // txtModPath
            // 
            this.txtModPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModPath.Location = new System.Drawing.Point(69, 4);
            this.txtModPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtModPath.Name = "txtModPath";
            this.txtModPath.Size = new System.Drawing.Size(828, 20);
            this.txtModPath.TabIndex = 1;
            // 
            // btnBrowseMod
            // 
            this.btnBrowseMod.Location = new System.Drawing.Point(901, 2);
            this.btnBrowseMod.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowseMod.Name = "btnBrowseMod";
            this.btnBrowseMod.Size = new System.Drawing.Size(67, 24);
            this.btnBrowseMod.TabIndex = 2;
            this.btnBrowseMod.Text = "Browse";
            this.btnBrowseMod.UseVisualStyleBackColor = true;
            this.btnBrowseMod.Click += new System.EventHandler(this.btnBrowseMod_Click);
            // 
            // innerTableLayout
            // 
            this.innerTableLayout.AutoSize = true;
            this.innerTableLayout.ColumnCount = 2;
            this.innerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.innerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.innerTableLayout.Controls.Add(this.column0TableLayout, 0, 0);
            this.innerTableLayout.Controls.Add(this.column1TableLayout, 1, 0);
            this.innerTableLayout.Location = new System.Drawing.Point(2, 34);
            this.innerTableLayout.Margin = new System.Windows.Forms.Padding(2);
            this.innerTableLayout.Name = "innerTableLayout";
            this.innerTableLayout.RowCount = 1;
            this.innerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.innerTableLayout.Size = new System.Drawing.Size(1256, 674);
            this.innerTableLayout.TabIndex = 1;
            // 
            // column0TableLayout
            // 
            this.column0TableLayout.AutoSize = true;
            this.column0TableLayout.ColumnCount = 1;
            this.column0TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.column0TableLayout.Controls.Add(this.worldSettingsGroupBox, 0, 0);
            this.column0TableLayout.Location = new System.Drawing.Point(2, 2);
            this.column0TableLayout.Margin = new System.Windows.Forms.Padding(2);
            this.column0TableLayout.Name = "column0TableLayout";
            this.column0TableLayout.RowCount = 1;
            this.column0TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.column0TableLayout.Size = new System.Drawing.Size(398, 670);
            this.column0TableLayout.TabIndex = 2;
            // 
            // worldSettingsGroupBox
            // 
            this.worldSettingsGroupBox.AutoSize = true;
            this.worldSettingsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.worldSettingsGroupBox.Controls.Add(this.worldSettingsTableLayout);
            this.worldSettingsGroupBox.Location = new System.Drawing.Point(2, 2);
            this.worldSettingsGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.worldSettingsGroupBox.Name = "worldSettingsGroupBox";
            this.worldSettingsGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.worldSettingsGroupBox.Size = new System.Drawing.Size(394, 666);
            this.worldSettingsGroupBox.TabIndex = 4;
            this.worldSettingsGroupBox.TabStop = false;
            this.worldSettingsGroupBox.Text = "World Settings";
            // 
            // worldSettingsTableLayout
            // 
            this.worldSettingsTableLayout.AutoSize = true;
            this.worldSettingsTableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.worldSettingsTableLayout.ColumnCount = 2;
            this.worldSettingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.worldSettingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.worldSettingsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worldSettingsTableLayout.Location = new System.Drawing.Point(2, 15);
            this.worldSettingsTableLayout.Margin = new System.Windows.Forms.Padding(2);
            this.worldSettingsTableLayout.Name = "worldSettingsTableLayout";
            this.worldSettingsTableLayout.RowCount = 9;
            this.worldSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.worldSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.worldSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.worldSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.worldSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.worldSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.worldSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.worldSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.worldSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.worldSettingsTableLayout.TabIndex = 5;
            this.worldSettingsTableLayout.Controls.Add(this.labelWorldId, 0, 0);
            this.worldSettingsTableLayout.Controls.Add(this.txtWorldId, 1, 0);
            this.worldSettingsTableLayout.Controls.Add(this.labelPriority, 0, 1);
            this.worldSettingsTableLayout.Controls.Add(this.nudPriority, 1, 1);
            this.worldSettingsTableLayout.Controls.Add(this.labelNameKey, 0, 2);
            this.worldSettingsTableLayout.Controls.Add(this.txtNameKey, 1, 2);
            this.worldSettingsTableLayout.Controls.Add(this.labelName, 0, 3);
            this.worldSettingsTableLayout.Controls.Add(this.txtNameValue, 1, 3);
            this.worldSettingsTableLayout.Controls.Add(this.labelDescKey, 0, 4);
            this.worldSettingsTableLayout.Controls.Add(this.txtDescKey, 1, 4);
            this.worldSettingsTableLayout.Controls.Add(this.labelDescription, 0, 5);
            this.worldSettingsTableLayout.Controls.Add(this.txtDescValue, 1, 5);
            this.worldSettingsTableLayout.Controls.Add(this.labelShortDescKey, 0, 6);
            this.worldSettingsTableLayout.Controls.Add(this.txtShortDescKey, 1, 6);
            this.worldSettingsTableLayout.Controls.Add(this.labelShortDesc, 0, 7);
            this.worldSettingsTableLayout.Controls.Add(this.txtShortDescValue, 1, 7);
            this.worldSettingsTableLayout.Controls.Add(this.labelSummary, 0, 8);
            this.worldSettingsTableLayout.Controls.Add(this.txtSummary, 1, 8);
            // 
            // labelWorldId
            // 
            this.labelWorldId.AutoSize = true;
            this.labelWorldId.Location = new System.Drawing.Point(15, 20);
            this.labelWorldId.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.labelWorldId.Name = "labelWorldId";
            this.labelWorldId.Size = new System.Drawing.Size(75, 20);
            this.labelWorldId.TabIndex = 6;
            this.labelWorldId.Text = "World ID:";
            this.toolTip1.SetToolTip(this.labelWorldId, "Must be Unique or Vanilla settings may be merged into your scenario or your scenario might alter the Vanilla world.");
            // 
            // txtWorldId
            // 
            this.txtWorldId.Location = new System.Drawing.Point(238, 20);
            this.txtWorldId.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.txtWorldId.Name = "txtWorldId";
            this.txtWorldId.Size = new System.Drawing.Size(300, 26);
            this.txtWorldId.TabIndex = 7;
            // 
            // labelPriority
            // 
            this.labelPriority.AutoSize = true;
            this.labelPriority.Location = new System.Drawing.Point(15, 60);
            this.labelPriority.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.labelPriority.Name = "labelPriority";
            this.labelPriority.Size = new System.Drawing.Size(188, 20);
            this.labelPriority.TabIndex = 8;
            this.labelPriority.Text = "Priority (World List Order):";
            this.toolTip1.SetToolTip(this.labelPriority, "Number should be set so that your scenario appears first or last. Other numbers may result in random sorting.");
            // 
            // nudPriority
            // 
            this.nudPriority.Location = new System.Drawing.Point(238, 60);
            this.nudPriority.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.nudPriority.Name = "nudPriority";
            this.nudPriority.Size = new System.Drawing.Size(120, 26);
            this.nudPriority.TabIndex = 9;
            // 
            // labelNameKey
            // 
            this.labelNameKey.AutoSize = true;
            this.labelNameKey.Location = new System.Drawing.Point(15, 100);
            this.labelNameKey.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.labelNameKey.Name = "labelNameKey";
            this.labelNameKey.Size = new System.Drawing.Size(75, 20);
            this.labelNameKey.TabIndex = 10;
            this.labelNameKey.Text = "Name Key:";
            this.toolTip1.SetToolTip(this.labelNameKey, "This key links the World Settings to your full text in your Language file(s).");
            // 
            // txtNameKey
            // 
            this.txtNameKey.Location = new System.Drawing.Point(238, 100);
            this.txtNameKey.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.txtNameKey.Name = "txtNameKey";
            this.txtNameKey.Size = new System.Drawing.Size(200, 26);
            this.txtNameKey.TabIndex = 11;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(15, 140);
            this.labelName.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(55, 20);
            this.labelName.TabIndex = 12;
            this.labelName.Text = "Name:";
            // 
            // txtNameValue
            // 
            this.txtNameValue.AcceptsReturn = true;
            this.txtNameValue.Location = new System.Drawing.Point(238, 140);
            this.txtNameValue.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.txtNameValue.Multiline = true;
            this.txtNameValue.Name = "txtNameValue";
            this.txtNameValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNameValue.Size = new System.Drawing.Size(300, 80);
            this.txtNameValue.TabIndex = 13;
            this.txtNameValue.WordWrap = true;
            // 
            // labelDescKey
            // 
            this.labelDescKey.AutoSize = true;
            this.labelDescKey.Location = new System.Drawing.Point(15, 240);
            this.labelDescKey.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.labelDescKey.Name = "labelDescKey";
            this.labelDescKey.Size = new System.Drawing.Size(108, 20);
            this.labelDescKey.TabIndex = 14;
            this.labelDescKey.Text = "Description Key:";
            this.toolTip1.SetToolTip(this.labelDescKey, "This key links the World Settings to your full text in your Language file(s).");
            // 
            // txtDescKey
            // 
            this.txtDescKey.Location = new System.Drawing.Point(238, 240);
            this.txtDescKey.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.txtDescKey.Name = "txtDescKey";
            this.txtDescKey.Size = new System.Drawing.Size(200, 26);
            this.txtDescKey.TabIndex = 15;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(15, 280);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(88, 20);
            this.labelDescription.TabIndex = 16;
            this.labelDescription.Text = "Description:";
            // 
            // txtDescValue
            // 
            this.txtDescValue.AcceptsReturn = true;
            this.txtDescValue.Location = new System.Drawing.Point(238, 280);
            this.txtDescValue.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.txtDescValue.Multiline = true;
            this.txtDescValue.Name = "txtDescValue";
            this.txtDescValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescValue.Size = new System.Drawing.Size(300, 80);
            this.txtDescValue.TabIndex = 17;
            this.txtDescValue.WordWrap = true;
            // 
            // labelShortDescKey
            // 
            this.labelShortDescKey.AutoSize = true;
            this.labelShortDescKey.Location = new System.Drawing.Point(15, 380);
            this.labelShortDescKey.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.labelShortDescKey.Name = "labelShortDescKey";
            this.labelShortDescKey.Size = new System.Drawing.Size(138, 20);
            this.labelShortDescKey.TabIndex = 18;
            this.labelShortDescKey.Text = "Short Description Key:";
            this.toolTip1.SetToolTip(this.labelShortDescKey, "This key links the World Settings to your full text in your Language file(s).");
            // 
            // txtShortDescKey
            // 
            this.txtShortDescKey.Location = new System.Drawing.Point(238, 380);
            this.txtShortDescKey.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.txtShortDescKey.Name = "txtShortDescKey";
            this.txtShortDescKey.Size = new System.Drawing.Size(200, 26);
            this.txtShortDescKey.TabIndex = 19;
            // 
            // labelShortDesc
            // 
            this.labelShortDesc.AutoSize = true;
            this.labelShortDesc.Location = new System.Drawing.Point(15, 420);
            this.labelShortDesc.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.labelShortDesc.Name = "labelShortDesc";
            this.labelShortDesc.Size = new System.Drawing.Size(118, 20);
            this.labelShortDesc.TabIndex = 20;
            this.labelShortDesc.Text = "Short Description:";
            // 
            // txtShortDescValue
            // 
            this.txtShortDescValue.AcceptsReturn = true;
            this.txtShortDescValue.Location = new System.Drawing.Point(238, 420);
            this.txtShortDescValue.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.txtShortDescValue.Multiline = true;
            this.txtShortDescValue.Name = "txtShortDescValue";
            this.txtShortDescValue.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShortDescValue.Size = new System.Drawing.Size(300, 80);
            this.txtShortDescValue.TabIndex = 21;
            this.txtShortDescValue.WordWrap = true;
            // 
            // labelSummary
            // 
            this.labelSummary.AutoSize = true;
            this.labelSummary.Location = new System.Drawing.Point(15, 520);
            this.labelSummary.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(110, 20);
            this.labelSummary.TabIndex = 22;
            this.labelSummary.Text = "Summary Key:";
            // 
            // txtSummary
            // 
            this.txtSummary.AcceptsReturn = true;
            this.txtSummary.Location = new System.Drawing.Point(238, 520);
            this.txtSummary.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSummary.Size = new System.Drawing.Size(300, 80);
            this.txtSummary.TabIndex = 23;
            this.txtSummary.WordWrap = true;
            // 
            // column1TableLayout
            // 
            this.column1TableLayout.AutoSize = true;
            this.column1TableLayout.ColumnCount = 1;
            this.column1TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.column1TableLayout.Controls.Add(this.startConditionsGroupBox, 0, 0);
            this.column1TableLayout.Controls.Add(this.startLocationsGroupBox, 0, 1);
            this.column1TableLayout.Controls.Add(this.objectivesGroupBox, 0, 2);
            this.column1TableLayout.Location = new System.Drawing.Point(402, 2);
            this.column1TableLayout.Margin = new System.Windows.Forms.Padding(2);
            this.column1TableLayout.Name = "column1TableLayout";
            this.column1TableLayout.RowCount = 3;
            this.column1TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.column1TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.column1TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.column1TableLayout.TabIndex = 3;
            // 
            // startConditionsGroupBox
            // 
            this.startConditionsGroupBox.AutoSize = true;
            this.startConditionsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.startConditionsGroupBox.Controls.Add(this.startConditionsTableLayout);
            this.startConditionsGroupBox.Location = new System.Drawing.Point(2, 2);
            this.startConditionsGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.startConditionsGroupBox.Name = "startConditionsGroupBox";
            this.startConditionsGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.startConditionsGroupBox.TabIndex = 0;
            this.startConditionsGroupBox.TabStop = false;
            this.startConditionsGroupBox.Text = "Start Conditions";
            // 
            // startConditionsTableLayout
            // 
            this.startConditionsTableLayout.AutoSize = true;
            this.startConditionsTableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.startConditionsTableLayout.ColumnCount = 2;
            this.startConditionsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.startConditionsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startConditionsTableLayout.Controls.Add(this.startConditionsButtonPanel, 0, 0);
            this.startConditionsTableLayout.Controls.Add(this.clbStartConditions, 1, 0);
            this.startConditionsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startConditionsTableLayout.Location = new System.Drawing.Point(2, 15);
            this.startConditionsTableLayout.Margin = new System.Windows.Forms.Padding(2);
            this.startConditionsTableLayout.Name = "startConditionsTableLayout";
            this.startConditionsTableLayout.RowCount = 1;
            this.startConditionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startConditionsTableLayout.TabIndex = 0;
            // 
            // startConditionsButtonPanel
            // 
            this.startConditionsButtonPanel.AutoSize = true;
            this.startConditionsButtonPanel.Controls.Add(this.btnAddCondition);
            this.startConditionsButtonPanel.Controls.Add(this.btnDeleteCondition);
            this.startConditionsButtonPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.startConditionsButtonPanel.Location = new System.Drawing.Point(2, 2);
            this.startConditionsButtonPanel.Margin = new System.Windows.Forms.Padding(2);
            this.startConditionsButtonPanel.Name = "startConditionsButtonPanel";
            this.startConditionsButtonPanel.Size = new System.Drawing.Size(64, 70);
            this.startConditionsButtonPanel.TabIndex = 0;
            // 
            // btnAddCondition
            // 
            this.btnAddCondition.Location = new System.Drawing.Point(3, 3);
            this.btnAddCondition.Margin = new System.Windows.Forms.Padding(3);
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new System.Drawing.Size(30, 30);
            this.btnAddCondition.TabIndex = 21;
            this.btnAddCondition.Text = "+";
            this.btnAddCondition.UseVisualStyleBackColor = true;
            this.btnAddCondition.Click += new System.EventHandler(this.btnAddCondition_Click);
            // 
            // btnDeleteCondition
            // 
            this.btnDeleteCondition.Location = new System.Drawing.Point(3, 36);
            this.btnDeleteCondition.Margin = new System.Windows.Forms.Padding(3);
            this.btnDeleteCondition.Name = "btnDeleteCondition";
            this.btnDeleteCondition.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteCondition.TabIndex = 22;
            this.btnDeleteCondition.Text = "🗑";
            this.btnDeleteCondition.UseVisualStyleBackColor = true;
            this.btnDeleteCondition.Click += new System.EventHandler(this.btnDeleteCondition_Click);
            // 
            // clbStartConditions
            // 
            this.clbStartConditions.Location = new System.Drawing.Point(72, 2);
            this.clbStartConditions.Name = "clbStartConditions";
            this.clbStartConditions.Size = new System.Drawing.Size(809, 319);
            this.clbStartConditions.TabIndex = 23;
            // 
            // startLocationsGroupBox
            // 
            this.startLocationsGroupBox.AutoSize = true;
            this.startLocationsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.startLocationsGroupBox.Controls.Add(this.startLocationsTableLayout);
            this.startLocationsGroupBox.Location = new System.Drawing.Point(2, 2);
            this.startLocationsGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.startLocationsGroupBox.Name = "startLocationsGroupBox";
            this.startLocationsGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.startLocationsGroupBox.TabIndex = 24;
            this.startLocationsGroupBox.TabStop = false;
            this.startLocationsGroupBox.Text = "Start Locations";
            // 
            // startLocationsTableLayout
            // 
            this.startLocationsTableLayout.AutoSize = true;
            this.startLocationsTableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.startLocationsTableLayout.ColumnCount = 2;
            this.startLocationsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.startLocationsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startLocationsTableLayout.Controls.Add(this.startLocationsButtonPanel, 0, 0);
            this.startLocationsTableLayout.Controls.Add(this.lvStartLocations, 1, 0);
            this.startLocationsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startLocationsTableLayout.Location = new System.Drawing.Point(2, 15);
            this.startLocationsTableLayout.Margin = new System.Windows.Forms.Padding(2);
            this.startLocationsTableLayout.Name = "startLocationsTableLayout";
            this.startLocationsTableLayout.RowCount = 1;
            this.startLocationsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startLocationsTableLayout.TabIndex = 25;
            // 
            // startLocationsButtonPanel
            // 
            this.startLocationsButtonPanel.AutoSize = true;
            this.startLocationsButtonPanel.Controls.Add(this.btnAddLocation);
            this.startLocationsButtonPanel.Controls.Add(this.btnDeleteLocation);
            this.startLocationsButtonPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.startLocationsButtonPanel.Location = new System.Drawing.Point(2, 2);
            this.startLocationsButtonPanel.Margin = new System.Windows.Forms.Padding(2);
            this.startLocationsButtonPanel.Name = "startLocationsButtonPanel";
            this.startLocationsButtonPanel.Size = new System.Drawing.Size(64, 70);
            this.startLocationsButtonPanel.TabIndex = 26;
            // 
            // btnAddLocation
            // 
            this.btnAddLocation.Location = new System.Drawing.Point(3, 3);
            this.btnAddLocation.Margin = new System.Windows.Forms.Padding(3);
            this.btnAddLocation.Name = "btnAddLocation";
            this.btnAddLocation.Size = new System.Drawing.Size(30, 30);
            this.btnAddLocation.TabIndex = 27;
            this.btnAddLocation.Text = "+";
            this.btnAddLocation.UseVisualStyleBackColor = true;
            this.btnAddLocation.Click += new System.EventHandler(this.btnAddLocation_Click);
            // 
            // btnDeleteLocation
            // 
            this.btnDeleteLocation.Location = new System.Drawing.Point(3, 36);
            this.btnDeleteLocation.Margin = new System.Windows.Forms.Padding(3);
            this.btnDeleteLocation.Name = "btnDeleteLocation";
            this.btnDeleteLocation.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteLocation.TabIndex = 28;
            this.btnDeleteLocation.Text = "🗑";
            this.btnDeleteLocation.UseVisualStyleBackColor = true;
            this.btnDeleteLocation.Click += new System.EventHandler(this.btnDeleteLocation_Click);
            // 
            // lvStartLocations
            // 
            this.lvStartLocations.HideSelection = false;
            this.lvStartLocations.Location = new System.Drawing.Point(72, 2);
            this.lvStartLocations.Name = "lvStartLocations";
            this.lvStartLocations.Size = new System.Drawing.Size(809, 319);
            this.lvStartLocations.TabIndex = 29;
            this.lvStartLocations.UseCompatibleStateImageBehavior = false;
            this.lvStartLocations.View = System.Windows.Forms.View.Details;
            // 
            // objectivesGroupBox
            // 
            this.objectivesGroupBox.AutoSize = true;
            this.objectivesGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.objectivesGroupBox.Controls.Add(this.objectivesTableLayout);
            this.objectivesGroupBox.Location = new System.Drawing.Point(2, 2);
            this.objectivesGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.objectivesGroupBox.Name = "objectivesGroupBox";
            this.objectivesGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.objectivesGroupBox.TabIndex = 30;
            this.objectivesGroupBox.TabStop = false;
            this.objectivesGroupBox.Text = "Objectives";
            // 
            // objectivesTableLayout
            // 
            this.objectivesTableLayout.AutoSize = true;
            this.objectivesTableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.objectivesTableLayout.ColumnCount = 2;
            this.objectivesTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.objectivesTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.objectivesTableLayout.Controls.Add(this.objectivesButtonPanel, 0, 0);
            this.objectivesTableLayout.Controls.Add(this.lvObjectives, 1, 0);
            this.objectivesTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectivesTableLayout.Location = new System.Drawing.Point(2, 15);
            this.objectivesTableLayout.Margin = new System.Windows.Forms.Padding(2);
            this.objectivesTableLayout.Name = "objectivesTableLayout";
            this.objectivesTableLayout.RowCount = 1;
            this.objectivesTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.objectivesTableLayout.TabIndex = 31;
            // 
            // objectivesButtonPanel
            // 
            this.objectivesButtonPanel.AutoSize = true;
            this.objectivesButtonPanel.Controls.Add(this.btnAddObjective);
            this.objectivesButtonPanel.Controls.Add(this.btnDeleteObjective);
            this.objectivesButtonPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.objectivesButtonPanel.Location = new System.Drawing.Point(2, 2);
            this.objectivesButtonPanel.Margin = new System.Windows.Forms.Padding(2);
            this.objectivesButtonPanel.Name = "objectivesButtonPanel";
            this.objectivesButtonPanel.Size = new System.Drawing.Size(64, 70);
            this.objectivesButtonPanel.TabIndex = 32;
            // 
            // btnAddObjective
            // 
            this.btnAddObjective.Location = new System.Drawing.Point(3, 3);
            this.btnAddObjective.Margin = new System.Windows.Forms.Padding(3);
            this.btnAddObjective.Name = "btnAddObjective";
            this.btnAddObjective.Size = new System.Drawing.Size(30, 30);
            this.btnAddObjective.TabIndex = 33;
            this.btnAddObjective.Text = "+";
            this.btnAddObjective.UseVisualStyleBackColor = true;
            this.btnAddObjective.Click += new System.EventHandler(this.btnAddObjective_Click);
            // 
            // btnDeleteObjective
            // 
            this.btnDeleteObjective.Location = new System.Drawing.Point(3, 36);
            this.btnDeleteObjective.Margin = new System.Windows.Forms.Padding(3);
            this.btnDeleteObjective.Name = "btnDeleteObjective";
            this.btnDeleteObjective.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteObjective.TabIndex = 34;
            this.btnDeleteObjective.Text = "🗑";
            this.btnDeleteObjective.UseVisualStyleBackColor = true;
            this.btnDeleteObjective.Click += new System.EventHandler(this.btnDeleteObjective_Click);
            // 
            // lvObjectives
            // 
            this.lvObjectives.HideSelection = false;
            this.lvObjectives.Location = new System.Drawing.Point(72, 2);
            this.lvObjectives.Name = "lvObjectives";
            this.lvObjectives.Size = new System.Drawing.Size(809, 319);
            this.lvObjectives.TabIndex = 35;
            this.lvObjectives.UseCompatibleStateImageBehavior = false;
            this.lvObjectives.View = System.Windows.Forms.View.Details;
            // 
            // tableLayoutPanelButtons
            // 
            this.tableLayoutPanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelButtons.ColumnCount = 2;
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelButtons.Controls.Add(this.btnClearAll, 0, 0);
            this.tableLayoutPanelButtons.Controls.Add(this.btnSaveWorldSettings, 1, 0);
            this.tableLayoutPanelButtons.Location = new System.Drawing.Point(1119, 730);
            this.tableLayoutPanelButtons.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            this.tableLayoutPanelButtons.RowCount = 1;
            this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelButtons.Size = new System.Drawing.Size(316, 44);
            this.tableLayoutPanelButtons.TabIndex = 2;
            // 
            // btnClearAll
            // 
            this.btnClearAll.AutoSize = true;
            this.btnClearAll.Location = new System.Drawing.Point(6, 8);
            this.btnClearAll.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(147, 33);
            this.btnClearAll.TabIndex = 0;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnSaveWorldSettings
            // 
            this.btnSaveWorldSettings.AutoSize = true;
            this.btnSaveWorldSettings.Location = new System.Drawing.Point(165, 8);
            this.btnSaveWorldSettings.Margin = new System.Windows.Forms.Padding(6, 8, 15, 8);
            this.btnSaveWorldSettings.Name = "btnSaveWorldSettings";
            this.btnSaveWorldSettings.Size = new System.Drawing.Size(139, 33);
            this.btnSaveWorldSettings.TabIndex = 1;
            this.btnSaveWorldSettings.Text = "Save";
            this.btnSaveWorldSettings.UseVisualStyleBackColor = true;
            this.btnSaveWorldSettings.Click += new System.EventHandler(this.btnSaveWorldSettings_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.SetToolTip(this.txtWorldId, "Must be Unique or Vanilla settings may be merged into your scenario or your scenario might alter the Vanilla world.");
            this.toolTip1.SetToolTip(this.nudPriority, "Number should be set so that your scenario appears first or last. Other numbers may result in random sorting.");
            this.toolTip1.SetToolTip(this.txtNameKey, "This key links the World Settings to your full text in your Language file(s).");
            this.toolTip1.SetToolTip(this.txtDescKey, "This key links the World Settings to your full text in your Language file(s).");
            this.toolTip1.SetToolTip(this.txtShortDescKey, "This key links the World Settings to your full text in your Language file(s).");
            // 
            // WorldEditorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.scrollPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WorldEditorUserControl";
            this.Size = new System.Drawing.Size(1280, 780);
            this.scrollPanel.ResumeLayout(false);
            this.scrollPanel.PerformLayout();
            this.outerTableLayout.ResumeLayout(false);
            this.outerTableLayout.PerformLayout();
            this.modPathTableLayout.ResumeLayout(false);
            this.modPathTableLayout.PerformLayout();
            this.innerTableLayout.ResumeLayout(false);
            this.innerTableLayout.PerformLayout();
            this.column0TableLayout.ResumeLayout(false);
            this.column0TableLayout.PerformLayout();
            this.worldSettingsGroupBox.ResumeLayout(false);
            this.worldSettingsTableLayout.ResumeLayout(false);
            this.worldSettingsTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).EndInit();
            this.column1TableLayout.ResumeLayout(false);
            this.column1TableLayout.PerformLayout();
            this.startConditionsGroupBox.ResumeLayout(false);
            this.startConditionsGroupBox.PerformLayout();
            this.startConditionsTableLayout.ResumeLayout(false);
            this.startConditionsTableLayout.PerformLayout();
            this.startConditionsButtonPanel.ResumeLayout(false);
            this.startLocationsGroupBox.ResumeLayout(false);
            this.startLocationsGroupBox.PerformLayout();
            this.startLocationsTableLayout.ResumeLayout(false);
            this.startLocationsTableLayout.PerformLayout();
            this.startLocationsButtonPanel.ResumeLayout(false);
            this.objectivesGroupBox.ResumeLayout(false);
            this.objectivesGroupBox.PerformLayout();
            this.objectivesTableLayout.ResumeLayout(false);
            this.objectivesTableLayout.PerformLayout();
            this.objectivesButtonPanel.ResumeLayout(false);
            this.tableLayoutPanelButtons.ResumeLayout(false);
            this.tableLayoutPanelButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
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
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.TableLayoutPanel column1TableLayout;
        private System.Windows.Forms.GroupBox startConditionsGroupBox;
        private System.Windows.Forms.TableLayoutPanel startConditionsTableLayout;
        private System.Windows.Forms.FlowLayoutPanel startConditionsButtonPanel;
        private System.Windows.Forms.Button btnAddCondition;
        private System.Windows.Forms.Button btnDeleteCondition;
        private System.Windows.Forms.CheckedListBox clbStartConditions;
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