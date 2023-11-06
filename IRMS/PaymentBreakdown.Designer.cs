namespace InspectionReportWebApp
{
    partial class PaymentBreakdown
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
            this.lblAccountNo = new Wisej.Web.Label();
            this.lblBusinessName = new Wisej.Web.Label();
            this.lblOVR = new Wisej.Web.Label();
            this.lblViolations = new Wisej.Web.Label();
            this.lblApprehension = new Wisej.Web.Label();
            this.lblInspectors = new Wisej.Web.Label();
            this.lblTotal = new Wisej.Web.Label();
            this.printBtn = new Wisej.Web.Button();
            this.SuspendLayout();
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAccountNo.Location = new System.Drawing.Point(23, 46);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(98, 15);
            this.lblAccountNo.TabIndex = 0;
            this.lblAccountNo.Text = "Account No.:";
            // 
            // lblBusinessName
            // 
            this.lblBusinessName.AutoSize = true;
            this.lblBusinessName.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBusinessName.Location = new System.Drawing.Point(23, 80);
            this.lblBusinessName.Name = "lblBusinessName";
            this.lblBusinessName.Size = new System.Drawing.Size(114, 15);
            this.lblBusinessName.TabIndex = 1;
            this.lblBusinessName.Text = "Business Name:";
            // 
            // lblOVR
            // 
            this.lblOVR.AutoSize = true;
            this.lblOVR.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOVR.Location = new System.Drawing.Point(23, 121);
            this.lblOVR.Name = "lblOVR";
            this.lblOVR.Size = new System.Drawing.Size(36, 15);
            this.lblOVR.TabIndex = 2;
            this.lblOVR.Text = "OVR:";
            // 
            // lblViolations
            // 
            this.lblViolations.AutoSize = true;
            this.lblViolations.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblViolations.Location = new System.Drawing.Point(23, 165);
            this.lblViolations.Name = "lblViolations";
            this.lblViolations.Size = new System.Drawing.Size(90, 15);
            this.lblViolations.TabIndex = 3;
            this.lblViolations.Text = "Violations:";
            // 
            // lblApprehension
            // 
            this.lblApprehension.AutoSize = true;
            this.lblApprehension.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblApprehension.Location = new System.Drawing.Point(486, 46);
            this.lblApprehension.Name = "lblApprehension";
            this.lblApprehension.Size = new System.Drawing.Size(145, 15);
            this.lblApprehension.TabIndex = 4;
            this.lblApprehension.Text = "Apprehension Date:";
            // 
            // lblInspectors
            // 
            this.lblInspectors.AutoSize = true;
            this.lblInspectors.Font = new System.Drawing.Font("Courier New", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblInspectors.Location = new System.Drawing.Point(486, 80);
            this.lblInspectors.Name = "lblInspectors";
            this.lblInspectors.Size = new System.Drawing.Size(90, 15);
            this.lblInspectors.TabIndex = 5;
            this.lblInspectors.Text = "Inspectors:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotal.Location = new System.Drawing.Point(22, 422);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(91, 28);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "TOTAL:";
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(617, 422);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(158, 40);
            this.printBtn.TabIndex = 7;
            this.printBtn.Text = "PRINT";
            this.printBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // PaymentBreakdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 504);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblInspectors);
            this.Controls.Add(this.lblApprehension);
            this.Controls.Add(this.lblViolations);
            this.Controls.Add(this.lblOVR);
            this.Controls.Add(this.lblBusinessName);
            this.Controls.Add(this.lblAccountNo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentBreakdown";
            this.StartPosition = Wisej.Web.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Label lblAccountNo;
        private Wisej.Web.Label lblBusinessName;
        private Wisej.Web.Label lblOVR;
        private Wisej.Web.Label lblViolations;
        private Wisej.Web.Label lblApprehension;
        private Wisej.Web.Label lblInspectors;
        private Wisej.Web.Label lblTotal;
        private Wisej.Web.Button printBtn;
    }
}
