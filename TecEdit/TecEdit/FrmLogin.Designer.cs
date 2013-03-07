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
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(363, 274);
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
            this.btnOK.Location = new System.Drawing.Point(258, 274);
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
            this.llteccraft.Location = new System.Drawing.Point(47, 289);
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
            this.lltbSpace.Location = new System.Drawing.Point(9, 276);
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
            this.ctlLogin1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ctlLogin1.Location = new System.Drawing.Point(12, 12);
            this.ctlLogin1.MinimumSize = new System.Drawing.Size(287, 256);
            this.ctlLogin1.Name = "ctlLogin1";
            this.ctlLogin1.Size = new System.Drawing.Size(450, 256);
            this.ctlLogin1.TabIndex = 0;
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(474, 314);
            this.ControlBox = false;
            this.Controls.Add(this.ctlLogin1);
            this.Controls.Add(this.lltbSpace);
            this.Controls.Add(this.llteccraft);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TecEdit - Anmeldung";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.LinkLabel llteccraft;
        private System.Windows.Forms.LinkLabel lltbSpace;
        private Kernel.Controls.CtlLogin ctlLogin1;

    }
}

