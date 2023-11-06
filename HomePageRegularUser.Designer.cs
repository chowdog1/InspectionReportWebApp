namespace InspectionReportWebApp
{
    partial class HomePageRegular
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
            this.panel1 = new Wisej.Web.Panel();
            this.label6 = new Wisej.Web.Label();
            this.label4 = new Wisej.Web.Label();
            this.line1 = new Wisej.Web.Line();
            this.label2 = new Wisej.Web.Label();
            this.label1 = new Wisej.Web.Label();
            this.IRMSBtn = new Wisej.Web.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = Wisej.Web.BorderStyle.Solid;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.line1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = Wisej.Web.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 250);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AllowHtml = true;
            this.label6.AutoSize = true;
            this.label6.Cursor = Wisej.Web.Cursors.Hand;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label6.Location = new System.Drawing.Point(102, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 22);
            this.label6.TabIndex = 6;
            this.label6.Text = "Logout";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label4
            // 
            this.label4.AllowHtml = true;
            this.label4.AutoSize = true;
            this.label4.Cursor = Wisej.Web.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label4.Location = new System.Drawing.Point(67, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Change Password";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // line1
            // 
            this.line1.LineColor = System.Drawing.Color.Black;
            this.line1.Location = new System.Drawing.Point(0, 73);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(278, 10);
            // 
            // label2
            // 
            this.label2.AllowHtml = true;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(55, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Information System";
            // 
            // label1
            // 
            this.label1.AllowHtml = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Environment Management";
            // 
            // IRMSBtn
            // 
            this.IRMSBtn.BackColor = System.Drawing.Color.FromArgb(51, 122, 183);
            this.IRMSBtn.Font = new System.Drawing.Font("Nirmala UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.IRMSBtn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.IRMSBtn.Location = new System.Drawing.Point(285, 44);
            this.IRMSBtn.Name = "IRMSBtn";
            this.IRMSBtn.Size = new System.Drawing.Size(378, 54);
            this.IRMSBtn.TabIndex = 1;
            this.IRMSBtn.Text = "Inspection Report Management System";
            this.IRMSBtn.Click += new System.EventHandler(this.IRMSBtn_Click);
            // 
            // HomePageRegular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 250);
            this.CloseBox = false;
            this.Controls.Add(this.IRMSBtn);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HomePageRegular";
            this.StartPosition = Wisej.Web.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.Panel panel1;
        private Wisej.Web.Label label1;
        private Wisej.Web.Label label2;
        private Wisej.Web.Label label4;
        private Wisej.Web.Line line1;
        private Wisej.Web.Label label6;
        private Wisej.Web.Button IRMSBtn;
    }
}
