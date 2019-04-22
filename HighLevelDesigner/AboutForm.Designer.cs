namespace HighLevelDesigner
{
    partial class AboutForm
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
            this.Main = new System.Windows.Forms.Panel();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.Product = new System.Windows.Forms.Label();
            this.Company = new System.Windows.Forms.Label();
            this.SupportUrl = new System.Windows.Forms.LinkLabel();
            this.Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // Main
            // 
            this.Main.Controls.Add(this.SupportUrl);
            this.Main.Controls.Add(this.Company);
            this.Main.Controls.Add(this.Product);
            this.Main.Controls.Add(this.Logo);
            this.Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main.Location = new System.Drawing.Point(0, 0);
            this.Main.Name = "Main";
            this.Main.Size = new System.Drawing.Size(444, 186);
            this.Main.TabIndex = 0;
            // 
            // Logo
            // 
            this.Logo.Dock = System.Windows.Forms.DockStyle.Left;
            this.Logo.Location = new System.Drawing.Point(0, 0);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(142, 186);
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // Product
            // 
            this.Product.AutoSize = true;
            this.Product.Location = new System.Drawing.Point(148, 9);
            this.Product.Name = "Product";
            this.Product.Size = new System.Drawing.Size(116, 13);
            this.Product.TabIndex = 1;
            this.Product.Text = "Product name (version)";
            // 
            // Company
            // 
            this.Company.AutoSize = true;
            this.Company.Location = new System.Drawing.Point(148, 36);
            this.Company.Name = "Company";
            this.Company.Size = new System.Drawing.Size(51, 13);
            this.Company.TabIndex = 2;
            this.Company.Text = "Company";
            // 
            // SupportUrl
            // 
            this.SupportUrl.AutoSize = true;
            this.SupportUrl.Location = new System.Drawing.Point(148, 59);
            this.SupportUrl.Name = "SupportUrl";
            this.SupportUrl.Size = new System.Drawing.Size(69, 13);
            this.SupportUrl.TabIndex = 3;
            this.SupportUrl.TabStop = true;
            this.SupportUrl.Text = "Support URL";
            this.SupportUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SupportUrl_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 186);
            this.Controls.Add(this.Main);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(460, 225);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(460, 225);
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.Main.ResumeLayout(false);
            this.Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Main;
        private System.Windows.Forms.Label Product;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.LinkLabel SupportUrl;
        private System.Windows.Forms.Label Company;
    }
}