using System;
using Wisej.Web;
using PdfSharp.Drawing.Layout;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;


namespace InspectionReportWebApp
{
    public partial class GeneratePDF : Form
    {
        public GeneratePDF()
        {
            InitializeComponent();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";

            string sqlQuery = "Select * from InspectionReport Where AccountNo = @AccountNo";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@AccountNo", accttxtBox.Text);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                PdfDocument document = new PdfDocument();
                                PdfPage page1 = document.AddPage();
                                XGraphics gfx = XGraphics.FromPdfPage(page1);
                                XFont regularFont = new XFont("Courier New", 8);
                                XFont labelFont = new XFont("Courier New", 8, XFontStyle.Bold);
                                XFont titleFont = new XFont("Courier New", 14, XFontStyle.Bold);
                                XTextFormatter tf = new XTextFormatter(gfx);

                                XUnit leftMargin = XUnit.FromInch(0.5);
                                XUnit rightMargin = XUnit.FromInch(0.5);
                                XUnit topMargin = XUnit.FromInch(0.5);
                                XUnit bottomMargin = XUnit.FromInch(0.5);

                                XUnit xPositioncomply = XUnit.FromInch(0.20); // Change this to the desired X position
                                XUnit yPositioncomply = XUnit.FromInch(3.80);

                                XRect rect = new XRect(xPositioncomply, yPositioncomply, page1.Width - leftMargin - rightMargin, page1.Height - topMargin - bottomMargin);

                                page1.Width = XUnit.FromMillimeter(210);
                                page1.Height = XUnit.FromMillimeter(297);

                                string AccountNo = (reader["AccountNo"] as string) ?? string.Empty;
                                string BusinessName = (reader["BusinessName"] as string) ?? string.Empty;
                                string Address = (reader["Address"] as string) ?? string.Empty;
                                string Barangay = (reader["Barangay"] as string) ?? string.Empty;
                                DateTime Date = (DateTime)reader["Date"];
                                string formattedDate = Date.ToString("yyyy-MM-dd");
                                string NatureOfBusiness = (reader["NatureOfBusiness"] as string) ?? string.Empty;
                                string EstablishmentHas = (reader["EstablishmentHas"] as string) ?? string.Empty;
                                string BusinessStatus = (reader["BusinessStatus"] as string) ?? string.Empty;
                                string EstablishmentIs = (reader["EstablishmentIs"] as string) ?? string.Empty;
                                string Violations = (reader["Violations"] as string) ?? string.Empty;
                                string ComplyWithin = (reader["ComplyWithin"] as string) ?? string.Empty;
                                string SecuretheFF = (reader["SecuretheFF"] as string) ?? string.Empty;
                                string AttendSeminar = (reader["AttendSeminar"] as string) ?? string.Empty;
                                string MayorsPermit = (reader["MayorsPermit"] as string) ?? string.Empty;
                                string EPPFee = (reader["EPPFee"] as string) ?? string.Empty;
                                string ECCCNC = (reader["ECCCNC"] as string) ?? string.Empty;
                                string ECCCNCNo = (reader["ECCCNCNo"] as string) ?? string.Empty;
                                object eccDateObject = reader["ECCDateIssued"];
                                string WDP = (reader["WDP"] as string) ?? string.Empty;
                                string WDPNo = (reader["WDPNo"] as string) ?? string.Empty;
                                object wdpDateObject = reader["WDPDateIssued"];
                                string PTO = (reader["PTO"] as string) ?? string.Empty;
                                string PTONo = (reader["PTONo"] as string) ?? string.Empty;
                                object ptoDateObject = reader["PTODateIssued"];
                                string HWID = (reader["HWID"] as string) ?? string.Empty;
                                string HWIDNo = (reader["HWIDNo"] as string) ?? string.Empty;
                                object hwidDateObject = reader["HWIDDateIssued"];
                                string HasPollutionOfficer = (reader["HasPollutionOfficer"] as string) ?? string.Empty;
                                string PollutionOfficer = (reader["PollutionOfficer"] as string) ?? string.Empty;
                                string Accreditation = (reader["Accreditation"] as string) ?? string.Empty;
                                object pocDateObject = reader["ValidityOfPOC"];
                                string ContactNo = (reader["ContactNo"] as string) ?? string.Empty;
                                string Email = (reader["Email"] as string) ?? string.Empty;
                                string HasWasteBin = (reader["HasWasteBin"] as string) ?? string.Empty;
                                string BinsLabeled = (reader["BinsLabeled"] as string) ?? string.Empty;
                                string BinsCovered = (reader["BinsCovered"] as string) ?? string.Empty;
                                string BinsSegregated = (reader["BinsSegregated"] as string) ?? string.Empty;
                                string MRF = (reader["MRF"] as string) ?? string.Empty;
                                string WasteCollected = (reader["WasteCollected"] as string) ?? string.Empty;
                                string FrequencyHauling = (reader["FrequencyHauling"] as string) ?? string.Empty;
                                string Hauler = (reader["Hauler"] as string) ?? string.Empty;
                                string HasSeptic = (reader["HasSeptic"] as string) ?? string.Empty;
                                string LocationSeptic = (reader["LocationSeptic"] as string) ?? string.Empty;
                                string FrequencyDesludge = (reader["FrequencyDesludge"] as string) ?? string.Empty;
                                object desludgeDateObject = reader["DateDesludge"];
                                string ServiceProvider = (reader["ServiceProvider"] as string) ?? string.Empty;
                                string HasGreaseTrap = (reader["HasGreaseTrap"] as string) ?? string.Empty;
                                string LocationGrease = (reader["LocationGrease"] as string) ?? string.Empty;
                                string CapacityGreaseTrap = (reader["CapacityGreaseTrap"] as string) ?? string.Empty;
                                string FrequencyGrease = (reader["FrequencyGrease"] as string) ?? string.Empty;
                                string HaulerGrease = (reader["HaulerGrease"] as string) ?? string.Empty;
                                string HasWasteWater = (reader["HasWasteWater"] as string) ?? string.Empty;
                                string UsedOilProperlyDisposed = (reader["UsedOilProperlyDisposed"] as string) ?? string.Empty;
                                string TypeofOil = (reader["TypeofOil"] as string) ?? string.Empty;
                                string FrequencyofHaulingOil = (reader["FrequencyofHaulingOil"] as string) ?? string.Empty;
                                string HaulerOil = (reader["HaulerOil"] as string) ?? string.Empty;
                                string HasAirPollutionManager = (reader["HasAirPollutionManager"] as string) ?? string.Empty;
                                string DeviceType = (reader["DeviceType"] as string) ?? string.Empty;
                                string MaintenanceProvider = (reader["MaintenanceProvider"] as string) ?? string.Empty;
                                string PurposeOfInspection = (reader["PurposeOfInspection"] as string) ?? string.Empty;
                                object reinspectDateObject = reader["ReinspectDate"];
                                string LevelofInspection = (reader["LevelofInspection"] as string) ?? string.Empty;
                                string LandUse = (reader["LandUse"] as string) ?? string.Empty;
                                string OwnershipTerms = (reader["OwnershipTerms"] as string) ?? string.Empty;
                                string Lessee = (reader["Lessee"] as string) ?? string.Empty;
                                string StandAlone = (reader["StandAlone"] as string) ?? string.Empty;
                                string EstablishmentStatus = (reader["EstablishmentStatus"] as string) ?? string.Empty;
                                string InspectorObservation = (reader["InspectorObservation"] as string) ?? string.Empty;
                                string Directives = (reader["Directives"] as string) ?? string.Empty;
                                string Recommendations = (reader["Recommendations"] as string) ?? string.Empty;
                                string Inspector = (reader["Inspector"] as string) ?? string.Empty;

                                string complytext = "The establishment must comply the following recommendations which covers the rules of doing business in the City of San Juan within ";
                                string[] comply = complytext.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                                gfx.DrawString("***NOTICE OF INSPECTION***", titleFont, XBrushes.Black, new XRect(190, 10, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Account No:", labelFont, XBrushes.Black, new XRect(10, 30, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(AccountNo, regularFont, XBrushes.Black, new XRect(70, 30, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Business Name:", labelFont, XBrushes.Black, new XRect(10, 45, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(BusinessName, regularFont, XBrushes.Black, new XRect(80, 45, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Address:", labelFont, XBrushes.Black, new XRect(10, 60, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(Address, regularFont, XBrushes.Black, new XRect(55, 60, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Barangay:", labelFont, XBrushes.Black, new XRect(10, 75, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(Barangay, regularFont, XBrushes.Black, new XRect(60, 75, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Date of Inspection:", labelFont, XBrushes.Black, new XRect(10, 90, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(formattedDate, regularFont, XBrushes.Black, new XRect(110, 90, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Establishment Has:", labelFont, XBrushes.Black, new XRect(10, 120, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(EstablishmentHas, regularFont, XBrushes.Black, new XRect(110, 120, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("VIOLATED CITY ORDINANCES:", labelFont, XBrushes.Black, new XRect(10, 135, 1000, 1000), XStringFormats.TopLeft);
                                string[] violationLines = Violations.Split('\n');
                                float yCoordinates = 150;
                                foreach (var line in violationLines)
                                {
                                    string[] segments = line.Trim().Split(new string[] { ", " }, StringSplitOptions.None);
                                    if (segments.Length > 1)
                                    {
                                        for (int i = 0; i < segments.Length - 1; i++)
                                        {
                                            tf.DrawString(segments[i], regularFont, XBrushes.Black, new XRect(10, yCoordinates, 1000, 1000), XStringFormats.TopLeft);
                                            yCoordinates += regularFont.Height;
                                        }
                                        tf.DrawString(segments[segments.Length - 1].Trim(), regularFont, XBrushes.Black, new XRect(10, yCoordinates, 1000, 1000), XStringFormats.TopLeft);
                                    }
                                    else
                                    {
                                        tf.DrawString(line.Trim(), regularFont, XBrushes.Black, new XRect(10, yCoordinates, 1000, 1000), XStringFormats.TopLeft);
                                    }

                                    yCoordinates += regularFont.Height;
                                }
                                foreach (string paragraph in comply)
                                {
                                    tf.DrawString(paragraph, regularFont, XBrushes.Black, rect, XStringFormats.TopLeft);
                                    rect = new XRect(leftMargin, rect.Top + labelFont.Height, page1.Width - leftMargin - rightMargin, page1.Height - topMargin - bottomMargin);
                                }
                                gfx.DrawString(ComplyWithin, labelFont, XBrushes.Black, new XRect(145, 283, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("from the actual date of inspection.", regularFont, XBrushes.Black, new XRect(200, 283, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("SECURE THE FOLLOWING:", labelFont, XBrushes.Black, new XRect(10, 298, 1000, 1000), XStringFormats.TopLeft);
                                string[] securethefflines = SecuretheFF.Split('\n');
                                float secureyCoordinates = 313;
                                foreach (var line in securethefflines)
                                {
                                    string[] segments = line.Trim().Split(new string[] { ", " }, StringSplitOptions.None);
                                    if (segments.Length > 1)
                                    {
                                        for (int i = 0; i < segments.Length - 1; i++)
                                        {
                                            tf.DrawString(segments[i], regularFont, XBrushes.Black, new XRect(10, secureyCoordinates, 1000, 1000), XStringFormats.TopLeft);
                                            secureyCoordinates += regularFont.Height;
                                        }
                                        tf.DrawString(segments[segments.Length - 1].Trim(), regularFont, XBrushes.Black, new XRect(10, secureyCoordinates, 1000, 1000), XStringFormats.TopLeft);
                                    }
                                    else
                                    {
                                        tf.DrawString(line.Trim(), regularFont, XBrushes.Black, new XRect(10, secureyCoordinates, 1000, 1000), XStringFormats.TopLeft);
                                    }

                                    yCoordinates += regularFont.Height;
                                }
                                gfx.DrawString("***INSPECTION CHECKLIST***", titleFont, XBrushes.Black, new XRect(190, 430, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("I. Permits & Certifications", labelFont, XBrushes.Black, new XRect(10, 455, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Mayor's Permit:", labelFont, XBrushes.Black, new XRect(10, 470, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(MayorsPermit, regularFont, XBrushes.Black, new XRect(90, 470, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("EPP Fee:", labelFont, XBrushes.Black, new XRect(10, 480, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(EPPFee, regularFont, XBrushes.Black, new XRect(60, 480, 1000, 1000), XStringFormats.TopLeft);

                                gfx.DrawString("ECC/CNC:", labelFont, XBrushes.Black, new XRect(10, 495, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(ECCCNC, regularFont, XBrushes.Black, new XRect(60, 495, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("ECC/CNC No:", labelFont, XBrushes.Black, new XRect(10, 505, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(ECCCNCNo, regularFont, XBrushes.Black, new XRect(65, 505, 1000, 1000), XStringFormats.TopLeft);

                                if (eccDateObject != DBNull.Value)
                                {
                                    DateTime ECCDateIssued = (DateTime)reader["ECCDateIssued"];
                                    string formattedECCDateIssued = ECCDateIssued.ToString("yyyy-MM-dd");
                                    gfx.DrawString("ECC/CNC Date Issued:", labelFont, XBrushes.Black, new XRect(10, 515, 1000, 1000), XStringFormats.TopLeft);
                                    gfx.DrawString(formattedECCDateIssued, regularFont, XBrushes.Black, new XRect(120, 515, 1000, 1000), XStringFormats.TopLeft);
                                }
                                else
                                {
                                    gfx.DrawString("ECC/CNC Date Issued:", labelFont, XBrushes.Black, new XRect(10, 515, 1000, 1000), XStringFormats.TopLeft);
                                    gfx.DrawString(" ", regularFont, XBrushes.Black, new XRect(120, 515, 1000, 1000), XStringFormats.TopLeft);
                                }

                                gfx.DrawString("WDP:", labelFont, XBrushes.Black, new XRect(10, 530, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(WDP, regularFont, XBrushes.Black, new XRect(40, 530, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("WDP No:", labelFont, XBrushes.Black, new XRect(10, 540, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(WDPNo, regularFont, XBrushes.Black, new XRect(60, 540, 1000, 1000), XStringFormats.TopLeft);
                                if (wdpDateObject != DBNull.Value)
                                {
                                    DateTime WDPDateIssued = (DateTime)reader["WDPDateIssued"];
                                    string formattedWDPDateIssued = WDPDateIssued.ToString("yyyy-MM-dd");
                                    gfx.DrawString("WDP Date Issued:", labelFont, XBrushes.Black, new XRect(10, 550, 1000, 1000), XStringFormats.TopLeft);
                                    gfx.DrawString(formattedWDPDateIssued, regularFont, XBrushes.Black, new XRect(90, 550, 1000, 1000), XStringFormats.TopLeft);
                                }
                                else
                                {
                                    gfx.DrawString("WDP Date Issued:", labelFont, XBrushes.Black, new XRect(10, 550, 1000, 1000), XStringFormats.TopLeft);
                                    gfx.DrawString(" ", regularFont, XBrushes.Black, new XRect(90, 550, 1000, 1000), XStringFormats.TopLeft);
                                }

                                gfx.DrawString("PTO for APSI/APSE:", labelFont, XBrushes.Black, new XRect(10, 565, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(PTO, regularFont, XBrushes.Black, new XRect(100, 565, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("PTO No:", labelFont, XBrushes.Black, new XRect(10, 575, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(PTONo, regularFont, XBrushes.Black, new XRect(40, 575, 1000, 1000), XStringFormats.TopLeft);
                                if (ptoDateObject != DBNull.Value)
                                {
                                    DateTime PTODateIssued = (DateTime)reader["PTODateIssued"];
                                    string formattedPTODateIssued = PTODateIssued.ToString("yyyy-MM-dd");
                                    gfx.DrawString("PTO Date Issued:", labelFont, XBrushes.Black, new XRect(10, 585, 1000, 1000), XStringFormats.TopLeft);
                                    gfx.DrawString(formattedPTODateIssued, regularFont, XBrushes.Black, new XRect(90, 585, 1000, 1000), XStringFormats.TopLeft);
                                }
                                else
                                {
                                    gfx.DrawString("PTO Date Issued:", labelFont, XBrushes.Black, new XRect(10, 585, 1000, 1000), XStringFormats.TopLeft);
                                    gfx.DrawString(" ", regularFont, XBrushes.Black, new XRect(95, 585, 1000, 1000), XStringFormats.TopLeft);
                                }

                                gfx.DrawString("HWID:", labelFont, XBrushes.Black, new XRect(10, 600, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(HWID, regularFont, XBrushes.Black, new XRect(40, 600, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("HWID No:", labelFont, XBrushes.Black, new XRect(10, 610, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(HWIDNo, regularFont, XBrushes.Black, new XRect(65, 610, 1000, 1000), XStringFormats.TopLeft);
                                if (hwidDateObject != DBNull.Value)
                                {
                                    DateTime HWIDDateIssued = (DateTime)reader["HWIDDateIssued"];
                                    string formattedHWIDDateIssued = HWIDDateIssued.ToString("yyyy-MM-dd");
                                    gfx.DrawString("HWID Date Issued:", labelFont, XBrushes.Black, new XRect(10, 620, 1000, 1000), XStringFormats.TopLeft);
                                    gfx.DrawString(formattedHWIDDateIssued, regularFont, XBrushes.Black, new XRect(90, 620, 1000, 1000), XStringFormats.TopLeft);
                                }
                                else
                                {
                                    gfx.DrawString("HWID Date Issued:", labelFont, XBrushes.Black, new XRect(10, 620, 1000, 1000), XStringFormats.TopLeft);
                                    gfx.DrawString(" ", regularFont, XBrushes.Black, new XRect(95, 620, 1000, 1000), XStringFormats.TopLeft);
                                }

                                gfx.DrawString("II. Pollution Control Officer", labelFont, XBrushes.Black, new XRect(10, 650, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Name:", labelFont, XBrushes.Black, new XRect(10, 665, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(PollutionOfficer, regularFont, XBrushes.Black, new XRect(30, 665, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Accreditation No:", labelFont, XBrushes.Black, new XRect(10, 675, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(Accreditation, regularFont, XBrushes.Black, new XRect(70, 675, 1000, 1000), XStringFormats.TopLeft);
                                if (pocDateObject != DBNull.Value)
                                {
                                    DateTime ValidityOfPOC = (DateTime)reader["ValidityOfPOC"];
                                    string formattedValidityOfPOC = ValidityOfPOC.ToString("yyyy-MM-dd");
                                    gfx.DrawString("Validity:", labelFont, XBrushes.Black, new XRect(10, 685, 1000, 1000), XStringFormats.TopLeft);
                                    gfx.DrawString(formattedValidityOfPOC, regularFont, XBrushes.Black, new XRect(60, 685, 1000, 1000), XStringFormats.TopLeft);
                                }
                                else
                                {
                                    gfx.DrawString("Validity:", labelFont, XBrushes.Black, new XRect(10, 685, 1000, 1000), XStringFormats.TopLeft);
                                    gfx.DrawString(" ", regularFont, XBrushes.Black, new XRect(60, 685, 1000, 1000), XStringFormats.TopLeft);
                                }
                                gfx.DrawString("Contact No:", labelFont, XBrushes.Black, new XRect(10, 695, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(ContactNo, regularFont, XBrushes.Black, new XRect(40, 695, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Email Address:", labelFont, XBrushes.Black, new XRect(10, 705, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(Email, regularFont, XBrushes.Black, new XRect(80, 705, 1000, 1000), XStringFormats.TopLeft);

                                gfx.DrawString("III. Waste Management", labelFont, XBrushes.Black, new XRect(250, 455, 1000, 1000), XStringFormats.TopLeft);

                                gfx.DrawString("Waste bins were provided:", labelFont, XBrushes.Black, new XRect(250, 470, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(HasWasteBin, regularFont, XBrushes.Black, new XRect(380, 470, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Bins were properly labeled:", labelFont, XBrushes.Black, new XRect(250, 480, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(BinsLabeled, regularFont, XBrushes.Black, new XRect(390, 480, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Bins were appropriately covered:", labelFont, XBrushes.Black, new XRect(250, 490, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(BinsCovered, regularFont, XBrushes.Black, new XRect(410, 490, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Proper waste segregation was practiced:", labelFont, XBrushes.Black, new XRect(250, 500, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(BinsSegregated, regularFont, XBrushes.Black, new XRect(445, 500, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Provision of MRF:", labelFont, XBrushes.Black, new XRect(250, 510, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(MRF, regularFont, XBrushes.Black, new XRect(340, 510, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Waste were collected:", labelFont, XBrushes.Black, new XRect(250, 520, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(WasteCollected, regularFont, XBrushes.Black, new XRect(360, 520, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Frequency of Hauling:", labelFont, XBrushes.Black, new XRect(250, 530, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(FrequencyHauling, regularFont, XBrushes.Black, new XRect(360, 530, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Hauler:", labelFont, XBrushes.Black, new XRect(250, 540, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(Hauler, regularFont, XBrushes.Black, new XRect(300, 540, 1000, 1000), XStringFormats.TopLeft);

                                gfx.DrawString("Installed Septic Tank:", labelFont, XBrushes.Black, new XRect(250, 555, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(HasSeptic, regularFont, XBrushes.Black, new XRect(360, 555, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Location:", labelFont, XBrushes.Black, new XRect(250, 565, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(LocationSeptic, regularFont, XBrushes.Black, new XRect(310, 565, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Frequency of Desludging:", labelFont, XBrushes.Black, new XRect(250, 575, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(FrequencyDesludge, regularFont, XBrushes.Black, new XRect(375, 575, 1000, 1000), XStringFormats.TopLeft);
                                if (desludgeDateObject != DBNull.Value)
                                {
                                    DateTime DateDesludge = (DateTime)reader["DateDesludge"];
                                    string formattedDateDesludge = DateDesludge.ToString("yyyy-MM-dd");
                                    gfx.DrawString("Date of Desludge:", labelFont, XBrushes.Black, new XRect(250, 585, 1000, 1000), XStringFormats.TopLeft);
                                    gfx.DrawString(formattedDateDesludge, regularFont, XBrushes.Black, new XRect(340, 585, 1000, 1000), XStringFormats.TopLeft);
                                }
                                else
                                {
                                    gfx.DrawString("Date of Desludge:", labelFont, XBrushes.Black, new XRect(250, 585, 1000, 1000), XStringFormats.TopLeft);
                                    gfx.DrawString(" ", regularFont, XBrushes.Black, new XRect(340, 585, 1000, 1000), XStringFormats.TopLeft);
                                }
                                gfx.DrawString("Service Provider:", labelFont, XBrushes.Black, new XRect(250, 595, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(ServiceProvider, regularFont, XBrushes.Black, new XRect(340, 595, 1000, 1000), XStringFormats.TopLeft);

                                gfx.DrawString("Installed Grease Trap:", labelFont, XBrushes.Black, new XRect(250, 610, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(HasGreaseTrap, regularFont, XBrushes.Black, new XRect(360, 610, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Location:", labelFont, XBrushes.Black, new XRect(250, 620, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(LocationGrease, regularFont, XBrushes.Black, new XRect(310, 620, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Frequency of Hauling:", labelFont, XBrushes.Black, new XRect(250, 630, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(FrequencyGrease, regularFont, XBrushes.Black, new XRect(375, 630, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Hauler:", labelFont, XBrushes.Black, new XRect(250, 640, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(HaulerGrease, regularFont, XBrushes.Black, new XRect(300, 640, 1000, 1000), XStringFormats.TopLeft);

                                gfx.DrawString("Wastewater Treatment Plant:", labelFont, XBrushes.Black, new XRect(250, 655, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(HasWasteWater, regularFont, XBrushes.Black, new XRect(390, 655, 1000, 1000), XStringFormats.TopLeft);

                                gfx.DrawString("Used oil were properly disposed:", labelFont, XBrushes.Black, new XRect(250, 670, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(UsedOilProperlyDisposed, regularFont, XBrushes.Black, new XRect(410, 670, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Type of Oil:", labelFont, XBrushes.Black, new XRect(250, 680, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(TypeofOil, regularFont, XBrushes.Black, new XRect(310, 680, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Frequency of Hauling:", labelFont, XBrushes.Black, new XRect(250, 690, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(FrequencyofHaulingOil, regularFont, XBrushes.Black, new XRect(375, 690, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Hauler:", labelFont, XBrushes.Black, new XRect(250, 700, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(HaulerOil, regularFont, XBrushes.Black, new XRect(300, 700, 1000, 1000), XStringFormats.TopLeft);

                                gfx.DrawString("IV. Air Pollution Management", labelFont, XBrushes.Black, new XRect(250, 735, 1000, 1000), XStringFormats.TopLeft);

                                gfx.DrawString("Pollution Control Devices:", labelFont, XBrushes.Black, new XRect(250, 750, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(HasAirPollutionManager, regularFont, XBrushes.Black, new XRect(390, 750, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Device Type:", labelFont, XBrushes.Black, new XRect(250, 760, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(DeviceType, regularFont, XBrushes.Black, new XRect(300, 760, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString("Maintenance Provider:", labelFont, XBrushes.Black, new XRect(250, 770, 1000, 1000), XStringFormats.TopLeft);
                                gfx.DrawString(MaintenanceProvider, regularFont, XBrushes.Black, new XRect(360, 770, 1000, 1000), XStringFormats.TopLeft);

                                PdfPage page2 = document.AddPage();
                                XGraphics gfx2 = XGraphics.FromPdfPage(page2);
                                XFont regularFont2 = new XFont("Courier New", 8);
                                XFont italicFont2 = new XFont("Courier New", 8, XFontStyle.Italic);
                                XFont labelFont2 = new XFont("Courier New", 8, XFontStyle.Bold);
                                XFont titleFont2 = new XFont("Courier New", 14, XFontStyle.Bold);
                                XTextFormatter tf2 = new XTextFormatter(gfx2);

                                XUnit leftMargin2 = XUnit.FromInch(0.5);
                                XUnit rightMargin2 = XUnit.FromInch(0.5);
                                XUnit topMargin2 = XUnit.FromInch(0.5);
                                XUnit bottomMargin2 = XUnit.FromInch(0.5);

                                page2.Width = XUnit.FromMillimeter(210);
                                page2.Height = XUnit.FromMillimeter(297);

                                gfx2.DrawString("***After Inspection Report***", titleFont2, XBrushes.Black, new XRect(180, 10, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString("I. Purpose of Inspection:", labelFont2, XBrushes.Black, new XRect(10, 40, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString(PurposeOfInspection, regularFont2, XBrushes.Black, new XRect(140, 40, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString("Level of Inspection:", labelFont2, XBrushes.Black, new XRect(30, 50, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString(LevelofInspection, regularFont2, XBrushes.Black, new XRect(140, 50, 1000, 1000), XStringFormats.TopLeft);
                                if (reinspectDateObject != DBNull.Value)
                                {
                                    DateTime ReinspectDate = (DateTime)reader["ReinspectDate"];
                                    string formattedReinspectDate = ReinspectDate.ToString("yyyy-MM-dd");
                                    gfx2.DrawString("Date of Reinspection:", labelFont2, XBrushes.Black, new XRect(30, 60, 1000, 10000), XStringFormats.TopLeft);
                                    gfx2.DrawString(formattedReinspectDate, regularFont, XBrushes.Black, new XRect(140, 60, 1000, 1000), XStringFormats.TopLeft);
                                }
                                else
                                {
                                    gfx2.DrawString("Date of Reinspection:", labelFont2, XBrushes.Black, new XRect(30, 60, 1000, 10000), XStringFormats.TopLeft);
                                    gfx2.DrawString("N/A", regularFont, XBrushes.Black, new XRect(140, 60, 1000, 1000), XStringFormats.TopLeft);
                                }


                                gfx2.DrawString("II. General Description of the Physical Environment", labelFont2, XBrushes.Black, new XRect(10, 90, 1000, 1000), XStringFormats.TopLeft);

                                gfx2.DrawString("Land Use:", labelFont2, XBrushes.Black, new XRect(30, 110, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString(LandUse, regularFont2, XBrushes.Black, new XRect(90, 110, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString("Ownership Terms:", labelFont2, XBrushes.Black, new XRect(30, 120, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString(OwnershipTerms, regularFont2, XBrushes.Black, new XRect(120, 120, 1000, 1000), XStringFormats.TopLeft);

                                gfx2.DrawString("Occupancy Terms", labelFont2, XBrushes.Black, new XRect(10, 145, 1000, 1000), XStringFormats.TopLeft);

                                gfx2.DrawString("Lessee:", labelFont2, XBrushes.Black, new XRect(30, 155, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString(Lessee, regularFont2, XBrushes.Black, new XRect(80, 155, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString("Stand Alone:", labelFont2, XBrushes.Black, new XRect(30, 165, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString(StandAlone, regularFont2, XBrushes.Black, new XRect(110, 165, 1000, 1000), XStringFormats.TopLeft);

                                gfx2.DrawString("III. Findings and Observations", labelFont2, XBrushes.Black, new XRect(10, 220, 1000, 1000), XStringFormats.TopLeft);

                                gfx2.DrawString("Establishment Operation's Status During Operation:", labelFont2, XBrushes.Black, new XRect(30, 235, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString(EstablishmentStatus, regularFont2, XBrushes.Black, new XRect(280, 235, 1000, 1000), XStringFormats.TopLeft);

                                gfx2.DrawString("Inspectors Observation Statement:", labelFont2, XBrushes.Black, new XRect(30, 255, 1000, 1000), XStringFormats.TopLeft);
                                string[] observationLines = InspectorObservation.Split('\n');
                                float yCoordinateObs = 270;

                                foreach (var line in observationLines)
                                {
                                    string[] segments = line.Trim().Split(new string[] { "\n" }, StringSplitOptions.None);
                                    if (segments.Length > 1)
                                    {
                                        for (int i = 0; i < segments.Length - 1; i++)
                                        {
                                            tf2.DrawString(segments[i], regularFont2, XBrushes.Black, new XRect(60, yCoordinateObs, 1000, 1000), XStringFormats.TopLeft);
                                            yCoordinates += regularFont.Height;
                                        }
                                        // Append the last segment as a list item without a comma
                                        tf2.DrawString(segments[segments.Length - 1].Trim(), regularFont, XBrushes.Black, new XRect(60, yCoordinateObs, 1000, 1000), XStringFormats.TopLeft);
                                    }
                                    else
                                    {
                                        // If there are no commas in the line, just draw it as is
                                        tf2.DrawString(line.Trim(), regularFont, XBrushes.Black, new XRect(60, yCoordinateObs, 1000, 1000), XStringFormats.TopLeft);
                                    }

                                    yCoordinateObs += regularFont.Height;
                                }

                                gfx2.DrawString("IV. Directives", labelFont2, XBrushes.Black, new XRect(10, 400, 1000, 1000), XStringFormats.TopLeft);
                                string[] directivesLines = Directives.Split('\n');
                                float yCoordinateDir = 420;

                                foreach (var line in directivesLines)
                                {
                                    string[] segments = line.Trim().Split(new string[] { "\n" }, StringSplitOptions.None);
                                    if (segments.Length > 1)
                                    {
                                        for (int i = 0; i < segments.Length - 1; i++)
                                        {
                                            tf2.DrawString(segments[i], regularFont2, XBrushes.Black, new XRect(60, yCoordinateDir, 1000, 1000), XStringFormats.TopLeft);
                                            yCoordinates += regularFont2.Height;
                                        }
                                        // Append the last segment as a list item without a comma
                                        tf2.DrawString(segments[segments.Length - 1].Trim(), regularFont2, XBrushes.Black, new XRect(60, yCoordinateDir, 1000, 1000), XStringFormats.TopLeft);
                                    }
                                    else
                                    {
                                        // If there are no commas in the line, just draw it as is
                                        tf2.DrawString(line.Trim(), regularFont2, XBrushes.Black, new XRect(60, yCoordinateDir, 1000, 1000), XStringFormats.TopLeft);
                                    }

                                    yCoordinateDir += regularFont2.Height;
                                }

                                gfx2.DrawString("V. Recommendations", labelFont2, XBrushes.Black, new XRect(10, 550, 1000, 1000), XStringFormats.TopLeft);
                                string[] recommendationLines = Recommendations.Split('\n');
                                float yCoordinatereco = 570;
                                foreach (var line in recommendationLines)
                                {
                                    string[] segments = line.Trim().Split(new string[] { ", " }, StringSplitOptions.None);
                                    if (segments.Length > 1)
                                    {
                                        for (int i = 0; i < segments.Length - 1; i++)
                                        {
                                            tf2.DrawString(segments[i], regularFont2, XBrushes.Black, new XRect(60, yCoordinatereco, 1000, 1000), XStringFormats.TopLeft);
                                            yCoordinatereco += regularFont2.Height;
                                        }
                                        tf2.DrawString(segments[segments.Length - 1].Trim(), regularFont2, XBrushes.Black, new XRect(60, yCoordinatereco, 1000, 1000), XStringFormats.TopLeft);
                                    }
                                    else
                                    {
                                        tf2.DrawString(line.Trim(), regularFont2, XBrushes.Black, new XRect(60, yCoordinatereco, 1000, 1000), XStringFormats.TopLeft);
                                    }

                                    yCoordinatereco += regularFont2.Height;
                                }

                                //string[] inspectors = Inspector.Split(", ");
                                string[] inspectors = Inspector.Split(new string[] { ", " }, StringSplitOptions.None);
                                double xCoordinateinsp = 70;
                                double yCoordinateinsp = 680;

                                for (int i = 0; i < inspectors.Length; i++)
                                {
                                    string inspectorName = inspectors[i].Trim();

                                    gfx2.DrawString(inspectorName, regularFont2, XBrushes.Black, new XRect(xCoordinateinsp, yCoordinateinsp, 1000, 1000), XStringFormats.TopLeft);
                                    gfx2.DrawString("Attested:", italicFont2, XBrushes.Black, new XRect(10, 650, 1000, 1000), XStringFormats.TopLeft);
                                    gfx2.DrawString("___________________________", regularFont2, XBrushes.Black, new XRect(40, 680, 1000, 1000), XStringFormats.TopLeft);
                                    gfx2.DrawString("Environmental Inspector", labelFont2, XBrushes.Black, new XRect(50, 690, 1000, 1000), XStringFormats.TopLeft);
                                    gfx2.DrawString("___________________________", regularFont2, XBrushes.Black, new XRect(225, 680, 1000, 1000), XStringFormats.TopLeft);
                                    gfx2.DrawString("Environmental Inspector", labelFont2, XBrushes.Black, new XRect(235, 690, 1000, 1000), XStringFormats.TopLeft);
                                    gfx2.DrawString("___________________________", regularFont2, XBrushes.Black, new XRect(410, 680, 1000, 1000), XStringFormats.TopLeft);
                                    gfx2.DrawString("Environmental Inspector", labelFont2, XBrushes.Black, new XRect(420, 690, 1000, 1000), XStringFormats.TopLeft);

                                    xCoordinateinsp += 190;
                                }

                                gfx2.DrawString("Assessed by:", italicFont2, XBrushes.Black, new XRect(110, 720, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString("_______________________________________", regularFont2, XBrushes.Black, new XRect(197, 740, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString("EMS II/Pollution Control Unit Head", labelFont2, XBrushes.Black, new XRect(210, 750, 1000, 1000), XStringFormats.TopLeft);

                                gfx2.DrawString("Approved by:", italicFont2, XBrushes.Black, new XRect(110, 780, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString("Gabriel Gerard S. Katigbak", regularFont2, XBrushes.Black, new XRect(228, 798, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString("_______________________________________", regularFont2, XBrushes.Black, new XRect(197, 800, 1000, 1000), XStringFormats.TopLeft);
                                gfx2.DrawString("Department Head, CENRO", labelFont2, XBrushes.Black, new XRect(240, 810, 1000, 1000), XStringFormats.TopLeft);

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
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
