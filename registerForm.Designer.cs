namespace InspectionReportWebApp
{
    partial class registerForm
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
            this.label1 = new Wisej.Web.Label();
            this.label2 = new Wisej.Web.Label();
            this.label3 = new Wisej.Web.Label();
            this.registerBtn = new Wisej.Web.Button();
            this.clearBtn = new Wisej.Web.Button();
            this.cancelBtn = new Wisej.Web.Button();
            this.usernametxtBox = new Wisej.Web.TextBox();
            this.passwordtxtBox = new Wisej.Web.TextBox();
            this.confirmpasswordtxtBox = new Wisej.Web.TextBox();
            this.showchkBox = new Wisej.Web.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowHtml = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("default, Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(25, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AllowHtml = true;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("default, Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(25, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Desired Password";
            // 
            // label3
            // 
            this.label3.AllowHtml = true;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("default, Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(25, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm Password";
            // 
            // registerBtn
            // 
            this.registerBtn.BackColor = System.Drawing.Color.FromName("@success");
            this.registerBtn.Font = new System.Drawing.Font("default, Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.registerBtn.Location = new System.Drawing.Point(25, 323);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(269, 47);
            this.registerBtn.TabIndex = 3;
            this.registerBtn.Text = "REGISTER";
            this.registerBtn.Click += new System.EventHandler(this.registerBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.BackColor = System.Drawing.Color.FromName("@activeCaption");
            this.clearBtn.Font = new System.Drawing.Font("default, Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.clearBtn.Location = new System.Drawing.Point(25, 376);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(269, 47);
            this.clearBtn.TabIndex = 4;
            this.clearBtn.Text = "CLEAR";
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromName("@invalid");
            this.cancelBtn.Font = new System.Drawing.Font("default, Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cancelBtn.Location = new System.Drawing.Point(25, 462);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(269, 47);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // usernametxtBox
            // 
            this.usernametxtBox.Location = new System.Drawing.Point(25, 62);
            this.usernametxtBox.Name = "usernametxtBox";
            this.usernametxtBox.Size = new System.Drawing.Size(269, 30);
            this.usernametxtBox.TabIndex = 6;
            // 
            // passwordtxtBox
            // 
            this.passwordtxtBox.InputType.Type = Wisej.Web.TextBoxType.Password;
            this.passwordtxtBox.Location = new System.Drawing.Point(25, 145);
            this.passwordtxtBox.Name = "passwordtxtBox";
            this.passwordtxtBox.PasswordChar = '*';
            this.passwordtxtBox.Size = new System.Drawing.Size(269, 30);
            this.passwordtxtBox.TabIndex = 7;
            // 
            // confirmpasswordtxtBox
            // 
            this.confirmpasswordtxtBox.InputType.Type = Wisej.Web.TextBoxType.Password;
            this.confirmpasswordtxtBox.Location = new System.Drawing.Point(25, 231);
            this.confirmpasswordtxtBox.Name = "confirmpasswordtxtBox";
            this.confirmpasswordtxtBox.PasswordChar = '*';
            this.confirmpasswordtxtBox.Size = new System.Drawing.Size(269, 30);
            this.confirmpasswordtxtBox.TabIndex = 8;
            // 
            // showchkBox
            // 
            this.showchkBox.Location = new System.Drawing.Point(175, 267);
            this.showchkBox.Name = "showchkBox";
            this.showchkBox.Size = new System.Drawing.Size(119, 23);
            this.showchkBox.TabIndex = 9;
            this.showchkBox.Text = "Show Password";
            // 
            // registerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 555);
            this.Controls.Add(this.showchkBox);
            this.Controls.Add(this.confirmpasswordtxtBox);
            this.Controls.Add(this.passwordtxtBox);
            this.Controls.Add(this.usernametxtBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = Wisej.Web.FormBorderStyle.Fixed;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "registerForm";
            this.StartPosition = Wisej.Web.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Label label1;
        private Wisej.Web.Label label2;
        private Wisej.Web.Label label3;
        private Wisej.Web.Button registerBtn;
        private Wisej.Web.Button clearBtn;
        private Wisej.Web.Button cancelBtn;
        private Wisej.Web.TextBox usernametxtBox;
        private Wisej.Web.TextBox passwordtxtBox;
        private Wisej.Web.TextBox confirmpasswordtxtBox;
        private Wisej.Web.CheckBox showchkBox;
    }
}
