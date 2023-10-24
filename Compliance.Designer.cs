namespace InspectionReportWebApp
{
    partial class Compliance
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new Wisej.Web.DataGridView();
            this.label1 = new Wisej.Web.Label();
            this.acctnotextBox = new Wisej.Web.TextBox();
            this.groupBox1 = new Wisej.Web.GroupBox();
            this.submittednoradioBtn = new Wisej.Web.RadioButton();
            this.submittedyesradioBtn = new Wisej.Web.RadioButton();
            this.label2 = new Wisej.Web.Label();
            this.compliancechklistBox = new Wisej.Web.CheckedListBox();
            this.label3 = new Wisej.Web.Label();
            this.otherstextBox = new Wisej.Web.TextBox();
            this.confirmBtn = new Wisej.Web.Button();
            this.cancelBtn = new Wisej.Web.Button();
            this.mainMenu1 = new Wisej.Web.MainMenu(this.components);
            this.menuItem1 = new Wisej.Web.MenuItem();
            this.menuItem2 = new Wisej.Web.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(24, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(600, 195);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AllowHtml = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account No.:";
            // 
            // acctnotextBox
            // 
            this.acctnotextBox.Location = new System.Drawing.Point(133, 272);
            this.acctnotextBox.Name = "acctnotextBox";
            this.acctnotextBox.Size = new System.Drawing.Size(188, 22);
            this.acctnotextBox.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.submittednoradioBtn);
            this.groupBox1.Controls.Add(this.submittedyesradioBtn);
            this.groupBox1.Location = new System.Drawing.Point(411, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 82);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.Text = "Submitted?";
            // 
            // submittednoradioBtn
            // 
            this.submittednoradioBtn.AllowHtml = true;
            this.submittednoradioBtn.Location = new System.Drawing.Point(57, 34);
            this.submittednoradioBtn.Name = "submittednoradioBtn";
            this.submittednoradioBtn.Size = new System.Drawing.Size(49, 22);
            this.submittednoradioBtn.TabIndex = 1;
            this.submittednoradioBtn.TabStop = true;
            this.submittednoradioBtn.Text = "No";
            // 
            // submittedyesradioBtn
            // 
            this.submittedyesradioBtn.AllowHtml = true;
            this.submittedyesradioBtn.Location = new System.Drawing.Point(6, 34);
            this.submittedyesradioBtn.Name = "submittedyesradioBtn";
            this.submittedyesradioBtn.Size = new System.Drawing.Size(55, 22);
            this.submittedyesradioBtn.TabIndex = 0;
            this.submittedyesradioBtn.TabStop = true;
            this.submittedyesradioBtn.Text = "Yes";
            // 
            // label2
            // 
            this.label2.AllowHtml = true;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "For Compliance:";
            // 
            // compliancechklistBox
            // 
            this.compliancechklistBox.AllowHtml = true;
            this.compliancechklistBox.Items.AddRange(new object[] {
            "Environmental Compliance Certificate",
            "Certificate of Non-Coverage",
            "Wastewater Discharge Permit",
            "Hazardous Waste Generator ID",
            "Pollution Control Officer",
            "Permit to Operate For Air Pollution Source Installation or Equipment",
            "Transport, Storage and Disposal Certificate",
            "Installation of Septic Tank/Desludging Certificate Issued by DENR-EMB Accredited " +
                "Hauler",
            "Installation of Grease Trap",
            "Waste Segregation Bins with Proper Markings and Cover"});
            this.compliancechklistBox.Location = new System.Drawing.Point(133, 350);
            this.compliancechklistBox.Name = "compliancechklistBox";
            this.compliancechklistBox.Size = new System.Drawing.Size(493, 158);
            this.compliancechklistBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AllowHtml = true;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 536);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Others:";
            // 
            // otherstextBox
            // 
            this.otherstextBox.Location = new System.Drawing.Point(133, 532);
            this.otherstextBox.Multiline = true;
            this.otherstextBox.Name = "otherstextBox";
            this.otherstextBox.Size = new System.Drawing.Size(278, 91);
            this.otherstextBox.TabIndex = 7;
            // 
            // confirmBtn
            // 
            this.confirmBtn.BackColor = System.Drawing.Color.FromArgb(0, 110, 255);
            this.confirmBtn.Font = new System.Drawing.Font("Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.confirmBtn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.confirmBtn.Location = new System.Drawing.Point(467, 543);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(134, 27);
            this.confirmBtn.TabIndex = 8;
            this.confirmBtn.Text = "CONFIRM";
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Red;
            this.cancelBtn.Font = new System.Drawing.Font("Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cancelBtn.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.cancelBtn.Location = new System.Drawing.Point(467, 585);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(134, 27);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.menuItem1});
            this.mainMenu1.Name = "mainMenu1";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new Wisej.Web.MenuItem[] {
            this.menuItem2});
            this.menuItem1.Name = "menuItem1";
            this.menuItem1.Text = "Option";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Name = "menuItem2";
            this.menuItem2.Text = "Print";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // Compliance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 659);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.otherstextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.compliancechklistBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.acctnotextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = Wisej.Web.FormBorderStyle.Fixed;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "Compliance";
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
        private Wisej.Web.GroupBox groupBox1;
        private Wisej.Web.RadioButton submittednoradioBtn;
        private Wisej.Web.RadioButton submittedyesradioBtn;
        private Wisej.Web.Label label2;
        private Wisej.Web.CheckedListBox compliancechklistBox;
        private Wisej.Web.Label label3;
        private Wisej.Web.TextBox otherstextBox;
        private Wisej.Web.Button confirmBtn;
        private Wisej.Web.Button cancelBtn;
        private Wisej.Web.MainMenu mainMenu1;
        private Wisej.Web.MenuItem menuItem1;
        private Wisej.Web.MenuItem menuItem2;
    }
}
