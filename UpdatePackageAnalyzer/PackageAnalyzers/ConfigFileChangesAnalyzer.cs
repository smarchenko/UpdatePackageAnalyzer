using System.Collections.Generic;

namespace UpdatePackageAnalyzer.PackageAnalyzers
{
  using Sitecore.Update.Commands;
  using Sitecore.Update.Interfaces;

  public class ConfigFileChangesAnalyzer : PackageAnalyzer
  {
    public override IList<ProblemDescriptor> Scan(IList<ICommand> commands)
    {
      IList<ProblemDescriptor> result = new List<ProblemDescriptor>();
      var descriptor = new ProblemDescriptor()
                         {
                           LongDescription = "Commands for changing configuration files are not usually allowed unless these files are not likely to be modified. In any case documentation should describe the way how to handle conflitcs related to these files, please check.",
                           ShortDescription = "Configuration File changes",
                           Commands = new List<ICommand>()
                         };
      foreach (var command in commands)
      {
        var changeFileCommand = command as ChangeFileCommand;
        if (changeFileCommand == null)
        {
          continue;
        }

        string path = changeFileCommand.FilePath.ToLowerInvariant().Trim();

        if (path.EndsWith(".config") || path.EndsWith(".config.example"))
        {
          descriptor.Commands.Add(command);
        }
      }


      if (descriptor.Commands.Count > 0)
      {
        result.Add(descriptor);
      }

      return result;
    }
  }
}
