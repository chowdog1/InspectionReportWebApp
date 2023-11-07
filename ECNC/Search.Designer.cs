namespace InspectionReportWebApp.ECNC
{
    partial class Search
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
            this.applicationnotxtBox = new Wisej.Web.TextBox();
            this.brgycmbBox = new Wisej.Web.ComboBox();
            this.projecttypecmbBox = new Wisej.Web.ComboBox();
            this.searchBtn = new Wisej.Web.Button();
            this.button2 = new Wisej.Web.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(16, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(832, 424);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AllowHtml = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(16, 473);
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
            this.label2.Location = new System.Drawing.Point(16, 517);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Barangay:";
            // 
            // label3
            // 
            this.label3.AllowHtml = true;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(360, 472);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Project Type:";
            // 
            // applicationnotxtBox
            // 
            this.applicationnotxtBox.Location = new System.Drawing.Point(130, 469);
            this.applicationnotxtBox.Name = "applicationnotxtBox";
            this.applicationnotxtBox.Size = new System.Drawing.Size(215, 22);
            this.applicationnotxtBox.TabIndex = 4;
            // 
            // brgycmbBox
            // 
            this.brgycmbBox.Items.AddRange(new object[] {
            "Addition Hills",
            "Balong Bato",
            "Batis",
            "Corazon De Jesus",
            "Ermitaño",
            "Greenhills",
            "Isabelita",
            "Kabayanan",
            "Little Baguio",
            "Maytunas",
            "Onse",
            "Pasadena",
            "Pedro Cruz",
            "Progreso",
            "Rivera",
            "Salapan",
            "San Perfecto",
            "St. Joseph",
            "Sta. Lucia",
            "Tibagan",
            "West Crame"});
            this.brgycmbBox.Location = new System.Drawing.Point(130, 513);
            this.brgycmbBox.Name = "brgycmbBox";
            this.brgycmbBox.Size = new System.Drawing.Size(215, 22);
            this.brgycmbBox.TabIndex = 5;
            // 
            // projecttypecmbBox
            // 
            this.projecttypecmbBox.Items.AddRange(new object[] {
            "Construction",
            "Renovation"});
            this.projecttypecmbBox.Location = new System.Drawing.Point(450, 469);
            this.projecttypecmbBox.Name = "projecttypecmbBox";
            this.projecttypecmbBox.Size = new System.Drawing.Size(189, 22);
            this.projecttypecmbBox.TabIndex = 6;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(670, 467);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(163, 33);
            this.searchBtn.TabIndex = 7;
            this.searchBtn.Text = "Search";
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(670, 511);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 33);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 573);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.projecttypecmbBox);
            this.Controls.Add(this.brgycmbBox);
            this.Controls.Add(this.applicationnotxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Search";
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
        private Wisej.Web.TextBox applicationnotxtBox;
        private Wisej.Web.ComboBox brgycmbBox;
        private Wisej.Web.ComboBox projecttypecmbBox;
        private Wisej.Web.Button searchBtn;
        private Wisej.Web.Button button2;
    }
}
