namespace KICLauncher
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pbxInfo = new System.Windows.Forms.PictureBox();
            this.pbxStart = new System.Windows.Forms.PictureBox();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.pbxHD = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHD)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxInfo
            // 
            this.pbxInfo.BackColor = System.Drawing.Color.Transparent;
            this.pbxInfo.ErrorImage = null;
            this.pbxInfo.Image = global::KICLauncher.Properties.Resources.infoButtonFlat;
            this.pbxInfo.Location = new System.Drawing.Point(12, 499);
            this.pbxInfo.Name = "pbxInfo";
            this.pbxInfo.Size = new System.Drawing.Size(90, 90);
            this.pbxInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxInfo.TabIndex = 9;
            this.pbxInfo.TabStop = false;
            this.pbxInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxInfo_MouseDown);
            this.pbxInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxInfo_MouseUp);
            // 
            // pbxStart
            // 
            this.pbxStart.BackColor = System.Drawing.Color.Transparent;
            this.pbxStart.Image = global::KICLauncher.Properties.Resources.startButtonFlat;
            this.pbxStart.Location = new System.Drawing.Point(354, 499);
            this.pbxStart.Name = "pbxStart";
            this.pbxStart.Size = new System.Drawing.Size(90, 90);
            this.pbxStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxStart.TabIndex = 7;
            this.pbxStart.TabStop = false;
            this.pbxStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxStart_MouseDown);
            this.pbxStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxStart_MouseUp);
            // 
            // pbxLogo
            // 
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxLogo.Location = new System.Drawing.Point(12, 23);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(775, 417);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogo.TabIndex = 10;
            this.pbxLogo.TabStop = false;
            // 
            // pbxHD
            // 
            this.pbxHD.BackColor = System.Drawing.Color.Transparent;
            this.pbxHD.Image = global::KICLauncher.Properties.Resources.hdButtonFlat;
            this.pbxHD.Location = new System.Drawing.Point(697, 499);
            this.pbxHD.Name = "pbxHD";
            this.pbxHD.Size = new System.Drawing.Size(90, 90);
            this.pbxHD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxHD.TabIndex = 8;
            this.pbxHD.TabStop = false;
            this.pbxHD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbxSettings_MouseUp);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(799, 601);
            this.Controls.Add(this.pbxInfo);
            this.Controls.Add(this.pbxHD);
            this.Controls.Add(this.pbxStart);
            this.Controls.Add(this.pbxLogo);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KIC Launcher by Sevenanths";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxHD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxInfo;
        private System.Windows.Forms.PictureBox pbxStart;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.PictureBox pbxHD;
    }
}

