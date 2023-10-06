namespace InspectionReportWebApp
{
    partial class Loginpage
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

        #region Wisej.NET Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loginpage));
            this.label1 = new Wisej.Web.Label();
            this.label2 = new Wisej.Web.Label();
            this.usernametxtBox = new Wisej.Web.TextBox();
            this.passwordtxtBox = new Wisej.Web.TextBox();
            this.showchkBox = new Wisej.Web.CheckBox();
            this.loginBtn = new Wisej.Web.Button();
            this.clrBtn = new Wisej.Web.Button();
            this.label3 = new Wisej.Web.Label();
            this.label4 = new Wisej.Web.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowHtml = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("nirmala, Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.FromName("@controlText");
            this.label1.Location = new System.Drawing.Point(23, 122);
            this.label1.Name = "label1";
            this.label1.ResponsiveProfiles.Add(((Wisej.Base.ResponsiveProfile)(resources.GetObject("label1.ResponsiveProfiles"))));
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AllowHtml = true;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("default, Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label2.ForeColor = System.Drawing.Color.FromName("@controlText");
            this.label2.Location = new System.Drawing.Point(23, 215);
            this.label2.Name = "label2";
            this.label2.ResponsiveProfiles.Add(((Wisej.Base.ResponsiveProfile)(resources.GetObject("label2.ResponsiveProfiles"))));
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // usernametxtBox
            // 
            this.usernametxtBox.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.usernametxtBox.ForeColor = System.Drawing.Color.FromName("@appWorkspace");
            this.usernametxtBox.Location = new System.Drawing.Point(23, 152);
            this.usernametxtBox.Name = "usernametxtBox";
            this.usernametxtBox.ResponsiveProfiles.Add(((Wisej.Base.ResponsiveProfile)(resources.GetObject("usernametxtBox.ResponsiveProfiles"))));
            this.usernametxtBox.ScrollBars = Wisej.Web.ScrollBars.None;
            this.usernametxtBox.Size = new System.Drawing.Size(291, 22);
            this.usernametxtBox.TabIndex = 2;
            // 
            // passwordtxtBox
            // 
            this.passwordtxtBox.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.passwordtxtBox.ForeColor = System.Drawing.Color.FromName("@appWorkspace");
            this.passwordtxtBox.InputType.Type = Wisej.Web.TextBoxType.Password;
            this.passwordtxtBox.Location = new System.Drawing.Point(23, 242);
            this.passwordtxtBox.Name = "passwordtxtBox";
            this.passwordtxtBox.PasswordChar = '*';
            this.passwordtxtBox.ResponsiveProfiles.Add(((Wisej.Base.ResponsiveProfile)(resources.GetObject("passwordtxtBox.ResponsiveProfiles"))));
            this.passwordtxtBox.ScrollBars = Wisej.Web.ScrollBars.None;
            this.passwordtxtBox.Size = new System.Drawing.Size(291, 22);
            this.passwordtxtBox.TabIndex = 3;
            // 
            // showchkBox
            // 
            this.showchkBox.AllowHtml = true;
            this.showchkBox.Font = new System.Drawing.Font("default, Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.showchkBox.Location = new System.Drawing.Point(185, 279);
            this.showchkBox.Name = "showchkBox";
            this.showchkBox.ResponsiveProfiles.Add(((Wisej.Base.ResponsiveProfile)(resources.GetObject("showchkBox.ResponsiveProfiles"))));
            this.showchkBox.Size = new System.Drawing.Size(129, 22);
            this.showchkBox.TabIndex = 4;
            this.showchkBox.Text = "Show Password";
            this.showchkBox.CheckedChanged += new System.EventHandler(this.showchkBox_CheckedChanged);
            // 
            // loginBtn
            // 
            this.loginBtn.Font = new System.Drawing.Font("default, Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.loginBtn.Location = new System.Drawing.Point(23, 329);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.ResponsiveProfiles.Add(((Wisej.Base.ResponsiveProfile)(resources.GetObject("loginBtn.ResponsiveProfiles"))));
            this.loginBtn.Size = new System.Drawing.Size(291, 39);
            this.loginBtn.TabIndex = 5;
            this.loginBtn.Text = "LOGIN";
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // clrBtn
            // 
            this.clrBtn.BackColor = System.Drawing.Color.FromName("@activeCaptionText");
            this.clrBtn.Font = new System.Drawing.Font("default, Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.clrBtn.ForeColor = System.Drawing.Color.FromName("@appWorkspace");
            this.clrBtn.Location = new System.Drawing.Point(23, 378);
            this.clrBtn.Name = "clrBtn";
            this.clrBtn.ResponsiveProfiles.Add(((Wisej.Base.ResponsiveProfile)(resources.GetObject("clrBtn.ResponsiveProfiles"))));
            this.clrBtn.Size = new System.Drawing.Size(291, 39);
            this.clrBtn.TabIndex = 6;
            this.clrBtn.Text = "CLEAR";
            // 
            // label3
            // 
            this.label3.AllowHtml = true;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("default, Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(127, 433);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "No account?";
            // 
            // label4
            // 
            this.label4.AllowHtml = true;
            this.label4.AutoSize = true;
            this.label4.Cursor = Wisej.Web.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("default, Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label4.ForeColor = System.Drawing.Color.FromName("@activeCaption");
            this.label4.Location = new System.Drawing.Point(118, 454);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Contact Admin";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Loginpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 542);
            this.CloseBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clrBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.showchkBox);
            this.Controls.Add(this.passwordtxtBox);
            this.Controls.Add(this.usernametxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = Wisej.Web.FormBorderStyle.Fixed;
            this.HeaderBackColor = System.Drawing.Color.FromName("@activeBorder");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "Loginpage";
            this.ResponsiveProfiles.Add(((Wisej.Base.ResponsiveProfile)(resources.GetObject("$this.ResponsiveProfiles"))));
            this.StartPosition = Wisej.Web.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Label label1;
        private Wisej.Web.Label label2;
        private Wisej.Web.TextBox usernametxtBox;
        private Wisej.Web.TextBox passwordtxtBox;
        private Wisej.Web.CheckBox showchkBox;
        private Wisej.Web.Button loginBtn;
        private Wisej.Web.Button clrBtn;
        private Wisej.Web.Label label3;
        private Wisej.Web.Label label4;
    }
}
