using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpdatePackageAnalyzer.CustomCommandFilters
{
  using Sitecore.Update.Commands;
  using Sitecore.Update.Interfaces;

  public class TranslationChangeFilter : ICommandFilter
  {
    public ICommand FilterCommand(ICommand command)
    {
      if (!(command is ChangeItemCommand))
      {
        return command;
      }

      var changeItemCommand = command as ChangeItemCommand;

      foreach (var c in changeItemCommand.Commands)
      {
        if (c is BaseFieldCommand)
        {
          return command;
        }

        if (c is ChangeVersionCommand)
        {
          var changeVersion = c as ChangeVersionCommand;
          if (string.Compare(changeVersion.Language, "en", StringComparison.InvariantCultureIgnoreCase) == 0)
          {
            return command;
          }

          continue;
        }

        if (c is DeleteVersionCommand)
        {
          var deleteVersion = c as DeleteVersionCommand;
          if (string.Compare(deleteVersion.Language, "en", StringComparison.InvariantCultureIgnoreCase) == 0)
          {
            return command;
          }

          continue;
        }

        if (c is AddVersionCommand)
        {
          var changeVersionCommand = c as AddVersionCommand;
          if (string.Compare(changeVersionCommand.Language, "en", StringComparison.InvariantCultureIgnoreCase) == 0)
          {
            return command;
          }

          continue;
        }
        
        return command;
      }

      return null;
    }

    public ICommandFilter Clone()
    {
      return new TranslationChangeFilter();
    }
  }
}
