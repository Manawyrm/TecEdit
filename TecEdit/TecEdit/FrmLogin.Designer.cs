namespace de.manawyrm.TecEdit
{
    partial class FrmLogin
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
          this.btnCancel = new System.Windows.Forms.Button();
          this.btnOK = new System.Windows.Forms.Button();
          this.llteccraft = new System.Windows.Forms.LinkLabel();
          this.lltbSpace = new System.Windows.Forms.LinkLabel();
          this.ctlLogin1 = new de.manawyrm.TecEdit.Kernel.Controls.CtlLogin();
          this.panel1 = new System.Windows.Forms.Panel();
          this.button1 = new System.Windows.Forms.Button();
          this.panel1.SuspendLayout();
          this.SuspendLayout();
          // 
          // btnCancel
          // 
          this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.btnCancel.Location = new System.Drawing.Point(365, 11);
          this.btnCancel.Name = "btnCancel";
          this.btnCancel.Size = new System.Drawing.Size(99, 28);
          this.btnCancel.TabIndex = 2;
          this.btnCancel.Text = "Abbrechen";
          this.btnCancel.UseVisualStyleBackColor = true;
          this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
          // 
          // btnOK
          // 
          this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
          this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
          this.btnOK.Location = new System.Drawing.Point(260, 11);
          this.btnOK.Name = "btnOK";
          this.btnOK.Size = new System.Drawing.Size(99, 28);
          this.btnOK.TabIndex = 1;
          this.btnOK.Text = "OK";
          this.btnOK.UseVisualStyleBackColor = true;
          this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
          // 
          // llteccraft
          // 
          this.llteccraft.AutoSize = true;
          this.llteccraft.Location = new System.Drawing.Point(45, 24);
          this.llteccraft.Name = "llteccraft";
          this.llteccraft.Size = new System.Drawing.Size(73, 13);
          this.llteccraft.TabIndex = 3;
          this.llteccraft.TabStop = true;
          this.llteccraft.Text = "for teccraft.de";
          this.llteccraft.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llteccraft_LinkClicked);
          // 
          // lltbSpace
          // 
          this.lltbSpace.AutoSize = true;
          this.lltbSpace.Location = new System.Drawing.Point(7, 11);
          this.lltbSpace.Name = "lltbSpace";
          this.lltbSpace.Size = new System.Drawing.Size(111, 13);
          this.lltbSpace.TabIndex = 4;
          this.lltbSpace.TabStop = true;
          this.lltbSpace.Text = "Written by tbspace.de";
          this.lltbSpace.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lltbSpace_LinkClicked);
          // 
          // ctlLogin1
          // 
          this.ctlLogin1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.ctlLogin1.BackColor = System.Drawing.Color.Transparent;
          this.ctlLogin1.Location = new System.Drawing.Point(12, 12);
          this.ctlLogin1.MinimumSize = new System.Drawing.Size(287, 256);
          this.ctlLogin1.Name = "ctlLogin1";
          this.ctlLogin1.Size = new System.Drawing.Size(450, 256);
          this.ctlLogin1.TabIndex = 0;
          // 
          // panel1
          // 
          this.panel1.BackColor = System.Drawing.SystemColors.Control;
          this.panel1.Controls.Add(this.button1);
          this.panel1.Controls.Add(this.lltbSpace);
          this.panel1.Controls.Add(this.btnCancel);
          this.panel1.Controls.Add(this.btnOK);
          this.panel1.Controls.Add(this.llteccraft);
          this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.panel1.Location = new System.Drawing.Point(0, 264);
          this.panel1.Name = "panel1";
          this.panel1.Size = new System.Drawing.Size(474, 50);
          this.panel1.TabIndex = 5;
          // 
          // button1
          // 
          this.button1.Location = new System.Drawing.Point(156, 13);
          this.button1.Name = "button1";
          this.button1.Size = new System.Drawing.Size(75, 23);
          this.button1.TabIndex = 5;
          this.button1.Text = "button1";
          this.button1.UseVisualStyleBackColor = true;
          this.button1.Click += new System.EventHandler(this.button1_Click);
          // 
          // FrmLogin
          // 
          this.AcceptButton = this.btnOK;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.Color.White;
          this.CancelButton = this.btnCancel;
          this.ClientSize = new System.Drawing.Size(474, 314);
          this.ControlBox = false;
          this.Controls.Add(this.panel1);
          this.Controls.Add(this.ctlLogin1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.Name = "FrmLogin";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "TecEdit - Anmeldung";
          this.panel1.ResumeLayout(false);
          this.panel1.PerformLayout();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.LinkLabel llteccraft;
        private System.Windows.Forms.LinkLabel lltbSpace;
        private Kernel.Controls.CtlLogin ctlLogin1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}

