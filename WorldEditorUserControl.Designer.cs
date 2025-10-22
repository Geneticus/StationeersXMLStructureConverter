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
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.outerTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.innerTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.column0TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.column1TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.worldSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.worldSettingsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.labelWorldId = new System.Windows.Forms.Label();
            this.txtWorldId = new System.Windows.Forms.TextBox();
            this.labelPriority = new System.Windows.Forms.Label();
            this.nudPriority = new System.Windows.Forms.NumericUpDown();
            this.labelName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.labelShortDesc = new System.Windows.Forms.Label();
            this.txtShortDesc = new System.Windows.Forms.TextBox();
            this.labelSummary = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.TextBox();
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
            this.btnSaveWorldSettings = new System.Windows.Forms.Button();
            this.scrollPanel.SuspendLayout();
            this.outerTableLayout.SuspendLayout();
            this.innerTableLayout.SuspendLayout();
            this.column0TableLayout.SuspendLayout();
            this.column1TableLayout.SuspendLayout();
            this.worldSettingsGroupBox.SuspendLayout();
            this.worldSettingsTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).BeginInit();
            this.startConditionsGroupBox.SuspendLayout();
            this.startConditionsTableLayout.SuspendLayout();
            this.startConditionsButtonPanel.SuspendLayout();
            this.startLocationsGroupBox.SuspendLayout();
            this.startLocationsTableLayout.SuspendLayout();
            this.startLocationsButtonPanel.SuspendLayout();
            this.objectivesGroupBox.SuspendLayout();
            this.objectivesTableLayout.SuspendLayout();
            this.objectivesButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // scrollPanel
            this.scrollPanel.AutoScroll = false;
            this.scrollPanel.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.scrollPanel.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.scrollPanel.AutoSize = true;
            this.scrollPanel.Controls.Add(this.outerTableLayout);
            this.scrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel.Location = new System.Drawing.Point(0, 0);
            this.scrollPanel.Margin = new System.Windows.Forms.Padding(15);
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.TabIndex = 0;
            // outerTableLayout
            this.outerTableLayout.AutoSize = true;
            this.outerTableLayout.ColumnCount = 1;
            this.outerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outerTableLayout.Controls.Add(this.innerTableLayout, 0, 0);
            this.outerTableLayout.Controls.Add(this.btnSaveWorldSettings, 0, 1);
            this.outerTableLayout.Location = new System.Drawing.Point(15, 15);
            this.outerTableLayout.Margin = new System.Windows.Forms.Padding(15);
            this.outerTableLayout.Name = "outerTableLayout";
            this.outerTableLayout.RowCount = 2;
            this.outerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.outerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.outerTableLayout.TabIndex = 1;
            // innerTableLayout
            this.innerTableLayout.AutoSize = true;
            this.innerTableLayout.ColumnCount = 2;
            this.innerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.innerTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 900F));
            this.innerTableLayout.Controls.Add(this.column0TableLayout, 0, 0);
            this.innerTableLayout.Controls.Add(this.column1TableLayout, 1, 0);
            this.innerTableLayout.Location = new System.Drawing.Point(15, 15);
            this.innerTableLayout.Margin = new System.Windows.Forms.Padding(15);
            this.innerTableLayout.Name = "innerTableLayout";
            this.innerTableLayout.RowCount = 1;
            this.innerTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.innerTableLayout.TabIndex = 0;
            // column0TableLayout
            this.column0TableLayout.AutoSize = true;
            this.column0TableLayout.ColumnCount = 1;
            this.column0TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.column0TableLayout.Controls.Add(this.worldSettingsGroupBox, 0, 0);
            this.column0TableLayout.Location = new System.Drawing.Point(3, 3);
            this.column0TableLayout.Margin = new System.Windows.Forms.Padding(3);
            this.column0TableLayout.Name = "column0TableLayout";
            this.column0TableLayout.RowCount = 1;
            this.column0TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.column0TableLayout.TabIndex = 2;
            // column1TableLayout
            this.column1TableLayout.AutoSize = true;
            this.column1TableLayout.ColumnCount = 1;
            this.column1TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.column1TableLayout.Controls.Add(this.startLocationsGroupBox, 0, 0);
            this.column1TableLayout.Controls.Add(this.objectivesGroupBox, 0, 1);
            this.column1TableLayout.Controls.Add(this.startConditionsGroupBox, 0, 2);
            this.column1TableLayout.Location = new System.Drawing.Point(606, 3);
            this.column1TableLayout.Margin = new System.Windows.Forms.Padding(3);
            this.column1TableLayout.Name = "column1TableLayout";
            this.column1TableLayout.RowCount = 3;
            this.column1TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.column1TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.column1TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.column1TableLayout.TabIndex = 3;
            // worldSettingsGroupBox
            this.worldSettingsGroupBox.AutoSize = true;
            this.worldSettingsGroupBox.Controls.Add(this.worldSettingsTableLayout);
            this.worldSettingsGroupBox.Location = new System.Drawing.Point(3, 3);
            this.worldSettingsGroupBox.Margin = new System.Windows.Forms.Padding(3);
            this.worldSettingsGroupBox.Name = "worldSettingsGroupBox";
            this.worldSettingsGroupBox.TabIndex = 4;
            this.worldSettingsGroupBox.TabStop = false;
            this.worldSettingsGroupBox.Text = "World Settings";
            // worldSettingsTableLayout
            this.worldSettingsTableLayout.AutoSize = true;
            this.worldSettingsTableLayout.ColumnCount = 2;
            this.worldSettingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 208F));
            this.worldSettingsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.worldSettingsTableLayout.Controls.Add(this.labelWorldId, 0, 0);
            this.worldSettingsTableLayout.Controls.Add(this.txtWorldId, 1, 0);
            this.worldSettingsTableLayout.Controls.Add(this.labelPriority, 0, 1);
            this.worldSettingsTableLayout.Controls.Add(this.nudPriority, 1, 1);
            this.worldSettingsTableLayout.Controls.Add(this.labelName, 0, 2);
            this.worldSettingsTableLayout.Controls.Add(this.txtName, 1, 2);
            this.worldSettingsTableLayout.Controls.Add(this.labelDescription, 0, 3);
            this.worldSettingsTableLayout.Controls.Add(this.txtDescription, 1, 3);
            this.worldSettingsTableLayout.Controls.Add(this.labelShortDesc, 0, 4);
            this.worldSettingsTableLayout.Controls.Add(this.txtShortDesc, 1, 4);
            this.worldSettingsTableLayout.Controls.Add(this.labelSummary, 0, 5);
            this.worldSettingsTableLayout.Controls.Add(this.txtSummary, 1, 5);
            this.worldSettingsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worldSettingsTableLayout.Location = new System.Drawing.Point(3, 22);
            this.worldSettingsTableLayout.Margin = new System.Windows.Forms.Padding(15, 15, 15, 30);
            this.worldSettingsTableLayout.Name = "worldSettingsTableLayout";
            this.worldSettingsTableLayout.RowCount = 6;
            this.worldSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.worldSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.worldSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.worldSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.worldSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.worldSettingsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.worldSettingsTableLayout.TabIndex = 5;
            // labelWorldId
            this.labelWorldId.AutoSize = true;
            this.labelWorldId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelWorldId.Location = new System.Drawing.Point(15, 20);
            this.labelWorldId.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.labelWorldId.Name = "labelWorldId";
            this.labelWorldId.Size = new System.Drawing.Size(75, 20);
            this.labelWorldId.TabIndex = 6;
            this.labelWorldId.Text = "World ID:";
            // txtWorldId
            this.txtWorldId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtWorldId.Location = new System.Drawing.Point(238, 20);
            this.txtWorldId.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.txtWorldId.Name = "txtWorldId";
            this.txtWorldId.Size = new System.Drawing.Size(300, 26);
            this.txtWorldId.TabIndex = 7;
            // labelPriority
            this.labelPriority.AutoSize = true;
            this.labelPriority.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPriority.Location = new System.Drawing.Point(15, 60);
            this.labelPriority.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.labelPriority.Name = "labelPriority";
            this.labelPriority.Size = new System.Drawing.Size(188, 20);
            this.labelPriority.TabIndex = 8;
            this.labelPriority.Text = "Priority (World List Order):";
            // nudPriority
            this.nudPriority.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudPriority.Location = new System.Drawing.Point(238, 60);
            this.nudPriority.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.nudPriority.Name = "nudPriority";
            this.nudPriority.Size = new System.Drawing.Size(120, 26);
            this.nudPriority.TabIndex = 9;
            // labelName
            this.labelName.AutoSize = true;
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelName.Location = new System.Drawing.Point(15, 100);
            this.labelName.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(55, 20);
            this.labelName.TabIndex = 10;
            this.labelName.Text = "Name:";
            // txtName
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtName.Location = new System.Drawing.Point(238, 100);
            this.txtName.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 26);
            this.txtName.TabIndex = 11;
            // labelDescription
            this.labelDescription.AutoSize = true;
            this.labelDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDescription.Location = new System.Drawing.Point(15, 140);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(123, 20);
            this.labelDescription.TabIndex = 12;
            this.labelDescription.Text = "Description Key:";
            // txtDescription
            this.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDescription.Location = new System.Drawing.Point(238, 140);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(300, 200);
            this.txtDescription.TabIndex = 13;
            // labelShortDesc
            this.labelShortDesc.AutoSize = true;
            this.labelShortDesc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelShortDesc.Location = new System.Drawing.Point(15, 360);
            this.labelShortDesc.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.labelShortDesc.Name = "labelShortDesc";
            this.labelShortDesc.Size = new System.Drawing.Size(123, 20);
            this.labelShortDesc.TabIndex = 14;
            this.labelShortDesc.Text = "Short Desc Key:";
            // txtShortDesc
            this.txtShortDesc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtShortDesc.Location = new System.Drawing.Point(238, 360);
            this.txtShortDesc.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.txtShortDesc.Multiline = true;
            this.txtShortDesc.Name = "txtShortDesc";
            this.txtShortDesc.Size = new System.Drawing.Size(300, 200);
            this.txtShortDesc.TabIndex = 15;
            // labelSummary
            this.labelSummary.AutoSize = true;
            this.labelSummary.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSummary.Location = new System.Drawing.Point(15, 580);
            this.labelSummary.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(110, 20);
            this.labelSummary.TabIndex = 16;
            this.labelSummary.Text = "Summary Key:";
            // txtSummary
            this.txtSummary.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSummary.Location = new System.Drawing.Point(238, 580);
            this.txtSummary.Margin = new System.Windows.Forms.Padding(15, 20, 15, 30);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(300, 200);
            this.txtSummary.TabIndex = 17;
            // startConditionsGroupBox
            this.startConditionsGroupBox.Controls.Add(this.startConditionsTableLayout);
            this.startConditionsGroupBox.Location = new System.Drawing.Point(3, 706);
            this.startConditionsGroupBox.Margin = new System.Windows.Forms.Padding(3);
            this.startConditionsGroupBox.Name = "startConditionsGroupBox";
            this.startConditionsGroupBox.Size = new System.Drawing.Size(870, 350);
            this.startConditionsGroupBox.TabIndex = 18;
            this.startConditionsGroupBox.TabStop = false;
            this.startConditionsGroupBox.Text = "Start Conditions";
            // startConditionsTableLayout
            this.startConditionsTableLayout.AutoSize = true;
            this.startConditionsTableLayout.ColumnCount = 2;
            this.startConditionsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.startConditionsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startConditionsTableLayout.Controls.Add(this.startConditionsButtonPanel, 0, 0);
            this.startConditionsTableLayout.Controls.Add(this.clbStartConditions, 1, 0);
            this.startConditionsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startConditionsTableLayout.Location = new System.Drawing.Point(3, 22);
            this.startConditionsTableLayout.Margin = new System.Windows.Forms.Padding(15, 15, 15, 30);
            this.startConditionsTableLayout.Name = "startConditionsTableLayout";
            this.startConditionsTableLayout.RowCount = 1;
            this.startConditionsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startConditionsTableLayout.Size = new System.Drawing.Size(864, 325);
            this.startConditionsTableLayout.TabIndex = 19;
            // startConditionsButtonPanel
            this.startConditionsButtonPanel.AutoSize = true;
            this.startConditionsButtonPanel.Controls.Add(this.btnAddCondition);
            this.startConditionsButtonPanel.Controls.Add(this.btnDeleteCondition);
            this.startConditionsButtonPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.startConditionsButtonPanel.Location = new System.Drawing.Point(15, 15);
            this.startConditionsButtonPanel.Margin = new System.Windows.Forms.Padding(15);
            this.startConditionsButtonPanel.Name = "startConditionsButtonPanel";
            this.startConditionsButtonPanel.Size = new System.Drawing.Size(40, 100);
            this.startConditionsButtonPanel.TabIndex = 20;
            // btnAddCondition
            this.btnAddCondition.Location = new System.Drawing.Point(3, 3);
            this.btnAddCondition.Margin = new System.Windows.Forms.Padding(3);
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new System.Drawing.Size(30, 30);
            this.btnAddCondition.TabIndex = 21;
            this.btnAddCondition.Text = "+";
            this.btnAddCondition.UseVisualStyleBackColor = true;
            this.btnAddCondition.Click += new System.EventHandler(this.btnAddCondition_Click);
            // btnDeleteCondition
            this.btnDeleteCondition.Location = new System.Drawing.Point(3, 36);
            this.btnDeleteCondition.Margin = new System.Windows.Forms.Padding(3);
            this.btnDeleteCondition.Name = "btnDeleteCondition";
            this.btnDeleteCondition.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteCondition.TabIndex = 22;
            this.btnDeleteCondition.Text = "🗑";
            this.btnDeleteCondition.UseVisualStyleBackColor = true;
            this.btnDeleteCondition.Click += new System.EventHandler(this.btnDeleteCondition_Click);
            // clbStartConditions
            this.clbStartConditions.Location = new System.Drawing.Point(85, 15);
            this.clbStartConditions.Margin = new System.Windows.Forms.Padding(15);
            this.clbStartConditions.Name = "clbStartConditions";
            this.clbStartConditions.Size = new System.Drawing.Size(764, 300);
            this.clbStartConditions.TabIndex = 23;
            // startLocationsGroupBox
            this.startLocationsGroupBox.Controls.Add(this.startLocationsTableLayout);
            this.startLocationsGroupBox.Location = new System.Drawing.Point(3, 3);
            this.startLocationsGroupBox.Margin = new System.Windows.Forms.Padding(3);
            this.startLocationsGroupBox.Name = "startLocationsGroupBox";
            this.startLocationsGroupBox.Size = new System.Drawing.Size(870, 350);
            this.startLocationsGroupBox.TabIndex = 24;
            this.startLocationsGroupBox.TabStop = false;
            this.startLocationsGroupBox.Text = "Start Locations";
            // startLocationsTableLayout
            this.startLocationsTableLayout.AutoSize = true;
            this.startLocationsTableLayout.ColumnCount = 2;
            this.startLocationsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.startLocationsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startLocationsTableLayout.Controls.Add(this.startLocationsButtonPanel, 0, 0);
            this.startLocationsTableLayout.Controls.Add(this.lvStartLocations, 1, 0);
            this.startLocationsTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startLocationsTableLayout.Location = new System.Drawing.Point(3, 22);
            this.startLocationsTableLayout.Margin = new System.Windows.Forms.Padding(15, 15, 15, 30);
            this.startLocationsTableLayout.Name = "startLocationsTableLayout";
            this.startLocationsTableLayout.RowCount = 1;
            this.startLocationsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startLocationsTableLayout.Size = new System.Drawing.Size(864, 325);
            this.startLocationsTableLayout.TabIndex = 25;
            // startLocationsButtonPanel
            this.startLocationsButtonPanel.AutoSize = true;
            this.startLocationsButtonPanel.Controls.Add(this.btnAddLocation);
            this.startLocationsButtonPanel.Controls.Add(this.btnDeleteLocation);
            this.startLocationsButtonPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.startLocationsButtonPanel.Location = new System.Drawing.Point(15, 15);
            this.startLocationsButtonPanel.Margin = new System.Windows.Forms.Padding(15);
            this.startLocationsButtonPanel.Name = "startLocationsButtonPanel";
            this.startLocationsButtonPanel.Size = new System.Drawing.Size(40, 100);
            this.startLocationsButtonPanel.TabIndex = 26;
            // btnAddLocation
            this.btnAddLocation.Location = new System.Drawing.Point(3, 3);
            this.btnAddLocation.Margin = new System.Windows.Forms.Padding(3);
            this.btnAddLocation.Name = "btnAddLocation";
            this.btnAddLocation.Size = new System.Drawing.Size(30, 30);
            this.btnAddLocation.TabIndex = 27;
            this.btnAddLocation.Text = "+";
            this.btnAddLocation.UseVisualStyleBackColor = true;
            this.btnAddLocation.Click += new System.EventHandler(this.btnAddLocation_Click);
            // btnDeleteLocation
            this.btnDeleteLocation.Location = new System.Drawing.Point(3, 36);
            this.btnDeleteLocation.Margin = new System.Windows.Forms.Padding(3);
            this.btnDeleteLocation.Name = "btnDeleteLocation";
            this.btnDeleteLocation.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteLocation.TabIndex = 28;
            this.btnDeleteLocation.Text = "🗑";
            this.btnDeleteLocation.UseVisualStyleBackColor = true;
            this.btnDeleteLocation.Click += new System.EventHandler(this.btnDeleteLocation_Click);
            // lvStartLocations
            this.lvStartLocations.HideSelection = false;
            this.lvStartLocations.Location = new System.Drawing.Point(85, 15);
            this.lvStartLocations.Margin = new System.Windows.Forms.Padding(15);
            this.lvStartLocations.Name = "lvStartLocations";
            this.lvStartLocations.Size = new System.Drawing.Size(764, 300);
            this.lvStartLocations.TabIndex = 29;
            this.lvStartLocations.UseCompatibleStateImageBehavior = false;
            this.lvStartLocations.View = System.Windows.Forms.View.Details;
            // objectivesGroupBox
            this.objectivesGroupBox.Controls.Add(this.objectivesTableLayout);
            this.objectivesGroupBox.Location = new System.Drawing.Point(3, 356);
            this.objectivesGroupBox.Margin = new System.Windows.Forms.Padding(3);
            this.objectivesGroupBox.Name = "objectivesGroupBox";
            this.objectivesGroupBox.Size = new System.Drawing.Size(870, 350);
            this.objectivesGroupBox.TabIndex = 30;
            this.objectivesGroupBox.TabStop = false;
            this.objectivesGroupBox.Text = "Objectives";
            // objectivesTableLayout
            this.objectivesTableLayout.AutoSize = true;
            this.objectivesTableLayout.ColumnCount = 2;
            this.objectivesTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.objectivesTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.objectivesTableLayout.Controls.Add(this.objectivesButtonPanel, 0, 0);
            this.objectivesTableLayout.Controls.Add(this.lvObjectives, 1, 0);
            this.objectivesTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectivesTableLayout.Location = new System.Drawing.Point(3, 22);
            this.objectivesTableLayout.Margin = new System.Windows.Forms.Padding(15, 15, 15, 30);
            this.objectivesTableLayout.Name = "objectivesTableLayout";
            this.objectivesTableLayout.RowCount = 1;
            this.objectivesTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.objectivesTableLayout.Size = new System.Drawing.Size(864, 325);
            this.objectivesTableLayout.TabIndex = 31;
            // objectivesButtonPanel
            this.objectivesButtonPanel.AutoSize = true;
            this.objectivesButtonPanel.Controls.Add(this.btnAddObjective);
            this.objectivesButtonPanel.Controls.Add(this.btnDeleteObjective);
            this.objectivesButtonPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.objectivesButtonPanel.Location = new System.Drawing.Point(15, 15);
            this.objectivesButtonPanel.Margin = new System.Windows.Forms.Padding(15);
            this.objectivesButtonPanel.Name = "objectivesButtonPanel";
            this.objectivesButtonPanel.Size = new System.Drawing.Size(40, 100);
            this.objectivesButtonPanel.TabIndex = 32;
            // btnAddObjective
            this.btnAddObjective.Location = new System.Drawing.Point(3, 3);
            this.btnAddObjective.Margin = new System.Windows.Forms.Padding(3);
            this.btnAddObjective.Name = "btnAddObjective";
            this.btnAddObjective.Size = new System.Drawing.Size(30, 30);
            this.btnAddObjective.TabIndex = 33;
            this.btnAddObjective.Text = "+";
            this.btnAddObjective.UseVisualStyleBackColor = true;
            this.btnAddObjective.Click += new System.EventHandler(this.btnAddObjective_Click);
            // btnDeleteObjective
            this.btnDeleteObjective.Location = new System.Drawing.Point(3, 36);
            this.btnDeleteObjective.Margin = new System.Windows.Forms.Padding(3);
            this.btnDeleteObjective.Name = "btnDeleteObjective";
            this.btnDeleteObjective.Size = new System.Drawing.Size(30, 30);
            this.btnDeleteObjective.TabIndex = 34;
            this.btnDeleteObjective.Text = "🗑";
            this.btnDeleteObjective.UseVisualStyleBackColor = true;
            this.btnDeleteObjective.Click += new System.EventHandler(this.btnDeleteObjective_Click);
            // lvObjectives
            this.lvObjectives.HideSelection = false;
            this.lvObjectives.Location = new System.Drawing.Point(85, 15);
            this.lvObjectives.Margin = new System.Windows.Forms.Padding(15);
            this.lvObjectives.Name = "lvObjectives";
            this.lvObjectives.Size = new System.Drawing.Size(764, 300);
            this.lvObjectives.TabIndex = 35;
            this.lvObjectives.UseCompatibleStateImageBehavior = false;
            this.lvObjectives.View = System.Windows.Forms.View.Details;
            // btnSaveWorldSettings
            this.btnSaveWorldSettings.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveWorldSettings.Location = new System.Drawing.Point(1485, 15);
            this.btnSaveWorldSettings.Margin = new System.Windows.Forms.Padding(15, 20, 15, 20);
            this.btnSaveWorldSettings.Name = "btnSaveWorldSettings";
            this.btnSaveWorldSettings.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3); // Adjusted padding for new height
            this.btnSaveWorldSettings.Size = new System.Drawing.Size(100, 35); // Increased height to 35px
            this.btnSaveWorldSettings.TabIndex = 37;
            this.btnSaveWorldSettings.Text = "Save";
            this.btnSaveWorldSettings.UseVisualStyleBackColor = true;
            this.btnSaveWorldSettings.Click += new System.EventHandler(this.btnSaveWorldSettings_Click);
            // WorldEditorUserControl
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.scrollPanel);
            this.MinimumSize = new System.Drawing.Size(0, 0);
            this.Margin = new System.Windows.Forms.Padding(15);
            this.Name = "WorldEditorUserControl";
            this.scrollPanel.ResumeLayout(false);
            this.scrollPanel.PerformLayout();
            this.outerTableLayout.ResumeLayout(false);
            this.outerTableLayout.PerformLayout();
            this.innerTableLayout.ResumeLayout(false);
            this.innerTableLayout.PerformLayout();
            this.column0TableLayout.ResumeLayout(false);
            this.column0TableLayout.PerformLayout();
            this.column1TableLayout.ResumeLayout(false);
            this.column1TableLayout.PerformLayout();
            this.worldSettingsGroupBox.ResumeLayout(false);
            this.worldSettingsTableLayout.ResumeLayout(false);
            this.worldSettingsTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriority)).EndInit();
            this.startConditionsGroupBox.ResumeLayout(false);
            this.startConditionsTableLayout.ResumeLayout(false);
            this.startConditionsTableLayout.PerformLayout();
            this.startConditionsButtonPanel.ResumeLayout(false);
            this.startLocationsGroupBox.ResumeLayout(false);
            this.startLocationsTableLayout.ResumeLayout(false);
            this.startLocationsTableLayout.PerformLayout();
            this.startLocationsButtonPanel.ResumeLayout(false);
            this.objectivesGroupBox.ResumeLayout(false);
            this.objectivesTableLayout.ResumeLayout(false);
            this.objectivesTableLayout.PerformLayout();
            this.objectivesButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Panel scrollPanel;
        private System.Windows.Forms.TableLayoutPanel outerTableLayout;
        private System.Windows.Forms.TableLayoutPanel innerTableLayout;
        private System.Windows.Forms.TableLayoutPanel column0TableLayout;
        private System.Windows.Forms.TableLayoutPanel column1TableLayout;
        private System.Windows.Forms.GroupBox worldSettingsGroupBox;
        private System.Windows.Forms.TableLayoutPanel worldSettingsTableLayout;
        private System.Windows.Forms.Label labelWorldId;
        private System.Windows.Forms.TextBox txtWorldId;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.NumericUpDown nudPriority;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label labelShortDesc;
        private System.Windows.Forms.TextBox txtShortDesc;
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.TextBox txtSummary;
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
        private System.Windows.Forms.Button btnSaveWorldSettings;
    }
}