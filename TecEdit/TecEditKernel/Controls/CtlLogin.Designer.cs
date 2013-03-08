namespace de.manawyrm.TecEdit.Kernel.Controls
{
    partial class CtlLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlLogin));
            this.tbxUser = new System.Windows.Forms.TextBox();
            this.tbxHost = new System.Windows.Forms.TextBox();
            this.tbxPassw = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.eProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxUser
            // 
            this.tbxUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxUser.Location = new System.Drawing.Point(0, 174);
            this.tbxUser.Name = "tbxUser";
            this.tbxUser.Size = new System.Drawing.Size(265, 20);
            this.tbxUser.TabIndex = 1;
            this.tbxUser.Validating += new System.ComponentModel.CancelEventHandler(this.tbxUser_Validating);
            // 
            // tbxHost
            // 
            this.tbxHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxHost.Location = new System.Drawing.Point(0, 135);
            this.tbxHost.Name = "tbxHost";
            this.tbxHost.Size = new System.Drawing.Size(265, 20);
            this.tbxHost.TabIndex = 0;
            this.tbxHost.Validating += new System.ComponentModel.CancelEventHandler(this.tbxHost_Validating);
            // 
            // tbxPassw
            // 
            this.tbxPassw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPassw.Location = new System.Drawing.Point(0, 213);
            this.tbxPassw.Name = "tbxPassw";
            this.tbxPassw.PasswordChar = '*';
            this.tbxPassw.Size = new System.Drawing.Size(265, 20);
            this.tbxPassw.TabIndex = 2;
            this.tbxPassw.Validating += new System.ComponentModel.CancelEventHandler(this.tbxPassw_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "&Hostname: (z.B. http://teccraft.de/tecedit/)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "&Benutzername:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "&Kennwort:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::de.manawyrm.TecEdit.Kernel.Properties.Resources.tecedit;
            this.pictureBox1.InitialImage = global::de.manawyrm.TecEdit.Kernel.Properties.Resources.tecedit;
            this.pictureBox1.Location = new System.Drawing.Point(15, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // eProvider
            // 
            this.eProvider.BlinkRate = 300;
            this.eProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.eProvider.ContainerControl = this;
            this.eProvider.Icon = ((System.Drawing.Icon)(resources.GetObject("eProvider.Icon")));
            // 
            // CtlLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxPassw);
            this.Controls.Add(this.tbxHost);
            this.Controls.Add(this.tbxUser);
            this.MinimumSize = new System.Drawing.Size(287, 256);
            this.Name = "CtlLogin";
            this.Size = new System.Drawing.Size(287, 256);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxUser;
        private System.Windows.Forms.TextBox tbxHost;
        private System.Windows.Forms.TextBox tbxPassw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider eProvider;
    }
}
