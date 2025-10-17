using StationeersSpawnXML;
using StationeersStructureXMLConverter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyleElement.TaskbarClock;

namespace StationeersStructureXMLConverter
{
    partial class Main_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabConversion = new System.Windows.Forms.TabPage();
            this.tabWorldEditor = new System.Windows.Forms.TabPage();
            this.tabTools = new System.Windows.Forms.TabPage();
            this.worldEditorTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.txtWorldId = new System.Windows.Forms.TextBox();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.chkHidden = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtShortDesc = new System.Windows.Forms.TextBox();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.clbStartConditions = new System.Windows.Forms.CheckedListBox();
            this.lvStartLocations = new System.Windows.Forms.ListView();
            this.btnAddLocation = new System.Windows.Forms.Button();
            this.btnEditLocation = new System.Windows.Forms.Button();
            this.btnDeleteLocation = new System.Windows.Forms.Button();
            this.lvObjectives = new System.Windows.Forms.ListView();
            this.btnAddObjective = new System.Windows.Forms.Button();
            this.btnEditObjective = new System.Windows.Forms.Button();
            this.btnDeleteObjective = new System.Windows.Forms.Button();
            this.btnSaveWorldSettings = new System.Windows.Forms.Button();
            this.btnRunXsdGenerator = new System.Windows.Forms.Button();
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
            this.tabConversion.SuspendLayout();
            this.tabWorldEditor.SuspendLayout();
            this.tabTools.SuspendLayout();
            this.worldEditorTableLayout.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabConversion);
            this.tabControlMain.Controls.Add(this.tabWorldEditor);
            this.tabControlMain.Controls.Add(this.tabTools);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1500, 900);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabConversion
            // 
            this.tabConversion.Controls.Add(this.tableLayoutPanel1);
            this.tabConversion.Location = new System.Drawing.Point(4, 22);
            this.tabConversion.Name = "tabConversion";
            this.tabConversion.Size = new System.Drawing.Size(1492, 874);
            this.tabConversion.TabIndex = 0;
            this.tabConversion.Text = "Conversion";
            // 
            // tabWorldEditor
            // 
            this.tabWorldEditor.Controls.Add(this.worldEditorTableLayout);
            this.tabWorldEditor.Location = new System.Drawing.Point(4, 22);
            this.tabWorldEditor.Name = "tabWorldEditor";
            this.tabWorldEditor.Size = new System.Drawing.Size(1492, 874);
            this.tabWorldEditor.TabIndex = 1;
            this.tabWorldEditor.Text = "World Editor";
            // 
            // worldEditorTableLayout
            // 
            this.worldEditorTableLayout.ColumnCount = 2;
            this.worldEditorTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.worldEditorTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.worldEditorTableLayout.RowCount = 5;
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.worldEditorTableLayout.Controls.Add(new System.Windows.Forms.Label { Text = "World ID:", AutoSize = true }, 0, 0);
            this.worldEditorTableLayout.Controls.Add(this.txtWorldId, 0, 0);
            this.worldEditorTableLayout.Controls.Add(new System.Windows.Forms.Label { Text = "Priority:", AutoSize = true }, 0, 0);
            this.worldEditorTableLayout.Controls.Add(this.txtPriority, 0, 0);
            this.worldEditorTableLayout.Controls.Add(new System.Windows.Forms.Label { Text = "Hidden:", AutoSize = true }, 0, 0);
            this.worldEditorTableLayout.Controls.Add(this.chkHidden, 0, 0);
            this.worldEditorTableLayout.Controls.Add(new System.Windows.Forms.Label { Text = "Name:", AutoSize = true }, 0, 0);
            this.worldEditorTableLayout.Controls.Add(this.txtName, 0, 0);
            this.worldEditorTableLayout.Controls.Add(new System.Windows.Forms.Label { Text = "Description Key:", AutoSize = true }, 0, 1);
            this.worldEditorTableLayout.Controls.Add(this.txtDescription, 0, 1);
            this.worldEditorTableLayout.Controls.Add(new System.Windows.Forms.Label { Text = "Short Desc Key:", AutoSize = true }, 0, 1);
            this.worldEditorTableLayout.Controls.Add(this.txtShortDesc, 0, 1);
            this.worldEditorTableLayout.Controls.Add(new System.Windows.Forms.Label { Text = "Summary Key:", AutoSize = true }, 0, 1);
            this.worldEditorTableLayout.Controls.Add(this.txtSummary, 0, 1);
            this.worldEditorTableLayout.Controls.Add(new System.Windows.Forms.Label { Text = "Start Conditions:", AutoSize = true }, 1, 0);
            this.worldEditorTableLayout.Controls.Add(this.clbStartConditions, 1, 0);
            this.worldEditorTableLayout.Controls.Add(new System.Windows.Forms.Label { Text = "Start Locations:", AutoSize = true }, 0, 2);
            this.worldEditorTableLayout.Controls.Add(this.lvStartLocations, 0, 2);
            this.worldEditorTableLayout.Controls.Add(this.btnAddLocation, 0, 3);
            this.worldEditorTableLayout.Controls.Add(this.btnEditLocation, 0, 3);
            this.worldEditorTableLayout.Controls.Add(this.btnDeleteLocation, 0, 3);
            this.worldEditorTableLayout.Controls.Add(new System.Windows.Forms.Label { Text = "Objectives:", AutoSize = true }, 1, 2);
            this.worldEditorTableLayout.Controls.Add(this.lvObjectives, 1, 2);
            this.worldEditorTableLayout.Controls.Add(this.btnAddObjective, 1, 3);
            this.worldEditorTableLayout.Controls.Add(this.btnEditObjective, 1, 3);
            this.worldEditorTableLayout.Controls.Add(this.btnDeleteObjective, 1, 3);
            this.worldEditorTableLayout.Controls.Add(this.btnSaveWorldSettings, 0, 4);
            this.worldEditorTableLayout.SetRow(this.txtWorldId, 0);
            this.worldEditorTableLayout.SetColumn(this.txtWorldId, 1);
            this.worldEditorTableLayout.SetRow(this.txtPriority, 1);
            this.worldEditorTableLayout.SetColumn(this.txtPriority, 1);
            this.worldEditorTableLayout.SetRow(this.chkHidden, 2);
            this.worldEditorTableLayout.SetColumn(this.chkHidden, 1);
            this.worldEditorTableLayout.SetRow(this.txtName, 3);
            this.worldEditorTableLayout.SetColumn(this.txtName, 1);
            this.worldEditorTableLayout.SetRow(this.txtDescription, 0);
            this.worldEditorTableLayout.SetColumn(this.txtDescription, 1);
            this.worldEditorTableLayout.SetRow(this.txtShortDesc, 1);
            this.worldEditorTableLayout.SetColumn(this.txtShortDesc, 1);
            this.worldEditorTableLayout.SetRow(this.txtSummary, 2);
            this.worldEditorTableLayout.SetColumn(this.txtSummary, 1);
            this.worldEditorTableLayout.SetRow(this.clbStartConditions, 0);
            this.worldEditorTableLayout.SetColumn(this.clbStartConditions, 1);
            this.worldEditorTableLayout.SetRow(this.lvStartLocations, 0);
            this.worldEditorTableLayout.SetColumn(this.lvStartLocations, 0);
            this.worldEditorTableLayout.SetRow(this.btnAddLocation, 0);
            this.worldEditorTableLayout.SetColumn(this.btnAddLocation, 1);
            this.worldEditorTableLayout.SetRow(this.btnEditLocation, 1);
            this.worldEditorTableLayout.SetColumn(this.btnEditLocation, 1);
            this.worldEditorTableLayout.SetRow(this.btnDeleteLocation, 2);
            this.worldEditorTableLayout.SetColumn(this.btnDeleteLocation, 1);
            this.worldEditorTableLayout.SetRow(this.lvObjectives, 0);
            this.worldEditorTableLayout.SetColumn(this.lvObjectives, 0);
            this.worldEditorTableLayout.SetRow(this.btnAddObjective, 0);
            this.worldEditorTableLayout.SetColumn(this.btnAddObjective, 1);
            this.worldEditorTableLayout.SetRow(this.btnEditObjective, 1);
            this.worldEditorTableLayout.SetColumn(this.btnEditObjective, 1);
            this.worldEditorTableLayout.SetRow(this.btnDeleteObjective, 2);
            this.worldEditorTableLayout.SetColumn(this.btnDeleteObjective, 1);
            this.worldEditorTableLayout.SetRow(this.btnSaveWorldSettings, 0);
            this.worldEditorTableLayout.SetColumn(this.btnSaveWorldSettings, 0);
            this.worldEditorTableLayout.Location = new System.Drawing.Point(10, 10);
            this.worldEditorTableLayout.Name = "worldEditorTableLayout";
            this.worldEditorTableLayout.Size = new System.Drawing.Size(1472, 854);
            this.worldEditorTableLayout.TabIndex = 0;
            // 
            // txtWorldId
            // 
            this.txtWorldId.Location = new System.Drawing.Point(100, 10);
            this.txtWorldId.Size = new System.Drawing.Size(200, 20);
            this.txtWorldId.TabIndex = 0;
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(100, 40);
            this.txtPriority.Size = new System.Drawing.Size(50, 20);
            this.txtPriority.TabIndex = 1;
            // 
            // chkHidden
            // 
            this.chkHidden.Location = new System.Drawing.Point(100, 70);
            this.chkHidden.Name = "chkHidden";
            this.chkHidden.Size = new System.Drawing.Size(80, 20);
            this.chkHidden.Text = "Hidden";
            this.chkHidden.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(100, 100);
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(100, 10);
            this.txtDescription.Size = new System.Drawing.Size(200, 20);
            this.txtDescription.TabIndex = 4;
            // 
            // txtShortDesc
            // 
            this.txtShortDesc.Location = new System.Drawing.Point(100, 40);
            this.txtShortDesc.Size = new System.Drawing.Size(200, 20);
            this.txtShortDesc.TabIndex = 5;
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(100, 70);
            this.txtSummary.Size = new System.Drawing.Size(200, 20);
            this.txtSummary.TabIndex = 6;
            // 
            // clbStartConditions
            // 
            this.clbStartConditions.Location = new System.Drawing.Point(746, 20);
            this.clbStartConditions.Size = new System.Drawing.Size(200, 140);
            this.clbStartConditions.TabIndex = 7;
            // 
            // lvStartLocations
            // 
            this.lvStartLocations.Location = new System.Drawing.Point(10, 330);
            this.lvStartLocations.Size = new System.Drawing.Size(300, 200);
            this.lvStartLocations.View = System.Windows.Forms.View.Details;
            this.lvStartLocations.Columns.Add("X", 80);
            this.lvStartLocations.Columns.Add("Y", 80);
            this.lvStartLocations.Columns.Add("Z", 80);
            this.lvStartLocations.TabIndex = 8;
            // 
            // btnAddLocation
            // 
            this.btnAddLocation.Location = new System.Drawing.Point(320, 540);
            this.btnAddLocation.Size = new System.Drawing.Size(80, 30);
            this.btnAddLocation.Text = "Add Location";
            this.btnAddLocation.TabIndex = 9;
            this.btnAddLocation.UseVisualStyleBackColor = true;
            this.btnAddLocation.Click += new System.EventHandler(this.btnAddLocation_Click);
            // 
            // btnEditLocation
            // 
            this.btnEditLocation.Location = new System.Drawing.Point(400, 540);
            this.btnEditLocation.Size = new System.Drawing.Size(80, 30);
            this.btnEditLocation.Text = "Edit Location";
            this.btnEditLocation.TabIndex = 10;
            this.btnEditLocation.UseVisualStyleBackColor = true;
            this.btnEditLocation.Click += new System.EventHandler(this.btnEditLocation_Click);
            // 
            // btnDeleteLocation
            // 
            this.btnDeleteLocation.Location = new System.Drawing.Point(480, 540);
            this.btnDeleteLocation.Size = new System.Drawing.Size(80, 30);
            this.btnDeleteLocation.Text = "Delete Location";
            this.btnDeleteLocation.TabIndex = 11;
            this.btnDeleteLocation.UseVisualStyleBackColor = true;
            this.btnDeleteLocation.Click += new System.EventHandler(this.btnDeleteLocation_Click);
            // 
            // lvObjectives
            // 
            this.lvObjectives.Location = new System.Drawing.Point(746, 330);
            this.lvObjectives.Size = new System.Drawing.Size(300, 200);
            this.lvObjectives.View = System.Windows.Forms.View.Details;
            this.lvObjectives.Columns.Add("ID", 100);
            this.lvObjectives.Columns.Add("Description", 100);
            this.lvObjectives.Columns.Add("Info Key", 100);
            this.lvObjectives.TabIndex = 12;
            // 
            // btnAddObjective
            // 
            this.btnAddObjective.Location = new System.Drawing.Point(1056, 540);
            this.btnAddObjective.Size = new System.Drawing.Size(80, 30);
            this.btnAddObjective.Text = "Add Objective";
            this.btnAddObjective.TabIndex = 13;
            this.btnAddObjective.UseVisualStyleBackColor = true;
            this.btnAddObjective.Click += new System.EventHandler(this.btnAddObjective_Click);
            // 
            // btnEditObjective
            // 
            this.btnEditObjective.Location = new System.Drawing.Point(1136, 540);
            this.btnEditObjective.Size = new System.Drawing.Size(80, 30);
            this.btnEditObjective.Text = "Edit Objective";
            this.btnEditObjective.TabIndex = 14;
            this.btnEditObjective.UseVisualStyleBackColor = true;
            this.btnEditObjective.Click += new System.EventHandler(this.btnEditObjective_Click);
            // 
            // btnDeleteObjective
            // 
            this.btnDeleteObjective.Location = new System.Drawing.Point(1216, 540);
            this.btnDeleteObjective.Size = new System.Drawing.Size(80, 30);
            this.btnDeleteObjective.Text = "Delete Objective";
            this.btnDeleteObjective.TabIndex = 15;
            this.btnDeleteObjective.UseVisualStyleBackColor = true;
            this.btnDeleteObjective.Click += new System.EventHandler(this.btnDeleteObjective_Click);
            // 
            // btnSaveWorldSettings
            // 
            this.btnSaveWorldSettings.Location = new System.Drawing.Point(10, 740);
            this.btnSaveWorldSettings.Size = new System.Drawing.Size(80, 30);
            this.btnSaveWorldSettings.Text = "Save";
            this.btnSaveWorldSettings.TabIndex = 16;
            this.btnSaveWorldSettings.UseVisualStyleBackColor = true;
            this.btnSaveWorldSettings.Click += new System.EventHandler(this.btnSaveWorldSettings_Click);
            // 
            // btnRunXsdGenerator
            // 
            this.btnRunXsdGenerator.Location = new System.Drawing.Point(20, 20);
            this.btnRunXsdGenerator.Name = "btnRunXsdGenerator";
            this.btnRunXsdGenerator.Size = new System.Drawing.Size(150, 30);
            this.btnRunXsdGenerator.TabIndex = 0;
            this.btnRunXsdGenerator.Text = "Run XSD Generator";
            this.btnRunXsdGenerator.UseVisualStyleBackColor = true;
            this.btnRunXsdGenerator.Click += new System.EventHandler(this.btnRunXsdGenerator_Click);
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
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1492, 874);
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
            this.labelInstructions.Size = new System.Drawing.Size(1492, 13);
            this.labelInstructions.TabIndex = 0;
            this.labelInstructions.Text = resources.GetString("labelInstructions.Text");
            this.labelInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelPaths
            // 
            this.tableLayoutPanelPaths.ColumnCount = 3;
            this.tableLayoutPanelPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanelPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanelPaths.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanelPaths.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelPaths.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanelPaths.Controls.Add(this.button2, 2, 0);
            this.tableLayoutPanelPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPaths.Location = new System.Drawing.Point(3, 36);
            this.tableLayoutPanelPaths.Name = "tableLayoutPanelPaths";
            this.tableLayoutPanelPaths.RowCount = 1;
            this.tableLayoutPanelPaths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPaths.Size = new System.Drawing.Size(1486, 50);
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
            this.textBox1.Size = new System.Drawing.Size(928, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(1092, 5);
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
            this.ItemFilters_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 497F));
            this.ItemFilters_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 498F));
            this.ItemFilters_TableLayout.Controls.Add(this.WorldTypeOptions_GroupBox, 0, 0);
            this.ItemFilters_TableLayout.Controls.Add(this.ItemFilters_GroupBox, 1, 0);
            this.ItemFilters_TableLayout.Controls.Add(this.Right_GroupBox, 2, 0);
            this.ItemFilters_TableLayout.Location = new System.Drawing.Point(3, 92);
            this.ItemFilters_TableLayout.Name = "ItemFilters_TableLayout";
            this.ItemFilters_TableLayout.RowCount = 1;
            this.ItemFilters_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.ItemFilters_TableLayout.Size = new System.Drawing.Size(1486, 200);
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
            this.ItemFilters_GroupBox.Size = new System.Drawing.Size(489, 190);
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
            this.Right_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Right_GroupBox.Location = new System.Drawing.Point(998, 5);
            this.Right_GroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Right_GroupBox.Name = "Right_GroupBox";
            this.Right_GroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Right_GroupBox.Size = new System.Drawing.Size(490, 190);
            this.Right_GroupBox.TabIndex = 6;
            this.Right_GroupBox.TabStop = false;
            this.Right_GroupBox.Text = "Mod Creation Options";
            // 
            // configureOutputsButton
            // 
            this.configureOutputsButton.AutoSize = true;
            this.configureOutputsButton.Enabled = false;
            this.configureOutputsButton.Location = new System.Drawing.Point(12, 42);
            this.configureOutputsButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.configureOutputsButton.Name = "configureOutputsButton";
            this.configureOutputsButton.Size = new System.Drawing.Size(140, 30);
            this.configureOutputsButton.TabIndex = 0;
            this.configureOutputsButton.Text = "Configure File Outputs";
            this.toolTip1.SetToolTip(this.configureOutputsButton, "Open a form to configure mod creation settings.");
            this.configureOutputsButton.UseVisualStyleBackColor = true;
            this.configureOutputsButton.Click += new System.EventHandler(this.ConfigureOutputs_Click);
            // 
            // configureOutputsLabel
            // 
            this.configureOutputsLabel.AutoSize = true;
            this.configureOutputsLabel.Location = new System.Drawing.Point(9, 23);
            this.configureOutputsLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            this.groupBox2.Size = new System.Drawing.Size(1484, 532);
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
            this.textBox3.Size = new System.Drawing.Size(1476, 509);
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
            this.tableLayoutPanelButtons.Location = new System.Drawing.Point(1276, 857);
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
            this.button1.Click += new System.EventHandler(this.Convert_Click);
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
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 900);
            this.Controls.Add(this.tabControlMain);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1500, 900);
            this.Name = "Main_Form";
            this.Text = "Stationeers Scenario Toolbox";
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
            this.tabConversion.ResumeLayout(false);
            this.tabWorldEditor.ResumeLayout(false);
            this.tabTools.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.worldEditorTableLayout.ResumeLayout(false);
            this.worldEditorTableLayout.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}