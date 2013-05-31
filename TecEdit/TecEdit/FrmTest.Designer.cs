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
      this.button1 = new System.Windows.Forms.Button();
      this.ctlFileExplorer1 = new de.manawyrm.TecEdit.Kernel.Controls.CtlFileExplorer();
      this.ctlEditorPane1 = new de.manawyrm.TecEdit.Kernel.Controls.CtlEditorPane();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(281, 12);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 2;
      this.button1.Text = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // ctlFileExplorer1
      // 
      this.ctlFileExplorer1.Location = new System.Drawing.Point(12, 12);
      this.ctlFileExplorer1.Name = "ctlFileExplorer1";
      this.ctlFileExplorer1.Size = new System.Drawing.Size(263, 389);
      this.ctlFileExplorer1.TabIndex = 1;
      // 
      // ctlEditorPane1
      // 
      this.ctlEditorPane1.Location = new System.Drawing.Point(362, 12);
      this.ctlEditorPane1.Name = "ctlEditorPane1";
      this.ctlEditorPane1.Size = new System.Drawing.Size(642, 389);
      this.ctlEditorPane1.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(281, 68);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(35, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "label1";
      // 
      // FrmTest
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1016, 413);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.ctlFileExplorer1);
      this.Controls.Add(this.ctlEditorPane1);
      this.Name = "FrmTest";
      this.Text = "FrmTest";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Kernel.Controls.CtlEditorPane ctlEditorPane1;
    private Kernel.Controls.CtlFileExplorer ctlFileExplorer1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
  }
}