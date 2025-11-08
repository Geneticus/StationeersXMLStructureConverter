namespace StationeersStructureXMLConverter
{
    partial class ObjectiveBuilderUserControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            mainTable = new TableLayoutPanel();
            pathPanel = new TableLayoutPanel();
            lblPath = new Label();
            txtModPath = new TextBox();
            btnFlow = new FlowLayoutPanel();
            btnBrowse = new Button();
            btnReload = new Button();
            groupPanel = new TableLayoutPanel();
            groupBtnFlow = new FlowLayoutPanel();
            btnAddGroup = new Button();
            btnAddObjective = new Button();
            btnEditGroup = new Button();
            btnDeleteGroup = new Button();
            tvGroups = new TreeView();
            objPanel = new TableLayoutPanel();
            objBtnFlow = new FlowLayoutPanel();
            btnAddCondition = new Button();
            btnEditObjective = new Button();
            btnDeleteObjective = new Button();
            lbObjectives = new ListBox();
            bottomFlow = new FlowLayoutPanel();
            btnSave = new Button();
            btnClearAll = new Button();
            mainTable.SuspendLayout();
            pathPanel.SuspendLayout();
            btnFlow.SuspendLayout();
            groupPanel.SuspendLayout();
            groupBtnFlow.SuspendLayout();
            objPanel.SuspendLayout();
            objBtnFlow.SuspendLayout();
            bottomFlow.SuspendLayout();
            SuspendLayout();
            // 
            // mainTable
            // 
            mainTable.ColumnCount = 1;
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55F));
            mainTable.Controls.Add(pathPanel, 0, 0);
            mainTable.Controls.Add(groupPanel, 0, 1);
            mainTable.Controls.Add(objPanel, 0, 2);
            mainTable.Controls.Add(bottomFlow, 0, 3);
            mainTable.Dock = DockStyle.Fill;
            mainTable.Location = new Point(0, 0);
            mainTable.Margin = new Padding(4);
            mainTable.Name = "mainTable";
            mainTable.Padding = new Padding(12);
            mainTable.RowCount = 4;
            mainTable.RowStyles.Add(new RowStyle());
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainTable.RowStyles.Add(new RowStyle());
            mainTable.Size = new Size(1250, 812);
            mainTable.TabIndex = 0;
            // 
            // pathPanel
            // 
            pathPanel.AutoSize = true;
            pathPanel.ColumnCount = 3;
            pathPanel.ColumnStyles.Add(new ColumnStyle());
            pathPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pathPanel.ColumnStyles.Add(new ColumnStyle());
            pathPanel.Controls.Add(lblPath, 0, 0);
            pathPanel.Controls.Add(txtModPath, 1, 0);
            pathPanel.Controls.Add(btnFlow, 2, 0);
            pathPanel.Dock = DockStyle.Top;
            pathPanel.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            pathPanel.Location = new Point(12, 12);
            pathPanel.Margin = new Padding(0, 0, 0, 10);
            pathPanel.Name = "pathPanel";
            pathPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            pathPanel.Size = new Size(1226, 55);
            pathPanel.TabIndex = 0;
            // 
            // lblPath
            // 
            lblPath.AutoSize = true;
            lblPath.Location = new Point(0, 10);
            lblPath.Margin = new Padding(0, 10, 0, 0);
            lblPath.Name = "lblPath";
            lblPath.Size = new Size(93, 25);
            lblPath.TabIndex = 0;
            lblPath.Text = "Mod Path:";
            // 
            // txtModPath
            // 
            txtModPath.Dock = DockStyle.Fill;
            txtModPath.Location = new Point(99, 6);
            txtModPath.Margin = new Padding(6);
            txtModPath.Name = "txtModPath";
            txtModPath.Size = new Size(887, 31);
            txtModPath.TabIndex = 1;
            // 
            // btnFlow
            // 
            btnFlow.AutoSize = true;
            btnFlow.Controls.Add(btnBrowse);
            btnFlow.Controls.Add(btnReload);
            btnFlow.Location = new Point(998, 6);
            btnFlow.Margin = new Padding(6, 6, 0, 6);
            btnFlow.Name = "btnFlow";
            btnFlow.Size = new Size(228, 43);
            btnFlow.TabIndex = 2;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(4, 4);
            btnBrowse.Margin = new Padding(4);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(106, 38);
            btnBrowse.TabIndex = 0;
            btnBrowse.Text = "Browse";
            // 
            // btnReload
            // 
            btnReload.Location = new Point(118, 4);
            btnReload.Margin = new Padding(4);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(106, 38);
            btnReload.TabIndex = 1;
            btnReload.Text = "Reload";
            // 
            // groupPanel
            // 
            groupPanel.ColumnCount = 2;
            groupPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            groupPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            groupPanel.Controls.Add(groupBtnFlow, 0, 0);
            groupPanel.Controls.Add(tvGroups, 1, 0);
            groupPanel.Dock = DockStyle.Fill;
            groupPanel.Location = new Point(16, 81);
            groupPanel.Margin = new Padding(4);
            groupPanel.Name = "groupPanel";
            groupPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            groupPanel.Size = new Size(1218, 322);
            groupPanel.TabIndex = 1;
            // 
            // groupBtnFlow
            // 
            groupBtnFlow.AutoSize = true;
            groupBtnFlow.Controls.Add(btnAddGroup);
            groupBtnFlow.Controls.Add(btnAddObjective);
            groupBtnFlow.Controls.Add(btnEditGroup);
            groupBtnFlow.Controls.Add(btnDeleteGroup);
            groupBtnFlow.FlowDirection = FlowDirection.TopDown;
            groupBtnFlow.Location = new Point(6, 6);
            groupBtnFlow.Margin = new Padding(6);
            groupBtnFlow.Name = "groupBtnFlow";
            groupBtnFlow.Size = new Size(146, 208);
            groupBtnFlow.TabIndex = 0;
            // 
            // btnAddGroup
            // 
            btnAddGroup.Location = new Point(4, 4);
            btnAddGroup.Margin = new Padding(4);
            btnAddGroup.Name = "btnAddGroup";
            btnAddGroup.Size = new Size(138, 44);
            btnAddGroup.TabIndex = 0;
            btnAddGroup.Text = "+ New Group";
            // 
            // btnAddObjective
            // 
            btnAddObjective.Location = new Point(4, 56);
            btnAddObjective.Margin = new Padding(4);
            btnAddObjective.Name = "btnAddObjective";
            btnAddObjective.Size = new Size(138, 44);
            btnAddObjective.TabIndex = 1;
            btnAddObjective.Text = "+ New Objective";
            // 
            // btnEditGroup
            // 
            btnEditGroup.Location = new Point(4, 108);
            btnEditGroup.Margin = new Padding(4);
            btnEditGroup.Name = "btnEditGroup";
            btnEditGroup.Size = new Size(138, 44);
            btnEditGroup.TabIndex = 2;
            btnEditGroup.Text = "Edit";
            // 
            // btnDeleteGroup
            // 
            btnDeleteGroup.Location = new Point(4, 160);
            btnDeleteGroup.Margin = new Padding(4);
            btnDeleteGroup.Name = "btnDeleteGroup";
            btnDeleteGroup.Size = new Size(138, 44);
            btnDeleteGroup.TabIndex = 3;
            btnDeleteGroup.Text = "Delete";
            // 
            // tvGroups
            // 
            tvGroups.Dock = DockStyle.Fill;
            tvGroups.Location = new Point(186, 4);
            tvGroups.Margin = new Padding(4);
            tvGroups.Name = "tvGroups";
            tvGroups.Size = new Size(1028, 314);
            tvGroups.TabIndex = 1;
            // 
            // objPanel
            // 
            objPanel.ColumnCount = 2;
            objPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            objPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            objPanel.Controls.Add(objBtnFlow, 0, 0);
            objPanel.Controls.Add(lbObjectives, 1, 0);
            objPanel.Dock = DockStyle.Fill;
            objPanel.Location = new Point(16, 411);
            objPanel.Margin = new Padding(4);
            objPanel.Name = "objPanel";
            objPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            objPanel.Size = new Size(1218, 322);
            objPanel.TabIndex = 2;
            // 
            // objBtnFlow
            // 
            objBtnFlow.AutoSize = true;
            objBtnFlow.Controls.Add(btnAddCondition);
            objBtnFlow.Controls.Add(btnEditObjective);
            objBtnFlow.Controls.Add(btnDeleteObjective);
            objBtnFlow.FlowDirection = FlowDirection.TopDown;
            objBtnFlow.Location = new Point(6, 6);
            objBtnFlow.Margin = new Padding(6);
            objBtnFlow.Name = "objBtnFlow";
            objBtnFlow.Size = new Size(146, 156);
            objBtnFlow.TabIndex = 0;
            // 
            // btnAddCondition
            // 
            btnAddCondition.Location = new Point(4, 4);
            btnAddCondition.Margin = new Padding(4);
            btnAddCondition.Name = "btnAddCondition";
            btnAddCondition.Size = new Size(138, 44);
            btnAddCondition.TabIndex = 0;
            btnAddCondition.Text = "+ Add Condition";
            // 
            // btnEditObjective
            // 
            btnEditObjective.Location = new Point(4, 56);
            btnEditObjective.Margin = new Padding(4);
            btnEditObjective.Name = "btnEditObjective";
            btnEditObjective.Size = new Size(138, 44);
            btnEditObjective.TabIndex = 1;
            btnEditObjective.Text = "Edit";
            // 
            // btnDeleteObjective
            // 
            btnDeleteObjective.Location = new Point(4, 108);
            btnDeleteObjective.Margin = new Padding(4);
            btnDeleteObjective.Name = "btnDeleteObjective";
            btnDeleteObjective.Size = new Size(138, 44);
            btnDeleteObjective.TabIndex = 2;
            btnDeleteObjective.Text = "Delete";
            // 
            // lbObjectives
            // 
            lbObjectives.Dock = DockStyle.Fill;
            lbObjectives.ItemHeight = 25;
            lbObjectives.Location = new Point(186, 4);
            lbObjectives.Margin = new Padding(4);
            lbObjectives.Name = "lbObjectives";
            lbObjectives.Size = new Size(1028, 314);
            lbObjectives.TabIndex = 1;
            // 
            // bottomFlow
            // 
            bottomFlow.Controls.Add(btnSave);
            bottomFlow.Controls.Add(btnClearAll);
            bottomFlow.Dock = DockStyle.Bottom;
            bottomFlow.FlowDirection = FlowDirection.RightToLeft;
            bottomFlow.Location = new Point(12, 750);
            bottomFlow.Margin = new Padding(0, 12, 0, 0);
            bottomFlow.Name = "bottomFlow";
            bottomFlow.Size = new Size(1226, 50);
            bottomFlow.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(1097, 4);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(125, 44);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            // 
            // btnClearAll
            // 
            btnClearAll.Location = new Point(964, 4);
            btnClearAll.Margin = new Padding(4);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(125, 44);
            btnClearAll.TabIndex = 1;
            btnClearAll.Text = "Clear All";
            // 
            // ObjectiveBuilderUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainTable);
            Margin = new Padding(4);
            Name = "ObjectiveBuilderUserControl";
            Size = new Size(1250, 812);
            mainTable.ResumeLayout(false);
            mainTable.PerformLayout();
            pathPanel.ResumeLayout(false);
            pathPanel.PerformLayout();
            btnFlow.ResumeLayout(false);
            groupPanel.ResumeLayout(false);
            groupPanel.PerformLayout();
            groupBtnFlow.ResumeLayout(false);
            objPanel.ResumeLayout(false);
            objPanel.PerformLayout();
            objBtnFlow.ResumeLayout(false);
            bottomFlow.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TableLayoutPanel mainTable;
        private TableLayoutPanel pathPanel;
        private Label lblPath;
        private TextBox txtModPath;
        private FlowLayoutPanel btnFlow;
        private Button btnBrowse;
        private Button btnReload;
        private TableLayoutPanel groupPanel;
        private FlowLayoutPanel groupBtnFlow;
        private Button btnAddGroup;
        private Button btnAddObjective;
        private Button btnEditGroup;
        private Button btnDeleteGroup;
        private TreeView tvGroups;
        private TableLayoutPanel objPanel;
        private FlowLayoutPanel objBtnFlow;
        private Button btnAddCondition;
        private Button btnEditObjective;
        private Button btnDeleteObjective;
        private ListBox lbObjectives;
        private FlowLayoutPanel bottomFlow;
        private Button btnSave;
        private Button btnClearAll;
    }
}