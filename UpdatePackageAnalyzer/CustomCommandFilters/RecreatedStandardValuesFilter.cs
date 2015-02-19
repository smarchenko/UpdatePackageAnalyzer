using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpdatePackageAnalyzer.CustomCommandFilters
{
  using Sitecore.Update.Commands;
  using Sitecore.Update.Interfaces;

  public class RecreatedStandardValuesFilter : ICommandFilter
  {
    private List<ICommand> filteredCommands;

    public List<ICommand> FilteredCommands
    {
      get
      {
        return this.filteredCommands;
      }
      set
      {
        this.filteredCommands = value;
      }
    }

    public RecreatedStandardValuesFilter(IList<ICommand> commands)
    {
      filteredCommands = new List<ICommand>();
      foreach (ICommand command in commands)
      {
        var addCommand = command as AddItemCommand;
        if (addCommand == null)
        {
          continue;
        }

        if (string.Compare(addCommand.AddedItem.Name, "__Standard Values", StringComparison.CurrentCultureIgnoreCase) != 0)
        {
          continue;
        }

        string svPath = addCommand.AddedItem.ItemPath;

        for (int i = 0; i < commands.Count; i++)
        {
          var deleteCommand = commands[i] as DeleteItemCommand;
          if (deleteCommand == null)
          {
            continue;
          }

          if (string.Compare(deleteCommand.ItemPath, svPath, StringComparison.CurrentCultureIgnoreCase) != 0)
          {
            continue;
          }

          filteredCommands.Add(commands[i]);
          filteredCommands.Add(command);
          break;
        }
      }
    }

    public ICommand FilterCommand(ICommand command)
    {
      for (int i = 0; i < this.filteredCommands.Count; i++)
      {
        if (command == this.filteredCommands[i])
        {
          return null;
        }
      }

      return command;
    }

    public ICommandFilter Clone()
    {
      var clone = new RecreatedStandardValuesFilter(new List<ICommand>())
                    {
                      FilteredCommands = this.filteredCommands
                    };
      return clone;
    }
  }
}
