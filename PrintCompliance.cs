using PdfSharp.Drawing.Layout;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using Wisej.Web;


namespace InspectionReportWebApp
{
    public partial class PrintCompliance : Form
    {
        public PrintCompliance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string accountNumber = accttxtBox.Text;
            string query = "SELECT AccountNo, BusinessName, Compliances FROM Compliance WHERE AccountNo = @AccountNo";

            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True"))
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@AccountNo", accountNumber);
                    con.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string accountNo = reader["AccountNo"].ToString() ?? "DefaultValue";
                            string businessName = reader["BusinessName"].ToString() ?? "DefaultValue";
                            string compliances = reader["Compliances"].ToString() ?? "DefaultValue";
                            {
                                PdfDocument document = new PdfDocument();
                                PdfPage page = document.AddPage();
                                XGraphics gfx = XGraphics.FromPdfPage(page);
                                XFont font = new XFont("Arial", 10);

                                double currentX = 20;
                                double currentY = 20;
                                double pageWidth = page.Width - 2 * currentX; // Adjust for page margins

                                string[] lines = new string[]
                                {
                                    "*******FOR COMPLIANCE*******",
                                    " ",
                                    "Account No: " + accountNo,
                                    "Business Name: " + businessName,
                                    "Compliances: ",
                                    "-Environmental Compliance Certificate",
                                    "-Certificate of Non-Coverage",
                                    "-Wastewater Discharge Permit",
                                    "-Hazardous Waste Generator ID",
                                    "-Pollution Control Officer",
                                    "-Permit to Operate for Air Pollution Source Installation or Equipment",
                                    "-Transport, Storage and Disposal Certificate",
                                    "-Installation of Septic Tank/Desludging Certificate Issued by a DENR-EMB Accredited Hauler",
                                    "-Installation of Grease Trap",
                                    "-Provide waste segregation bin (Biodegradable)",
                                    "-Provide waste segregation bin (Recyclable)",
                                    "-Provide waste segregation bin (Residual)",
                                    "-Provide waste segregation bin (Special Wastes)",
                                    "-Proper waste segregation in accordance with the markings",
                                    "_________________________________________________",
                                    " ",
                                    " ",
                                    "               _________________________________",
                                    "                                  CENRO STAFF"
                                };

                                bool hasEnvironmentalCompliance = Regex.IsMatch(compliances, @"\bEnvironmental Compliance Certificate\b");
                                bool hasCNC = Regex.IsMatch(compliances, @"\bCertificate of Non-Coverage\b");
                                bool hasWWD = Regex.IsMatch(compliances, @"\bWastewater Discharge Permit\b");
                                bool hasGENID = Regex.IsMatch(compliances, @"\bHazardous Waste Generator ID\b");
                                bool hasPCO = Regex.IsMatch(compliances, @"\bPollution Control Officer\b");
                                bool hasPTO = Regex.IsMatch(compliances, @"\bPermit to Operate for Air Pollution Source Installation or Equipment\b");
                                bool hasTSD = Regex.IsMatch(compliances, @"\bTransport, Storage and Disposal Certificate\b");
                                bool hasSeptic = Regex.IsMatch(compliances, @"\bInstallation of Septic Tank/Desludging Certificate Issued by a DENR-EMB Accredited Hauler\b");
                                bool hasGrease = Regex.IsMatch(compliances, @"\bInstallation of Grease Trap\b");
                                bool hasBio = compliances.Contains("Provide waste segregation bin (Biodegradable)");
                                bool hasRecyc = compliances.Contains("Provide waste segregation bin (Recyclable)");
                                bool hasResidual = compliances.Contains("Provide waste segregation bin (Residual)");
                                bool hasSpecial = compliances.Contains("Provide waste segregation bin (Special Wastes)");
                                bool hasSeg = Regex.IsMatch(compliances, @"\bProper waste segregation in accordance with the markings\b");

                                // Define the center of the page
                                double centerX = page.Width / 2;

                                // Define the maximum allowed Y position based on the center
                                double maxY = page.Height;

                                foreach (string line in lines)
                                {
                                    bool shouldBold = false; // Variable to determine if text should be bold
                                    string displayLine = line;
                                    if (line.Contains("Environmental Compliance Certificate") && hasEnvironmentalCompliance)
                                    {
                                        displayLine = "***" + line;
                                        shouldBold = true;
                                    }
                                    else if (line.Contains("Certificate of Non-Coverage") && hasCNC)
                                    {
                                        displayLine = "***" + line;
                                        shouldBold = true;
                                    }
                                    else if (line.Contains("Wastewater Discharge Permit") && hasWWD)
                                    {
                                        displayLine = "***" + line;
                                        shouldBold = true;
                                    }
                                    else if (line.Contains("Hazardous Waste Generator ID") && hasGENID)
                                    {
                                        displayLine = "***" + line;
                                        shouldBold = true;
                                    }
                                    else if (line.Contains("Pollution Control Officer") && hasPCO)
                                    {
                                        displayLine = "***" + line;
                                        shouldBold = true;
                                    }
                                    else if (line.Contains("Permit to Operate for Air Pollution Source Installation or Equipment") && hasPTO)
                                    {
                                        displayLine = "***" + line;
                                        shouldBold = true;
                                    }
                                    else if (line.Contains("Transport, Storage and Disposal Certificate") && hasTSD)
                                    {
                                        displayLine = "***" + line;
                                        shouldBold = true;
                                    }
                                    else if (line.Contains("Installation of Septic Tank/Desludging Certificate Issued by a DENR-EMB Accredited Hauler") && hasSeptic)
                                    {
                                        displayLine = "***" + line;
                                        shouldBold = true;
                                    }
                                    else if (line.Contains("Installation of Grease Trap") && hasGrease)
                                    {
                                        displayLine = "***" + line;
                                        shouldBold = true;
                                    }
                                    else if (line.Contains("Provide waste segregation bin (Biodegradable)") && hasBio)
                                    {
                                        displayLine = "***" + line;
                                        shouldBold = true;
                                    }
                                    else if (line.Contains("Provide waste segregation bin (Recyclable)") && hasRecyc)
                                    {
                                        displayLine = "***" + line;
                                        shouldBold = true;
                                    }
                                    else if (line.Contains("Provide waste segregation bin (Residual)") && hasResidual)
                                    {
                                        displayLine = "***" + line;
                                        shouldBold = true;
                                    }
                                    else if (line.Contains("Provide waste segregation bin (Special Wastes)") && hasSpecial)
                                    {
                                        displayLine = "***" + line;
                                        shouldBold = true;
                                    }
                                    else if (line.Contains("Proper waste segregation in accordance with the markings") && hasSeg)
                                    {
                                        displayLine = "***" + line;
                                        shouldBold = true;
                                    }

                                    // Calculate text size
                                    List<string> splitLines = new List<string>();
                                    if (displayLine.Length > 50) // Adjust the threshold as needed
                                    {
                                        // Split the line into smaller chunks while preserving word boundaries
                                        string[] words = displayLine.Split(' ');
                                        StringBuilder currentLine = new StringBuilder();
                                        foreach (string word in words)
                                        {
                                            if (currentLine.Length + word.Length + 1 <= 50) // +1 for space
                                            {
                                                if (currentLine.Length > 0)
                                                    currentLine.Append(' ');
                                                currentLine.Append(word);
                                            }
                                            else
                                            {
                                                splitLines.Add(currentLine.ToString());
                                                currentLine.Clear();
                                                currentLine.Append(word);
                                            }
                                        }
                                        if (currentLine.Length > 0)
                                            splitLines.Add(currentLine.ToString());
                                    }
                                    else
                                    {
                                        // Line is short enough, no need to split
                                        splitLines.Add(displayLine);
                                    }

                                    foreach (string splitLine in splitLines)
                                    {
                                        // Calculate text size for the split line
                                        XSize textSize = gfx.MeasureString(splitLine, font);

                                        // Check if the currentY + text height exceeds the maxY
                                        if (currentY + textSize.Height > maxY)
                                        {
                                            // Start a new page
                                            page = document.AddPage();
                                            gfx = XGraphics.FromPdfPage(page);
                                            currentX = 20;
                                            currentY = 20;
                                        }

                                        // Use XTextFormatter to wrap the text within the specified width
                                        XTextFormatter tf = new XTextFormatter(gfx);

                                        // Create a font with Bold style if shouldBold is true
                                        XFont currentFont = shouldBold ? new XFont(font.Name, font.Size, XFontStyle.Bold) : font;

                                        XRect rect = new XRect(currentX, currentY, pageWidth, maxY - currentY);
                                        tf.DrawString(splitLine, currentFont, XBrushes.Black, rect, XStringFormats.TopLeft);

                                        // Update currentY for the next line
                                        currentY += textSize.Height + 5;
                                    }
                                }

                                using (MemoryStream stream = new MemoryStream())
                                {
                                    document.Save(stream);

                                    // Specify the full path to the Google Chrome executable
                                    string chromePath = @"C:\Program Files (x86)\AVAST Software\Browser\Application\AvastBrowser.exe"; // Update with the correct path

                                    // Create a temporary PDF file to open in Chrome
                                    string tempPdfPath = Path.Combine(Path.GetTempPath(), "temp.pdf");
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
                        }
                        else
                        {
                            MessageBox.Show("Account not found.");
                            this.Close();
                        }
                    }
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
