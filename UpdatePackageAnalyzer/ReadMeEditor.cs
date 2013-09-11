using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UpdatePackageAnalyzer
{
  using Sitecore.Update;

  public partial class ReadMeEditor : Form
  {
    private DiffInfo diff;

    public ReadMeEditor(DiffInfo info)
    {
      InitializeComponent();
      this.diff = info;
      this.readmeEditArea.Text = this.diff.Readme;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.diff.Readme = this.readmeEditArea.Text;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}
