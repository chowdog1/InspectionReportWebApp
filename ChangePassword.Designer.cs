namespace InspectionReportWebApp
{
    partial class ChangePassword
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
            this.confirmBtn = new Wisej.Web.Button();
            this.oldpwtextBox = new Wisej.Web.TextBox();
            this.newpwtextBox = new Wisej.Web.TextBox();
            this.confirmnewtextBox = new Wisej.Web.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowHtml = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Old Password:";
            // 
            // label2
            // 
            this.label2.AllowHtml = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Password:";
            // 
            // label3
            // 
            this.label3.AllowHtml = true;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm Password:";
            // 
            // confirmBtn
            // 
            this.confirmBtn.AllowHtml = true;
            this.confirmBtn.Location = new System.Drawing.Point(147, 150);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(100, 37);
            this.confirmBtn.TabIndex = 3;
            this.confirmBtn.Text = "Confirm";
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // oldpwtextBox
            // 
            this.oldpwtextBox.InputType.Type = Wisej.Web.TextBoxType.Password;
            this.oldpwtextBox.Location = new System.Drawing.Point(142, 20);
            this.oldpwtextBox.Name = "oldpwtextBox";
            this.oldpwtextBox.PasswordChar = '*';
            this.oldpwtextBox.Size = new System.Drawing.Size(220, 30);
            this.oldpwtextBox.TabIndex = 4;
            // 
            // newpwtextBox
            // 
            this.newpwtextBox.InputType.Type = Wisej.Web.TextBoxType.Password;
            this.newpwtextBox.Location = new System.Drawing.Point(142, 61);
            this.newpwtextBox.Name = "newpwtextBox";
            this.newpwtextBox.PasswordChar = '*';
            this.newpwtextBox.Size = new System.Drawing.Size(220, 30);
            this.newpwtextBox.TabIndex = 5;
            // 
            // confirmnewtextBox
            // 
            this.confirmnewtextBox.InputType.Type = Wisej.Web.TextBoxType.Password;
            this.confirmnewtextBox.Location = new System.Drawing.Point(141, 103);
            this.confirmnewtextBox.Name = "confirmnewtextBox";
            this.confirmnewtextBox.PasswordChar = '*';
            this.confirmnewtextBox.Size = new System.Drawing.Size(220, 30);
            this.confirmnewtextBox.TabIndex = 6;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 212);
            this.Controls.Add(this.confirmnewtextBox);
            this.Controls.Add(this.newpwtextBox);
            this.Controls.Add(this.oldpwtextBox);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = Wisej.Web.FormBorderStyle.Fixed;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePassword";
            this.StartPosition = Wisej.Web.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Label label1;
        private Wisej.Web.Label label2;
        private Wisej.Web.Label label3;
        private Wisej.Web.Button confirmBtn;
        private Wisej.Web.TextBox oldpwtextBox;
        private Wisej.Web.TextBox newpwtextBox;
        private Wisej.Web.TextBox confirmnewtextBox;
    }
}
