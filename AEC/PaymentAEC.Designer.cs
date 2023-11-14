namespace InspectionReportWebApp.AEC
{
    partial class PaymentAEC
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
            this.label3 = new Wisej.Web.Label();
            this.label4 = new Wisej.Web.Label();
            this.accountnotxtBox = new Wisej.Web.TextBox();
            this.amounttxtBox = new Wisej.Web.TextBox();
            this.ornotxtBox = new Wisej.Web.TextBox();
            this.label5 = new Wisej.Web.Label();
            this.dopdatetimePicker = new Wisej.Web.DateTimePicker();
            this.foryearcmbBox = new Wisej.Web.ComboBox();
            this.searchBtn = new Wisej.Web.Button();
            this.submitBtn = new Wisej.Web.Button();
            this.button3 = new Wisej.Web.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(15, 15);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(577, 300);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new Wisej.Web.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // label1
            // 
            this.label1.AllowHtml = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account No.:";
            // 
            // label2
            // 
            this.label2.AllowHtml = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Amount:";
            // 
            // label3
            // 
            this.label3.AllowHtml = true;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 542);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "For Year:";
            // 
            // label4
            // 
            this.label4.AllowHtml = true;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 493);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "OR No.:";
            // 
            // accountnotxtBox
            // 
            this.accountnotxtBox.Location = new System.Drawing.Point(131, 332);
            this.accountnotxtBox.Name = "accountnotxtBox";
            this.accountnotxtBox.Size = new System.Drawing.Size(194, 22);
            this.accountnotxtBox.TabIndex = 5;
            // 
            // amounttxtBox
            // 
            this.amounttxtBox.Location = new System.Drawing.Point(131, 435);
            this.amounttxtBox.Name = "amounttxtBox";
            this.amounttxtBox.Size = new System.Drawing.Size(194, 22);
            this.amounttxtBox.TabIndex = 6;
            // 
            // ornotxtBox
            // 
            this.ornotxtBox.Location = new System.Drawing.Point(131, 485);
            this.ornotxtBox.Name = "ornotxtBox";
            this.ornotxtBox.Size = new System.Drawing.Size(194, 22);
            this.ornotxtBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AllowHtml = true;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Date of Payment:";
            // 
            // dopdatetimePicker
            // 
            this.dopdatetimePicker.Format = Wisej.Web.DateTimePickerFormat.Short;
            this.dopdatetimePicker.Location = new System.Drawing.Point(131, 379);
            this.dopdatetimePicker.Name = "dopdatetimePicker";
            this.dopdatetimePicker.Size = new System.Drawing.Size(194, 22);
            this.dopdatetimePicker.TabIndex = 9;
            this.dopdatetimePicker.ValueChanged += new System.EventHandler(this.dopdatetimePicker_ValueChanged);
            // 
            // foryearcmbBox
            // 
            this.foryearcmbBox.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.foryearcmbBox.Location = new System.Drawing.Point(131, 534);
            this.foryearcmbBox.Name = "foryearcmbBox";
            this.foryearcmbBox.Size = new System.Drawing.Size(194, 22);
            this.foryearcmbBox.TabIndex = 10;
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.Color.FromArgb(0, 122, 255);
            this.searchBtn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.searchBtn.Location = new System.Drawing.Point(436, 379);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(100, 37);
            this.searchBtn.TabIndex = 11;
            this.searchBtn.Text = "Search";
            this.searchBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.FromArgb(6, 255, 0);
            this.submitBtn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.submitBtn.Location = new System.Drawing.Point(436, 458);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(100, 37);
            this.submitBtn.TabIndex = 12;
            this.submitBtn.Text = "Submit";
            this.submitBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
            this.button3.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.button3.Location = new System.Drawing.Point(436, 501);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 37);
            this.button3.TabIndex = 13;
            this.button3.Text = "Cancel";
            // 
            // PaymentAEC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 591);
            this.CloseBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.foryearcmbBox);
            this.Controls.Add(this.dopdatetimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ornotxtBox);
            this.Controls.Add(this.amounttxtBox);
            this.Controls.Add(this.accountnotxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentAEC";
            this.StartPosition = Wisej.Web.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.DataGridView dataGridView1;
        private Wisej.Web.Label label1;
        private Wisej.Web.Label label2;
        private Wisej.Web.Label label3;
        private Wisej.Web.Label label4;
        private Wisej.Web.TextBox accountnotxtBox;
        private Wisej.Web.TextBox amounttxtBox;
        private Wisej.Web.TextBox ornotxtBox;
        private Wisej.Web.Label label5;
        private Wisej.Web.DateTimePicker dopdatetimePicker;
        private Wisej.Web.ComboBox foryearcmbBox;
        private Wisej.Web.Button searchBtn;
        private Wisej.Web.Button submitBtn;
        private Wisej.Web.Button button3;
    }
}
