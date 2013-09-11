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
  public partial class FilteredCommandsForm : Form
  {
    public FilteredCommandsForm()
    {
      InitializeComponent();
    }

    private void FilteredCommandList_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ((int)(e.KeyChar) == 27)
      {
        this.Close();
      }
    }

    public void SetStringValue(string value)
    {
      this.FilteredCommandList.Text = value;
    }
  }
}
