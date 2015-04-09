using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UpdatePackageAnalyzer
{
  using System.Configuration;
  using System.IO;
  using System.Web;
  using System.Xml;

  using Sitecore.Diagnostics;
  using Sitecore.Install.BlobData;
  using Sitecore.Install.Files;
  using Sitecore.Install.Framework;
  using Sitecore.Install.Items;
  using Sitecore.Install.Metadata;
  using Sitecore.Install.Zip;
  using Sitecore.Update;
  using Sitecore.Update.Commands;
  using Sitecore.Update.Configuration;
  using Sitecore.Update.Data;
  using Sitecore.Update.Installer;
  using Sitecore.Update.Installer.Items;
  using Sitecore.Update.Installer.Utils;
  using Sitecore.Update.Interfaces;
  using Sitecore.Update.Utils;

  using UpdatePackageAnalyzer.CustomCommandFilters;
  using UpdatePackageAnalyzer.PackageAnalyzers;

  public partial class MainForm : Form
  {
    private DiffInfo diff = null;
    private bool showInList = true;
    private ICommand selectedCommand = null;
    private string diffFilePath = null;
    private Dictionary<string, ICommandFilter> customFilters;
    private List<PackageAnalyzer> analyzers;

    public MainForm()
    {
      InitializeComponent();
    }

    protected void LoadFilters(IList<ICommand> commands)
    {
      this.LoadCommandTypeFilters(commands);
      this.LoadDatabaseFilters(commands);
      this.LoadCustomFilters(commands);
      LoadPackageAnalyzers(commands);
    }

    protected void LoadPackageAnalyzers(IList<ICommand> commands)
    {
      this.analyzers = new List<PackageAnalyzer>();
      this.analyzers.Add(new LicenseFileChangesAnalyzer());
      this.analyzers.Add(new RadControlsChangesAnalyzer());
      this.analyzers.Add(new ConfigFileChangesAnalyzer());
    }

    protected void LoadCustomFilters(IList<ICommand> commands)
    {
      this.customFilters = new Dictionary<string, ICommandFilter>();
      this.customFilters.Add("Filter Translation changes", new TranslationChangeFilter());
      this.customFilters.Add("Filter Dictionary commands", new DictionaryCommandFilter());
      this.customFilters.Add("Filter Recreation Standard Values", new RecreatedStandardValuesFilter(commands));
      this.customFilters.Add("Filter changes in Teplate Standard Values reference", new ChangeStandardValuesReferenceFilter());

      this.CustomFilterList.Items.Clear();
      foreach (string text in this.customFilters.Keys)
      {
        this.CustomFilterList.Items.Add(text);
      }
    }

    protected void LoadDatabaseFilters(IList<ICommand> commands)
    {
      this.DatabaseFilters.Items.Clear();
      if ((commands == null) || (commands.Count == 0))
      {
        return;
      }

      Dictionary<string, int> databases = new Dictionary<string, int>();
      foreach (var command in commands)
      {
        string databaseName = this.GetCommandDatabaseName(command);

        if (!databases.ContainsKey(databaseName))
        {
          databases.Add(databaseName, 0);
        }

        databases[databaseName]++;
      }

      foreach (string key in databases.Keys)
      {
        this.DatabaseFilters.Items.Add(key, true);
      }
    }

    protected void LoadCommandTypeFilters(IList<ICommand> commands)
    {
      this.CommandTypesCheckedListBox.Items.Clear();
      if ((commands == null) || (commands.Count == 0))
      {
        return;
      }

      Dictionary<string, int> types = this.GroupByType(commands);

      foreach (string key in types.Keys)
      {
        this.CommandTypesCheckedListBox.Items.Add(key, true);
      }
    }

    protected Dictionary<string, int> GroupByType(IList<ICommand> commands)
    {
      var types = new Dictionary<string, int>();
      foreach (var command in commands)
      {
        if (!types.ContainsKey(command.CommandPrefix))
        {
          types.Add(command.CommandPrefix, 0);
        }

        types[command.CommandPrefix]++;
      }

      return types;
    }

    protected string GetCommandDatabaseName(ICommand command)
    {
      if (command is BaseItemCommand)
      {
        return (command as BaseItemCommand).DatabaseName;
      }

      return "File System";
    }

    protected IList<ICommand> GetFilteredCommands(IList<ICommand> commands)
    {
      IList<ICommand> result = new List<ICommand>();
      List<string> commandTypes = new List<string>();
      for (int i = 0; i < this.CommandTypesCheckedListBox.CheckedItems.Count; i++)
      {
        commandTypes.Add(this.CommandTypesCheckedListBox.CheckedItems[i].ToString());
      }

      List<string> databases = new List<string>();
      for (int i = 0; i < this.DatabaseFilters.CheckedItems.Count; i++)
      {
        databases.Add(this.DatabaseFilters.CheckedItems[i].ToString());
      }

      string searchText = this.SearchText.Text;

      foreach (ICommand command in commands)
      {
        if (commandTypes.Contains(command.CommandPrefix))
        {
          if (databases.Contains(this.GetCommandDatabaseName(command)))
          {
            if (string.IsNullOrEmpty(searchText) || this.GetCommandText(command).ToLower().Contains(searchText.ToLower()))
            {
              var c = this.FilterByCustomFilter(command);
              if (c == null || c.IsEmpty)
              {
                continue;
              }

              result.Add(command);
            }
          }
        }
      }

      return result;
    }

    protected ICommand FilterByCustomFilter(ICommand command)
    {
      var c = command;
      foreach (string text in this.CustomFilterList.CheckedItems)
      {
        var filter = this.customFilters[text];
        c = filter.FilterCommand(c);

        if (c == null || c.IsEmpty)
        {
          return null;
        }
      }

      return command;
    }

    protected void LoadCommands(IList<ICommand> commands, bool treeView)
    {
      if (commands == null)
      {
        return;
      }

      if (!treeView)
      {
        this.LoadCommandList(commands);
      }

      this.CommandsCount.Text = commands.Count.ToString();
      this.GeneralCommands.Text = this.diff.Commands.Count.ToString();
    }

    protected void LoadCommandList(IList<ICommand> commands)
    {
      TreeViewHelper.InitializeTreeView(this.CommandsTreeView, commands);
    }

    private void ApplyFiltersBtn_Click(object sender, EventArgs e)
    {
      if (this.diff == null)
      {
        return;
      }

      this.LoadCommands(this.GetFilteredCommands(this.diff.Commands), !this.showInList);
    }

    private void CommandsTreeView_DoubleClick(object sender, EventArgs e)
    {
      var filteredCommandsForm = new FilteredCommandsForm();
      StringBuilder list = new StringBuilder();
      for (int i = 0; i < this.CommandsTreeView.Nodes.Count; i++)
      {
        list.AppendLine(this.CommandsTreeView.Nodes[i].Text);
      }

      filteredCommandsForm.SetStringValue(list.ToString());
      filteredCommandsForm.ShowDialog();
    }

    private void CommandsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if ((e.Node == null) || (this.diff == null))
      {
        return;
      }

      ICommand command = null;
      foreach (ICommand c in this.diff.Commands)
      {
        if (string.Compare(TreeViewHelper.GetCommandUniqueId(c), e.Node.Tag.ToString(), true) == 0)
        {
          command = c;
          break;
        }
      }

      this.selectedCommand = command;

      if (command == null)
      {
        return;
      }

      this.BindCommandText(command);
    }

    protected void BindCommandText(ICommand command)
    {
      this.CommandContent.Text = this.GetCommandText(command);
      using (var writer = new StreamWriter(this.GetTempXmlFilePath()))
      {
        writer.Write(this.CommandContent.Text);
      }

      this.PreviewCommandContent.Url = new Uri(this.GetTempXmlFilePath());
    }

    protected string GetTempXmlFilePath()
    {
      return Environment.CurrentDirectory + "\\temp.xml";
    }

    protected string GetCommandText(ICommand command)
    {
      return CommandSerializer.Serialize(command);
    }

    private void SearchBtn_Click(object sender, EventArgs e)
    {
      if (this.diff == null)
      {
        return;
      }

      this.LoadCommands(this.GetFilteredCommands(this.diff.Commands), !this.showInList);
    }

    private void ApplyChanges_Click(object sender, EventArgs e)
    {
      string commandText = this.CommandContent.Text;
      ICommand command = null;
      try
      {
        MemoryStream stream = new MemoryStream();
        using (var writer = new StreamWriter(stream))
        {
          writer.Write(commandText);
          writer.Flush();
          stream.Flush();
          stream.Seek(0, SeekOrigin.Begin);
          var reader = CommandSerializer.GetReader(stream);
          reader.MoveToContent();
          SerializationContext context = SerializationCommandFactory.GetSerializationContext();
          command = SerializationCommandFactory.DeserializeCommand(reader, context);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("Invalid command text format. Cannot deserialize the command.", "Desirizalization Error");
        return;
      }

      if (command == null)
      {
        MessageBox.Show("Invalid command text format. Cannot deserialize the command.", "Desirizalization Error");
        return;
      }

      if (this.selectedCommand == null)
      {
        MessageBox.Show("Hm... Command to be updated not found.", "Strange error.");
        return;
      }

      this.diff.Commands.Insert(this.diff.Commands.IndexOf(this.selectedCommand), command);
      this.diff.Commands.Remove(this.selectedCommand);
      this.BindCommandText(command);
    }

    private void loadDiffToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.FolderBrowserDialog.SelectedPath))
      {
        if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["defaultDiffLocation"]))
        {
          this.FolderBrowserDialog.SelectedPath = ConfigurationManager.AppSettings["defaultDiffLocation"];
        }
      }

      DialogResult result = this.FolderBrowserDialog.ShowDialog();
      if (result == DialogResult.OK)
      {
        try
        {
          this.diff = new DiffLoader().Load(this.FolderBrowserDialog.SelectedPath);
          this.diffFilePath = this.FolderBrowserDialog.SelectedPath;
          this.InitializeForm();
          this.editReadMeToolStripMenuItem.Enabled = true;
          this.compareToToolStripMenuItem.Enabled = true;
          this.Text += " diff: " + this.diffFilePath;
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format("Cannot load Diff: {0}", ex.ToString()));
        }
      }
    }

    protected void InitializeForm()
    {
      IList<ICommand> commands = new List<ICommand>(this.diff.Commands);
      this.LoadFilters(commands);
      if (commands.Count > 0)
      {
        this.RenderPackageOverview();
      }

      commands = this.GetFilteredCommands(commands);
      this.LoadCommands(commands, !showInList);
      this.editReadMeToolStripMenuItem.Enabled = false;
    }

    protected void RenderPackageOverview()
    {
      if (this.diff == null)
      {
        return;
      }

      if (!string.IsNullOrEmpty(this.openFileDialog1.FileName))
      {
        this.PackageName.Text = Path.GetFileName(this.openFileDialog1.FileName);
      }
      else
      {
        this.PackageName.Text = "Diff file";
      }

      if (!string.IsNullOrEmpty(this.diff.Title))
      {
        this.PackageDescription.Text = this.diff.Title;
      }

      this.TotalCommandsCount.Text = this.diff.Commands.Count.ToString();
      this.RenderCommandsOverwiew();
      this.RenderPackageProblems();

      this.tabControl1.SelectTab(this.PackageOverview);
    }

    protected void RenderPackageProblems()
    {
      if (this.diff == null || this.analyzers == null)
      {
        return;
      }

      List<ProblemDescriptor> problems = new List<ProblemDescriptor>();
      foreach (var analyzer in this.analyzers)
      {
        problems.AddRange(analyzer.Scan(this.diff.Commands));
      }

      if (problems.Count > 0)
      {
        foreach (var problem in problems)
        {
          var renderer = new PackageProblemRenderer(problem);
          renderer.Dock = DockStyle.Top;
          this.problemsPanel.Controls.Add(renderer);
        }
      }
    }

    protected void RenderCommandsOverwiew()
    {
      if (this.diff == null)
      {
        return;
      }

      var types = this.GroupByType(this.diff.Commands);
      var commandTypes = types.Select((entry) => new CommandType { CommandTypeName = entry.Key, CommandCount = entry.Value }).ToList();
      this.CommandsOverview.DataSource = commandTypes;
      this.CommandsOverview.AutoSize = true;
      this.CommandsOverview.Columns[0].HeaderText = "Command type";
      this.CommandsOverview.Columns[1].HeaderText = "Commands count";
    }

    protected class CommandType
    {
      public string CommandTypeName { get; set; }
      public int CommandCount { get; set; }
    }

    private void loadPackageToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(this.FolderBrowserDialog.SelectedPath))
      {
        if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["defaultDiffLocation"]))
        {
          this.openFileDialog1.InitialDirectory = ConfigurationManager.AppSettings["defaultDiffLocation"];
        }
      }

      DialogResult result = this.openFileDialog1.ShowDialog();
      if (result == DialogResult.OK)
      {
        try
        {
          string packagePath = this.openFileDialog1.FileName;
          this.diff = new DiffLoader().Load(packagePath);
          this.InitializeForm();
          this.editReadMeToolStripMenuItem.Enabled = false;
          this.compareToToolStripMenuItem.Enabled = true;
          this.Text += " package: " + packagePath;
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format("Cannot load Diff: {0}", ex.ToString()));
        }
      }
    }

    private void editReadMeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.diff == null)
      {
        MessageBox.Show("Diff is not loaded.", "Invalid Operation.");
        return;
      }

      var editorDialog = new ReadMeEditor(this.diff);

      if (editorDialog.ShowDialog() == DialogResult.OK)
      {
        this.diff.Serialize(this.diffFilePath);
      }
    }

    private void compareToToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var sourcePackagePath = this.openFileDialog1.FileName;
      var sourceDiffPath = this.FolderBrowserDialog.SelectedPath;

      var sourcePath = sourcePackagePath ?? sourceDiffPath;
      Assert.IsNotNull(sourcePath, "source path");

      string initialDirectory = sourcePath;
      if (File.Exists(sourcePath))
      {
        var fileInfo = new FileInfo(sourcePath);
        initialDirectory = fileInfo.DirectoryName;
      }
      else
      {
        initialDirectory = sourcePath;
      }

      this.openFileDialog2.InitialDirectory = initialDirectory;
      DialogResult result = this.openFileDialog2.ShowDialog();
      if (result == DialogResult.OK)
      {
        string targetPackagePath = this.openFileDialog2.FileName;
        Assert.IsNotNull(targetPackagePath, "target package");

        var editorDialog = new PackageComparer(sourcePath, targetPackagePath);
        editorDialog.ShowDialog();
      }
    }

    private void testToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var editorDialog = new PackageComparer(@"D:\Temp\Update package for Sitecore CMS 7.2 rev. 150402\Sitecore 7.2 rev. 150402.update", @"D:\Temp\Update package for Sitecore CMS 7.2 rev. 150402\Sitecore 7.2 rev. 141226.update");
      editorDialog.ShowDialog();
    }
  }
}
