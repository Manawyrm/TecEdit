namespace de.manawyrm.TecEdit
{
  partial class FrmTest
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
      this.ctlEditorPane1 = new de.manawyrm.TecEdit.Kernel.Controls.CtlEditorPane();
      this.SuspendLayout();
      // 
      // ctlEditorPane1
      // 
      this.ctlEditorPane1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ctlEditorPane1.Location = new System.Drawing.Point(0, 0);
      this.ctlEditorPane1.Name = "ctlEditorPane1";
      this.ctlEditorPane1.Size = new System.Drawing.Size(583, 395);
      this.ctlEditorPane1.TabIndex = 0;
      // 
      // FrmTest
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(583, 395);
      this.Controls.Add(this.ctlEditorPane1);
      this.Name = "FrmTest";
      this.Text = "FrmTest";
      this.ResumeLayout(false);

    }

    #endregion

    private Kernel.Controls.CtlEditorPane ctlEditorPane1;
  }
}