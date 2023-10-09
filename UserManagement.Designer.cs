namespace InspectionReportWebApp
{
    partial class UserManagement
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
            this.dataGridViewUsers = new Wisej.Web.DataGridView();
            this.label1 = new Wisej.Web.Label();
            this.usernametxtBox = new Wisej.Web.TextBox();
            this.promoteuserBtn = new Wisej.Web.Button();
            this.removeadminBtn = new Wisej.Web.Button();
            this.dltuserBtn = new Wisej.Web.Button();
            this.unlockBtn = new Wisej.Web.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.Location = new System.Drawing.Point(19, 18);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.Size = new System.Drawing.Size(499, 154);
            this.dataGridViewUsers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AllowHtml = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:";
            // 
            // usernametxtBox
            // 
            this.usernametxtBox.Location = new System.Drawing.Point(182, 186);
            this.usernametxtBox.Name = "usernametxtBox";
            this.usernametxtBox.Size = new System.Drawing.Size(189, 30);
            this.usernametxtBox.TabIndex = 2;
            // 
            // promoteuserBtn
            // 
            this.promoteuserBtn.Location = new System.Drawing.Point(49, 248);
            this.promoteuserBtn.Name = "promoteuserBtn";
            this.promoteuserBtn.Size = new System.Drawing.Size(421, 39);
            this.promoteuserBtn.TabIndex = 3;
            this.promoteuserBtn.Text = "Make this user an Admin";
            this.promoteuserBtn.Click += new System.EventHandler(this.promoteuserBtn_Click);
            // 
            // removeadminBtn
            // 
            this.removeadminBtn.Location = new System.Drawing.Point(49, 302);
            this.removeadminBtn.Name = "removeadminBtn";
            this.removeadminBtn.Size = new System.Drawing.Size(421, 39);
            this.removeadminBtn.TabIndex = 4;
            this.removeadminBtn.Text = "Remove Admin rights";
            this.removeadminBtn.Click += new System.EventHandler(this.removeadminBtn_Click);
            // 
            // dltuserBtn
            // 
            this.dltuserBtn.Location = new System.Drawing.Point(49, 360);
            this.dltuserBtn.Name = "dltuserBtn";
            this.dltuserBtn.Size = new System.Drawing.Size(421, 39);
            this.dltuserBtn.TabIndex = 5;
            this.dltuserBtn.Text = "Delete this user";
            this.dltuserBtn.Click += new System.EventHandler(this.dltuserBtn_Click);
            // 
            // unlockBtn
            // 
            this.unlockBtn.Location = new System.Drawing.Point(49, 417);
            this.unlockBtn.Name = "unlockBtn";
            this.unlockBtn.Size = new System.Drawing.Size(421, 39);
            this.unlockBtn.TabIndex = 6;
            this.unlockBtn.Text = "Unlock account";
            this.unlockBtn.Click += new System.EventHandler(this.unlockBtn_Click);
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 489);
            this.Controls.Add(this.unlockBtn);
            this.Controls.Add(this.dltuserBtn);
            this.Controls.Add(this.removeadminBtn);
            this.Controls.Add(this.promoteuserBtn);
            this.Controls.Add(this.usernametxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewUsers);
            this.FormBorderStyle = Wisej.Web.FormBorderStyle.Fixed;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserManagement";
            this.StartPosition = Wisej.Web.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.DataGridView dataGridViewUsers;
        private Wisej.Web.Label label1;
        private Wisej.Web.TextBox usernametxtBox;
        private Wisej.Web.Button promoteuserBtn;
        private Wisej.Web.Button removeadminBtn;
        private Wisej.Web.Button dltuserBtn;
        private Wisej.Web.Button unlockBtn;
    }
}
