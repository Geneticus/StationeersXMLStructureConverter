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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.tableLayoutPanelPaths = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.ItemFilters_TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.WorldTypeOptions_GroupBox = new System.Windows.Forms.GroupBox();
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
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanelButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelInstructions, 0, 0);
            this.tableLayoutPanel1.SetColumnSpan(this.labelInstructions, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelPaths, 0, 1);
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanelPaths, 3);
            this.tableLayoutPanel1.Controls.Add(this.ItemFilters_TableLayout, 0, 2);
            this.tableLayoutPanel1.SetColumnSpan(this.ItemFilters_TableLayout, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 4);
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelButtons, 0, 5);
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanelButtons, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(1500, 900);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1500, 900);
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
            this.labelInstructions.Size = new System.Drawing.Size(1500, 40);
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
            this.tableLayoutPanelPaths.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanelPaths.Name = "tableLayoutPanelPaths";
            this.tableLayoutPanelPaths.RowCount = 1;
            this.tableLayoutPanelPaths.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPaths.Size = new System.Drawing.Size(1494, 100);
            this.tableLayoutPanelPaths.TabIndex = 1;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input XML Path:";
            //
            // textBox1
            //
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(150, 5);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0, 5, 4, 5);
            this.textBox1.MinimumSize = new System.Drawing.Size(300, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1026, 26);
            this.textBox1.TabIndex = 1;
            //
            // button2
            //
            this.button2.AutoSize = false;
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.button2.Size = new System.Drawing.Size(314, 34);
            this.button2.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.button2.Text = "Browse Input";
            this.button2.Click += new System.EventHandler(this.BrowseInput_Click);
            this.toolTip1.SetToolTip(this.button2, "Select the .save file to convert.");
            //
            // ItemFilters_TableLayout
            //
            this.ItemFilters_TableLayout.ColumnCount = 3;
            this.ItemFilters_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.ItemFilters_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.ItemFilters_TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.ItemFilters_TableLayout.Controls.Add(this.WorldTypeOptions_GroupBox, 0, 0);
            this.ItemFilters_TableLayout.Controls.Add(this.ItemFilters_GroupBox, 1, 0);
            this.ItemFilters_TableLayout.Controls.Add(this.Right_GroupBox, 2, 0);
            this.ItemFilters_TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemFilters_TableLayout.Location = new System.Drawing.Point(4, 173);
            this.ItemFilters_TableLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ItemFilters_TableLayout.Name = "ItemFilters_TableLayout";
            this.ItemFilters_TableLayout.RowCount = 1;
            this.ItemFilters_TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ItemFilters_TableLayout.Size = new System.Drawing.Size(1492, 200);
            this.ItemFilters_TableLayout.TabIndex = 2;
            //
            // WorldTypeOptions_GroupBox
            //
            this.WorldTypeOptions_GroupBox.Controls.Add(this.VanillaWorld_CheckBox);
            this.WorldTypeOptions_GroupBox.Controls.Add(this.LocalMod_CheckBox);
            this.WorldTypeOptions_GroupBox.Controls.Add(this.None_CheckBox);
            this.WorldTypeOptions_GroupBox.Controls.Add(this.WorldSelection_ComboBox);
            this.WorldTypeOptions_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorldTypeOptions_GroupBox.Location = new System.Drawing.Point(4, 5);
            this.WorldTypeOptions_GroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WorldTypeOptions_GroupBox.Name = "WorldTypeOptions_GroupBox";
            this.WorldTypeOptions_GroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WorldTypeOptions_GroupBox.Size = new System.Drawing.Size(492, 190);
            this.WorldTypeOptions_GroupBox.TabIndex = 4;
            this.WorldTypeOptions_GroupBox.TabStop = false;
            this.WorldTypeOptions_GroupBox.Text = "World Type Options";
            //
            // VanillaWorld_CheckBox
            //
            this.VanillaWorld_CheckBox.AutoSize = true;
            this.VanillaWorld_CheckBox.Location = new System.Drawing.Point(12, 25);
            this.VanillaWorld_CheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.VanillaWorld_CheckBox.Name = "VanillaWorld_CheckBox";
            this.VanillaWorld_CheckBox.Size = new System.Drawing.Size(110, 24);
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
            this.LocalMod_CheckBox.Size = new System.Drawing.Size(90, 24);
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
            this.None_CheckBox.Size = new System.Drawing.Size(60, 24);
            this.None_CheckBox.TabIndex = 2;
            this.None_CheckBox.Text = "None";
            this.None_CheckBox.UseVisualStyleBackColor = true;
            //
            // WorldSelection_ComboBox
            //
            this.WorldSelection_ComboBox.FormattingEnabled = true;
            this.WorldSelection_ComboBox.Location = new System.Drawing.Point(150, 55);
            this.WorldSelection_ComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WorldSelection_ComboBox.Name = "WorldSelection_ComboBox";
            this.WorldSelection_ComboBox.Size = new System.Drawing.Size(200, 23);
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
            this.ItemFilters_GroupBox.Location = new System.Drawing.Point(500, 5);
            this.ItemFilters_GroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ItemFilters_GroupBox.Name = "ItemFilters_GroupBox";
            this.ItemFilters_GroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ItemFilters_GroupBox.Size = new System.Drawing.Size(492, 190);
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
            this.checkBox2.Size = new System.Drawing.Size(97, 24);
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
            this.checkBox1.Size = new System.Drawing.Size(165, 24);
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
            this.checkBox3.Size = new System.Drawing.Size(135, 24);
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
            this.Filter5_CheckBox.Size = new System.Drawing.Size(80, 24);
            this.Filter5_CheckBox.TabIndex = 3;
            this.Filter5_CheckBox.Text = "Filter 5";
            this.Filter5_CheckBox.UseVisualStyleBackColor = true;
            //
            // Filter6_CheckBox
            //
            this.Filter6_CheckBox.AutoSize = true;
            this.Filter6_CheckBox.Location = new System.Drawing.Point(12, 167);
            this.Filter6_CheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Filter6_CheckBox.Name = "Filter6_CheckBox";
            this.Filter6_CheckBox.Size = new System.Drawing.Size(80, 24);
            this.Filter6_CheckBox.TabIndex = 4;
            this.Filter6_CheckBox.Text = "Filter 6";
            this.Filter6_CheckBox.UseVisualStyleBackColor = true;
            //
            // Right_GroupBox
            //
            this.Right_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Right_GroupBox.Location = new System.Drawing.Point(996, 5);
            this.Right_GroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Right_GroupBox.Name = "Right_GroupBox";
            this.Right_GroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Right_GroupBox.Size = new System.Drawing.Size(492, 190);
            this.Right_GroupBox.TabIndex = 6;
            this.Right_GroupBox.TabStop = false;
            this.Right_GroupBox.Text = "Right Options";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 348);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 9;
            //
            // groupBox2
            //
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 373);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1492, 299);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conversion Log";
            //
            // textBox3
            //
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Location = new System.Drawing.Point(4, 24);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(1484, 270);
            this.textBox3.TabIndex = 0;
            //
            // tableLayoutPanelButtons
            //
            this.tableLayoutPanelButtons.ColumnCount = 2;
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelButtons.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanelButtons.Controls.Add(this.button4, 1, 0);
            this.tableLayoutPanelButtons.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanelButtons.Location = new System.Drawing.Point(1184, 682);
            this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            this.tableLayoutPanelButtons.RowCount = 1;
            this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelButtons.Size = new System.Drawing.Size(312, 45);
            this.tableLayoutPanelButtons.TabIndex = 13;
            //
            // button1
            //
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(4, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "Convert";
            this.button1.Click += new System.EventHandler(this.Convert_Click);
            this.toolTip1.SetToolTip(this.button1, "Convert the input XML to the output format.");
            //
            // button4
            //
            this.button4.AutoSize = true;
            this.button4.Location = new System.Drawing.Point(158, 5);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 10, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(150, 35);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 900);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1500, 900);
            this.Name = "Main_Form";
            this.Text = "Stationeers Scenario Toolbox";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanelPaths.ResumeLayout(false);
            this.ItemFilters_TableLayout.ResumeLayout(false);
            this.WorldTypeOptions_GroupBox.ResumeLayout(false);
            this.ItemFilters_GroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}