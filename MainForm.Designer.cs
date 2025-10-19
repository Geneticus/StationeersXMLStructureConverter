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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabConversion = new System.Windows.Forms.TabPage();
            this.tabWorldEditor = new System.Windows.Forms.TabPage();
            this.tabTools = new System.Windows.Forms.TabPage();
            this.conversionUserControl = new ConversionUserControl();
            this.worldEditorUserControl = new WorldEditorUserControl();
            this.toolsUserControl = new ToolsUserControl();
            this.tabControlMain.SuspendLayout();
            this.tabConversion.SuspendLayout();
            this.tabWorldEditor.SuspendLayout();
            this.tabTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabConversion);
            this.tabControlMain.Controls.Add(this.tabWorldEditor);
            this.tabControlMain.Controls.Add(this.tabTools);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1500, 900);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabConversion
            // 
            this.tabConversion.Controls.Add(this.conversionUserControl);
            this.tabConversion.Location = new System.Drawing.Point(4, 22);
            this.tabConversion.Name = "tabConversion";
            this.tabConversion.Size = new System.Drawing.Size(1492, 874);
            this.tabConversion.TabIndex = 0;
            this.tabConversion.Text = "Conversion";
            this.tabConversion.UseVisualStyleBackColor = true;
            // 
            // tabWorldEditor
            // 
            this.tabWorldEditor.Controls.Add(this.worldEditorUserControl);
            this.tabWorldEditor.Location = new System.Drawing.Point(4, 22);
            this.tabWorldEditor.Name = "tabWorldEditor";
            this.tabWorldEditor.Size = new System.Drawing.Size(1492, 874);
            this.tabWorldEditor.TabIndex = 1;
            this.tabWorldEditor.Text = "World Editor";
            this.tabWorldEditor.UseVisualStyleBackColor = true;
            // 
            // tabTools
            // 
            this.tabTools.Controls.Add(this.toolsUserControl);
            this.tabTools.Location = new System.Drawing.Point(4, 22);
            this.tabTools.Name = "tabTools";
            this.tabTools.Size = new System.Drawing.Size(1492, 874);
            this.tabTools.TabIndex = 2;
            this.tabTools.Text = "Tools";
            this.tabTools.UseVisualStyleBackColor = true;
            // 
            // conversionUserControl
            // 
            this.conversionUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conversionUserControl.Location = new System.Drawing.Point(0, 0);
            this.conversionUserControl.Name = "conversionUserControl";
            this.conversionUserControl.Size = new System.Drawing.Size(1492, 874);
            this.conversionUserControl.TabIndex = 0;
            // 
            // worldEditorUserControl
            // 
            this.worldEditorUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worldEditorUserControl.Location = new System.Drawing.Point(0, 0);
            this.worldEditorUserControl.Name = "worldEditorUserControl";
            this.worldEditorUserControl.Size = new System.Drawing.Size(1492, 874);
            this.worldEditorUserControl.TabIndex = 0;
            // 
            // toolsUserControl
            // 
            this.toolsUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsUserControl.Location = new System.Drawing.Point(0, 0);
            this.toolsUserControl.Name = "toolsUserControl";
            this.toolsUserControl.Size = new System.Drawing.Size(1492, 874);
            this.toolsUserControl.TabIndex = 0;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 900);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Main_Form";
            this.Text = "Stationeers Structure XML Converter";
            this.tabControlMain.ResumeLayout(false);
            this.tabConversion.ResumeLayout(false);
            this.tabWorldEditor.ResumeLayout(false);
            this.tabTools.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabConversion;
        private System.Windows.Forms.TabPage tabWorldEditor;
        private System.Windows.Forms.TabPage tabTools;
        private ConversionUserControl conversionUserControl;
        private WorldEditorUserControl worldEditorUserControl;
        private ToolsUserControl toolsUserControl;
    }
}