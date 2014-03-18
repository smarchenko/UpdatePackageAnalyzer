namespace UpdatePackageAnalyzer
{
  partial class MainForm
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
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.SearchBtn = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.SearchText = new System.Windows.Forms.TextBox();
      this.MenuStrip = new System.Windows.Forms.MenuStrip();
      this.Load = new System.Windows.Forms.ToolStripMenuItem();
      this.loadDiffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.loadDiffToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.loadPackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editReadMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.splitContainer3 = new System.Windows.Forms.SplitContainer();
      this.CommandsTreeView = new System.Windows.Forms.TreeView();
      this.ApplyFiltersBtn = new System.Windows.Forms.Button();
      this.FilterTabControl = new System.Windows.Forms.TabControl();
      this.CommandTypesPage = new System.Windows.Forms.TabPage();
      this.CommandTypesCheckedListBox = new System.Windows.Forms.CheckedListBox();
      this.DatabaseFiltersTab = new System.Windows.Forms.TabPage();
      this.DatabaseFilters = new System.Windows.Forms.CheckedListBox();
      this.CustomFilters = new System.Windows.Forms.TabPage();
      this.CustomFilterList = new System.Windows.Forms.CheckedListBox();
      this.StatusStrip = new System.Windows.Forms.StatusStrip();
      this.CommandsCount = new System.Windows.Forms.ToolStripStatusLabel();
      this.GeneralCommands = new System.Windows.Forms.ToolStripStatusLabel();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.PreviewCommandContent = new System.Windows.Forms.WebBrowser();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.splitContainer4 = new System.Windows.Forms.SplitContainer();
      this.CommandContent = new System.Windows.Forms.RichTextBox();
      this.ApplyChanges = new System.Windows.Forms.Button();
      this.PackageOverview = new System.Windows.Forms.TabPage();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label5 = new System.Windows.Forms.Label();
      this.CommandsOverview = new System.Windows.Forms.DataGridView();
      this.TotalCommandsCount = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.PackageDescription = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.PackageName = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.problemsPanel = new System.Windows.Forms.Panel();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.MenuStrip.SuspendLayout();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.splitContainer3.Panel1.SuspendLayout();
      this.splitContainer3.Panel2.SuspendLayout();
      this.splitContainer3.SuspendLayout();
      this.FilterTabControl.SuspendLayout();
      this.CommandTypesPage.SuspendLayout();
      this.DatabaseFiltersTab.SuspendLayout();
      this.CustomFilters.SuspendLayout();
      this.StatusStrip.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.splitContainer4.Panel1.SuspendLayout();
      this.splitContainer4.Panel2.SuspendLayout();
      this.splitContainer4.SuspendLayout();
      this.PackageOverview.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.CommandsOverview)).BeginInit();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.SearchBtn);
      this.splitContainer1.Panel1.Controls.Add(this.label3);
      this.splitContainer1.Panel1.Controls.Add(this.SearchText);
      this.splitContainer1.Panel1.Controls.Add(this.MenuStrip);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
      this.splitContainer1.Size = new System.Drawing.Size(1379, 738);
      this.splitContainer1.SplitterDistance = 57;
      this.splitContainer1.TabIndex = 1;
      // 
      // SearchBtn
      // 
      this.SearchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.SearchBtn.Location = new System.Drawing.Point(1292, 30);
      this.SearchBtn.Name = "SearchBtn";
      this.SearchBtn.Size = new System.Drawing.Size(75, 23);
      this.SearchBtn.TabIndex = 2;
      this.SearchBtn.Text = "Search";
      this.SearchBtn.UseVisualStyleBackColor = true;
      this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 33);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(65, 13);
      this.label3.TabIndex = 1;
      this.label3.Text = "Search Text";
      // 
      // SearchText
      // 
      this.SearchText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.SearchText.Location = new System.Drawing.Point(77, 30);
      this.SearchText.Name = "SearchText";
      this.SearchText.Size = new System.Drawing.Size(1202, 20);
      this.SearchText.TabIndex = 0;
      // 
      // MenuStrip
      // 
      this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Load,
            this.editReadMeToolStripMenuItem});
      this.MenuStrip.Location = new System.Drawing.Point(0, 0);
      this.MenuStrip.Name = "MenuStrip";
      this.MenuStrip.Size = new System.Drawing.Size(1379, 24);
      this.MenuStrip.TabIndex = 3;
      this.MenuStrip.Text = "menuStrip1";
      // 
      // Load
      // 
      this.Load.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDiffToolStripMenuItem});
      this.Load.Name = "Load";
      this.Load.Size = new System.Drawing.Size(37, 20);
      this.Load.Text = "File";
      // 
      // loadDiffToolStripMenuItem
      // 
      this.loadDiffToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDiffToolStripMenuItem1,
            this.loadPackageToolStripMenuItem});
      this.loadDiffToolStripMenuItem.Name = "loadDiffToolStripMenuItem";
      this.loadDiffToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
      this.loadDiffToolStripMenuItem.Text = "Load";
      // 
      // loadDiffToolStripMenuItem1
      // 
      this.loadDiffToolStripMenuItem1.Name = "loadDiffToolStripMenuItem1";
      this.loadDiffToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
      this.loadDiffToolStripMenuItem1.Text = "Load Diff";
      this.loadDiffToolStripMenuItem1.Click += new System.EventHandler(this.loadDiffToolStripMenuItem1_Click);
      // 
      // loadPackageToolStripMenuItem
      // 
      this.loadPackageToolStripMenuItem.Name = "loadPackageToolStripMenuItem";
      this.loadPackageToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
      this.loadPackageToolStripMenuItem.Text = "Load Package";
      this.loadPackageToolStripMenuItem.Click += new System.EventHandler(this.loadPackageToolStripMenuItem_Click);
      // 
      // editReadMeToolStripMenuItem
      // 
      this.editReadMeToolStripMenuItem.Enabled = false;
      this.editReadMeToolStripMenuItem.Name = "editReadMeToolStripMenuItem";
      this.editReadMeToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
      this.editReadMeToolStripMenuItem.Text = "Edit ReadMe";
      this.editReadMeToolStripMenuItem.Click += new System.EventHandler(this.editReadMeToolStripMenuItem_Click);
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
      this.splitContainer2.Size = new System.Drawing.Size(1379, 677);
      this.splitContainer2.SplitterDistance = 423;
      this.splitContainer2.TabIndex = 0;
      // 
      // splitContainer3
      // 
      this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer3.Location = new System.Drawing.Point(0, 0);
      this.splitContainer3.Name = "splitContainer3";
      this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer3.Panel1
      // 
      this.splitContainer3.Panel1.Controls.Add(this.CommandsTreeView);
      // 
      // splitContainer3.Panel2
      // 
      this.splitContainer3.Panel2.Controls.Add(this.ApplyFiltersBtn);
      this.splitContainer3.Panel2.Controls.Add(this.FilterTabControl);
      this.splitContainer3.Panel2.Controls.Add(this.StatusStrip);
      this.splitContainer3.Size = new System.Drawing.Size(423, 677);
      this.splitContainer3.SplitterDistance = 487;
      this.splitContainer3.TabIndex = 0;
      // 
      // CommandsTreeView
      // 
      this.CommandsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CommandsTreeView.HideSelection = false;
      this.CommandsTreeView.Location = new System.Drawing.Point(0, 0);
      this.CommandsTreeView.Name = "CommandsTreeView";
      this.CommandsTreeView.Size = new System.Drawing.Size(423, 487);
      this.CommandsTreeView.TabIndex = 1;
      this.CommandsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.CommandsTreeView_AfterSelect);
      this.CommandsTreeView.DoubleClick += new System.EventHandler(this.CommandsTreeView_DoubleClick);
      // 
      // ApplyFiltersBtn
      // 
      this.ApplyFiltersBtn.Dock = System.Windows.Forms.DockStyle.Right;
      this.ApplyFiltersBtn.Location = new System.Drawing.Point(348, 0);
      this.ApplyFiltersBtn.Name = "ApplyFiltersBtn";
      this.ApplyFiltersBtn.Size = new System.Drawing.Size(75, 164);
      this.ApplyFiltersBtn.TabIndex = 4;
      this.ApplyFiltersBtn.Text = "Apply Filters";
      this.ApplyFiltersBtn.UseVisualStyleBackColor = true;
      this.ApplyFiltersBtn.Click += new System.EventHandler(this.ApplyFiltersBtn_Click);
      // 
      // FilterTabControl
      // 
      this.FilterTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.FilterTabControl.Controls.Add(this.CommandTypesPage);
      this.FilterTabControl.Controls.Add(this.DatabaseFiltersTab);
      this.FilterTabControl.Controls.Add(this.CustomFilters);
      this.FilterTabControl.Location = new System.Drawing.Point(3, 2);
      this.FilterTabControl.Name = "FilterTabControl";
      this.FilterTabControl.SelectedIndex = 0;
      this.FilterTabControl.Size = new System.Drawing.Size(348, 159);
      this.FilterTabControl.TabIndex = 3;
      // 
      // CommandTypesPage
      // 
      this.CommandTypesPage.Controls.Add(this.CommandTypesCheckedListBox);
      this.CommandTypesPage.Location = new System.Drawing.Point(4, 22);
      this.CommandTypesPage.Name = "CommandTypesPage";
      this.CommandTypesPage.Padding = new System.Windows.Forms.Padding(3);
      this.CommandTypesPage.Size = new System.Drawing.Size(340, 133);
      this.CommandTypesPage.TabIndex = 0;
      this.CommandTypesPage.Text = "CommandTypes";
      this.CommandTypesPage.UseVisualStyleBackColor = true;
      // 
      // CommandTypesCheckedListBox
      // 
      this.CommandTypesCheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CommandTypesCheckedListBox.FormattingEnabled = true;
      this.CommandTypesCheckedListBox.Location = new System.Drawing.Point(3, 3);
      this.CommandTypesCheckedListBox.Name = "CommandTypesCheckedListBox";
      this.CommandTypesCheckedListBox.Size = new System.Drawing.Size(334, 127);
      this.CommandTypesCheckedListBox.TabIndex = 0;
      // 
      // DatabaseFiltersTab
      // 
      this.DatabaseFiltersTab.Controls.Add(this.DatabaseFilters);
      this.DatabaseFiltersTab.Location = new System.Drawing.Point(4, 22);
      this.DatabaseFiltersTab.Name = "DatabaseFiltersTab";
      this.DatabaseFiltersTab.Padding = new System.Windows.Forms.Padding(3);
      this.DatabaseFiltersTab.Size = new System.Drawing.Size(340, 133);
      this.DatabaseFiltersTab.TabIndex = 1;
      this.DatabaseFiltersTab.Text = "Databases";
      this.DatabaseFiltersTab.UseVisualStyleBackColor = true;
      // 
      // DatabaseFilters
      // 
      this.DatabaseFilters.Dock = System.Windows.Forms.DockStyle.Fill;
      this.DatabaseFilters.FormattingEnabled = true;
      this.DatabaseFilters.Location = new System.Drawing.Point(3, 3);
      this.DatabaseFilters.Name = "DatabaseFilters";
      this.DatabaseFilters.Size = new System.Drawing.Size(334, 127);
      this.DatabaseFilters.TabIndex = 0;
      // 
      // CustomFilters
      // 
      this.CustomFilters.Controls.Add(this.CustomFilterList);
      this.CustomFilters.Location = new System.Drawing.Point(4, 22);
      this.CustomFilters.Name = "CustomFilters";
      this.CustomFilters.Size = new System.Drawing.Size(340, 133);
      this.CustomFilters.TabIndex = 2;
      this.CustomFilters.Text = "Custom";
      this.CustomFilters.UseVisualStyleBackColor = true;
      // 
      // CustomFilterList
      // 
      this.CustomFilterList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CustomFilterList.FormattingEnabled = true;
      this.CustomFilterList.Items.AddRange(new object[] {
            "Filter Translation changes"});
      this.CustomFilterList.Location = new System.Drawing.Point(0, 0);
      this.CustomFilterList.Name = "CustomFilterList";
      this.CustomFilterList.Size = new System.Drawing.Size(340, 133);
      this.CustomFilterList.TabIndex = 0;
      // 
      // StatusStrip
      // 
      this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CommandsCount,
            this.GeneralCommands});
      this.StatusStrip.Location = new System.Drawing.Point(0, 164);
      this.StatusStrip.Name = "StatusStrip";
      this.StatusStrip.Size = new System.Drawing.Size(423, 22);
      this.StatusStrip.TabIndex = 2;
      this.StatusStrip.Text = "statusStrip1";
      // 
      // CommandsCount
      // 
      this.CommandsCount.Name = "CommandsCount";
      this.CommandsCount.Size = new System.Drawing.Size(105, 17);
      this.CommandsCount.Text = "Commands Count";
      // 
      // GeneralCommands
      // 
      this.GeneralCommands.Name = "GeneralCommands";
      this.GeneralCommands.Size = new System.Drawing.Size(112, 17);
      this.GeneralCommands.Text = "General Commands";
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Controls.Add(this.PackageOverview);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(952, 677);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.Controls.Add(this.PreviewCommandContent);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(944, 651);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "View";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // PreviewCommandContent
      // 
      this.PreviewCommandContent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PreviewCommandContent.Location = new System.Drawing.Point(3, 3);
      this.PreviewCommandContent.MinimumSize = new System.Drawing.Size(20, 20);
      this.PreviewCommandContent.Name = "PreviewCommandContent";
      this.PreviewCommandContent.Size = new System.Drawing.Size(938, 645);
      this.PreviewCommandContent.TabIndex = 0;
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.splitContainer4);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(944, 651);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Edit";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // splitContainer4
      // 
      this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer4.Location = new System.Drawing.Point(3, 3);
      this.splitContainer4.Name = "splitContainer4";
      this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer4.Panel1
      // 
      this.splitContainer4.Panel1.Controls.Add(this.CommandContent);
      // 
      // splitContainer4.Panel2
      // 
      this.splitContainer4.Panel2.Controls.Add(this.ApplyChanges);
      this.splitContainer4.Size = new System.Drawing.Size(938, 645);
      this.splitContainer4.SplitterDistance = 609;
      this.splitContainer4.TabIndex = 0;
      // 
      // CommandContent
      // 
      this.CommandContent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CommandContent.Location = new System.Drawing.Point(0, 0);
      this.CommandContent.Name = "CommandContent";
      this.CommandContent.Size = new System.Drawing.Size(938, 609);
      this.CommandContent.TabIndex = 1;
      this.CommandContent.Text = "";
      // 
      // ApplyChanges
      // 
      this.ApplyChanges.Location = new System.Drawing.Point(811, 4);
      this.ApplyChanges.Name = "ApplyChanges";
      this.ApplyChanges.Size = new System.Drawing.Size(103, 23);
      this.ApplyChanges.TabIndex = 0;
      this.ApplyChanges.Text = "Apply Changes";
      this.ApplyChanges.UseVisualStyleBackColor = true;
      this.ApplyChanges.Click += new System.EventHandler(this.ApplyChanges_Click);
      // 
      // PackageOverview
      // 
      this.PackageOverview.Controls.Add(this.panel1);
      this.PackageOverview.Controls.Add(this.CommandsOverview);
      this.PackageOverview.Controls.Add(this.TotalCommandsCount);
      this.PackageOverview.Controls.Add(this.label4);
      this.PackageOverview.Controls.Add(this.PackageDescription);
      this.PackageOverview.Controls.Add(this.label2);
      this.PackageOverview.Controls.Add(this.PackageName);
      this.PackageOverview.Controls.Add(this.label1);
      this.PackageOverview.Location = new System.Drawing.Point(4, 22);
      this.PackageOverview.Name = "PackageOverview";
      this.PackageOverview.Size = new System.Drawing.Size(944, 651);
      this.PackageOverview.TabIndex = 2;
      this.PackageOverview.Text = "Package Overview";
      this.PackageOverview.UseVisualStyleBackColor = true;
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.Controls.Add(this.problemsPanel);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Location = new System.Drawing.Point(3, 282);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(944, 369);
      this.panel1.TabIndex = 7;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Dock = System.Windows.Forms.DockStyle.Top;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label5.Location = new System.Drawing.Point(0, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(217, 20);
      this.label5.TabIndex = 0;
      this.label5.Text = "List of potential problems:";
      // 
      // CommandsOverview
      // 
      this.CommandsOverview.AllowUserToAddRows = false;
      this.CommandsOverview.AllowUserToDeleteRows = false;
      this.CommandsOverview.AllowUserToResizeColumns = false;
      this.CommandsOverview.AllowUserToResizeRows = false;
      this.CommandsOverview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.CommandsOverview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.CommandsOverview.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
      this.CommandsOverview.BackgroundColor = System.Drawing.SystemColors.Window;
      this.CommandsOverview.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.CommandsOverview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.CommandsOverview.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.CommandsOverview.Location = new System.Drawing.Point(19, 73);
      this.CommandsOverview.MultiSelect = false;
      this.CommandsOverview.Name = "CommandsOverview";
      this.CommandsOverview.ReadOnly = true;
      this.CommandsOverview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.CommandsOverview.Size = new System.Drawing.Size(917, 141);
      this.CommandsOverview.TabIndex = 6;
      // 
      // TotalCommandsCount
      // 
      this.TotalCommandsCount.AutoSize = true;
      this.TotalCommandsCount.Location = new System.Drawing.Point(128, 57);
      this.TotalCommandsCount.Name = "TotalCommandsCount";
      this.TotalCommandsCount.Size = new System.Drawing.Size(13, 13);
      this.TotalCommandsCount.TabIndex = 5;
      this.TotalCommandsCount.Text = "0";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label4.Location = new System.Drawing.Point(16, 57);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(104, 13);
      this.label4.TabIndex = 4;
      this.label4.Text = "Total Commands:";
      // 
      // PackageDescription
      // 
      this.PackageDescription.AutoSize = true;
      this.PackageDescription.Location = new System.Drawing.Point(128, 33);
      this.PackageDescription.Name = "PackageDescription";
      this.PackageDescription.Size = new System.Drawing.Size(33, 13);
      this.PackageDescription.TabIndex = 3;
      this.PackageDescription.Text = "None";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(16, 33);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(75, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Description:";
      // 
      // PackageName
      // 
      this.PackageName.AutoSize = true;
      this.PackageName.Location = new System.Drawing.Point(128, 11);
      this.PackageName.Name = "PackageName";
      this.PackageName.Size = new System.Drawing.Size(33, 13);
      this.PackageName.TabIndex = 1;
      this.PackageName.Text = "None";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(16, 11);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(95, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Package name:";
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // problemsPanel
      // 
      this.problemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.problemsPanel.Location = new System.Drawing.Point(0, 20);
      this.problemsPanel.Name = "problemsPanel";
      this.problemsPanel.Size = new System.Drawing.Size(944, 349);
      this.problemsPanel.TabIndex = 1;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1379, 738);
      this.Controls.Add(this.splitContainer1);
      this.Name = "MainForm";
      this.Text = "Update Package Analyzer";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.ResumeLayout(false);
      this.MenuStrip.ResumeLayout(false);
      this.MenuStrip.PerformLayout();
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.ResumeLayout(false);
      this.splitContainer3.Panel1.ResumeLayout(false);
      this.splitContainer3.Panel2.ResumeLayout(false);
      this.splitContainer3.Panel2.PerformLayout();
      this.splitContainer3.ResumeLayout(false);
      this.FilterTabControl.ResumeLayout(false);
      this.CommandTypesPage.ResumeLayout(false);
      this.DatabaseFiltersTab.ResumeLayout(false);
      this.CustomFilters.ResumeLayout(false);
      this.StatusStrip.ResumeLayout(false);
      this.StatusStrip.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.splitContainer4.Panel1.ResumeLayout(false);
      this.splitContainer4.Panel2.ResumeLayout(false);
      this.splitContainer4.ResumeLayout(false);
      this.PackageOverview.ResumeLayout(false);
      this.PackageOverview.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.CommandsOverview)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.SplitContainer splitContainer3;
    private System.Windows.Forms.TreeView CommandsTreeView;
    private System.Windows.Forms.Button SearchBtn;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox SearchText;
    private System.Windows.Forms.MenuStrip MenuStrip;
    private System.Windows.Forms.ToolStripMenuItem Load;
    private System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog;
    private System.Windows.Forms.StatusStrip StatusStrip;
    private System.Windows.Forms.ToolStripStatusLabel CommandsCount;
    private System.Windows.Forms.ToolStripStatusLabel GeneralCommands;
    private System.Windows.Forms.TabControl FilterTabControl;
    private System.Windows.Forms.TabPage CommandTypesPage;
    private System.Windows.Forms.TabPage DatabaseFiltersTab;
    private System.Windows.Forms.CheckedListBox CommandTypesCheckedListBox;
    private System.Windows.Forms.Button ApplyFiltersBtn;
    private System.Windows.Forms.CheckedListBox DatabaseFilters;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.SplitContainer splitContainer4;
    private System.Windows.Forms.RichTextBox CommandContent;
    private System.Windows.Forms.Button ApplyChanges;
    private System.Windows.Forms.WebBrowser PreviewCommandContent;
    private System.Windows.Forms.ToolStripMenuItem loadDiffToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem loadDiffToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem loadPackageToolStripMenuItem;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.ToolStripMenuItem editReadMeToolStripMenuItem;
    private System.Windows.Forms.TabPage PackageOverview;
    private System.Windows.Forms.Label PackageName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label PackageDescription;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label TotalCommandsCount;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.DataGridView CommandsOverview;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TabPage CustomFilters;
    private System.Windows.Forms.CheckedListBox CustomFilterList;
    private System.Windows.Forms.Panel problemsPanel;

  }
}

