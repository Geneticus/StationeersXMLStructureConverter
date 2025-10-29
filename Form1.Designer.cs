//using System;

//namespace StationeersStructureXMLConverter
//{
//    partial class Form1
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.sourceButton = new System.Windows.Forms.Button();
//            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
//            this.DestinationButton = new System.Windows.Forms.Button();
//            this.label1 = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.sourceFile_TextBox = new System.Windows.Forms.TextBox();
//            this.destinationFile_TextBox = new System.Windows.Forms.TextBox();
//            this.Convert = new System.Windows.Forms.Button();
//            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
//            this.label3 = new System.Windows.Forms.Label();
//            this.output_textBox = new System.Windows.Forms.TextBox();
//            this.SuspendLayout();
//            // 
//            // sourceButton
//            // 
//            this.sourceButton.Location = new System.Drawing.Point(23, 33);
//            this.sourceButton.Name = "sourceButton";
//            this.sourceButton.Size = new System.Drawing.Size(115, 35);
//            this.sourceButton.TabIndex = 0;
//            this.sourceButton.Text = "Source";
//            this.sourceButton.UseVisualStyleBackColor = true;
//            this.sourceButton.Click += new System.EventHandler(this.sourceButton_Click_1);
//            // 
//            // openFileDialog1
//            // 
//            this.openFileDialog1.FileName = "openFileDialog1";
//            this.openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
//            // 
//            // DestinationButton
//            // 
//            this.DestinationButton.Location = new System.Drawing.Point(23, 90);
//            this.DestinationButton.Name = "DestinationButton";
//            this.DestinationButton.Size = new System.Drawing.Size(115, 35);
//            this.DestinationButton.TabIndex = 1;
//            this.DestinationButton.Text = "Destination";
//            this.DestinationButton.UseVisualStyleBackColor = true;
//            this.DestinationButton.Click += new System.EventHandler(this.DestinationButton_Click);
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Location = new System.Drawing.Point(158, 10);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(301, 20);
//            this.label1.TabIndex = 2;
//            this.label1.Text = "World File(World.xml) with your Structures";
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Location = new System.Drawing.Point(158, 78);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(123, 20);
//            this.label2.TabIndex = 3;
//            this.label2.Text = "Destination File:";
//            // 
//            // sourceFile_TextBox
//            // 
//            this.sourceFile_TextBox.Location = new System.Drawing.Point(162, 40);
//            this.sourceFile_TextBox.Name = "sourceFile_TextBox";
//            this.sourceFile_TextBox.Size = new System.Drawing.Size(901, 26);
//            this.sourceFile_TextBox.TabIndex = 4;
//            // 
//            // destinationFile_TextBox
//            // 
//            this.destinationFile_TextBox.Location = new System.Drawing.Point(162, 101);
//            this.destinationFile_TextBox.Name = "destinationFile_TextBox";
//            this.destinationFile_TextBox.Size = new System.Drawing.Size(901, 26);
//            this.destinationFile_TextBox.TabIndex = 5;
//            // 
//            // Convert
//            // 
//            this.Convert.Location = new System.Drawing.Point(1147, 1079);
//            this.Convert.Name = "Convert";
//            this.Convert.Size = new System.Drawing.Size(183, 38);
//            this.Convert.TabIndex = 7;
//            this.Convert.Text = "Convert XML";
//            this.Convert.UseVisualStyleBackColor = true;
//            this.Convert.Click += new System.EventHandler(this.Convert_Click);
//            // 
//            // saveFileDialog1
//            // 
//            this.saveFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Location = new System.Drawing.Point(46, 134);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(58, 20);
//            this.label3.TabIndex = 8;
//            this.label3.Text = "Report";
//            // 
//            // output_textBox
//            // 
//            this.output_textBox.AcceptsReturn = true;
//            this.output_textBox.BackColor = System.Drawing.SystemColors.Window;
//            this.output_textBox.Location = new System.Drawing.Point(23, 157);
//            this.output_textBox.Multiline = true;
//            this.output_textBox.Name = "output_textBox";
//            this.output_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
//            this.output_textBox.Size = new System.Drawing.Size(1307, 890);
//            this.output_textBox.TabIndex = 9;
//            this.output_textBox.WordWrap = false;
//            // 
//            // Form1
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(1362, 1141);
//            this.Controls.Add(this.output_textBox);
//            this.Controls.Add(this.label3);
//            this.Controls.Add(this.Convert);
//            this.Controls.Add(this.destinationFile_TextBox);
//            this.Controls.Add(this.sourceFile_TextBox);
//            this.Controls.Add(this.label2);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.DestinationButton);
//            this.Controls.Add(this.sourceButton);
//            this.Name = "Form1";
//            this.Text = "Stationeers Structure Converter";
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.Button sourceButton;
//        private System.Windows.Forms.OpenFileDialog openFileDialog1;
//        private System.Windows.Forms.Button DestinationButton;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.TextBox sourceFile_TextBox;
//        private System.Windows.Forms.TextBox destinationFile_TextBox;
//        private System.Windows.Forms.Button Convert;
//        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.TextBox output_textBox;
//    }

//}

