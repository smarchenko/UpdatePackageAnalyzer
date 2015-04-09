namespace UpdatePackageAnalyzer
{
  partial class PackageComparer
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
      System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Removed Commands", System.Windows.Forms.HorizontalAlignment.Left);
      System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("New Commands", System.Windows.Forms.HorizontalAlignment.Left);
      System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Changed Commands", System.Windows.Forms.HorizontalAlignment.Left);
      System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Identical Commands", System.Windows.Forms.HorizontalAlignment.Left);
      System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("first");
      System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("second");
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.label1 = new System.Windows.Forms.Label();
      this.btnSearch = new System.Windows.Forms.Button();
      this.SearchText = new System.Windows.Forms.TextBox();
      this.commandsView = new System.Windows.Forms.ListView();
      this.CommandType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.CommandPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.database = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnFilter = new System.Windows.Forms.Button();
      this.tabFilters = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.clbGroupFilters = new System.Windows.Forms.CheckedListBox();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.clbCommandTypeFilter = new System.Windows.Forms.CheckedListBox();
      this.tabPage3 = new System.Windows.Forms.TabPage();
      this.CustomFilterList = new System.Windows.Forms.CheckedListBox();
      this.RightPackagePath = new System.Windows.Forms.TextBox();
      this.LeftPackagePath = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.statusStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.tabFilters.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.tabPage3.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel4});
      this.statusStrip1.Location = new System.Drawing.Point(0, 541);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(1207, 22);
      this.statusStrip1.TabIndex = 0;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel3
      // 
      this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
      this.toolStripStatusLabel3.Size = new System.Drawing.Size(106, 17);
      this.toolStripStatusLabel3.Text = "Shown commands";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(155, 17);
      this.toolStripStatusLabel1.Text = "Total Commands in the Left";
      // 
      // toolStripStatusLabel2
      // 
      this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
      this.toolStripStatusLabel2.Size = new System.Drawing.Size(161, 17);
      this.toolStripStatusLabel2.Text = "Total commands in the Right";
      // 
      // toolStripStatusLabel4
      // 
      this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
      this.toolStripStatusLabel4.Size = new System.Drawing.Size(126, 17);
      this.toolStripStatusLabel4.Text = "Commands By Groups";
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Location = new System.Drawing.Point(0, 37);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(1207, 501);
      this.panel1.TabIndex = 4;
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.label1);
      this.panel3.Controls.Add(this.btnSearch);
      this.panel3.Controls.Add(this.SearchText);
      this.panel3.Controls.Add(this.commandsView);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(1207, 365);
      this.panel3.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(1, 18);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(65, 13);
      this.label1.TabIndex = 11;
      this.label1.Text = "Search Text";
      // 
      // btnSearch
      // 
      this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSearch.Location = new System.Drawing.Point(1128, 14);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(75, 23);
      this.btnSearch.TabIndex = 10;
      this.btnSearch.Text = "Search";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // SearchText
      // 
      this.SearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.SearchText.Location = new System.Drawing.Point(72, 15);
      this.SearchText.Name = "SearchText";
      this.SearchText.Size = new System.Drawing.Size(1050, 20);
      this.SearchText.TabIndex = 3;
      // 
      // commandsView
      // 
      this.commandsView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.commandsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CommandType,
            this.CommandPath,
            this.database});
      this.commandsView.FullRowSelect = true;
      listViewGroup1.Header = "Removed Commands";
      listViewGroup1.Name = "RemovedGroup";
      listViewGroup2.Header = "New Commands";
      listViewGroup2.Name = "AddedGroup";
      listViewGroup3.Header = "Changed Commands";
      listViewGroup3.Name = "ChangedGroup";
      listViewGroup4.Header = "Identical Commands";
      listViewGroup4.Name = "IdenticalGroup";
      this.commandsView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
      listViewItem1.Group = listViewGroup2;
      listViewItem2.Group = listViewGroup1;
      listViewItem2.IndentCount = 1;
      this.commandsView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
      this.commandsView.Location = new System.Drawing.Point(4, 50);
      this.commandsView.MultiSelect = false;
      this.commandsView.Name = "commandsView";
      this.commandsView.Size = new System.Drawing.Size(1199, 312);
      this.commandsView.TabIndex = 1;
      this.commandsView.UseCompatibleStateImageBehavior = false;
      this.commandsView.View = System.Windows.Forms.View.Details;
      this.commandsView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.commandsView_MouseDoubleClick);
      // 
      // CommandType
      // 
      this.CommandType.Text = "Command";
      this.CommandType.Width = 150;
      // 
      // CommandPath
      // 
      this.CommandPath.Text = "Key";
      this.CommandPath.Width = 900;
      // 
      // database
      // 
      this.database.Text = "Command Database";
      this.database.Width = 121;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnFilter);
      this.panel2.Controls.Add(this.tabFilters);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 365);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(1207, 136);
      this.panel2.TabIndex = 1;
      // 
      // btnFilter
      // 
      this.btnFilter.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnFilter.Location = new System.Drawing.Point(1132, 0);
      this.btnFilter.Name = "btnFilter";
      this.btnFilter.Size = new System.Drawing.Size(75, 136);
      this.btnFilter.TabIndex = 1;
      this.btnFilter.Text = "Filter";
      this.btnFilter.UseVisualStyleBackColor = true;
      this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
      // 
      // tabFilters
      // 
      this.tabFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabFilters.Controls.Add(this.tabPage1);
      this.tabFilters.Controls.Add(this.tabPage2);
      this.tabFilters.Controls.Add(this.tabPage3);
      this.tabFilters.Location = new System.Drawing.Point(0, 0);
      this.tabFilters.Name = "tabFilters";
      this.tabFilters.SelectedIndex = 0;
      this.tabFilters.Size = new System.Drawing.Size(1126, 136);
      this.tabFilters.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.clbGroupFilters);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(1118, 110);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Group Filters";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // clbGroupFilters
      // 
      this.clbGroupFilters.Dock = System.Windows.Forms.DockStyle.Fill;
      this.clbGroupFilters.FormattingEnabled = true;
      this.clbGroupFilters.Location = new System.Drawing.Point(3, 3);
      this.clbGroupFilters.Name = "clbGroupFilters";
      this.clbGroupFilters.Size = new System.Drawing.Size(1112, 104);
      this.clbGroupFilters.TabIndex = 0;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.clbCommandTypeFilter);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(1118, 110);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Command Filters";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // clbCommandTypeFilter
      // 
      this.clbCommandTypeFilter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.clbCommandTypeFilter.FormattingEnabled = true;
      this.clbCommandTypeFilter.Location = new System.Drawing.Point(3, 3);
      this.clbCommandTypeFilter.Name = "clbCommandTypeFilter";
      this.clbCommandTypeFilter.Size = new System.Drawing.Size(1112, 104);
      this.clbCommandTypeFilter.TabIndex = 0;
      // 
      // tabPage3
      // 
      this.tabPage3.Controls.Add(this.CustomFilterList);
      this.tabPage3.Location = new System.Drawing.Point(4, 22);
      this.tabPage3.Name = "tabPage3";
      this.tabPage3.Size = new System.Drawing.Size(1118, 110);
      this.tabPage3.TabIndex = 2;
      this.tabPage3.Text = "Custom Filters";
      this.tabPage3.UseVisualStyleBackColor = true;
      // 
      // CustomFilterList
      // 
      this.CustomFilterList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CustomFilterList.FormattingEnabled = true;
      this.CustomFilterList.Location = new System.Drawing.Point(0, 0);
      this.CustomFilterList.Name = "CustomFilterList";
      this.CustomFilterList.Size = new System.Drawing.Size(1118, 110);
      this.CustomFilterList.TabIndex = 0;
      // 
      // RightPackagePath
      // 
      this.RightPackagePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.RightPackagePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.RightPackagePath.Location = new System.Drawing.Point(86, 23);
      this.RightPackagePath.Name = "RightPackagePath";
      this.RightPackagePath.ReadOnly = true;
      this.RightPackagePath.Size = new System.Drawing.Size(1107, 13);
      this.RightPackagePath.TabIndex = 9;
      this.RightPackagePath.TabStop = false;
      // 
      // LeftPackagePath
      // 
      this.LeftPackagePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.LeftPackagePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.LeftPackagePath.Location = new System.Drawing.Point(86, 9);
      this.LeftPackagePath.Name = "LeftPackagePath";
      this.LeftPackagePath.ReadOnly = true;
      this.LeftPackagePath.Size = new System.Drawing.Size(1107, 13);
      this.LeftPackagePath.TabIndex = 8;
      this.LeftPackagePath.TabStop = false;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(1, 23);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(81, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "Right Package:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(1, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(74, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Left Package:";
      // 
      // PackageComparer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1207, 563);
      this.Controls.Add(this.LeftPackagePath);
      this.Controls.Add(this.RightPackagePath);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.statusStrip1);
      this.Name = "PackageComparer";
      this.Text = "PackageComparer";
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.tabFilters.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.tabPage3.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.ListView commandsView;
    private System.Windows.Forms.ColumnHeader CommandType;
    private System.Windows.Forms.ColumnHeader CommandPath;
    private System.Windows.Forms.TabControl tabFilters;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.TextBox SearchText;
    private System.Windows.Forms.TextBox RightPackagePath;
    private System.Windows.Forms.TextBox LeftPackagePath;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ColumnHeader database;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
    private System.Windows.Forms.Button btnFilter;
    private System.Windows.Forms.CheckedListBox clbGroupFilters;
    private System.Windows.Forms.CheckedListBox clbCommandTypeFilter;
    private System.Windows.Forms.CheckedListBox CustomFilterList;

  }
}