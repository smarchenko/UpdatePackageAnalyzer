using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpdatePackageAnalyzer
{
  using System.Windows.Forms;

  using Sitecore.Update.Commands;
  using Sitecore.Update.Interfaces;

  public static class TreeViewHelper
  {
    public static void InitializeTreeView(TreeView tree, IList<ICommand> commands)
    {
      tree.Nodes.Clear();
      foreach (ICommand command in commands)
      {
        var node = GetNode(command);
        node.Text = string.Format("{0}: {1}", command.CommandPrefix, GetCommandPath(command));
        node.ToolTipText = command.Description;
        tree.Nodes.Add(node);
      }
    }

    public static TreeNode GetNode(ICommand command)
    {
      var node = new TreeNode();
      node.Tag = GetCommandUniqueId(command);
      return node;
    }

    public static string GetCommandUniqueId(ICommand command)
    {
      return string.Format("{2}_{1}_{0}", command.EntityID, command.CommandPrefix, command is BaseItemCommand ? (command as BaseItemCommand).DatabaseName : "filsystem");
    }

    public static string GetCommandPath(ICommand command)
    {
      if (command is BaseItemCommand)
      {
        return (command as BaseItemCommand).ItemPath + " " + (command as BaseItemCommand).ItemID;
      }

      return command.EntityPath;
    }
  }
}
