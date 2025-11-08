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
            components = new System.ComponentModel.Container();
            mainTable = new TableLayoutPanel();
            pathPanel = new TableLayoutPanel();
            lblPath = new Label();
            txtModPath = new TextBox();
            btnFlow = new FlowLayoutPanel();
            btnBrowse = new Button();
            btnReload = new Button();
            row2Panel = new TableLayoutPanel();
            tvGroups = new TreeView();
            nodeContextMenu = new ContextMenuStrip(components);
            menuAdd = new ToolStripMenuItem();
            menuEdit = new ToolStripMenuItem();
            menuDelete = new ToolStripMenuItem();
            dataGridView = new DataGridView();
            row3Panel = new TableLayoutPanel();
            emptyLeft = new Panel();
            buttonGroup = new FlowLayoutPanel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            savePanel = new TableLayoutPanel();
            btnSave = new Button();
            mainTable.SuspendLayout();
            pathPanel.SuspendLayout();
            btnFlow.SuspendLayout();
            row2Panel.SuspendLayout();
            nodeContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            row3Panel.SuspendLayout();
            buttonGroup.SuspendLayout();
            savePanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainTable
            // 
            mainTable.ColumnCount = 1;
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55F));
            mainTable.Controls.Add(pathPanel, 0, 0);
            mainTable.Controls.Add(row2Panel, 0, 1);
            mainTable.Controls.Add(row3Panel, 0, 2);
            mainTable.Controls.Add(savePanel, 0, 3);
            mainTable.Dock = DockStyle.Fill;
            mainTable.Location = new Point(0, 0);
            mainTable.Margin = new Padding(4);
            mainTable.Name = "mainTable";
            mainTable.Padding = new Padding(12);
            mainTable.RowCount = 4;
            mainTable.RowStyles.Add(new RowStyle());
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTable.RowStyles.Add(new RowStyle());
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
            // row2Panel
            // 
            row2Panel.ColumnCount = 2;
            row2Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            row2Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            row2Panel.Controls.Add(tvGroups, 0, 0);
            row2Panel.Controls.Add(dataGridView, 1, 0);
            row2Panel.Dock = DockStyle.Fill;
            row2Panel.Location = new Point(16, 81);
            row2Panel.Margin = new Padding(4);
            row2Panel.Name = "row2Panel";
            row2Panel.RowCount = 1;
            row2Panel.RowStyles.Add(new RowStyle());
            row2Panel.Size = new Size(1218, 585);
            row2Panel.TabIndex = 1;
            // 
            // tvGroups
            // 
            tvGroups.ContextMenuStrip = nodeContextMenu;
            tvGroups.Dock = DockStyle.Fill;
            tvGroups.Location = new Point(3, 3);
            tvGroups.Name = "tvGroups";
            tvGroups.Size = new Size(359, 579);
            tvGroups.TabIndex = 0;
            // 
            // nodeContextMenu
            // 
            nodeContextMenu.ImageScalingSize = new Size(24, 24);
            nodeContextMenu.Items.AddRange(new ToolStripItem[] { menuAdd, menuEdit, menuDelete });
            nodeContextMenu.Name = "nodeContextMenu";
            nodeContextMenu.Size = new Size(135, 100);
            // 
            // menuAdd
            // 
            menuAdd.Name = "menuAdd";
            menuAdd.Size = new Size(134, 32);
            menuAdd.Text = "Add...";
            // 
            // menuEdit
            // 
            menuEdit.Name = "menuEdit";
            menuEdit.Size = new Size(134, 32);
            menuEdit.Text = "Edit";
            // 
            // menuDelete
            // 
            menuDelete.Name = "menuDelete";
            menuDelete.Size = new Size(134, 32);
            menuDelete.Text = "Delete";
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(368, 3);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 62;
            dataGridView.Size = new Size(847, 579);
            dataGridView.TabIndex = 1;
            // 
            // row3Panel
            // 
            row3Panel.ColumnCount = 2;
            row3Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            row3Panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            row3Panel.Controls.Add(emptyLeft, 0, 0);
            row3Panel.Controls.Add(buttonGroup, 1, 0);
            row3Panel.Dock = DockStyle.Top;
            row3Panel.Location = new Point(16, 674);
            row3Panel.Margin = new Padding(4);
            row3Panel.Name = "row3Panel";
            row3Panel.RowCount = 1;
            row3Panel.RowStyles.Add(new RowStyle());
            row3Panel.Size = new Size(1218, 60);
            row3Panel.TabIndex = 2;
            // 
            // emptyLeft
            // 
            emptyLeft.Dock = DockStyle.Fill;
            emptyLeft.Location = new Point(3, 3);
            emptyLeft.Name = "emptyLeft";
            emptyLeft.Size = new Size(359, 100);
            emptyLeft.TabIndex = 0;
            // 
            // buttonGroup
            // 
            buttonGroup.Controls.Add(btnAdd);
            buttonGroup.Controls.Add(btnEdit);
            buttonGroup.Controls.Add(btnDelete);
            buttonGroup.Dock = DockStyle.Top;
            buttonGroup.Location = new Point(368, 3);
            buttonGroup.Name = "buttonGroup";
            buttonGroup.Size = new Size(847, 50);
            buttonGroup.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(3, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 44);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(109, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 44);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(215, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 44);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            // 
            // savePanel
            // 
            savePanel.ColumnCount = 1;
            savePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            savePanel.Controls.Add(btnSave, 0, 0);
            savePanel.Dock = DockStyle.Bottom;
            savePanel.Location = new Point(12, 750);
            savePanel.Margin = new Padding(0, 12, 0, 0);
            savePanel.Name = "savePanel";
            savePanel.RowCount = 1;
            savePanel.RowStyles.Add(new RowStyle());
            savePanel.Size = new Size(1226, 50);
            savePanel.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Right;
            btnSave.Location = new Point(1097, 4);
            btnSave.Margin = new Padding(4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(125, 44);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
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
            row2Panel.ResumeLayout(false);
            nodeContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            row3Panel.ResumeLayout(false);
            buttonGroup.ResumeLayout(false);
            savePanel.ResumeLayout(false);
            ResumeLayout(false);
        }
        private TableLayoutPanel mainTable;
        private TableLayoutPanel pathPanel;
        private Label lblPath;
        private TextBox txtModPath;
        private FlowLayoutPanel btnFlow;
        private Button btnBrowse;
        private Button btnReload;
        private TableLayoutPanel row2Panel;
        private TreeView tvGroups;
        private DataGridView dataGridView;
        private TableLayoutPanel row3Panel;
        private Panel emptyLeft;
        private FlowLayoutPanel buttonGroup;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private TableLayoutPanel savePanel;
        private Button btnSave;
        private ContextMenuStrip nodeContextMenu;
        private ToolStripMenuItem menuAdd;
        private ToolStripMenuItem menuEdit;
        private ToolStripMenuItem menuDelete;
    }
}