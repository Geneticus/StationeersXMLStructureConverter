using System;
using System.Windows.Forms;

namespace StationeersStructureXMLConverter
{
    partial class Main_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.labelProgressBar = new System.Windows.Forms.Label();
            this.progressBarOutline = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelPaths.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelProgressBar, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.progressBarOutline, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelButtons, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(900, 700);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(900, 700);
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
            this.labelInstructions.Size = new System.Drawing.Size(900, 40);
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
            this.tableLayoutPanelPaths.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanelPaths.Controls.Add(this.textBox2, 1, 1);
            this.tableLayoutPanelPaths.Controls.Add(this.button3, 2, 1);
            this.tableLayoutPanelPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPaths.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanelPaths.Name = "tableLayoutPanelPaths";
            this.tableLayoutPanelPaths.RowCount = 2;
            this.tableLayoutPanelPaths.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPaths.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPaths.Size = new System.Drawing.Size(894, 100);
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
            this.textBox1.Size = new System.Drawing.Size(516, 26);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.AutoSize = false; // Disable auto-sizing
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.button2.Size = new System.Drawing.Size(140, 34); // Fixed width
            this.button2.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.button2.Text = "Browse Input";
            this.toolTip1.SetToolTip(this.button2, "Select the input XML file to convert.");
            // 
            // button3
            // 
            this.button3.AutoSize = false; // Disable auto-sizing
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left;
            this.button3.Size = new System.Drawing.Size(140, 34); // Fixed width
            this.button3.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.button3.Text = "Browse Output";
            this.toolTip1.SetToolTip(this.button3, "Select the output path for the converted XML file.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output Path:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(150, 45);
            this.textBox2.Margin = new System.Windows.Forms.Padding(0, 5, 4, 5);
            this.textBox2.MinimumSize = new System.Drawing.Size(300, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(516, 26);
            this.textBox2.TabIndex = 4;

            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.AutoSize = false; // Fixed height to prevent excessive expansion
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(4, 109);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.groupBox1.Size = new System.Drawing.Size(892, 117); // Fixed height for 3 checkboxes
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Filters";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(14, 75); // Adjusted for 3rd checkbox
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(135, 24);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "Exclude Supply Landers";
            this.toolTip1.SetToolTip(this.checkBox3, "Check to exclude Supply Landers and any connected containers.");
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(14, 51); // Adjusted for 2nd checkbox
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(135, 24);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Exclude Character";
            this.toolTip1.SetToolTip(this.checkBox2, "Check to exclude your Character and items from the output.");
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(14, 27); // Adjusted for 1st checkbox
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(169, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Exclude Player Lander";
            this.toolTip1.SetToolTip(this.checkBox1, "Check to exclude Landing Capsule and items from the output.");
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // labelProgressBar
            // 
            this.labelProgressBar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelProgressBar.AutoSize = true;
            this.labelProgressBar.Location = new System.Drawing.Point(374, 268);
            this.labelProgressBar.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelProgressBar.Name = "labelProgressBar";
            this.labelProgressBar.Size = new System.Drawing.Size(151, 20);
            this.labelProgressBar.TabIndex = 7;
            this.labelProgressBar.Text = "Extraction Progress:";
            // 
            // progressBarOutline
            // 
            this.progressBarOutline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressBarOutline.Controls.Add(this.progressBar1); // Only add progressBar1 to the panel
            this.progressBarOutline.Anchor = System.Windows.Forms.AnchorStyles.Top; // Centered, no stretching
            this.progressBarOutline.Margin = new System.Windows.Forms.Padding(225, 0, 225, 10); // 25% padding on each side
            this.progressBarOutline.Name = "progressBarOutline";
            this.progressBarOutline.Size = new System.Drawing.Size(450, 25); // 50% width
            this.progressBarOutline.TabIndex = 14;
            // 
            // progressBar1
            // 
            this.progressBar1.Visible = false;
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right; // Stretch within panel
            this.progressBar1.Location = new System.Drawing.Point(0, 0); // Top-left of the panel
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(450, 25); // Match panel width
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 8;
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
            this.groupBox2.Location = new System.Drawing.Point(4, 376);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(892, 299);
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
            this.textBox3.Size = new System.Drawing.Size(884, 270);
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
            this.tableLayoutPanelButtons.Location = new System.Drawing.Point(684, 556); // Adjusted dynamically by anchor
            this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            this.tableLayoutPanelButtons.RowCount = 1;
            this.tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelButtons.Size = new System.Drawing.Size(212, 45);
            this.tableLayoutPanelButtons.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(4, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 4);
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
            this.button4.Size = new System.Drawing.Size(75, 4);
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
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "Main_Form";
            this.Text = "Stationeers Scenario Toolbox";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanelPaths.ResumeLayout(false);
            this.tableLayoutPanelPaths.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanelButtons.ResumeLayout(false);
            this.tableLayoutPanelButtons.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
    }
}