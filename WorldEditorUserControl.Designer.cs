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
            this.worldEditorTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.labelWorldId = new System.Windows.Forms.Label();
            this.txtWorldId = new System.Windows.Forms.TextBox();
            this.labelPriority = new System.Windows.Forms.Label();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.labelHidden = new System.Windows.Forms.Label();
            this.chkHidden = new System.Windows.Forms.CheckBox();
            this.labelName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.labelShortDesc = new System.Windows.Forms.Label();
            this.txtShortDesc = new System.Windows.Forms.TextBox();
            this.labelSummary = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.labelStartConditions = new System.Windows.Forms.Label();
            this.clbStartConditions = new System.Windows.Forms.CheckedListBox();
            this.labelStartLocations = new System.Windows.Forms.Label();
            this.lvStartLocations = new System.Windows.Forms.ListView();
            this.btnAddLocation = new System.Windows.Forms.Button();
            this.btnEditLocation = new System.Windows.Forms.Button();
            this.btnDeleteLocation = new System.Windows.Forms.Button();
            this.labelObjectives = new System.Windows.Forms.Label();
            this.lvObjectives = new System.Windows.Forms.ListView();
            this.btnAddObjective = new System.Windows.Forms.Button();
            this.btnEditObjective = new System.Windows.Forms.Button();
            this.btnDeleteObjective = new System.Windows.Forms.Button();
            this.btnSaveWorldSettings = new System.Windows.Forms.Button();
            this.worldEditorTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // worldEditorTableLayout
            // 
            this.worldEditorTableLayout.ColumnCount = 2;
            this.worldEditorTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.74352F));
            this.worldEditorTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.25648F));
            this.worldEditorTableLayout.Controls.Add(this.labelWorldId, 0, 0);
            this.worldEditorTableLayout.Controls.Add(this.txtWorldId, 1, 0);
            this.worldEditorTableLayout.Controls.Add(this.labelPriority, 0, 1);
            this.worldEditorTableLayout.Controls.Add(this.txtPriority, 1, 1);
            this.worldEditorTableLayout.Controls.Add(this.labelHidden, 0, 2);
            this.worldEditorTableLayout.Controls.Add(this.chkHidden, 1, 2);
            this.worldEditorTableLayout.Controls.Add(this.labelName, 0, 3);
            this.worldEditorTableLayout.Controls.Add(this.txtName, 1, 3);
            this.worldEditorTableLayout.Controls.Add(this.labelDescription, 0, 4);
            this.worldEditorTableLayout.Controls.Add(this.txtDescription, 1, 4);
            this.worldEditorTableLayout.Controls.Add(this.labelShortDesc, 0, 5);
            this.worldEditorTableLayout.Controls.Add(this.txtShortDesc, 1, 5);
            this.worldEditorTableLayout.Controls.Add(this.labelSummary, 0, 6);
            this.worldEditorTableLayout.Controls.Add(this.txtSummary, 1, 6);
            this.worldEditorTableLayout.Controls.Add(this.labelStartConditions, 1, 0);
            this.worldEditorTableLayout.Controls.Add(this.clbStartConditions, 1, 1);
            this.worldEditorTableLayout.Controls.Add(this.labelStartLocations, 0, 5);
            this.worldEditorTableLayout.Controls.Add(this.lvStartLocations, 0, 6);
            this.worldEditorTableLayout.Controls.Add(this.btnAddLocation, 1, 7);
            this.worldEditorTableLayout.Controls.Add(this.btnEditLocation, 1, 7);
            this.worldEditorTableLayout.Controls.Add(this.btnDeleteLocation, 1, 7);
            this.worldEditorTableLayout.Controls.Add(this.labelObjectives, 1, 5);
            this.worldEditorTableLayout.Controls.Add(this.lvObjectives, 1, 6);
            this.worldEditorTableLayout.Controls.Add(this.btnAddObjective, 1, 7);
            this.worldEditorTableLayout.Controls.Add(this.btnEditObjective, 1, 7);
            this.worldEditorTableLayout.Controls.Add(this.btnDeleteObjective, 1, 7);
            this.worldEditorTableLayout.Controls.Add(this.btnSaveWorldSettings, 0, 7);
            this.worldEditorTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worldEditorTableLayout.Location = new System.Drawing.Point(0, 0);
            this.worldEditorTableLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.worldEditorTableLayout.Name = "worldEditorTableLayout";
            this.worldEditorTableLayout.RowCount = 8;
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.worldEditorTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.worldEditorTableLayout.Size = new System.Drawing.Size(2238, 1345);
            this.worldEditorTableLayout.TabIndex = 0;
            // 
            // labelWorldId
            // 
            this.labelWorldId.AutoSize = true;
            this.labelWorldId.Location = new System.Drawing.Point(4, 0);
            this.labelWorldId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWorldId.Name = "labelWorldId";
            this.labelWorldId.Size = new System.Drawing.Size(75, 20);
            this.labelWorldId.TabIndex = 0;
            this.labelWorldId.Text = "World ID:";
            // 
            // txtWorldId
            // 
            this.txtWorldId.Location = new System.Drawing.Point(4, 51);
            this.txtWorldId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWorldId.Name = "txtWorldId";
            this.txtWorldId.Size = new System.Drawing.Size(298, 26);
            this.txtWorldId.TabIndex = 0;
            // 
            // labelPriority
            // 
            this.labelPriority.AutoSize = true;
            this.labelPriority.Location = new System.Drawing.Point(513, 46);
            this.labelPriority.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPriority.Name = "labelPriority";
            this.labelPriority.Size = new System.Drawing.Size(60, 20);
            this.labelPriority.TabIndex = 1;
            this.labelPriority.Text = "Priority:";
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(513, 97);
            this.txtPriority.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(73, 26);
            this.txtPriority.TabIndex = 1;
            // 
            // labelHidden
            // 
            this.labelHidden.AutoSize = true;
            this.labelHidden.Location = new System.Drawing.Point(4, 138);
            this.labelHidden.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHidden.Name = "labelHidden";
            this.labelHidden.Size = new System.Drawing.Size(64, 20);
            this.labelHidden.TabIndex = 2;
            this.labelHidden.Text = "Hidden:";
            // 
            // chkHidden
            // 
            this.chkHidden.Location = new System.Drawing.Point(513, 143);
            this.chkHidden.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkHidden.Name = "chkHidden";
            this.chkHidden.Size = new System.Drawing.Size(120, 36);
            this.chkHidden.TabIndex = 2;
            this.chkHidden.Text = "Hidden";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(4, 184);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(55, 20);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(513, 189);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(298, 26);
            this.txtName.TabIndex = 3;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(4, 230);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(123, 20);
            this.labelDescription.TabIndex = 4;
            this.labelDescription.Text = "Description Key:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(513, 235);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(298, 26);
            this.txtDescription.TabIndex = 4;
            // 
            // labelShortDesc
            // 
            this.labelShortDesc.AutoSize = true;
            this.labelShortDesc.Location = new System.Drawing.Point(513, 298);
            this.labelShortDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelShortDesc.Name = "labelShortDesc";
            this.labelShortDesc.Size = new System.Drawing.Size(123, 20);
            this.labelShortDesc.TabIndex = 5;
            this.labelShortDesc.Text = "Short Desc Key:";
            // 
            // txtShortDesc
            // 
            this.txtShortDesc.Location = new System.Drawing.Point(513, 363);
            this.txtShortDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtShortDesc.Name = "txtShortDesc";
            this.txtShortDesc.Size = new System.Drawing.Size(298, 26);
            this.txtShortDesc.TabIndex = 5;
            // 
            // labelSummary
            // 
            this.labelSummary.AutoSize = true;
            this.labelSummary.Location = new System.Drawing.Point(513, 408);
            this.labelSummary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(110, 20);
            this.labelSummary.TabIndex = 6;
            this.labelSummary.Text = "Summary Key:";
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(513, 609);
            this.txtSummary.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(298, 26);
            this.txtSummary.TabIndex = 6;
            // 
            // labelStartConditions
            // 
            this.labelStartConditions.AutoSize = true;
            this.labelStartConditions.Location = new System.Drawing.Point(513, 0);
            this.labelStartConditions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStartConditions.Name = "labelStartConditions";
            this.labelStartConditions.Size = new System.Drawing.Size(127, 20);
            this.labelStartConditions.TabIndex = 7;
            this.labelStartConditions.Text = "Start Conditions:";
            // 
            // clbStartConditions
            // 
            this.clbStartConditions.Location = new System.Drawing.Point(4, 97);
            this.clbStartConditions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clbStartConditions.Name = "clbStartConditions";
            this.clbStartConditions.Size = new System.Drawing.Size(298, 27);
            this.clbStartConditions.TabIndex = 7;
            // 
            // labelStartLocations
            // 
            this.labelStartLocations.AutoSize = true;
            this.labelStartLocations.Location = new System.Drawing.Point(4, 298);
            this.labelStartLocations.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStartLocations.Name = "labelStartLocations";
            this.labelStartLocations.Size = new System.Drawing.Size(121, 20);
            this.labelStartLocations.TabIndex = 8;
            this.labelStartLocations.Text = "Start Locations:";
            // 
            // lvStartLocations
            // 
            this.lvStartLocations.HideSelection = false;
            this.lvStartLocations.Location = new System.Drawing.Point(4, 413);
            this.lvStartLocations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvStartLocations.Name = "lvStartLocations";
            this.lvStartLocations.Size = new System.Drawing.Size(448, 186);
            this.lvStartLocations.TabIndex = 8;
            this.lvStartLocations.UseCompatibleStateImageBehavior = false;
            this.lvStartLocations.View = System.Windows.Forms.View.Details;
            // 
            // btnAddLocation
            // 
            this.btnAddLocation.Location = new System.Drawing.Point(4, 993);
            this.btnAddLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddLocation.Name = "btnAddLocation";
            this.btnAddLocation.Size = new System.Drawing.Size(120, 46);
            this.btnAddLocation.TabIndex = 9;
            this.btnAddLocation.Text = "Add Location";
            this.btnAddLocation.UseVisualStyleBackColor = true;
            this.btnAddLocation.Click += new System.EventHandler(this.btnAddLocation_Click);
            // 
            // btnEditLocation
            // 
            this.btnEditLocation.Location = new System.Drawing.Point(513, 931);
            this.btnEditLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditLocation.Name = "btnEditLocation";
            this.btnEditLocation.Size = new System.Drawing.Size(120, 46);
            this.btnEditLocation.TabIndex = 10;
            this.btnEditLocation.Text = "Edit Location";
            this.btnEditLocation.UseVisualStyleBackColor = true;
            this.btnEditLocation.Click += new System.EventHandler(this.btnEditLocation_Click);
            // 
            // btnDeleteLocation
            // 
            this.btnDeleteLocation.Location = new System.Drawing.Point(513, 993);
            this.btnDeleteLocation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteLocation.Name = "btnDeleteLocation";
            this.btnDeleteLocation.Size = new System.Drawing.Size(120, 46);
            this.btnDeleteLocation.TabIndex = 11;
            this.btnDeleteLocation.Text = "Delete Location";
            this.btnDeleteLocation.UseVisualStyleBackColor = true;
            this.btnDeleteLocation.Click += new System.EventHandler(this.btnDeleteLocation_Click);
            // 
            // labelObjectives
            // 
            this.labelObjectives.AutoSize = true;
            this.labelObjectives.Location = new System.Drawing.Point(4, 358);
            this.labelObjectives.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelObjectives.Name = "labelObjectives";
            this.labelObjectives.Size = new System.Drawing.Size(86, 20);
            this.labelObjectives.TabIndex = 12;
            this.labelObjectives.Text = "Objectives:";
            // 
            // lvObjectives
            // 
            this.lvObjectives.HideSelection = false;
            this.lvObjectives.Location = new System.Drawing.Point(4, 609);
            this.lvObjectives.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvObjectives.Name = "lvObjectives";
            this.lvObjectives.Size = new System.Drawing.Size(448, 205);
            this.lvObjectives.TabIndex = 12;
            this.lvObjectives.UseCompatibleStateImageBehavior = false;
            this.lvObjectives.View = System.Windows.Forms.View.Details;
            // 
            // btnAddObjective
            // 
            this.btnAddObjective.Location = new System.Drawing.Point(4, 1061);
            this.btnAddObjective.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddObjective.Name = "btnAddObjective";
            this.btnAddObjective.Size = new System.Drawing.Size(120, 46);
            this.btnAddObjective.TabIndex = 13;
            this.btnAddObjective.Text = "Add Objective";
            this.btnAddObjective.UseVisualStyleBackColor = true;
            this.btnAddObjective.Click += new System.EventHandler(this.btnAddObjective_Click);
            // 
            // btnEditObjective
            // 
            this.btnEditObjective.Location = new System.Drawing.Point(513, 828);
            this.btnEditObjective.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditObjective.Name = "btnEditObjective";
            this.btnEditObjective.Size = new System.Drawing.Size(120, 82);
            this.btnEditObjective.TabIndex = 14;
            this.btnEditObjective.Text = "Edit Objective";
            this.btnEditObjective.UseVisualStyleBackColor = true;
            this.btnEditObjective.Click += new System.EventHandler(this.btnEditObjective_Click);
            // 
            // btnDeleteObjective
            // 
            this.btnDeleteObjective.Location = new System.Drawing.Point(4, 931);
            this.btnDeleteObjective.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteObjective.Name = "btnDeleteObjective";
            this.btnDeleteObjective.Size = new System.Drawing.Size(120, 46);
            this.btnDeleteObjective.TabIndex = 15;
            this.btnDeleteObjective.Text = "Delete Objective";
            this.btnDeleteObjective.UseVisualStyleBackColor = true;
            this.btnDeleteObjective.Click += new System.EventHandler(this.btnDeleteObjective_Click);
            // 
            // btnSaveWorldSettings
            // 
            this.btnSaveWorldSettings.Location = new System.Drawing.Point(4, 828);
            this.btnSaveWorldSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveWorldSettings.Name = "btnSaveWorldSettings";
            this.btnSaveWorldSettings.Size = new System.Drawing.Size(120, 82);
            this.btnSaveWorldSettings.TabIndex = 16;
            this.btnSaveWorldSettings.Text = "Save";
            this.btnSaveWorldSettings.UseVisualStyleBackColor = true;
            this.btnSaveWorldSettings.Click += new System.EventHandler(this.btnSaveWorldSettings_Click);
            // 
            // WorldEditorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.worldEditorTableLayout);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "WorldEditorUserControl";
            this.Size = new System.Drawing.Size(2238, 1345);
            this.worldEditorTableLayout.ResumeLayout(false);
            this.worldEditorTableLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel worldEditorTableLayout;
        private System.Windows.Forms.Label labelWorldId;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.Label labelHidden;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelShortDesc;
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.Label labelStartConditions;
        private System.Windows.Forms.Label labelStartLocations;
        private System.Windows.Forms.Label labelObjectives;
        private System.Windows.Forms.TextBox txtWorldId;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.CheckBox chkHidden;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtShortDesc;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.CheckedListBox clbStartConditions;
        private System.Windows.Forms.ListView lvStartLocations;
        private System.Windows.Forms.Button btnAddLocation;
        private System.Windows.Forms.Button btnEditLocation;
        private System.Windows.Forms.Button btnDeleteLocation;
        private System.Windows.Forms.ListView lvObjectives;
        private System.Windows.Forms.Button btnAddObjective;
        private System.Windows.Forms.Button btnEditObjective;
        private System.Windows.Forms.Button btnDeleteObjective;
        private System.Windows.Forms.Button btnSaveWorldSettings;
    }
}