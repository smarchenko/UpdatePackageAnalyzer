using System.Collections.Generic;

namespace UpdatePackageAnalyzer.PackageAnalyzers
{
  using Sitecore.Update.Interfaces;

  public abstract class PackageAnalyzer
  {
    public abstract IList<ProblemDescriptor> Scan(IList<ICommand> commands);
  }
}
