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

  public partial class MainForm : Form
  {
    private DiffInfo diff = null;
    private bool showInList = true;
    private ICommand selectedCommand = null;
    private string diffFilePath = null;

    public MainForm()
    {
      InitializeComponent();
    }

    protected void LoadFilters(IList<ICommand> commands)
    {
      this.LoadCommandTypeFilters(commands);
      this.LoadDatabaseFilters(commands);
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

      Dictionary<string, int> types = new Dictionary<string, int>();
      foreach (var command in commands)
      {
        if (!types.ContainsKey(command.CommandPrefix))
        {
          types.Add(command.CommandPrefix, 0);
        }

        types[command.CommandPrefix]++;
      }

      foreach (string key in types.Keys)
      {
        this.CommandTypesCheckedListBox.Items.Add(key, true);
      }
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
              result.Add(command);
            }
          }
        }
      }

      return result;
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
      this.CommandsTreeView.Nodes.Clear();
      foreach (ICommand command in commands)
      {
        var node = this.GetNode(command);
        node.Text = string.Format("{0}: {1}", command.CommandPrefix, GetCommandPath(command));
        node.ToolTipText = command.Description;
        this.CommandsTreeView.Nodes.Add(node);
      }
    }

    protected string GetCommandPath(ICommand command)
    {
      if(command is BaseItemCommand)
      {
        return (command as BaseItemCommand).ItemPath + " " + (command as BaseItemCommand).ItemID;
      }

      return command.EntityPath;
    }

    protected TreeNode GetNode(ICommand command)
    {
      var node = new TreeNode();
      node.Tag = this.GetCommandUniqueId(command);
      return node;
    }

    private string GetCommandUniqueId(ICommand command)
    {
      return string.Format("{2}_{1}_{0}", command.EntityID, command.CommandPrefix, command is BaseItemCommand ? (command as BaseItemCommand).DatabaseName : "filsystem");
    }

    private XmlWriter GetWriter(Stream stream)
    {
      XmlWriterSettings settings = new XmlWriterSettings();
      settings.Indent = true;
      settings.NewLineHandling = NewLineHandling.Entitize;
      settings.ConformanceLevel = ConformanceLevel.Fragment;
      return XmlWriter.Create(stream, settings);
    }

   private XmlReader GetReader(Stream stream)
   {
     var settings = new XmlReaderSettings
     {
       IgnoreWhitespace = true,
       ConformanceLevel = ConformanceLevel.Fragment
     };

     return XmlReader.Create(stream, settings);
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
        if (string.Compare(this.GetCommandUniqueId(c), e.Node.Tag.ToString(), true) == 0)
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
      MemoryStream stream = new MemoryStream();
      XmlWriter writer = GetWriter(stream);
      SerializationContext context = SerializationCommandFactory.GetSerializationContext();
      SerializationCommandFactory.SerializeCommand(command, writer, context);
      writer.Close();
      stream.Seek(0, SeekOrigin.Begin);
      string value;
      using (var reader = new StreamReader(stream))
      {
        value = reader.ReadToEnd();
      }

      return value;
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
          var reader = GetReader(stream);
          reader.MoveToContent();
          SerializationContext context = SerializationCommandFactory.GetSerializationContext();
          command = SerializationCommandFactory.DeserializeCommand(reader, context);
        }
      }
      catch(Exception ex)
      {
        MessageBox.Show("Invalid command text format. Cannot deserialize the command.", "Desirizalization Error");
        return;
      }

      if(command == null)
      {
        MessageBox.Show("Invalid command text format. Cannot deserialize the command.", "Desirizalization Error");
        return;
      }

      if(this.selectedCommand == null)
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
          this.diff = DiffInfo.LoadDiff(this.FolderBrowserDialog.SelectedPath);
          this.diffFilePath = this.FolderBrowserDialog.SelectedPath;
          this.InitializeForm();
          this.editReadMeToolStripMenuItem.Enabled = true;
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
      commands = this.GetFilteredCommands(commands);
      this.LoadCommands(commands, !showInList);
      this.editReadMeToolStripMenuItem.Enabled = false;
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
          IProcessingContext context = new SimpleProcessingContext();
          CommandInstallerContext.Setup(context, System.IO.Path.GetFileNameWithoutExtension(packagePath), UpgradeAction.Preview, Sitecore.Update.Utils.InstallMode.Install, null, new List<ContingencyEntry>());
          ISource<PackageEntry> source = new PackageReader(packagePath);
          ISink<PackageEntry> installer = DoCreateInstallerSink(context);
          PackageDumper sorter = new PackageDumper(source);
          sorter.Initialize(context);
          sorter.Populate(installer);
          installer.Flush();
          List<ICommand> commands = new List<ICommand>(sorter.Commands);
          DataEngine engine = new DataEngine();
          engine.FilterCommands = false;
          engine.OptimizeCommands = false;
          engine.ProcessCommands(ref commands);

          DiffInfo info = new DiffInfo(commands, string.Empty, string.Empty, "Generated by ConvertFromPackage command.");
          MetadataView view = UpdateHelper.LoadMetadata(packagePath);
          if (view != null)
          {
            info.Readme = view.Readme;
            info.InstallMode = view.Comment;
            info.Title = view.PackageName;
          }

          this.diff = info;
          this.InitializeForm();
          this.editReadMeToolStripMenuItem.Enabled = false;
        }
        catch (Exception ex)
        {
          MessageBox.Show(string.Format("Cannot load Diff: {0}", ex.ToString()));
        }
      }
    }

    protected virtual ISink<PackageEntry> DoCreateInstallerSink(IProcessingContext context)
    {
      MySinkDispatcher dispatcher = new MySinkDispatcher(context);
      dispatcher.AddSink(Sitecore.Install.Constants.MetadataPrefix, new MetadataSink(context));
      dispatcher.AddSink(Sitecore.Install.Constants.BlobDataPrefix, new BlobInstaller(context));
      dispatcher.AddSink(Sitecore.Install.Constants.ItemsPrefix, new LegacyItemUnpacker(new ItemInstaller(context)));
      dispatcher.AddSink(Sitecore.Install.Constants.FilesPrefix, new FileInstaller(context));

      if (dispatcher != null)
      {
        dispatcher.Initialize(context);
        foreach (ICommand command in Factory.Instance.GetSupportedCommands().Values)
        {
          ISink<PackageEntry> sink = SinkItemFactory.GetInstallerSink(command.CommandPrefix, UpgradeAction.Preview, context);
          if (sink != null)
          {
            dispatcher.AddSink(command.CommandPrefix, sink);
          }
        }
      }

      return dispatcher;
    }

    private void editReadMeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if(this.diff == null)
      {
        MessageBox.Show("Diff is not loaded.", "Invalid Operation.");
        return;
      }

      var editorDialog = new ReadMeEditor(this.diff);

      if(editorDialog.ShowDialog() == DialogResult.OK)
      {
        this.diff.Serialize(this.diffFilePath);
      }
    }
  }
}
