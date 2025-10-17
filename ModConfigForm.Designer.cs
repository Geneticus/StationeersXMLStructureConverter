namespace StationeersStructureXMLConverter
{
    public partial class ModConfigForm
    {
        private System.ComponentModel.IContainer components = null;
        //private System.Windows.Forms.TextBox modNameTextBox;
        //private System.Windows.Forms.TextBox worldNameTextBox;
        //private System.Windows.Forms.TextBox descriptionTextBox;
        //private System.Windows.Forms.TextBox summaryTextBox;
        //private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Label modNameLabel;
        private System.Windows.Forms.Label worldNameLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label summaryLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        //private System.Windows.Forms.ToolTip toolTip;

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
            this.modNameTextBox = new System.Windows.Forms.TextBox();
            this.worldNameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.summaryTextBox = new System.Windows.Forms.TextBox();
            this.doneButton = new System.Windows.Forms.Button();
            this.modNameLabel = new System.Windows.Forms.Label();
            this.worldNameLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.summaryLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // modNameTextBox
            // 
            this.modNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top; // Removed Right
            this.modNameTextBox.Location = new System.Drawing.Point(83, 3); // Adjusted from 103
            this.modNameTextBox.Name = "modNameTextBox";
            this.modNameTextBox.Size = new System.Drawing.Size(280, 26); // Reduced from 294 for padding
            this.modNameTextBox.TabIndex = 1;
            this.modNameTextBox.Text = "MyNewMod";
            this.toolTip.SetToolTip(this.modNameTextBox, "Enter the name for the new mod folder.");
            // 
            // worldNameTextBox
            // 
            this.worldNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top; // Removed Right
            this.worldNameTextBox.Location = new System.Drawing.Point(83, 35); // Adjusted from 103
            this.worldNameTextBox.Name = "worldNameTextBox";
            this.worldNameTextBox.Size = new System.Drawing.Size(280, 26); // Reduced from 294
            this.worldNameTextBox.TabIndex = 3;
            this.toolTip.SetToolTip(this.worldNameTextBox, "Enter the in-game world name (optional).");
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top; // Removed Right
            this.descriptionTextBox.Location = new System.Drawing.Point(83, 67); // Adjusted from 103
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.WordWrap = true;
            this.descriptionTextBox.AcceptsReturn = false;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(280, 80); // Reduced from 294
            this.descriptionTextBox.TabIndex = 5;
            this.toolTip.SetToolTip(this.descriptionTextBox, "Enter an optional description for the mod (one paragraph, no newlines).");
            // 
            // summaryTextBox
            // 
            this.summaryTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top; // Removed Right
            this.summaryTextBox.Location = new System.Drawing.Point(83, 157); // Adjusted from 103
            this.summaryTextBox.Multiline = true;
            this.summaryTextBox.WordWrap = true;
            this.summaryTextBox.AcceptsReturn = false;
            this.summaryTextBox.Name = "summaryTextBox";
            this.summaryTextBox.Size = new System.Drawing.Size(280, 80); // Reduced from 294
            this.summaryTextBox.TabIndex = 7;
            this.toolTip.SetToolTip(this.summaryTextBox, "Enter an optional summary for the mod (one paragraph, no newlines).");
            // 
            // doneButton
            // 
            this.doneButton.AutoSize = true;
            this.doneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.doneButton.Location = new System.Drawing.Point(317, 260);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 30);
            this.doneButton.TabIndex = 8;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            // 
            // modNameLabel
            // 
            this.modNameLabel.AutoSize = true;
            this.modNameLabel.Location = new System.Drawing.Point(3, 6); // Adjusted from 8 to center with textbox
            this.modNameLabel.Name = "modNameLabel";
            this.modNameLabel.Size = new System.Drawing.Size(60, 20);
            this.modNameLabel.TabIndex = 0;
            this.modNameLabel.Text = "Mod Name:";
            this.modNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // worldNameLabel
            // 
            this.worldNameLabel.AutoSize = true;
            this.worldNameLabel.Location = new System.Drawing.Point(3, 38); // Adjusted from 40 to center
            this.worldNameLabel.Name = "worldNameLabel";
            this.worldNameLabel.Size = new System.Drawing.Size(60, 20);
            this.worldNameLabel.TabIndex = 2;
            this.worldNameLabel.Text = "World Name:";
            this.worldNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(3, 67); // Adjusted from 72 to align with textbox top
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(60, 20);
            this.descriptionLabel.TabIndex = 4;
            this.descriptionLabel.Text = "Description:";
            this.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // summaryLabel
            // 
            this.summaryLabel.AutoSize = true;
            this.summaryLabel.Location = new System.Drawing.Point(3, 157); // Adjusted from 162 to align with textbox top
            this.summaryLabel.Name = "summaryLabel";
            this.summaryLabel.Size = new System.Drawing.Size(60, 20);
            this.summaryLabel.TabIndex = 6;
            this.summaryLabel.Text = "Summary:";
            this.summaryLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F)); // Reduced from 100F
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel.Controls.Add(this.modNameLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.modNameTextBox, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.worldNameLabel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.worldNameTextBox, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.descriptionLabel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.descriptionTextBox, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.summaryLabel, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.summaryTextBox, 1, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Size = new System.Drawing.Size(400, 244);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // ModConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure Mod Outputs";

        }

        
    }
}