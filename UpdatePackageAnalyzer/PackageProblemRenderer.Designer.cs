namespace UpdatePackageAnalyzer
{
  partial class PackageProblemRenderer
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.label1 = new System.Windows.Forms.Label();
      this.ProblemDescription = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.treeView1 = new System.Windows.Forms.TreeView();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(104, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Problem Description:";
      // 
      // ProblemDescription
      // 
      this.ProblemDescription.AutoSize = true;
      this.ProblemDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.ProblemDescription.ForeColor = System.Drawing.Color.Maroon;
      this.ProblemDescription.Location = new System.Drawing.Point(113, 10);
      this.ProblemDescription.Name = "ProblemDescription";
      this.ProblemDescription.Size = new System.Drawing.Size(41, 13);
      this.ProblemDescription.TabIndex = 1;
      this.ProblemDescription.Text = "label2";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 23);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(62, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Commands:";
      // 
      // treeView1
      // 
      this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.treeView1.Location = new System.Drawing.Point(4, 40);
      this.treeView1.Name = "treeView1";
      this.treeView1.Size = new System.Drawing.Size(575, 95);
      this.treeView1.TabIndex = 3;
      this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
      // 
      // PackageProblemRenderer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Controls.Add(this.treeView1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.ProblemDescription);
      this.Controls.Add(this.label1);
      this.Name = "PackageProblemRenderer";
      this.Size = new System.Drawing.Size(582, 148);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label ProblemDescription;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TreeView treeView1;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}
