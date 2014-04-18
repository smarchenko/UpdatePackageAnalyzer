using System.Collections.Generic;

namespace UpdatePackageAnalyzer.PackageAnalyzers
{
  using Sitecore.Update.Commands;
  using Sitecore.Update.Interfaces;

  public class LicenseFileChangesAnalyzer : PackageAnalyzer
  {
    public override IList<ProblemDescriptor> Scan(IList<ICommand> commands)
    {
      IList<ProblemDescriptor> result = new List<ProblemDescriptor>();
      var descriptor = new ProblemDescriptor()
      {
        LongDescription = "Some changes to license files have been detected. Please, ensure that changes are approved by management and Alexander But.",
        ShortDescription = "License File changes",
        Commands = new List<ICommand>()
      };

      foreach (var command in commands)
      {
        var baseFileCommand = command as BaseFileCommand;
        if (baseFileCommand == null)
        {
          continue;
        }

        string path = baseFileCommand.FilePath.ToLowerInvariant().Trim();

        if (path.Contains("sitecore\\copyrights\\"))
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
