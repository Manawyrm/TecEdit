namespace de.manawyrm.TecEdit.Kernel.Controls
{
  partial class CtlReport
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
      this.GroupBox1 = new System.Windows.Forms.GroupBox();
      this.Label5 = new System.Windows.Forms.Label();
      this.cbxReportType = new System.Windows.Forms.ComboBox();
      this.Label4 = new System.Windows.Forms.Label();
      this.txtReport = new System.Windows.Forms.TextBox();
      this.txtMail = new System.Windows.Forms.TextBox();
      this.Label3 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.Label2 = new System.Windows.Forms.Label();
      this.Label1 = new System.Windows.Forms.Label();
      this.GroupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // GroupBox1
      // 
      this.GroupBox1.Controls.Add(this.Label5);
      this.GroupBox1.Controls.Add(this.cbxReportType);
      this.GroupBox1.Controls.Add(this.Label4);
      this.GroupBox1.Controls.Add(this.txtReport);
      this.GroupBox1.Controls.Add(this.txtMail);
      this.GroupBox1.Controls.Add(this.Label3);
      this.GroupBox1.Controls.Add(this.txtName);
      this.GroupBox1.Controls.Add(this.Label2);
      this.GroupBox1.Location = new System.Drawing.Point(0, 33);
      this.GroupBox1.Name = "GroupBox1";
      this.GroupBox1.Size = new System.Drawing.Size(362, 309);
      this.GroupBox1.TabIndex = 5;
      this.GroupBox1.TabStop = false;
      this.GroupBox1.Text = "Fehlerdaten";
      // 
      // Label5
      // 
      this.Label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.Label5.AutoSize = true;
      this.Label5.Location = new System.Drawing.Point(58, 285);
      this.Label5.Name = "Label5";
      this.Label5.Size = new System.Drawing.Size(51, 13);
      this.Label5.TabIndex = 9;
      this.Label5.Text = "Fehlerart:";
      // 
      // cbxReportType
      // 
      this.cbxReportType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cbxReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxReportType.FormattingEnabled = true;
      this.cbxReportType.Items.AddRange(new object[] {
            "Absturz",
            "Fehlermeldung",
            "Fehlfunktion",
            "Rechtschreibfehler",
            "Vorschlag/Idee"});
      this.cbxReportType.Location = new System.Drawing.Point(115, 282);
      this.cbxReportType.Name = "cbxReportType";
      this.cbxReportType.Size = new System.Drawing.Size(241, 21);
      this.cbxReportType.TabIndex = 3;
      // 
      // Label4
      // 
      this.Label4.AutoSize = true;
      this.Label4.Location = new System.Drawing.Point(6, 81);
      this.Label4.Name = "Label4";
      this.Label4.Size = new System.Drawing.Size(103, 13);
      this.Label4.TabIndex = 7;
      this.Label4.Text = "Fehlerbeschreibung:";
      // 
      // txtReport
      // 
      this.txtReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtReport.Location = new System.Drawing.Point(6, 97);
      this.txtReport.Multiline = true;
      this.txtReport.Name = "txtReport";
      this.txtReport.Size = new System.Drawing.Size(350, 179);
      this.txtReport.TabIndex = 2;
      // 
      // txtMail
      // 
      this.txtMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMail.Location = new System.Drawing.Point(90, 50);
      this.txtMail.Name = "txtMail";
      this.txtMail.Size = new System.Drawing.Size(266, 20);
      this.txtMail.TabIndex = 1;
      // 
      // Label3
      // 
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(40, 53);
      this.Label3.Name = "Label3";
      this.Label3.Size = new System.Drawing.Size(39, 13);
      this.Label3.TabIndex = 4;
      this.Label3.Text = "E-Mail:";
      // 
      // txtName
      // 
      this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtName.Location = new System.Drawing.Point(90, 22);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(266, 20);
      this.txtName.TabIndex = 0;
      // 
      // Label2
      // 
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(42, 25);
      this.Label2.Name = "Label2";
      this.Label2.Size = new System.Drawing.Size(38, 13);
      this.Label2.TabIndex = 3;
      this.Label2.Text = "Name:";
      // 
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(-3, 0);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(296, 26);
      this.Label1.TabIndex = 6;
      this.Label1.Text = "Vielen Dank,\r\ndass Du einen Fehler/Vorschlag in TecEdit melden möchtest.\r\n";
      // 
      // CtlReport
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.Label1);
      this.Controls.Add(this.GroupBox1);
      this.MinimumSize = new System.Drawing.Size(362, 342);
      this.Name = "CtlReport";
      this.Size = new System.Drawing.Size(362, 342);
      this.GroupBox1.ResumeLayout(false);
      this.GroupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.GroupBox GroupBox1;
    private System.Windows.Forms.Label Label5;
    private System.Windows.Forms.ComboBox cbxReportType;
    private System.Windows.Forms.Label Label4;
    private System.Windows.Forms.TextBox txtReport;
    private System.Windows.Forms.TextBox txtMail;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.Label Label1;

  }
}
