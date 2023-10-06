namespace InspectionReportWebApp
{
    partial class Request
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
            this.label4 = new Wisej.Web.Label();
            this.nametextBox = new Wisej.Web.TextBox();
            this.depttextBox = new Wisej.Web.TextBox();
            this.emailtextBox = new Wisej.Web.TextBox();
            this.reasontextBox = new Wisej.Web.TextBox();
            this.sendBtn = new Wisej.Web.Button();
            this.cancelBtn = new Wisej.Web.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowHtml = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AllowHtml = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Department:";
            // 
            // label3
            // 
            this.label3.AllowHtml = true;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AllowHtml = true;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Reason:";
            // 
            // nametextBox
            // 
            this.nametextBox.Location = new System.Drawing.Point(180, 58);
            this.nametextBox.Name = "nametextBox";
            this.nametextBox.Size = new System.Drawing.Size(334, 22);
            this.nametextBox.TabIndex = 4;
            // 
            // depttextBox
            // 
            this.depttextBox.Location = new System.Drawing.Point(180, 109);
            this.depttextBox.Name = "depttextBox";
            this.depttextBox.Size = new System.Drawing.Size(334, 22);
            this.depttextBox.TabIndex = 5;
            // 
            // emailtextBox
            // 
            this.emailtextBox.Location = new System.Drawing.Point(180, 163);
            this.emailtextBox.Name = "emailtextBox";
            this.emailtextBox.Size = new System.Drawing.Size(334, 22);
            this.emailtextBox.TabIndex = 6;
            // 
            // reasontextBox
            // 
            this.reasontextBox.Location = new System.Drawing.Point(180, 226);
            this.reasontextBox.Multiline = true;
            this.reasontextBox.Name = "reasontextBox";
            this.reasontextBox.Size = new System.Drawing.Size(334, 108);
            this.reasontextBox.TabIndex = 7;
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(98, 374);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(344, 52);
            this.sendBtn.TabIndex = 8;
            this.sendBtn.Text = "SUBMIT";
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromName("@invalid");
            this.cancelBtn.Location = new System.Drawing.Point(98, 446);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(344, 52);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // Request
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 550);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.reasontextBox);
            this.Controls.Add(this.emailtextBox);
            this.Controls.Add(this.depttextBox);
            this.Controls.Add(this.nametextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("default, Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = Wisej.Web.FormBorderStyle.Fixed;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Request";
            this.StartPosition = Wisej.Web.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Label label1;
        private Wisej.Web.Label label2;
        private Wisej.Web.Label label3;
        private Wisej.Web.Label label4;
        private Wisej.Web.TextBox nametextBox;
        private Wisej.Web.TextBox depttextBox;
        private Wisej.Web.TextBox emailtextBox;
        private Wisej.Web.TextBox reasontextBox;
        private Wisej.Web.Button sendBtn;
        private Wisej.Web.Button cancelBtn;
    }
}
