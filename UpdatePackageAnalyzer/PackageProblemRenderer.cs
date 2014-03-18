using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UpdatePackageAnalyzer
{
  using Sitecore.Update.Commands;
  using Sitecore.Update.Interfaces;

  using UpdatePackageAnalyzer.PackageAnalyzers;

  public partial class PackageProblemRenderer : UserControl
  {
    private ProblemDescriptor descriptor;

    public PackageProblemRenderer(ProblemDescriptor descriptor)
    {
      this.descriptor = descriptor;
      InitializeComponent();
      this.Render(this.descriptor);
    }

    protected void Render(ProblemDescriptor problem)
    {
      this.ProblemDescription.Text = problem.ShortDescription;
      this.toolTip1.SetToolTip(this.ProblemDescription, problem.LongDescription);

      TreeViewHelper.InitializeTreeView(this.treeView1, problem.Commands);
    }

    private void treeView1_DoubleClick(object sender, EventArgs e)
    {
      var filteredCommandsForm = new FilteredCommandsForm();
      StringBuilder list = new StringBuilder();
      for (int i = 0; i < this.treeView1.Nodes.Count; i++)
      {
        list.AppendLine(this.treeView1.Nodes[i].Text);
      }

      filteredCommandsForm.SetStringValue(list.ToString());
      filteredCommandsForm.ShowDialog();
    }
  }
}
