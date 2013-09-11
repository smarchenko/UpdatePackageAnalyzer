namespace UpdatePackageAnalyzer
{
  partial class FilteredCommandsForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.FilteredCommandList = new System.Windows.Forms.RichTextBox();
      this.SuspendLayout();
      // 
      // FilteredCommandList
      // 
      this.FilteredCommandList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.FilteredCommandList.Location = new System.Drawing.Point(0, 0);
      this.FilteredCommandList.Name = "FilteredCommandList";
      this.FilteredCommandList.Size = new System.Drawing.Size(808, 445);
      this.FilteredCommandList.TabIndex = 0;
      this.FilteredCommandList.Text = "";
      this.FilteredCommandList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FilteredCommandList_KeyPress);
      // 
      // FilteredCommandsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(808, 445);
      this.Controls.Add(this.FilteredCommandList);
      this.Name = "FilteredCommandsForm";
      this.Text = "FilteredCommands";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.RichTextBox FilteredCommandList;
  }
}