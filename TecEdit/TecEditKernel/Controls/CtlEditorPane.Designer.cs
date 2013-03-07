namespace de.manawyrm.TecEdit.Kernel.Controls
{
  partial class CtlEditorPane
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
        this.tCEditor = new System.Windows.Forms.TabControl();
        this.SuspendLayout();
        // 
        // tCEditor
        // 
        this.tCEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.tCEditor.Location = new System.Drawing.Point(0, 0);
        this.tCEditor.Name = "tCEditor";
        this.tCEditor.SelectedIndex = 0;
        this.tCEditor.Size = new System.Drawing.Size(186, 138);
        this.tCEditor.TabIndex = 0;
        this.tCEditor.SelectedIndexChanged += new System.EventHandler(this.tCEditor_SelectedIndexChanged);
        // 
        // CtlEditorPane
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.tCEditor);
        this.Name = "CtlEditorPane";
        this.Size = new System.Drawing.Size(186, 138);
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tCEditor;

  }
}
