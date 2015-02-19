using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpdatePackageAnalyzer.CustomCommandFilters
{
  using Sitecore.Update.Commands;
  using Sitecore.Update.Interfaces;

  public class DictionaryCommandFilter : ICommandFilter
  {
    public ICommand FilterCommand(ICommand command)
    {
      if (!(command is BaseItemCommand))
      {
        return command;
      }

      var itemCommand = command as BaseItemCommand;
      if (itemCommand.ItemPath.StartsWith(
        "/sitecore/system/Dictionary/", StringComparison.InvariantCultureIgnoreCase))
      {
        return null;
      }

      return command;
    }

    public ICommandFilter Clone()
    {
      return new DictionaryCommandFilter();
    }
  }
}
