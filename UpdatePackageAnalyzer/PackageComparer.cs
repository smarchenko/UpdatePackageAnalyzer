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
  using System.Diagnostics;
  using System.Reflection;

  using Sitecore.Diagnostics;
  using Sitecore.Update;
  using Sitecore.Update.Commands;
  using Sitecore.Update.Interfaces;
  using System.IO;

  using UpdatePackageAnalyzer.CustomCommandFilters;

  public partial class PackageComparer : Form
  {
    private IList<CommandViewItem> data = null;
    private Dictionary<string, ICommandFilter> customFilters;

    public PackageComparer(string sourcePath, string targetPackagePath)
    {
      InitializeComponent();

      Assert.IsNotNullOrEmpty(sourcePath, "source path");
      Assert.IsNotNullOrEmpty(targetPackagePath, "target path");
      this.SourcePath = sourcePath;
      this.TargetPackagePath = targetPackagePath;

      this.InitializeForm();
    }

    public string SourcePath { get; set; }
    public string TargetPackagePath { get; set; }

    protected void InitializeForm()
    {
      this.InitializeHeader();
      this.InitializeCommandsView();
      this.data = this.InitializeData();
      InitializeFilters(this.data);
      this.BindData(this.data);
    }

    protected virtual void InitializeHeader()
    {
      this.LeftPackagePath.Text = this.SourcePath;
      this.RightPackagePath.Text = this.TargetPackagePath;
    }

    protected virtual IList<CommandViewItem> InitializeData()
    {
      var leftDiff = this.LoadData(this.SourcePath);
      var rightDiff = this.LoadData(this.TargetPackagePath);
      this.statusStrip1.Items[1].Text = "Total commands in source: " + leftDiff.Commands.Count;
      this.statusStrip1.Items[2].Text = "Total commands in target: " + rightDiff.Commands.Count;
      return this.GetDifference(leftDiff, rightDiff);
    }

    protected virtual void InitializeFilters(IList<CommandViewItem> commands)
    {
      this.InitializeGroupFilters(commands);
      this.InitializeCommandTypeFilters(commands);
      this.InitializeCustomFilters(commands);
    }

    protected void InitializeCustomFilters(IList<CommandViewItem> commands)
    {
      this.customFilters = new Dictionary<string, ICommandFilter>();
      this.customFilters.Add("Filter Translation changes", new TranslationChangeFilter());
      this.customFilters.Add("Filter Dictionary commands", new DictionaryCommandFilter());

      this.CustomFilterList.Items.Clear();
      foreach (string text in this.customFilters.Keys)
      {
        this.CustomFilterList.Items.Add(text);
      }
    }

    protected virtual void InitializeGroupFilters(IList<CommandViewItem> commands)
    {
      this.clbGroupFilters.Items.Clear();
      if ((commands == null) || (commands.Count == 0))
      {
        return;
      }

      Dictionary<Groups, int> types = this.GetCommandGroups(commands);

      foreach (Groups key in types.Keys)
      {
        this.clbGroupFilters.Items.Add(key.ToString(), true);
      }
    }

    protected virtual void InitializeCommandTypeFilters(IList<CommandViewItem> commands)
    {
      this.clbCommandTypeFilter.Items.Clear();
      if ((commands == null) || (commands.Count == 0))
      {
        return;
      }

      Dictionary<string, int> types = this.GetCommandTypeGroups(commands);

      foreach (string key in types.Keys)
      {
        this.clbCommandTypeFilter.Items.Add(key, true);
      }
    }

    protected virtual Dictionary<string, int> GetCommandTypeGroups(IList<CommandViewItem> commands)
    {
      var result = new Dictionary<string, int>();
      foreach (var viewItem in commands)
      {
        var command = viewItem.LeftCommand ?? viewItem.RightCommand;

        if (!result.ContainsKey(command.CommandPrefix))
        {
          result.Add(command.CommandPrefix, 0);
        }

        result[command.CommandPrefix]++;
      }

      return result;
    }

    protected virtual Dictionary<Groups, int> GetCommandGroups(IList<CommandViewItem> commands)
    {
      var result = new Dictionary<Groups, int>();
      foreach (var viewItem in commands)
      {
        if (!result.ContainsKey(viewItem.Group))
        {
          result.Add(viewItem.Group, 0);
        }

        result[viewItem.Group]++;
      }

      return result;
    }

    protected virtual IList<CommandViewItem> GetDifference(DiffInfo source, DiffInfo target)
    {
      Dictionary<string, ICommand> sourceCommands = this.ExtractCommands(source);
      Dictionary<string, ICommand> targetCommands = this.ExtractCommands(target);

      List<CommandViewItem> result = new List<CommandViewItem>();
      foreach (string key in sourceCommands.Keys.ToArray())
      {
        if (!targetCommands.ContainsKey(key))
        {
          result.Add(this.GetAddedCommand(sourceCommands[key]));
          sourceCommands.Remove(key);
        }
        else
        {
          result.Add(this.GetChangedCommand(sourceCommands[key], targetCommands[key]));
          sourceCommands.Remove(key);
          targetCommands.Remove(key);
        }
      }

      Assert.IsTrue(sourceCommands.Keys.Count == 0, "problem in algorithm that compares packages. source");

      foreach (var key in targetCommands.Keys.ToArray())
      {
        result.Add(this.GetDeletedCommand(targetCommands[key]));
        targetCommands.Remove(key);
      }

      Assert.IsTrue(targetCommands.Keys.Count == 0, "problem in algorithm that compares packages. target");

      return result;
    }

    protected virtual CommandViewItem GetAddedCommand(ICommand command)
    {
      return new CommandViewItem
      {
        CommandKey = this.GetCommandKey(command),
        CommandName = command.CommandPrefix,
        Group = Groups.Added,
        LeftCommand = command,
        Database = this.GetCommandDatabase(command)
      };
    }

    protected virtual CommandViewItem GetChangedCommand(ICommand source, ICommand target)
    {
      var result = new CommandViewItem
      {
        CommandKey = this.GetCommandKey(source),
        CommandName = source.CommandPrefix,
        LeftCommand = source,
        RightCommand = target,
        Database = this.GetCommandDatabase(source)
      };

      string sourceStr = CommandSerializer.Serialize(source);
      string targetStr = CommandSerializer.Serialize(target);

      result.Group = String.CompareOrdinal(sourceStr, targetStr) == 0 ? Groups.Unmodified : Groups.Changed;

      return result;
    }

    protected virtual CommandViewItem GetDeletedCommand(ICommand command)
    {
      return new CommandViewItem
      {
        CommandKey = this.GetCommandKey(command),
        CommandName = command.CommandPrefix,
        Group = Groups.Deleted,
        RightCommand = command,
        Database = this.GetCommandDatabase(command)
      };
    }

    protected virtual Dictionary<string, ICommand> ExtractCommands(DiffInfo diff)
    {
      var result = new Dictionary<string, ICommand>();
      foreach (var command in diff.Commands)
      {
        result.Add(this.GetCommandKey(command), command);
      }

      return result;
    }

    protected virtual DiffInfo LoadData(string path)
    {
      return (new DiffLoader()).Load(path);
    }

    protected virtual void InitializeCommandsView()
    {
      this.commandsView.Columns[1].Width = -1;
    }

    protected virtual void BindData(IList<CommandViewItem> commands)
    {
      this.statusStrip1.Items[0].Text = "Shown rows: " + commands.Count;
      this.commandsView.Items.Clear();
      var groupStatistic = new Dictionary<Groups, int>();
      foreach (var groupName in Enum.GetNames(typeof(Groups)))
      {
        var group = (Groups)Enum.Parse(typeof(Groups), groupName);
        groupStatistic.Add(group, 0);
      }

      foreach (var command in commands)
      {
        var listItem = new ListViewItem();
        groupStatistic[command.Group]++;
        string groupName = "undefined";
        switch (command.Group)
        {
          case Groups.Added:
            groupName = "AddedGroup";
            break;
          case Groups.Changed:
            groupName = "ChangedGroup";
            break;
          case Groups.Deleted:
            groupName = "RemovedGroup";
            break;
          case Groups.Unmodified:
            groupName = "IdenticalGroup";
            break;
        }

        listItem.Group = this.commandsView.Groups[groupName];
        listItem.SubItems[0] = new ListViewItem.ListViewSubItem(listItem, command.CommandName);
        listItem.SubItems.Add(command.CommandKey);
        listItem.SubItems.Add(command.Database);

        this.commandsView.Items.Add(listItem);
      }

      var builder = new StringBuilder();
      int groupCounter = 0;
      foreach (Groups key in groupStatistic.Keys)
      {
        if (groupCounter > 0)
        {
          builder.Append(",");
        }

        builder.Append(key.ToString() + ": " + groupStatistic[key]);
        groupCounter++;
      }

      this.statusStrip1.Items[3].Text = builder.ToString();
    }

    protected virtual string GetCommandKey(ICommand command)
    {
      return command.EntityPath.ToLowerInvariant();
    }

    protected virtual string GetCommandDatabase(ICommand command)
    {
      if (command is BaseItemCommand)
      {
        return (command as BaseItemCommand).DatabaseName.ToLowerInvariant();
      }

      return "filesystem";
    }

    public enum Groups
    {
      Added,
      Deleted,
      Changed,
      Unmodified
    }

    public class CommandViewItem
    {
      public Groups Group { get; set; }

      public string CommandName { get; set; }

      public string CommandKey { get; set; }

      public string Database { get; set; }

      public ICommand LeftCommand { get; set; }

      public ICommand RightCommand { get; set; }
    }

    private void btnFilter_Click(object sender, EventArgs e)
    {
      if (this.data == null)
      {
        return;
      }

      this.BindData(this.FilterCommands(this.data));
    }

    protected virtual IList<CommandViewItem> FilterCommands(IList<CommandViewItem> commands)
    {
      var result = new List<CommandViewItem>();

      var groupTypes = new List<string>();
      for (int i = 0; i < this.clbGroupFilters.CheckedItems.Count; i++)
      {
        groupTypes.Add(this.clbGroupFilters.CheckedItems[i].ToString());
      }

      var commandTypes = new List<string>();
      for (int i = 0; i < this.clbCommandTypeFilter.CheckedItems.Count; i++)
      {
        commandTypes.Add(this.clbCommandTypeFilter.CheckedItems[i].ToString());
      }

      string searchText = this.SearchText.Text;

      foreach (var command in commands)
      {
        if (!groupTypes.Contains(command.Group.ToString()))
        {
          continue;
        }

        if (!commandTypes.Contains((command.LeftCommand ?? command.RightCommand).CommandPrefix))
        {
          continue;
        }

        var leftCommand = command.LeftCommand;
        if (leftCommand != null && FilterByCustomFilter(leftCommand) == null)
        {
          continue;
        }

        var rightCommand = command.RightCommand;
        if (rightCommand != null && FilterByCustomFilter(rightCommand) == null)
        {
          continue;
        }

        if (!string.IsNullOrEmpty(searchText))
        {
          if (command.LeftCommand != null)
          {
            if (CommandSerializer.Serialize(command.LeftCommand).ToLower().Contains(searchText))
            {
              result.Add(command);
              continue;
            }
          }

          if (command.RightCommand != null)
          {
            if (CommandSerializer.Serialize(command.RightCommand).ToLower().Contains(searchText))
            {
              result.Add(command);
              continue;
            }
          }

          continue;
        }

        result.Add(command);
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

    private void commandsView_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void commandsView_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      CommandViewItem command = null;
      string path = this.commandsView.SelectedItems[0].SubItems[1].Text;

      foreach (var cmd in this.data)
      {
        if (string.CompareOrdinal(cmd.CommandKey, path) == 0)
        {
          command = cmd;
          break;
        }
      }

      if (command == null)
      {
        MessageBox.Show("Command not found... Something is going wrong.");
      }
      else
      {
        string assemblyPath = Assembly.GetExecutingAssembly().Location;
        string dumpPath = new FileInfo(assemblyPath).DirectoryName + "\\merge";
        if (!Directory.Exists(dumpPath))
        {
          Directory.CreateDirectory(dumpPath);
        }

        string sourcePath = dumpPath + "\\source_" + command.CommandKey.GetHashCode() + ".txt";
        string targetPath = dumpPath + "\\target_" + command.CommandKey.GetHashCode() + ".txt";

        CommandSerializer.Serialize(sourcePath, command.LeftCommand);
        CommandSerializer.Serialize(targetPath, command.RightCommand);
        
        Process.Start("winmergeU.exe", "\"" + sourcePath + "\"" + " " + "\"" + targetPath + "\"");
      }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
      if (this.data == null)
      {
        return;
      }

      this.BindData(this.FilterCommands(this.data));
    }

  }
}
