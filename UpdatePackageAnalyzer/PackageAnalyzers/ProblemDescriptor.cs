using System.Collections.Generic;

namespace UpdatePackageAnalyzer.PackageAnalyzers
{
  using Sitecore.Update.Interfaces;

  public class ProblemDescriptor
  {
    public string ShortDescription { get; set; }

    public string LongDescription { get; set; }

    public IList<ICommand> Commands { get; set; }
  }
}
