namespace InspectionReportWebApp
{
    partial class GeneratePDF
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
            this.accttxtBox = new Wisej.Web.TextBox();
            this.printBtn = new Wisej.Web.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowHtml = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account No:";
            // 
            // accttxtBox
            // 
            this.accttxtBox.Location = new System.Drawing.Point(112, 16);
            this.accttxtBox.Name = "accttxtBox";
            this.accttxtBox.Size = new System.Drawing.Size(200, 30);
            this.accttxtBox.TabIndex = 1;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(125, 75);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(100, 37);
            this.printBtn.TabIndex = 2;
            this.printBtn.Text = "Print";
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // GeneratePDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 141);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.accttxtBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = Wisej.Web.FormBorderStyle.Fixed;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneratePDF";
            this.StartPosition = Wisej.Web.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Label label1;
        private Wisej.Web.TextBox accttxtBox;
        private Wisej.Web.Button printBtn;
    }
}
