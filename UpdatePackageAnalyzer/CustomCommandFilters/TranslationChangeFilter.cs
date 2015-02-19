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
        if (!(c is AddVersionCommand))
        {
          return command;
        }

        var changeVersionCommand = c as AddVersionCommand;
        if (string.Compare(changeVersionCommand.Language, "en", true) == 0)
        {
          return command;
        }
      }

      return null;
    }

    public ICommandFilter Clone()
    {
      return new TranslationChangeFilter();
    }
  }
}
