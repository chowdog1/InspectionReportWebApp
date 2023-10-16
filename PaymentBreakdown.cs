using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using Wisej.Web;


namespace InspectionReportWebApp
{
    public partial class PaymentBreakdown : Form
    {
        private string accountNo;
        private List<ViolationClass> violationsList;
        public PaymentBreakdown(string accountNo, List<ViolationClass> violationsList)
        {
            InitializeComponent();
            this.accountNo = accountNo;
            this.violationsList = violationsList;
            PopulateLabels();
        }
        private void PopulateLabels()
        {
            // Assuming you have labels named lblAccountNo, lblBusinessName, lblApprehensionDate, lblViolation, lblInspector, and lblOVR

            if (violationsList.Count > 0)
            {
                // Display the first item in the list (you can loop through the list to display all items)
                var violation = violationsList[0];

                lblAccountNo.Text = "Account Number: " + violation.AccountNo;
                lblBusinessName.Text = "Business Name: " + violation.BusinessName;
                lblApprehension.Text = "Apprehension Date: " + violation.ApprehensionDate?.ToString("yyyy-MM-dd");

                decimal total = 0;

                Dictionary<string, decimal> violationFees = new Dictionary<string, decimal>
                {
                    { "3504-2A C.O. #35-2004 SEC. 2A (NO SEGREGATION)", 1000.0m },
                    { "3099-5C C.O. #30-1999 SEC. 5C (NO LABELED MARK)", 500.0m },
                    { "9494-1 C.O. #94-1994 SEC. 1 (NO COVERED)", 500.0m },
                    { "5F-03D C.O. #91-2013 SEC. 5F-03D (NO ANTI-POLLUTION DEVICES)", 5000.0m },
                    { "911-31 C.O. #09-2011 SEC. 3-1 (ANTI-LITTERING)", 500.0m },
                    { "2111-142 C.O. #21-2011 SEC. 14-2 (FAILURE TO DESLUDGE SEPTIC TANK)", 3000.0m },
                    { "5F-03E C.O. #91-2013 SEC. 5F-03E (NO DENR-EMB PERMITS)", 5000.0m },
                    { "5F-03B C.O. #91-2013 SEC. 5F-03B (NO PCO)", 2500.0m },
                    { "1511-1B C.O. #15-2011 SEC. 1B (PROPER DISPOSAL OF USED COOKING OIL)", 5000.0m },
                    { "5F-03A C.O. #91-2013 SEC. 5F-03A (FAILURE TO PAY EPP FEE)", 2500.0m },
                    { "5F-03C C.O. #91-2013 SEC. 5F-03C (Refusal of ENTRY)", 2500.0m },
                    { "517-A C.O. #05-2017 SEC. A (SMOKING IN PUBLIC PLACES)", 1000.0m },
                    { "517-B C.O. #05-2017 SEC. B (PERSON INCHARGE)", 1000.0m },
                    { "517-H C.O. #05-2017 SEC. H (SELLING TOBACCO W/O PERMIT)", 2000.0m },
                    { "517-P C.O. #05-2017 SEC. P (DISPLAY & PLACE TOBACCO PRODUCT)", 2000.0m }
                };


                lblViolations.Text = "Violations:\n";
                if (!string.IsNullOrEmpty(violation.ViolationCommitted))
                {
                    // Split the violations by commas and add each one as a new line
                    string[] violations = violation.ViolationCommitted.Split(',');

                    // Determine the maximum width needed for the fees
                    int maxViolationWidth = 5;

                    foreach (string singleViolation in violations)
                    {
                        string trimmedViolation = singleViolation.Trim();
                        decimal fee;
                        if (!violationFees.TryGetValue(trimmedViolation, out fee))
                        {
                            fee = 0; // Set the default value if the key is not found
                        }
                        total += fee;

                        // Calculate the width of the violation as a string
                        int violationWidth = trimmedViolation.Length;
                        if (violationWidth > maxViolationWidth)
                        {
                            maxViolationWidth = violationWidth;
                        }
                    }

                    foreach (string singleViolation in violations)
                    {
                        string trimmedViolation = singleViolation.Trim();
                        decimal fee;
                        if (!violationFees.TryGetValue(trimmedViolation, out fee))
                        {
                            fee = 0; // Set the default value if the key is not found
                        }

                        // Create a formatted string with the violation and fee columns aligned
                        string violationLine = String.Format("{0,-" + maxViolationWidth + "} {1,20:C2}", trimmedViolation, fee);

                        lblViolations.Text += violationLine + "\n";
                    }

                    // Set the font to a monospaced font for proper alignment
                    lblViolations.Font = new Font("Courier New", 10); // You can adjust the font size if needed
                }

                lblInspectors.Text = "Inspectors: ";
                if (!string.IsNullOrEmpty(violation.Inspector))
                {
                    // Split the inspectors by commas and add each one as a new line
                    string[] inspectors = violation.Inspector.Split(',');

                    for (int i = 0; i < inspectors.Length; i++)
                    {
                        string singleInspector = inspectors[i].Trim();
                        if (i == 0)
                        {
                            lblInspectors.Text += " " + singleInspector; // Display the first inspector without a newline
                        }
                        else
                        {
                            lblInspectors.Text += "\n             " + singleInspector; // Add spaces for alignment
                        }
                    }
                }
                lblOVR.Text = "OVR: " + violation.OVR;
                lblTotal.Text = "Total Fees: " + total.ToString("C2");
            }
            else
            {
                // Handle the case where the list is empty or no data is available
                lblAccountNo.Text = "Account Number: ";
                lblBusinessName.Text = "Business Name: ";
                lblApprehension.Text = "Apprehension Date: ";
                lblViolations.Text = "Violation: ";
                lblInspectors.Text = "Inspector: ";
                lblOVR.Text = "OVR: ";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont regularFont = new XFont("Courier New", 8);
                XFont labelFont = new XFont("Courier New", 8, XFontStyle.Bold);
                XFont LabelTotalFont = new XFont("Courier New", 12, XFontStyle.Bold);
                XFont RegularTotalFont = new XFont("Courier New", 12);
                XTextFormatter tf = new XTextFormatter(gfx);

                string accountno = lblAccountNo.Text;
                string businessname = lblBusinessName.Text;
                string ovr = lblOVR.Text;
                string inspectors = lblInspectors.Text;
                string apprehension = lblApprehension.Text;
                string violations = lblViolations.Text;
                string totalfee = lblTotal.Text;

                tf.DrawString("Account Number:", labelFont, XBrushes.Black, new XRect(30, 50, 1000, 20), XStringFormats.TopLeft);
                tf.DrawString(accountno.Replace("Account Number:", ""), regularFont, XBrushes.Black, new XRect(100, 50, 1000, 20), XStringFormats.TopLeft);
                tf.DrawString("Business Name:", labelFont, XBrushes.Black, new XRect(30, 80, 1000, 20), XStringFormats.TopLeft);
                tf.DrawString(businessname.Replace("Business Name:", ""), regularFont, XBrushes.Black, new XRect(100, 80, 1000, 20), XStringFormats.TopLeft);
                tf.DrawString("Apprehension Date:", labelFont, XBrushes.Black, new XRect(390, 50, 1000, 20), XStringFormats.TopLeft);
                tf.DrawString(apprehension.Replace("Apprehension Date:", ""), regularFont, XBrushes.Black, new XRect(480, 50, 1000, 20), XStringFormats.TopLeft);
                tf.DrawString("Inspectors:", labelFont, XBrushes.Black, new XRect(390, 80, 1000, 1000), XStringFormats.TopLeft);
                string[] inspectorLines = inspectors.Replace("Inspectors:", "").Split('\n');
                float yCoordinate = 80;

                foreach (var line in inspectorLines)
                {
                    tf.DrawString(line.Trim(), regularFont, XBrushes.Black, new XRect(450, yCoordinate, 1000, 1000), XStringFormats.TopLeft);
                    yCoordinate += regularFont.Height;
                }
                tf.DrawString("OVR:", labelFont, XBrushes.Black, new XRect(30, 120, 1000, 20), XStringFormats.TopLeft);
                tf.DrawString(ovr.Replace("OVR:", ""), regularFont, XBrushes.Black, new XRect(50, 120, 1000, 20), XStringFormats.TopLeft);
                tf.DrawString("Violations:", labelFont, XBrushes.Black, new XRect(30, 160, 1000, 1000), XStringFormats.TopLeft);
                string[] violationLines = violations.Replace("Violations:", "").Split('\n');
                float yCoordinates = 170;

                foreach (var line in violationLines)
                {
                    tf.DrawString(line.Trim(), regularFont, XBrushes.Black, new XRect(30, yCoordinates, 1000, 1000), XStringFormats.TopLeft);
                    yCoordinates += regularFont.Height;
                }
                tf.DrawString("Total Fees:", LabelTotalFont, XBrushes.Black, new XRect(260, 310, 1000, 1000), XStringFormats.TopLeft);
                tf.DrawString(totalfee.Replace("Total Fees:", ""), RegularTotalFont, XBrushes.Black, new XRect(340, 310, 1000, 1000), XStringFormats.TopLeft);
                tf.DrawString("ISSUED BY:_____________________________", labelFont, XBrushes.Black, new XRect(30, 390, 1000, 1000), XStringFormats.TopLeft);

                using (MemoryStream stream = new MemoryStream())
                {
                    document.Save(stream);

                    // Specify the full path to the Google Chrome executable
                    string chromePath = @"C:\Program Files (x86)\AVAST Software\Browser\Application\AvastBrowser.exe"; // Update with the correct path

                    // Create a temporary PDF file to open in Chrome
                    string tempPdfPath = Path.Combine(Path.GetTempPath(), "temp.pdf");

                    // Check if the temporary PDF file exists
                    if (File.Exists(tempPdfPath))
                    {
                        // Delete the temporary PDF file
                        File.Delete(tempPdfPath);
                    }

                    // Create the temporary PDF file
                    File.WriteAllBytes(tempPdfPath, stream.ToArray());

                    // Open the temporary PDF file with Google Chrome
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = chromePath,
                        Arguments = $"\"{tempPdfPath}\"",
                        UseShellExecute = true,
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
