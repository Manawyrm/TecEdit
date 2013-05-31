namespace de.manawyrm.TecEdit.Kernel.Controls
{
  partial class CtlFileExplorer
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
      this.tvFolderView = new System.Windows.Forms.TreeView();
      this.SuspendLayout();
      // 
      // tvFolderView
      // 
      this.tvFolderView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tvFolderView.Location = new System.Drawing.Point(0, 0);
      this.tvFolderView.Name = "tvFolderView";
      this.tvFolderView.Size = new System.Drawing.Size(150, 150);
      this.tvFolderView.TabIndex = 0;
      // 
      // CtlFileExplorer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tvFolderView);
      this.DoubleBuffered = true;
      this.Name = "CtlFileExplorer";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TreeView tvFolderView;
  }
}
