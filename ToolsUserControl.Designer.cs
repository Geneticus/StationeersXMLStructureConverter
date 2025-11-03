namespace StationeersStructureXMLConverter
{
    partial class ToolsUserControl
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
            //this.AutoScaleMode = AutoScaleMode.Dpi;
            this.btnRunXsdGenerator = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // ToolsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRunXsdGenerator);
            this.Name = "ToolsUserControl";
            this.Size = new System.Drawing.Size(1492, 874);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnRunXsdGenerator;
    }
}