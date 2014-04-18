using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UpdatePackageAnalyzer.PackageAnalyzers
{
  using Sitecore.Update.Commands;
  using Sitecore.Update.Interfaces;

  public class RadControlsChangesAnalyzer : PackageAnalyzer
  {
    public override IList<ProblemDescriptor> Scan(IList<ICommand> commands)
    {
      IList<ProblemDescriptor> result = new List<ProblemDescriptor>();
      var descriptor = new ProblemDescriptor()
      {
        LongDescription = "From time to time RedControls are not installed during the build. In most cases it is related to using DEV channel.",
        ShortDescription = "Rad Controls have been removed",
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

        if (path.Contains("sitecore\\shell\\radcontrols"))
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
