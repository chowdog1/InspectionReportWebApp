namespace InspectionReportWebApp
{
    partial class Violations
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
            this.acctnotextBox = new Wisej.Web.TextBox();
            this.label2 = new Wisej.Web.Label();
            this.ovrtextBox = new Wisej.Web.TextBox();
            this.label3 = new Wisej.Web.Label();
            this.label4 = new Wisej.Web.Label();
            this.violationschklistBox = new Wisej.Web.CheckedListBox();
            this.eoeechklistBox = new Wisej.Web.CheckedListBox();
            this.label5 = new Wisej.Web.Label();
            this.apprehensiondatetimePicker = new Wisej.Web.DateTimePicker();
            this.groupBox1 = new Wisej.Web.GroupBox();
            this.paidyesradioBtn = new Wisej.Web.RadioButton();
            this.paidnoradioBtn = new Wisej.Web.RadioButton();
            this.label6 = new Wisej.Web.Label();
            this.label7 = new Wisej.Web.Label();
            this.ornotextBox = new Wisej.Web.TextBox();
            this.dopdatetimePicker = new Wisej.Web.DateTimePicker();
            this.paymentbreakdownBtn = new Wisej.Web.Button();
            this.submitBtn = new Wisej.Web.Button();
            this.cancelBtn = new Wisej.Web.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(17, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(750, 243);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AllowHtml = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account No.:";
            // 
            // acctnotextBox
            // 
            this.acctnotextBox.Location = new System.Drawing.Point(102, 273);
            this.acctnotextBox.Name = "acctnotextBox";
            this.acctnotextBox.Size = new System.Drawing.Size(181, 22);
            this.acctnotextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AllowHtml = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "OVR:";
            // 
            // ovrtextBox
            // 
            this.ovrtextBox.Location = new System.Drawing.Point(351, 272);
            this.ovrtextBox.Name = "ovrtextBox";
            this.ovrtextBox.Size = new System.Drawing.Size(209, 22);
            this.ovrtextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AllowHtml = true;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(372, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Violations (ADD VIOLATIONS ONLY IF TICKETED BY EO/EE):";
            // 
            // label4
            // 
            this.label4.AllowHtml = true;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "EO and EE:";
            // 
            // violationschklistBox
            // 
            this.violationschklistBox.Items.AddRange(new object[] {
            "3504-2A C.O. #35-2004 SEC. 2A (NO SEGREGATION)",
            "3099-5C C.O. #30-1999 SEC. 5C (NO LABELED MARK)",
            "9494-1 C.O. #94-1994 SEC. 1 (NO COVERED)",
            "5F-03D C.O. #91-2013 SEC. 5F-03D (NO ANTI-POLLUTION DEVICES)",
            "911-31 C.O. #09-2011 SEC. 3-1 (ANTI-LITTERING)",
            "2111-142 C.O. #21-2011 SEC. 14-2 (FAILURE TO DESLUDGE SEPTIC TANK)",
            "5F-03E C.O. #91-2013 SEC. 5F-03E (NO DENR-EMB PERMITS)",
            "5F-03B C.O. #91-2013 SEC. 5F-03B (NO PCO)",
            "1511-1B C.O. #15-2011 SEC. 1B (PROPER DISPOSAL OF USED COOKING OIL)",
            "5F-03A C.O. #91-2013 SEC. 5F-03A (FAILURE TO PAY EPP FEE)",
            "5F-03C C.O. #91-2013 SEC. 5F-03C (Refusal of ENTRY)",
            "517-A C.O. #05-2017 SEC. A (SMOKING IN PUBLIC PLACES)",
            "517-B C.O. #05-2017 SEC. B (PERSON INCHARGE)",
            "517-H C.O. #05-2017 SEC. H (SELLING TOBACCO W/O PERMIT)",
            "517-P C.O. #05-2017 SEC. P (DISPLAY & PLACE TOBACCO PRODUCT)"});
            this.violationschklistBox.Location = new System.Drawing.Point(17, 333);
            this.violationschklistBox.Name = "violationschklistBox";
            this.violationschklistBox.Size = new System.Drawing.Size(432, 254);
            this.violationschklistBox.TabIndex = 7;
            // 
            // eoeechklistBox
            // 
            this.eoeechklistBox.Items.AddRange(new object[] {
            "Alfa Teodosio",
            "Michelle Anora",
            "Jenny Sandrino",
            "Dwight Babagay",
            "Gina Terana",
            "Edwin Paderes",
            "Carmencita Valdemoro",
            "Princess Eduarte",
            "Lhen Landoy",
            "Anna Pacheco"});
            this.eoeechklistBox.Location = new System.Drawing.Point(455, 333);
            this.eoeechklistBox.Name = "eoeechklistBox";
            this.eoeechklistBox.Size = new System.Drawing.Size(312, 218);
            this.eoeechklistBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AllowHtml = true;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(461, 565);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Apprehension Date:";
            // 
            // apprehensiondatetimePicker
            // 
            this.apprehensiondatetimePicker.Anchor = ((Wisej.Web.AnchorStyles)(((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom) 
            | Wisej.Web.AnchorStyles.Left)));
            this.apprehensiondatetimePicker.Location = new System.Drawing.Point(581, 561);
            this.apprehensiondatetimePicker.Name = "apprehensiondatetimePicker";
            this.apprehensiondatetimePicker.Size = new System.Drawing.Size(186, 22);
            this.apprehensiondatetimePicker.TabIndex = 10;
            this.apprehensiondatetimePicker.ValueChanged += new System.EventHandler(this.apprehensiondatetimePicker_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.paidnoradioBtn);
            this.groupBox1.Controls.Add(this.paidyesradioBtn);
            this.groupBox1.Location = new System.Drawing.Point(17, 596);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 98);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.Text = "Already Paid?";
            // 
            // paidyesradioBtn
            // 
            this.paidyesradioBtn.Location = new System.Drawing.Point(28, 25);
            this.paidyesradioBtn.Name = "paidyesradioBtn";
            this.paidyesradioBtn.Size = new System.Drawing.Size(55, 22);
            this.paidyesradioBtn.TabIndex = 0;
            this.paidyesradioBtn.TabStop = true;
            this.paidyesradioBtn.Text = "Yes";
            // 
            // paidnoradioBtn
            // 
            this.paidnoradioBtn.Location = new System.Drawing.Point(28, 58);
            this.paidnoradioBtn.Name = "paidnoradioBtn";
            this.paidnoradioBtn.Size = new System.Drawing.Size(49, 22);
            this.paidnoradioBtn.TabIndex = 1;
            this.paidnoradioBtn.TabStop = true;
            this.paidnoradioBtn.Text = "No";
            // 
            // label6
            // 
            this.label6.AllowHtml = true;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 621);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "OR:";
            // 
            // label7
            // 
            this.label7.AllowHtml = true;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(147, 661);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Date of Payment:";
            // 
            // ornotextBox
            // 
            this.ornotextBox.Location = new System.Drawing.Point(181, 618);
            this.ornotextBox.Name = "ornotextBox";
            this.ornotextBox.Size = new System.Drawing.Size(263, 22);
            this.ornotextBox.TabIndex = 14;
            // 
            // dopdatetimePicker
            // 
            this.dopdatetimePicker.Anchor = ((Wisej.Web.AnchorStyles)(((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Bottom) 
            | Wisej.Web.AnchorStyles.Left)));
            this.dopdatetimePicker.Location = new System.Drawing.Point(258, 657);
            this.dopdatetimePicker.Name = "dopdatetimePicker";
            this.dopdatetimePicker.Size = new System.Drawing.Size(186, 22);
            this.dopdatetimePicker.TabIndex = 15;
            this.dopdatetimePicker.ValueChanged += new System.EventHandler(this.dopdatetimePicker_ValueChanged);
            // 
            // paymentbreakdownBtn
            // 
            this.paymentbreakdownBtn.BackColor = System.Drawing.Color.FromArgb(103, 191, 63);
            this.paymentbreakdownBtn.Location = new System.Drawing.Point(460, 596);
            this.paymentbreakdownBtn.Name = "paymentbreakdownBtn";
            this.paymentbreakdownBtn.Size = new System.Drawing.Size(307, 27);
            this.paymentbreakdownBtn.TabIndex = 16;
            this.paymentbreakdownBtn.Text = "PAYMENT BREAKDOWN";
            this.paymentbreakdownBtn.Click += new System.EventHandler(this.paymentbreakdownBtn_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.FromArgb(0, 158, 255);
            this.submitBtn.Location = new System.Drawing.Point(461, 638);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(307, 27);
            this.submitBtn.TabIndex = 17;
            this.submitBtn.Text = "SUBMIT";
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.FromName("@invalid");
            this.cancelBtn.Location = new System.Drawing.Point(461, 671);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(307, 27);
            this.cancelBtn.TabIndex = 18;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // Violations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 717);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.paymentbreakdownBtn);
            this.Controls.Add(this.dopdatetimePicker);
            this.Controls.Add(this.ornotextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.apprehensiondatetimePicker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.eoeechklistBox);
            this.Controls.Add(this.violationschklistBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ovrtextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.acctnotextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Violations";
            this.StartPosition = Wisej.Web.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.DataGridView dataGridView1;
        private Wisej.Web.Label label1;
        private Wisej.Web.TextBox acctnotextBox;
        private Wisej.Web.Label label2;
        private Wisej.Web.TextBox ovrtextBox;
        private Wisej.Web.Label label3;
        private Wisej.Web.Label label4;
        private Wisej.Web.CheckedListBox violationschklistBox;
        private Wisej.Web.CheckedListBox eoeechklistBox;
        private Wisej.Web.Label label5;
        private Wisej.Web.DateTimePicker apprehensiondatetimePicker;
        private Wisej.Web.GroupBox groupBox1;
        private Wisej.Web.RadioButton paidnoradioBtn;
        private Wisej.Web.RadioButton paidyesradioBtn;
        private Wisej.Web.Label label6;
        private Wisej.Web.Label label7;
        private Wisej.Web.TextBox ornotextBox;
        private Wisej.Web.DateTimePicker dopdatetimePicker;
        private Wisej.Web.Button paymentbreakdownBtn;
        private Wisej.Web.Button submitBtn;
        private Wisej.Web.Button cancelBtn;
    }
}
