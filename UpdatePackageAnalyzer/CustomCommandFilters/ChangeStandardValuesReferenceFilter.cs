namespace UpdatePackageAnalyzer.CustomCommandFilters
{
  using System.Linq;

  using Sitecore;
  using Sitecore.Data;
  using Sitecore.Update.Commands;
  using Sitecore.Update.Interfaces;

  public class ChangeStandardValuesReferenceFilter : ICommandFilter
  {
    public ICommand FilterCommand(ICommand command)
    {
      var changeItem = command as ChangeItemCommand;
      if (changeItem == null)
      {
        return command;
      }

      bool containsOnlySVReferenceChanges = changeItem.Commands.All(
        innerCommand =>
          { 
            var fieldCommand = innerCommand as BaseFieldCommand;
            if (fieldCommand == null)
            {
              return false;
            }

            return new ID(fieldCommand.FieldID) == FieldIDs.StandardValues;
          });
      if (containsOnlySVReferenceChanges)
      {
        return null;
      }

      return command;
    }

    public ICommandFilter Clone()
    {
      return new ChangeStandardValuesReferenceFilter();
    }
  }
}
