using System.Drawing;
using System.Windows.Forms;
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
            this.tabobjectiveBuilder = new System.Windows.Forms.TabPage();
            this.tabTools = new System.Windows.Forms.TabPage();
            this.conversionUserControl = new ConversionUserControl();
            this.worldEditorUserControl = new WorldEditorUserControl();
            this.objectiveBuilderUserControl = new ObjectiveBuilderUserControl();
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
            this.tabControlMain.Controls.Add(this.tabobjectiveBuilder);
            this.tabControlMain.Controls.Add(this.tabTools);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1280, 800); // Adjusted to match ClientSize
            this.tabControlMain.TabIndex = 0;
            // 
            // tabConversion
            // 
            this.tabConversion.AutoScroll = true;
            this.tabConversion.Controls.Add(this.conversionUserControl);
            this.tabConversion.Location = new System.Drawing.Point(4, 22);
            this.tabConversion.Name = "tabConversion";
            this.tabConversion.Text = "Conversion";
            this.tabConversion.UseVisualStyleBackColor = true;
            this.tabConversion.TabIndex = 0;
            // 
            // tabWorldEditor
            // 
            this.tabWorldEditor.AutoScroll = true;
            this.tabWorldEditor.Controls.Add(this.worldEditorUserControl);
            this.tabWorldEditor.Location = new System.Drawing.Point(4, 22);
            this.tabWorldEditor.Name = "tabWorldEditor";
            this.tabWorldEditor.Text = "World Editor";
            this.tabWorldEditor.UseVisualStyleBackColor = true;
            this.tabWorldEditor.TabIndex = 1;
            // 
            // tabobjectiveBuilder
            //
            this.tabobjectiveBuilder.AutoScroll = true;
            this.tabobjectiveBuilder.Controls.Add(this.objectiveBuilderUserControl);
            this.tabobjectiveBuilder.Location = new System.Drawing.Point(4, 22);
            this.tabobjectiveBuilder.Name = "tabobjectiveBuilder";
            this.tabobjectiveBuilder.Text = "Objective Builder";
            this.tabobjectiveBuilder.UseVisualStyleBackColor = true;
            this.tabobjectiveBuilder.TabIndex = 2;
            // 
            // tabTools
            // 
            this.tabTools.AutoScroll = true;
            this.tabTools.Controls.Add(this.toolsUserControl);
            this.tabTools.Location = new System.Drawing.Point(4, 22);
            this.tabTools.Name = "tabTools";
            this.tabTools.Text = "Tools";
            this.tabTools.UseVisualStyleBackColor = true;
            this.tabTools.TabIndex = 3;
            // 
            // conversionUserControl
            // 
            this.conversionUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conversionUserControl.Location = new System.Drawing.Point(0, 0);
            this.conversionUserControl.Name = "conversionUserControl";
            this.conversionUserControl.TabIndex = 0;
            // 
            // worldEditorUserControl
            // 
            this.worldEditorUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worldEditorUserControl.Location = new System.Drawing.Point(0, 0);
            this.worldEditorUserControl.Name = "worldEditorUserControl";
            this.worldEditorUserControl.TabIndex = 0;
            // 
            // objectiveBuilderUserControl
            // 
            this.objectiveBuilderUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectiveBuilderUserControl.Location = new System.Drawing.Point(0, 0);
            this.objectiveBuilderUserControl.Name = "objectiveBuilderUserControl";
            this.objectiveBuilderUserControl.TabIndex = 0;
            // 
            // toolsUserControl
            // 
            this.toolsUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsUserControl.Location = new System.Drawing.Point(0, 0);
            this.toolsUserControl.Name = "toolsUserControl";
            this.toolsUserControl.TabIndex = 0;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.ClientSize = new System.Drawing.Size(1280, 800); // Reduced height to 800px logical
            this.MinimumSize = new System.Drawing.Size(1200, 800); // Kept minimum
            this.Controls.Add(this.tabControlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "Main_Form";
            this.Text = "Stationeers Structure XML Converter";
            this.tabControlMain.ResumeLayout(false);
            this.tabConversion.ResumeLayout(false);
            this.tabWorldEditor.ResumeLayout(false);
            this.tabobjectiveBuilder.ResumeLayout(false);
            this.tabTools.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabConversion;
        private System.Windows.Forms.TabPage tabWorldEditor;
        private System.Windows.Forms.TabPage tabobjectiveBuilder;
        private System.Windows.Forms.TabPage tabTools;
        private ConversionUserControl conversionUserControl;
        private WorldEditorUserControl worldEditorUserControl;
        private ObjectiveBuilderUserControl objectiveBuilderUserControl;
        private ToolsUserControl toolsUserControl;
    }
}