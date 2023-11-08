namespace InspectionReportWebApp.ECNC
{
    partial class Payment
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
            this.dataGridView1 = new Wisej.Web.DataGridView();
            this.label1 = new Wisej.Web.Label();
            this.label2 = new Wisej.Web.Label();
            this.applicationnotxtBox = new Wisej.Web.TextBox();
            this.paidyesradioBtn = new Wisej.Web.RadioButton();
            this.paidnoradioBtn = new Wisej.Web.RadioButton();
            this.submitBtn = new Wisej.Web.Button();
            this.cancelBtn = new Wisej.Web.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(19, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(490, 277);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AllowHtml = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(19, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Application No.:";
            // 
            // label2
            // 
            this.label2.AllowHtml = true;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(19, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Paid?:";
            // 
            // applicationnotxtBox
            // 
            this.applicationnotxtBox.Location = new System.Drawing.Point(138, 313);
            this.applicationnotxtBox.Name = "applicationnotxtBox";
            this.applicationnotxtBox.Size = new System.Drawing.Size(200, 22);
            this.applicationnotxtBox.TabIndex = 3;
            // 
            // paidyesradioBtn
            // 
            this.paidyesradioBtn.Location = new System.Drawing.Point(77, 357);
            this.paidyesradioBtn.Name = "paidyesradioBtn";
            this.paidyesradioBtn.Size = new System.Drawing.Size(55, 22);
            this.paidyesradioBtn.TabIndex = 4;
            this.paidyesradioBtn.TabStop = true;
            this.paidyesradioBtn.Text = "Yes";
            // 
            // paidnoradioBtn
            // 
            this.paidnoradioBtn.Location = new System.Drawing.Point(138, 357);
            this.paidnoradioBtn.Name = "paidnoradioBtn";
            this.paidnoradioBtn.Size = new System.Drawing.Size(49, 22);
            this.paidnoradioBtn.TabIndex = 5;
            this.paidnoradioBtn.TabStop = true;
            this.paidnoradioBtn.Text = "No";
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.FromArgb(48, 116, 175);
            this.submitBtn.Font = new System.Drawing.Font("Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.submitBtn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.submitBtn.Location = new System.Drawing.Point(392, 314);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(100, 27);
            this.submitBtn.TabIndex = 6;
            this.submitBtn.Text = "Submit";
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
            this.cancelBtn.Font = new System.Drawing.Font("Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cancelBtn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.cancelBtn.Location = new System.Drawing.Point(392, 358);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(100, 27);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 412);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.paidnoradioBtn);
            this.Controls.Add(this.paidyesradioBtn);
            this.Controls.Add(this.applicationnotxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Payment";
            this.StartPosition = Wisej.Web.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.DataGridView dataGridView1;
        private Wisej.Web.Label label1;
        private Wisej.Web.Label label2;
        private Wisej.Web.TextBox applicationnotxtBox;
        private Wisej.Web.RadioButton paidyesradioBtn;
        private Wisej.Web.RadioButton paidnoradioBtn;
        private Wisej.Web.Button submitBtn;
        private Wisej.Web.Button cancelBtn;
    }
}
