using System;
using System.Data.SqlClient;
using System.Data;
using Wisej.Web;
using OfficeOpenXml;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp;
using PdfSharp.Drawing.Layout;
using PdfSharp.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Linq;
using System.IO;
using Wisej.Core;
using System.Globalization;

namespace InspectionReportWebApp
{
    public partial class inspectionReport : Form
    {
        private int addressColumnIndex = 2;
        private DateTime? doidate;
        private DateTime? ecccncdate;
        private DateTime? ptodate;
        private DateTime? validitypcodate;
        private DateTime? septicdate;
        private DateTime? wdpdate;
        private DateTime? hwiddate;
        private DateTime? reinspectdate;
        private LogForm logform;
        private List<string> logEntries = new List<string>();
        private string logFilePath = "E:\\CENRO\\Inspection Report\\bin\\Debug\\net6.0-windows\\log.txt";
        public inspectionReport()
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from InspectionReport", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            doidate = null;
            ecccncdate = null;
            ptodate = null;
            validitypcodate = null;
            septicdate = null;
            wdpdate = null;
            hwiddate = null;
            reinspectdate = null;

            doidateTimePicker.Format = DateTimePickerFormat.Custom;
            doidateTimePicker.CustomFormat = "dd/MM/yyyy";

            ecccncdateTimePicker.Format = DateTimePickerFormat.Custom;
            ecccncdateTimePicker.CustomFormat = "dd/MM/yyyy";

            ptodateTimePicker.Format = DateTimePickerFormat.Custom;
            ptodateTimePicker.CustomFormat = "dd/MM/yyyy";

            validitypcodateTimePicker.Format = DateTimePickerFormat.Custom;
            validitypcodateTimePicker.CustomFormat = "dd/MM/yyyy";

            septicdateTimePicker.Format = DateTimePickerFormat.Custom;
            septicdateTimePicker.CustomFormat = "dd/MM/yyyy";

            wdpdateTimePicker.Format = DateTimePickerFormat.Custom;
            wdpdateTimePicker.CustomFormat = "dd/MM/yyyy";

            hwiddateTimePicker.Format = DateTimePickerFormat.Custom;
            hwiddateTimePicker.CustomFormat = "dd/MM/yyyy";

            reinspectdateTimePicker.Format = DateTimePickerFormat.Custom;
            reinspectdateTimePicker.CustomFormat = "dd/MM/yyyy";

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }
        private void levelofinspectionchklistBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == levelofinspectionchklistBox.Items.IndexOf("2nd") || e.Index == levelofinspectionchklistBox.Items.IndexOf("3rd") || e.Index == levelofinspectionchklistBox.Items.IndexOf("4th") || e.Index == levelofinspectionchklistBox.Items.IndexOf("5th"))
            {
                if (e.NewValue == CheckState.Checked)
                {
                    reinspectdateTimePicker.Enabled = true;
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    reinspectdateTimePicker.Enabled = false;
                }
            }
        }
        private void establishmenthaschklistBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == establishmenthaschklistBox.Items.IndexOf("Violated City Ordinances") || e.Index == establishmenthaschklistBox.Items.IndexOf("Notice/Warning"))
            {
                if (e.NewValue == CheckState.Checked)
                {
                    violationschklistBox.Enabled = true;
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    violationschklistBox.Enabled = false;
                }
            }
        }
        private void ecccncyesRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (ecccncyesRadioBtn.Checked)
            {
                ecccnctxtBox.Enabled = true;
                ecccncdateTimePicker.Enabled = true;
            }
            else
            {
                ecccnctxtBox.Enabled = false;
                ecccncdateTimePicker.Enabled = false;
            }
        }
        private void wdpyesRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (wdpyesRadioBtn.Checked)
            {
                wdptxtBox.Enabled = true;
                wdpdateTimePicker.Enabled = true;
            }
            else
            {
                wdptxtBox.Enabled = false;
                wdpdateTimePicker.Enabled = false;
            }
        }
        private void ptoyesRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (ptoyesRadioBtn.Checked)
            {
                ptotxtBox.Enabled = true;
                ptodateTimePicker.Enabled = true;
            }
            else
            {
                ptotxtBox.Enabled = false;
                ptodateTimePicker.Enabled = false;
            }
        }
        private void hwyesRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (hwyesRadioBtn.Checked)
            {
                hwidtxtBox.Enabled = true;
                hwiddateTimePicker.Enabled = true;
            }
            else
            {
                hwidtxtBox.Enabled = false;
                hwiddateTimePicker.Enabled = false;
            }
        }
        private void wastecollectyesRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (wastecollectyesRadioBtn.Checked)
            {
                haulertxtBox.Enabled = true;
                frequencycmbBox.Enabled = true;
            }
            else
            {
                haulertxtBox.Enabled = false;
                frequencycmbBox.Enabled = false;
            }
        }
        private void pcdyesRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (pcdyesRadioBtn.Checked)
            {
                providertxtBox.Enabled = true;
                pcdtxtBox.Enabled = true;
            }
            else
            {
                providertxtBox.Enabled = false;
                pcdtxtBox.Enabled = false;
            }
        }
        private void pcoyesRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (pcoyesRadioBtn.Checked)
            {
                pollutionofficertxtBox.Enabled = true;
                accreditationtxtBox.Enabled = true;
                validitypcodateTimePicker.Enabled = true;
                contacttxtBox.Enabled = true;
                emailaddtxtBox.Enabled = true;
            }
            else
            {
                pollutionofficertxtBox.Enabled = false;
                accreditationtxtBox.Enabled = false;
                validitypcodateTimePicker.Enabled = false;
                contacttxtBox.Enabled = false;
                emailaddtxtBox.Enabled = false;
            }
        }
        private void septicyesRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (septicyesRadioBtn.Checked)
            {
                locationSeptictxtBox.Enabled = true;
                frequencysepticcmbBox.Enabled = true;
                septicdateTimePicker.Enabled = true;
                serviceseptictxtBox.Enabled = true;
            }
            else
            {
                locationSeptictxtBox.Enabled = false;
                frequencysepticcmbBox.Enabled = false;
                septicdateTimePicker.Enabled = false;
                serviceseptictxtBox.Enabled = false;
            }
        }
        private void greaseyesRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (greaseyesRadioBtn.Checked)
            {
                locationgreasetxtBox.Enabled = true;
                capacitygreasetxtBox.Enabled = true;
                greasefrequencycmbBox.Enabled = true;
                haulergreasetxtBox.Enabled = true;
            }
            else
            {
                locationgreasetxtBox.Enabled = false;
                capacitygreasetxtBox.Enabled = false;
                greasefrequencycmbBox.Enabled = false;
                haulergreasetxtBox.Enabled = false;
            }
        }
        private void usedoilyesRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (usedoilyesRadioBtn.Checked)
            {
                oiltxtBox.Enabled = true;
                oilfrequencycmbBox.Enabled = true;
                hauleroiltxtBox.Enabled = true;
            }
            else
            {
                oiltxtBox.Enabled = false;
                oilfrequencycmbBox.Enabled = false;
                hauleroiltxtBox.Enabled = false;
            }
        }
        void ClearSelectedItems(CheckedListBox listBox)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetItemChecked(i, false);
            }
        }
        private void ClearForm()
        {
            // Clear textboxes
            accttxtBox.Clear();
            businesstxtBox.Clear();
            addresstxtBox.Clear();
            obstxtBox.Clear();
            directivestxtBox.Clear();
            oiltxtBox.Clear();
            haulergreasetxtBox.Clear();
            capacitygreasetxtBox.Clear();
            locationgreasetxtBox.Clear();
            locationSeptictxtBox.Clear();
            serviceseptictxtBox.Clear();
            haulertxtBox.Clear();
            pollutionofficertxtBox.Clear();
            accreditationtxtBox.Clear();
            contacttxtBox.Clear();
            emailaddtxtBox.Clear();
            hwidtxtBox.Clear();
            wdptxtBox.Clear();
            ecccnctxtBox.Clear();
            ovrtextBox.Clear();

            // Clear combobox
            brgycmbBox.SelectedIndex = -1;
            establishmentiscmbBox.SelectedIndex = -1;
            complywithincmbBox.SelectedIndex = -1;
            purposecmbBox.SelectedIndex = -1;
            oilfrequencycmbBox.SelectedIndex = -1;
            greasefrequencycmbBox.SelectedIndex = -1;
            frequencysepticcmbBox.SelectedIndex = -1;
            frequencycmbBox.SelectedIndex = -1;


            // Clear radio buttons
            lowriskRadioBtn.Checked = false;
            highriskRadioBtn.Checked = false;
            mayoryesRadioBtn.Checked = false;
            mayornoRadioBtn.Checked = false;
            eppyesRadioBtn.Checked = false;
            eppnoRadioBtn.Checked = false;
            eppnaRadioBtn.Checked = false;
            ecccncyesRadioBtn.Checked = false;
            ecccncnoRadioBtn.Checked = false;
            ecccncnaRadioBtn.Checked = false;
            wdpyesRadioBtn.Checked = false;
            wdpnoRadioBtn.Checked = false;
            wdpnaRadioBtn.Checked = false;
            hwyesRadioBtn.Checked = false;
            hwnoRadioBtn.Checked = false;
            hwnaRadioBtn.Checked = false;
            pcoyesRadioBtn.Checked = false;
            pconoRadioBtn.Checked = false;
            pconaRadioBtn.Checked = false;
            ptoyesRadioBtn.Checked = false;
            ptonoRadioBtn.Checked = false;
            ptonaRadioBtn.Checked = false;
            wastebinyesRadioBtn.Checked = false;
            wastebinnoRadioBtn.Checked = false;
            binproperyesRadioBtn.Checked = false;
            binpropernoRadioBtn.Checked = false;
            bincoveryesRadioBtn.Checked = false;
            bincovernoRadioBtn.Checked = false;
            wastesegyesRadioBtn.Checked = false;
            wastesegnoRadioBtn.Checked = false;
            mrfyesRadioBtn.Checked = false;
            mrfnoRadioBtn.Checked = false;
            wastecollectyesRadioBtn.Checked = false;
            wastecollectnoRadioBtn.Checked = false;
            pcdyesRadioBtn.Checked = false;
            pcdnoRadioBtn.Checked = false;
            pcdnaRadioBtn.Checked = false;
            pcoyesRadioBtn.Checked = false;
            pconoRadioBtn.Checked = false;
            pconaRadioBtn.Checked = false;
            septicyesRadioBtn.Checked = false;
            septicnoRadioBtn.Checked = false;
            septicnaRadioBtn.Checked = false;
            greaseyesRadioBtn.Checked = false;
            greasenoRadioBtn.Checked = false;
            greasenaRadioBtn.Checked = false;
            wastewateryesRadioBtn.Checked = false;
            wastewaternoRadioBtn.Checked = false;
            wastewaternaRadioBtn.Checked = false;
            usedoilyesRadioBtn.Checked = false;
            usedoilnoRadioBtn.Checked = false;
            usedoilnaRadioBtn.Checked = false;
            landusecommercialRadioBtn.Checked = false;
            landuseresidentialRadioBtn.Checked = false;
            landuseindustrialRadioBtn.Checked = false;
            landuseinstitutionalRadioBtn.Checked = false;
            proprietorshipRadioBtn.Checked = false;
            privatecorpRadioBtn.Checked = false;
            multinationalRadioBtn.Checked = false;
            standaloneyesRadioBtn.Checked = false;
            standalonenoRadioBtn.Checked = false;
            lesseeyesRadioBtn.Checked = false;
            lesseenoRadioBtn.Checked = false;
            statusoperationalRadioBtn.Checked = false;
            statusnooperationRadioBtn.Checked = false;
            statusclosedRadioBtn.Checked = false;
            statuswfhRadioBtn.Checked = false;

            // Clear checkedlistboxes
            ClearSelectedItems(establishmenthaschklistBox);
            ClearSelectedItems(violationschklistBox);
            ClearSelectedItems(securetheffchklistBox);
            ClearSelectedItems(recommendationchklistBox);
            ClearSelectedItems(inspectorschklistBox);
            ClearSelectedItems(levelofinspectionchklistBox);

            // Clear date pickers
            doidate = null;
            ecccncdate = null;
            ptodate = null;
            validitypcodate = null;
            septicdate = null;
            wdpdate = null;
            hwiddate = null;
            reinspectdate = null;

            doidateTimePicker.Format = DateTimePickerFormat.Custom;
            doidateTimePicker.CustomFormat = "dd/MM/yyyy";

            ecccncdateTimePicker.Format = DateTimePickerFormat.Custom;
            ecccncdateTimePicker.CustomFormat = "dd/MM/yyyy";

            ptodateTimePicker.Format = DateTimePickerFormat.Custom;
            ptodateTimePicker.CustomFormat = "dd/MM/yyyy";

            validitypcodateTimePicker.Format = DateTimePickerFormat.Custom;
            validitypcodateTimePicker.CustomFormat = "dd/MM/yyyy";

            septicdateTimePicker.Format = DateTimePickerFormat.Custom;
            septicdateTimePicker.CustomFormat = "dd/MM/yyyy";

            wdpdateTimePicker.Format = DateTimePickerFormat.Custom;
            wdpdateTimePicker.CustomFormat = "dd/MM/yyyy";

            hwiddateTimePicker.Format = DateTimePickerFormat.Custom;
            hwiddateTimePicker.CustomFormat = "dd/MM/yyyy";

            reinspectdateTimePicker.Format = DateTimePickerFormat.Custom;
            reinspectdateTimePicker.CustomFormat = "dd/MM/yyyy";
        }
        public void DisableMainMenuItem()
        {
            menuItem9.Enabled = false;
            menuItem9.Visible = false;
            menuItem10.Enabled = false;
            menuItem10.Visible = false;
            menuItem11.Enabled = false;
            menuItem11.Visible = false;
            menuItem12.Enabled = false;
            menuItem12.Visible = false;
        }
        public void EnableMainMenuItem()
        {
            menuItem9.Enabled = true;
            menuItem9.Visible = true;
            menuItem10.Enabled = true;
            menuItem10.Visible = true;
            menuItem11.Enabled = true;
            menuItem11.Visible = true;
            menuItem12.Enabled = true;
            menuItem12.Visible = true;
        }
        private void PopulateDataGridView()
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string selectQuery = "SELECT * FROM InspectionReport";

                using (SqlCommand cmd = new SqlCommand(selectQuery, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }
        private bool CheckDataExists(string accountNo)
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM InspectionReport WHERE AccountNo = @AccountNo";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@AccountNo", accountNo);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void doidateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            doidateTimePicker.CustomFormat = "dd-MM-yyyy";
            doidate = doidateTimePicker.Value;
        }
        private void ecccncdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ecccncdateTimePicker.CustomFormat = "dd-MM-yyyy";
            ecccncdate = ecccncdateTimePicker.Value;
        }        private void wdpdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            wdpdateTimePicker.CustomFormat = "dd-MM-yyyy";
            wdpdate = wdpdateTimePicker.Value;
        }
        private void ptodateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ptodateTimePicker.CustomFormat = "dd-MM-yyyy";
            ptodate = ptodateTimePicker.Value;
        }
        private void hwiddateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            hwiddateTimePicker.CustomFormat = "dd-MM-yyyy";
            hwiddate = hwiddateTimePicker.Value;
        }
        private void validitypcodateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            validitypcodateTimePicker.CustomFormat = "dd-MM-yyyy";
            validitypcodate = validitypcodateTimePicker.Value;
        }

        private void septicdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            septicdateTimePicker.CustomFormat = "dd-MM-yyyy";
            septicdate = septicdateTimePicker.Value;
        }
        private void reinspectdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            reinspectdateTimePicker.CustomFormat = "dd-MM-yyyy";
            reinspectdate = reinspectdateTimePicker.Value;
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            string username = AuthenticatedUser.UserName ?? "DefaultUsername";
            string accountNo = accttxtBox.Text;
            string businessName = businesstxtBox.Text;
            string address = addresstxtBox.Text;
            string barangay = brgycmbBox.Text;
            string observation = obstxtBox.Text;
            string directives = directivestxtBox.Text;

            if (string.IsNullOrEmpty(accountNo) || string.IsNullOrEmpty(businessName) ||
                string.IsNullOrEmpty(address) || string.IsNullOrEmpty(barangay) ||
                string.IsNullOrEmpty(observation) || string.IsNullOrEmpty(directives) ||
                inspectorschklistBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please fill in all the required fields (Account No., Business Name, Address, Barangay, Observation, Directives, and at least one Inspector).", "Required Fields Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool dataExists = CheckDataExists(accountNo);
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string insertQuery = "INSERT INTO InspectionReport (AccountNo, BusinessName, Address, Barangay, Date, NatureOfBusiness, " +
                                     "EstablishmentHas, BusinessStatus, EstablishmentIs, Violations, ComplyWithin, SecuretheFF, AttendSeminar, " +
                                     "MayorsPermit, EPPFee, ECCCNC, ECCCNCNo, ECCDateIssued, WDP, WDPNo, WDPDateIssued, PTO, PTONo, PTODateIssued, HWID, HWIDNo, " +
                                     "HWIDDateIssued, HasPollutionOfficer, PollutionOfficer, Accreditation, ValidityOfPOC, ContactNo, Email, " +
                                     "HasWasteBin, BinsLabeled, BinsCovered, BinsSegregated, MRF, WasteCollected, FrequencyHauling, Hauler, " +
                                     "HasSeptic, LocationSeptic, FrequencyDesludge, DateDesludge, ServiceProvider, HasGreaseTrap, LocationGrease, " +
                                     "CapacityGreaseTrap, FrequencyGrease, HaulerGrease, HasWasteWater, UsedOilProperlyDisposed, TypeofOil, " +
                                     "FrequencyofHaulingOil, HaulerOil, HasAirPollutionManager, DeviceType, MaintenanceProvider, PurposeOfInspection, " +
                                     "ReinspectDate, LevelofInspection, LandUse, OwnershipTerms, Lessee, StandAlone, EstablishmentStatus, InspectorObservation, " +
                                     "Directives, OVR, Recommendations, Inspector, Encoder) " +
                                     "VALUES (@AccountNo, @BusinessName, @Address, @Barangay, @Date, @NatureOfBusiness, @EstablishmentHas, @BusinessStatus, " +
                                     "@EstablishmentIs, @Violations, @ComplyWithin, @SecuretheFF, @AttendSeminar, @MayorsPermit, @EPPFee, " +
                                     "@ECCCNC, @ECCCNCNo, @ECCDateIssued, @WDP, @WDPNo, @WDPDateIssued, @PTO, @PTONo, @PTODateIssued, @HWID, @HWIDNo, @HWIDDateIssued, " +
                                     "@HasPollutionOfficer, @PollutionOfficer, @Accreditation, @ValidityOfPOC, @ContactNo, @Email, @HasWasteBin, " +
                                     "@BinsLabeled, @BinsCovered, @BinsSegregated, @MRF, @WasteCollected, @FrequencyHauling, @Hauler, " +
                                     "@HasSeptic, @LocationSeptic, @FrequencyDesludge, @DateDesludge, @ServiceProvider, @HasGreaseTrap, " +
                                     "@LocationGrease, @CapacityGreaseTrap, @FrequencyGrease, @HaulerGrease, @HasWasteWater, " +
                                     "@UsedOilProperlyDisposed, @TypeofOil, @FrequencyofHaulingOil, @HaulerOil, @HasAirPollutionManager, " +
                                     "@DeviceType, @MaintenanceProvider, @PurposeOfInspection, @ReinspectDate, @LevelofInspection, @LandUse, @OwnershipTerms, " +
                                     "@Lessee, @StandAlone, @EstablishmentStatus, @InspectorObservation, @Directives, @OVR, @Recommendations, @Inspector, @Encoder)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@AccountNo", accttxtBox.Text);
                    cmd.Parameters.AddWithValue("@BusinessName", businesstxtBox.Text);
                    cmd.Parameters.AddWithValue("@Address", addresstxtBox.Text);
                    cmd.Parameters.AddWithValue("@Barangay", brgycmbBox.Text);
                    if (doidate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@Date", doidateTimePicker.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Date", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@NatureOfBusiness", natureofbusinesscmbBox.Text);
                    cmd.Parameters.AddWithValue("@EstablishmentHas", string.Join(", ", establishmenthaschklistBox.CheckedItems.Cast<string>()));
                    cmd.Parameters.AddWithValue("@BusinessStatus", GetSelectedRadioButtonText(lowriskRadioBtn, highriskRadioBtn));
                    cmd.Parameters.AddWithValue("@EstablishmentIs", establishmentiscmbBox.Text);
                    cmd.Parameters.AddWithValue("@Violations", string.Join(", ", violationschklistBox.CheckedItems.Cast<string>()));
                    cmd.Parameters.AddWithValue("@ComplyWithin", complywithincmbBox.Text);
                    cmd.Parameters.AddWithValue("@SecuretheFF", string.Join(", ", securetheffchklistBox.CheckedItems.Cast<string>()));
                    cmd.Parameters.AddWithValue("@AttendSeminar", seminartxtBox.Text);
                    cmd.Parameters.AddWithValue("@MayorsPermit", GetSelectedRadioButtonText(mayoryesRadioBtn, mayornoRadioBtn));
                    cmd.Parameters.AddWithValue("@EPPFee", GetSelectedRadioButtonText(eppyesRadioBtn, eppnoRadioBtn, eppnaRadioBtn));
                    cmd.Parameters.AddWithValue("@ECCCNC", GetSelectedRadioButtonText(ecccncyesRadioBtn, ecccncnoRadioBtn, ecccncnaRadioBtn));
                    cmd.Parameters.AddWithValue("@ECCCNCNo", ecccnctxtBox.Text);
                    if (ecccncdate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@ECCDateIssued", ecccncdateTimePicker.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ECCDateIssued", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@WDP", GetSelectedRadioButtonText(wdpyesRadioBtn, wdpnoRadioBtn, wdpnaRadioBtn));
                    cmd.Parameters.AddWithValue("@WDPNo", wdptxtBox.Text);
                    if (wdpdate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@WDPDateIssued", wdpdateTimePicker.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@WDPDateIssued", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@PTO", GetSelectedRadioButtonText(ptoyesRadioBtn, ptonoRadioBtn, ptonaRadioBtn));
                    cmd.Parameters.AddWithValue("@PTONo", ptotxtBox.Text);
                    if (ptodate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@PTODateIssued", ptodateTimePicker.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PTODateIssued", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@HWID", GetSelectedRadioButtonText(hwyesRadioBtn, hwnoRadioBtn, hwnaRadioBtn));
                    cmd.Parameters.AddWithValue("@HWIDNo", hwidtxtBox.Text);
                    if (hwiddate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@HWIDDateIssued", hwiddateTimePicker.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@HWIDDateIssued", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@HasPollutionOfficer", GetSelectedRadioButtonText(pcoyesRadioBtn, pconoRadioBtn, pconaRadioBtn));
                    cmd.Parameters.AddWithValue("@PollutionOfficer", pollutionofficertxtBox.Text);
                    cmd.Parameters.AddWithValue("@Accreditation", accreditationtxtBox.Text);
                    if (validitypcodate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@ValidityOfPOC", validitypcodateTimePicker.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ValidityOfPOC", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@ContactNo", contacttxtBox.Text);
                    cmd.Parameters.AddWithValue("@Email", emailaddtxtBox.Text);
                    cmd.Parameters.AddWithValue("@HasWasteBin", GetSelectedRadioButtonText(wastebinyesRadioBtn, wastebinnoRadioBtn));
                    cmd.Parameters.AddWithValue("@BinsLabeled", GetSelectedRadioButtonText(binproperyesRadioBtn, binpropernoRadioBtn));
                    cmd.Parameters.AddWithValue("@BinsCovered", GetSelectedRadioButtonText(bincoveryesRadioBtn, bincovernoRadioBtn));
                    cmd.Parameters.AddWithValue("@BinsSegregated", GetSelectedRadioButtonText(wastesegyesRadioBtn, wastesegnoRadioBtn));
                    cmd.Parameters.AddWithValue("@MRF", GetSelectedRadioButtonText(mrfyesRadioBtn, mrfnoRadioBtn));
                    cmd.Parameters.AddWithValue("@WasteCollected", GetSelectedRadioButtonText(wastecollectyesRadioBtn, wastecollectnoRadioBtn));
                    cmd.Parameters.AddWithValue("@FrequencyHauling", frequencycmbBox.Text);
                    cmd.Parameters.AddWithValue("@Hauler", haulertxtBox.Text);
                    cmd.Parameters.AddWithValue("@HasSeptic", GetSelectedRadioButtonText(septicyesRadioBtn, septicnoRadioBtn, septicnaRadioBtn));
                    cmd.Parameters.AddWithValue("@LocationSeptic", locationSeptictxtBox.Text);
                    cmd.Parameters.AddWithValue("@FrequencyDesludge", frequencysepticcmbBox.Text);
                    if (septicdate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@DateDesludge", septicdateTimePicker.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DateDesludge", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@ServiceProvider", serviceseptictxtBox.Text);
                    cmd.Parameters.AddWithValue("@HasGreaseTrap", GetSelectedRadioButtonText(greaseyesRadioBtn, greasenoRadioBtn, greasenaRadioBtn));
                    cmd.Parameters.AddWithValue("@LocationGrease", locationgreasetxtBox.Text);
                    cmd.Parameters.AddWithValue("@CapacityGreaseTrap", capacitygreasetxtBox.Text);
                    cmd.Parameters.AddWithValue("@FrequencyGrease", greasefrequencycmbBox.Text);
                    cmd.Parameters.AddWithValue("@HaulerGrease", haulergreasetxtBox.Text);
                    cmd.Parameters.AddWithValue("@HasWasteWater", GetSelectedRadioButtonText(wastewateryesRadioBtn, wastewaternoRadioBtn, wastewaternaRadioBtn));
                    cmd.Parameters.AddWithValue("@UsedOilProperlyDisposed", GetSelectedRadioButtonText(usedoilyesRadioBtn, usedoilnoRadioBtn, usedoilnaRadioBtn));
                    cmd.Parameters.AddWithValue("@TypeofOil", oiltxtBox.Text);
                    cmd.Parameters.AddWithValue("@FrequencyofHaulingOil", oilfrequencycmbBox.Text);
                    cmd.Parameters.AddWithValue("@HaulerOil", hauleroiltxtBox.Text);
                    cmd.Parameters.AddWithValue("@HasAirPollutionManager", GetSelectedRadioButtonText(pcdyesRadioBtn, pcdnoRadioBtn, pcdnaRadioBtn));
                    cmd.Parameters.AddWithValue("@DeviceType", pcdtxtBox.Text);
                    cmd.Parameters.AddWithValue("@MaintenanceProvider", providertxtBox.Text);
                    cmd.Parameters.AddWithValue("@PurposeOfInspection", purposecmbBox.Text);
                    if (reinspectdate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@ReinspectDate", reinspectdateTimePicker.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ReinspectDate", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@LevelofInspection", string.Join(", ", levelofinspectionchklistBox.CheckedItems.Cast<string>()));
                    cmd.Parameters.AddWithValue("@LandUse", GetSelectedRadioButtonText(landusecommercialRadioBtn, landuseresidentialRadioBtn, landuseindustrialRadioBtn, landuseinstitutionalRadioBtn));
                    cmd.Parameters.AddWithValue("@OwnershipTerms", GetSelectedRadioButtonText(proprietorshipRadioBtn, privatecorpRadioBtn, multinationalRadioBtn));
                    cmd.Parameters.AddWithValue("@Lessee", GetSelectedRadioButtonText(lesseeyesRadioBtn, lesseenoRadioBtn));
                    cmd.Parameters.AddWithValue("@StandAlone", GetSelectedRadioButtonText(standaloneyesRadioBtn, standalonenoRadioBtn));
                    cmd.Parameters.AddWithValue("@EstablishmentStatus", GetSelectedRadioButtonText(statusoperationalRadioBtn, statusnooperationRadioBtn, statusclosedRadioBtn, statuswfhRadioBtn));
                    cmd.Parameters.AddWithValue("@InspectorObservation", obstxtBox.Text);
                    cmd.Parameters.AddWithValue("@Directives", directivestxtBox.Text);
                    cmd.Parameters.AddWithValue("@OVR", ovrtextBox.Text);
                    cmd.Parameters.AddWithValue("@Recommendations", string.Join(", ", recommendationchklistBox.CheckedItems.Cast<string>()));
                    cmd.Parameters.AddWithValue("@Inspector", string.Join(", ", inspectorschklistBox.CheckedItems.Cast<string>()));
                    cmd.Parameters.AddWithValue("@Encoder", username);

                    if (dataExists)
                    {
                        DialogResult result = MessageBox.Show("Data with the same Account No.: " + accttxtBox.Text + " already exists!", "Data already existed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ClearForm();
                    }

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully Saved!");
                        LogEvent("Added Data");
                        ClearForm();
                        PopulateDataGridView();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Sql Error: " + ex.Message);
                    }
                }
            }
        }

        private string GetSelectedRadioButtonText(params RadioButton[] radioButtons)
        {
            foreach (var radioButton in radioButtons)
            {
                if (radioButton.Checked)
                {
                    return radioButton.Text;
                }
            }
            return string.Empty;
        }
        private void resetBtn_Click(object sender, EventArgs e)
        {
            ClearForm();
            PopulateDataGridView();
        }
        private void menuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
            Loginpage Loginpage = new Loginpage();
            Loginpage.Show();
        }
        private void menuItem5_Click(object sender, EventArgs e)
        {
            Loginpage loginForm = new Loginpage();
            loginForm.AdminLoggedIn += (s, args) =>
            {
                this.Close(); // Close the current MainForm
            };
            loginForm.RegularLoggedIn += (s, args) =>
            {
                this.Close(); // Close the current MainForm
            };
            loginForm.ShowDialog();
        }
        private void menuItem6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ShowLogForm()
        {
            if (logform == null || logform.IsDisposed)
            {
                logform = new LogForm(logEntries, logFilePath);
            }
            logform.Show();
        }
        private void LogEvent(string eventDescription)
        {
            string logEntry = $"{DateTime.Now} - {accttxtBox.Text} {AuthenticatedUser.UserName}: {eventDescription}";
            if (logform != null)
            {
                logform.AppendLog(logEntry);
            }
            logEntries.Add(logEntry);
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }

        private void menuItem9_Click(object sender, EventArgs e)
        {
            ShowLogForm();  
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";
            string accountNo = accttxtBox.Text;

            if (string.IsNullOrEmpty(accountNo))
            {
                MessageBox.Show("Please fill in the Account No.", "Required Field Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure do you want to update this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string updateQuery = "UPDATE InspectionReport SET " +
                                    "BusinessName = COALESCE(@BusinessName, BusinessName), " +
                                    "Address = COALESCE(@Address, Address), " +
                                    "Barangay = COALESCE(@Barangay, Barangay), " +
                                    "Date = COALESCE(@Date, Date), " +
                                    "NatureOfBusiness = COALESCE(@NatureOfBusiness, NatureOfBusiness), " +
                                    "EstablishmentHas = COALESCE(@EstablishmentHas, EstablishmentHas), " +
                                    "BusinessStatus = COALESCE(@BusinessStatus, BusinessStatus), " +
                                    "EstablishmentIs = COALESCE(@EstablishmentIs, EstablishmentIs), " +
                                    "Violations = CASE " +
                                    "WHEN LEN(ISNULL(@Violations, '')) > 0 AND LEN(ISNULL(Violations, '')) > 0 " +
                                    "THEN COALESCE(Violations + ', ', '') + @Violations " +
                                    "WHEN LEN(ISNULL(@Violations, '')) > 0 " +
                                    "THEN @Violations " +
                                    "ELSE Violations " +
                                    "END, " +
                                    "ComplyWithin = COALESCE(@ComplyWithin, ComplyWithin), " +
                                    "SecuretheFF = CASE " +
                                    "WHEN LEN(ISNULL(@SecuretheFF, '')) > 0 AND LEN(ISNULL(SecuretheFF, '')) > 0 " +
                                    "THEN COALESCE(SecuretheFF + ', ', '') + @SecuretheFF " +
                                    "WHEN LEN(ISNULL(@SecuretheFF, '')) > 0 " +
                                    "THEN @SecuretheFF " +
                                    "ELSE SecuretheFF " +
                                    "END, " +
                                    "AttendSeminar = COALESCE(@AttendSeminar, AttendSeminar), " +
                                    "MayorsPermit = COALESCE(@MayorsPermit, MayorsPermit), " +
                                    "EPPFee = COALESCE(@EPPFee, EPPFee), " +
                                    "ECCCNC = COALESCE(@ECCCNC, ECCCNC), " +
                                    "ECCCNCNo = COALESCE(@ECCCNCNo, ECCCNCNo), " +
                                    "ECCDateIssued = COALESCE(@ECCDateIssued, ECCDateIssued), " +
                                    "WDP = COALESCE(@WDP, WDP), " +
                                    "WDPNo = COALESCE(@WDPNo, WDPNo), " +
                                    "WDPDateIssued = COALESCE(@WDPDateIssued, WDPDateIssued), " +
                                    "PTO = COALESCE(@PTO, PTO), " +
                                    "PTONo = COALESCE(@PTONo, PTONo), " +
                                    "PTODateIssued = COALESCE(@PTODateIssued, PTODateIssued), " +
                                    "HWID = COALESCE(@HWID, HWID), " +
                                    "HWIDNo = COALESCE(@HWIDNo, HWIDNo), " +
                                    "HWIDDateIssued = COALESCE(@HWIDDateIssued, HWIDDateIssued), " +
                                    "HasPollutionOfficer = COALESCE(@HasPollutionOfficer, HasPollutionOfficer), " +
                                    "PollutionOfficer = COALESCE(@PollutionOfficer, PollutionOfficer), " +
                                    "Accreditation = COALESCE(@Accreditation, Accreditation), " +
                                    "ValidityOfPOC = COALESCE(@ValidityOfPOC, ValidityOfPOC), " +
                                    "ContactNo = COALESCE(@ContactNo, ContactNo), " +
                                    "Email = COALESCE(@Email, Email), " +
                                    "HasWasteBin = COALESCE(@HasWasteBin, HasWasteBin), " +
                                    "BinsLabeled = COALESCE(@BinsLabeled, BinsLabeled), " +
                                    "BinsCovered = COALESCE(@BinsCovered, BinsCovered), " +
                                    "BinsSegregated = COALESCE(@BinsSegregated, BinsSegregated), " +
                                    "MRF = COALESCE(@MRF, MRF), " +
                                    "WasteCollected = COALESCE(@WasteCollected, WasteCollected), " +
                                    "FrequencyHauling = COALESCE(@FrequencyHauling, FrequencyHauling), " +
                                    "Hauler = COALESCE(@Hauler, Hauler), " +
                                    "HasSeptic = COALESCE(@HasSeptic, HasSeptic), " +
                                    "LocationSeptic = COALESCE(@LocationSeptic, LocationSeptic), " +
                                    "FrequencyDesludge = COALESCE(@FrequencyDesludge, FrequencyDesludge), " +
                                    "DateDesludge = COALESCE(@DateDesludge, DateDesludge), " +
                                    "ServiceProvider = COALESCE(@ServiceProvider, ServiceProvider), " +
                                    "HasGreaseTrap = COALESCE(@HasGreaseTrap, HasGreaseTrap), " +
                                    "LocationGrease = COALESCE(@LocationGrease, LocationGrease), " +
                                    "CapacityGreaseTrap = COALESCE(@CapacityGreaseTrap, CapacityGreaseTrap), " +
                                    "FrequencyGrease = COALESCE(@FrequencyGrease, FrequencyGrease), " +
                                    "HaulerGrease = COALESCE(@HaulerGrease, HaulerGrease), " +
                                    "HasWasteWater = COALESCE(@HasWasteWater, HasWasteWater), " +
                                    "UsedOilProperlyDisposed = COALESCE(@UsedOilProperlyDisposed, UsedOilProperlyDisposed), " +
                                    "TypeofOil = COALESCE(@TypeofOil, TypeofOil), " +
                                    "FrequencyofHaulingOil = COALESCE(@FrequencyofHaulingOil, FrequencyofHaulingOil), " +
                                    "HaulerOil = COALESCE(@HaulerOil, HaulerOil), " +
                                    "HasAirPollutionManager = COALESCE(@HasAirPollutionManager, HasAirPollutionManager), " +
                                    "DeviceType = COALESCE(@DeviceType, DeviceType), " +
                                    "MaintenanceProvider = COALESCE(@MaintenanceProvider, MaintenanceProvider), " +
                                    "PurposeOfInspection = COALESCE(@PurposeOfInspection, PurposeOfInspection), " +
                                    "ReinspectDate = COALESCE(@ReinspectDate, ReinspectDate), " +
                                    "LevelofInspection = " +
                                    "CASE " +
                                    "WHEN LEN(ISNULL(@LevelofInspection, '')) > 0 AND LEN(ISNULL(LevelofInspection, '')) > 0 " +
                                    "THEN COALESCE(LevelofInspection + ', ', '') + @LevelofInspection " +
                                    "WHEN LEN(ISNULL(@LevelofInspection, '')) > 0 " +
                                    "THEN @LevelofInspection " +
                                    "ELSE LevelofInspection " +
                                    "END, " +
                                    "LandUse = COALESCE(@LandUse, LandUse), " +
                                    "OwnershipTerms = COALESCE(@OwnershipTerms, OwnershipTerms), " +
                                    "Lessee = COALESCE(@Lessee, Lessee), " +
                                    "StandAlone = COALESCE(@StandAlone, StandAlone), " +
                                    "EstablishmentStatus = COALESCE(@EstablishmentStatus, EstablishmentStatus), " +

                                    "InspectorObservation = " +
                                    "CASE " +
                                    "WHEN LEN(ISNULL(@InspectorObservation, '')) > 0 AND LEN(ISNULL(InspectorObservation, '')) > 0 " +
                                    "THEN COALESCE(InspectorObservation + '\n', '') + @InspectorObservation " +
                                    "WHEN LEN(ISNULL(@InspectorObservation, '')) > 0 " +
                                    "THEN @InspectorObservation " +
                                    "ELSE InspectorObservation " +
                                    "END, " +

                                    "Directives = " +
                                    "CASE " +
                                    "WHEN LEN(ISNULL(@Directives, '')) > 0 AND LEN(ISNULL(Directives, '')) > 0 " +
                                    "THEN COALESCE(Directives + '\n', '') + @Directives " +
                                    "WHEN LEN(ISNULL(@Directives, '')) > 0 " +
                                    "THEN @Directives " +
                                    "ELSE Directives " +
                                    "END, " +

                                    "OVR = " +
                                    "CASE " +
                                    "WHEN LEN(ISNULL(@OVR, '')) > 0 AND LEN(ISNULL(OVR, '')) > 0 " +
                                    "THEN COALESCE(OVR + '\n', '') + @OVR " +
                                    "WHEN LEN(ISNULL(@OVR, '')) > 0 " +
                                    "THEN @OVR " +
                                    "ELSE OVR " +
                                    "END, " +

                                    "Recommendations = " +
                                    "CASE " +
                                    "WHEN LEN(ISNULL(@Recommendations, '')) > 0 AND LEN(ISNULL(Recommendations, '')) > 0 " +
                                    "THEN COALESCE(Recommendations + ', ', '') + @Recommendations " +
                                    "WHEN LEN(ISNULL(@Recommendations, '')) > 0 " +
                                    "THEN @Recommendations " +
                                    "ELSE Recommendations " +
                                    "END, " +

                                    "Inspector = " +
                                    "CASE " +
                                    "WHEN LEN(ISNULL(@Inspector, '')) > 0 AND LEN(ISNULL(Inspector, '')) > 0 " +
                                    "THEN COALESCE(Inspector + ', ', '') + @Inspector " +
                                    "WHEN LEN(ISNULL(@Inspector, '')) > 0 " +
                                    "THEN @Inspector " +
                                    "ELSE Inspector " +
                                    "END " +

                                    "WHERE AccountNo = @AccountNo";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@AccountNo", accttxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@BusinessName", businesstxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@Address", addresstxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@Barangay", brgycmbBox.Text);
                        if (doidate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@Date", doidateTimePicker.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Date", DBNull.Value);
                        }
                        AddParameterIfNotEmpty(cmd, "@NatureOfBusiness", natureofbusinesscmbBox.Text);
                        AddParameterIfNotEmpty(cmd, "@EstablishmentHas", string.Join(", ", establishmenthaschklistBox.CheckedItems.Cast<string>()));
                        AddParameterIfNotEmpty(cmd, "@BusinessStatus", GetSelectedRadioButtonText(lowriskRadioBtn, highriskRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@EstablishmentIs", establishmentiscmbBox.Text);
                        AddParameterIfNotEmpty(cmd, "@Violations", string.Join(", ", violationschklistBox.CheckedItems.Cast<string>()));
                        AddParameterIfNotEmpty(cmd, "@ComplyWithin", complywithincmbBox.Text);
                        AddParameterIfNotEmpty(cmd, "@SecuretheFF", string.Join(", ", securetheffchklistBox.CheckedItems.Cast<string>()));
                        AddParameterIfNotEmpty(cmd, "@AttendSeminar", seminartxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@MayorsPermit", GetSelectedRadioButtonText(mayoryesRadioBtn, mayornoRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@EPPFee", GetSelectedRadioButtonText(eppyesRadioBtn, eppnoRadioBtn, eppnaRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@ECCCNC", GetSelectedRadioButtonText(ecccncyesRadioBtn, ecccncnoRadioBtn, ecccncnaRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@ECCCNCNo", ecccnctxtBox.Text);
                        if (ecccncdate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@ECCDateIssued", ecccncdateTimePicker.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ECCDateIssued", DBNull.Value);
                        }
                        AddParameterIfNotEmpty(cmd, "@WDP", GetSelectedRadioButtonText(wdpyesRadioBtn, wdpnoRadioBtn, wdpnaRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@WDPNo", wdptxtBox.Text);
                        if (wdpdate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@WDPDateIssued", wdpdateTimePicker.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@WDPDateIssued", DBNull.Value);
                        }
                        AddParameterIfNotEmpty(cmd, "@PTO", GetSelectedRadioButtonText(ptoyesRadioBtn, ptonoRadioBtn, ptonaRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@PTONo", ptotxtBox.Text);
                        if (ptodate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@PTODateIssued", ptodateTimePicker.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@PTODateIssued", DBNull.Value);
                        }
                        AddParameterIfNotEmpty(cmd, "@HWID", GetSelectedRadioButtonText(hwyesRadioBtn, hwnoRadioBtn, hwnaRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@HWIDNo", hwidtxtBox.Text);
                        if (hwiddate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@HWIDDateIssued", hwiddateTimePicker.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@HWIDDateIssued", DBNull.Value);
                        }
                        cmd.Parameters.AddWithValue("@HasPollutionOfficer", GetSelectedRadioButtonText(pcoyesRadioBtn, pconoRadioBtn, pconaRadioBtn));
                        cmd.Parameters.AddWithValue("@PollutionOfficer", pollutionofficertxtBox.Text);
                        cmd.Parameters.AddWithValue("@Accreditation", accreditationtxtBox.Text);
                        if (validitypcodate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@ValidityOfPOC", validitypcodateTimePicker.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ValidityOfPOC", DBNull.Value);
                        }
                        AddParameterIfNotEmpty(cmd, "@ContactNo", contacttxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@Email", emailaddtxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@HasWasteBin", GetSelectedRadioButtonText(wastebinyesRadioBtn, wastebinnoRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@BinsLabeled", GetSelectedRadioButtonText(binproperyesRadioBtn, binpropernoRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@BinsCovered", GetSelectedRadioButtonText(bincoveryesRadioBtn, bincovernoRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@BinsSegregated", GetSelectedRadioButtonText(wastesegyesRadioBtn, wastesegnoRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@MRF", GetSelectedRadioButtonText(mrfyesRadioBtn, mrfnoRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@WasteCollected", GetSelectedRadioButtonText(wastecollectyesRadioBtn, wastecollectnoRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@FrequencyHauling", frequencycmbBox.Text);
                        AddParameterIfNotEmpty(cmd, "@Hauler", haulertxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@HasSeptic", GetSelectedRadioButtonText(septicyesRadioBtn, septicnoRadioBtn, septicnaRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@LocationSeptic", locationSeptictxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@FrequencyDesludge", frequencysepticcmbBox.Text);
                        if (septicdate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@DateDesludge", septicdateTimePicker.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@DateDesludge", DBNull.Value);
                        }
                        AddParameterIfNotEmpty(cmd, "@ServiceProvider", serviceseptictxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@HasGreaseTrap", GetSelectedRadioButtonText(greaseyesRadioBtn, greasenoRadioBtn, greasenaRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@LocationGrease", locationgreasetxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@CapacityGreaseTrap", capacitygreasetxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@FrequencyGrease", greasefrequencycmbBox.Text);
                        AddParameterIfNotEmpty(cmd, "@HaulerGrease", haulergreasetxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@HasWasteWater", GetSelectedRadioButtonText(wastewateryesRadioBtn, wastewaternoRadioBtn, wastewaternaRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@UsedOilProperlyDisposed", GetSelectedRadioButtonText(usedoilyesRadioBtn, usedoilnoRadioBtn, usedoilnaRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@TypeofOil", oiltxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@FrequencyofHaulingOil", oilfrequencycmbBox.Text);
                        AddParameterIfNotEmpty(cmd, "@HaulerOil", hauleroiltxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@HasAirPollutionManager", GetSelectedRadioButtonText(pcdyesRadioBtn, pcdnoRadioBtn, pcdnaRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@DeviceType", pcdtxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@MaintenanceProvider", providertxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@PurposeOfInspection", purposecmbBox.Text);
                        if (reinspectdate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@ReinspectDate", reinspectdateTimePicker.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ReinspectDate", DBNull.Value);
                        }
                        AddParameterIfNotEmpty(cmd, "@LevelofInspection", string.Join(", ", levelofinspectionchklistBox.CheckedItems.Cast<string>()));
                        AddParameterIfNotEmpty(cmd, "@LandUse", GetSelectedRadioButtonText(landusecommercialRadioBtn, landuseresidentialRadioBtn, landuseindustrialRadioBtn, landuseinstitutionalRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@OwnershipTerms", GetSelectedRadioButtonText(proprietorshipRadioBtn, privatecorpRadioBtn, multinationalRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@Lessee", GetSelectedRadioButtonText(lesseeyesRadioBtn, lesseenoRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@StandAlone", GetSelectedRadioButtonText(standaloneyesRadioBtn, standalonenoRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@EstablishmentStatus", GetSelectedRadioButtonText(statusoperationalRadioBtn, statusnooperationRadioBtn, statusclosedRadioBtn, statuswfhRadioBtn));
                        AddParameterIfNotEmpty(cmd, "@InspectorObservation", obstxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@Directives", directivestxtBox.Text);
                        AddParameterIfNotEmpty(cmd, "@OVR", ovrtextBox.Text);
                        AddParameterIfNotEmpty(cmd, "@Recommendations", string.Join(", ", recommendationchklistBox.CheckedItems.Cast<string>()));
                        AddParameterIfNotEmpty(cmd, "@Inspector", string.Join(", ", inspectorschklistBox.CheckedItems.Cast<string>()));

                        try
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Successfully Updated!");
                                LogEvent("Updated Data");
                                ClearForm();
                                PopulateDataGridView();
                            }
                            else
                            {
                                MessageBox.Show("No record found for the specified Account No.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine("Sql Error: " + ex.Message);
                        }
                    }
                }
            }
        }
        private void AddParameterIfNotEmpty(SqlCommand cmd, string paramName, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                cmd.Parameters.AddWithValue(paramName, value);
            }
            else
            {
                // Check if the parameter already exists in the command
                if (cmd.Parameters.Contains(paramName))
                {
                    // If it exists, set the parameter to an empty string to prevent data deletion
                    cmd.Parameters[paramName].Value = "";
                }
                else
                {
                    // If it doesn't exist, add it as DBNull.Value
                    cmd.Parameters.AddWithValue(paramName, DBNull.Value);
                }
            }
        }
        private void searchBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string searchQuery = "SELECT * FROM InspectionReport where AccountNo=@AccountNo";

                using (SqlCommand cmd = new SqlCommand(searchQuery, con))
                {
                    cmd.Parameters.AddWithValue("@AccountNo", accttxtBox.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                        MessageBox.Show("Record Found!");
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("No record found!");
                    }
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            string accountNo = accttxtBox.Text;

            if (string.IsNullOrEmpty(accountNo))
            {
                MessageBox.Show("Please fill in the Account No. you want to delete", "Required Field Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string DeleteQuery = "DELETE InspectionReport where AccountNo=@AccountNo";

                    using (SqlCommand cmd = new SqlCommand(DeleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@AccountNo", accttxtBox.Text);

                        try
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Successfully Deleted!");
                                LogEvent("Deleted Data");
                                ClearForm();
                                PopulateDataGridView();
                            }
                            else
                            {
                                MessageBox.Show("No record found for the specified Account No.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine("Sql Error: " + ex.Message);
                        }
                    }
                }
            }
        }
        private void PerformDataBaseSearch(string sqlQuery)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand(sqlQuery, con))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("No Results found");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void ShowAdvancedSearchForm()
        {
            using (AdvancedSearch advancedSearch = new AdvancedSearch())
            {
                if (advancedSearch.ShowDialog() == DialogResult.OK)
                {
                    string sqlQuery = advancedSearch.SearchQuery;
                    if (!string.IsNullOrWhiteSpace(sqlQuery))
                    {
                        PerformDataBaseSearch(sqlQuery);
                    }
                    else
                    {
                        MessageBox.Show("Search query is null or empty");
                    }
                }
                else
                {
                    MessageBox.Show("Advanced search dialog was canceled");
                }
            }
        }

        private void advsearchBtn_Click(object sender, EventArgs e)
        {
            ShowAdvancedSearchForm();
        }

        private void menuItem11_Click(object sender, EventArgs e)
        {
            new UserManagement().Show();
        }

        private void menuItem13_Click(object sender, EventArgs e)
        {
            new ChangePassword().Show();
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            new registerForm().Show();
        }
        private void menuItem8_Click(object sender, EventArgs e)//Pulling Reports to Excel
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string sqlQuery = "SELECT * FROM InspectionReport";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);


                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {

                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Data");


                            worksheet.Cells["A1"].LoadFromDataTable(dt, true);


                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Roots.Add(new FileSystemProvider("E:\\", "Main_Directory"));
                            saveFileDialog.Filter = "Excel Files|*.xlsx";
                            saveFileDialog.Title = "Save Excel File";
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string filePath = saveFileDialog.FileName;
                                excelPackage.SaveAs(new FileInfo(filePath));
                                MessageBox.Show("Report generated successfully!");
                            }
                        }
                    }
                }
            }
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            new GeneratePDF().Show();
        }

        private void menuItem12_Click(object sender, EventArgs e)
        {
            List<string> dateColumns = new List<string>
            {
            "Date", "ECCDateIssued", "WDPDateIssued", "PTODateIssued", "HWIDDateIssued", "ValidityOfPOC", "DateDesludge", "ReinspectDate"
            };
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls",
                Title = "Select an Excel File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string excelFilePath = openFileDialog.FileName;

                using (var package = new ExcelPackage(new System.IO.FileInfo(excelFilePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];

                    string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();


                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                        {
                            bulkCopy.DestinationTableName = "InspectionReport";


                            bulkCopy.ColumnMappings.Add("AccountNo", "AccountNo");
                            bulkCopy.ColumnMappings.Add("BusinessName", "BusinessName");
                            bulkCopy.ColumnMappings.Add("Address", "Address");
                            bulkCopy.ColumnMappings.Add("Barangay", "Barangay");
                            bulkCopy.ColumnMappings.Add("Date", "Date");
                            bulkCopy.ColumnMappings.Add("NatureOfBusiness", "NatureOfBusiness");
                            bulkCopy.ColumnMappings.Add("EstablishmentHas", "EstablishmentHas");
                            bulkCopy.ColumnMappings.Add("BusinessStatus", "BusinessStatus");
                            bulkCopy.ColumnMappings.Add("EstablishmentIs", "EstablishmentIs");
                            bulkCopy.ColumnMappings.Add("Violations", "Violations");
                            bulkCopy.ColumnMappings.Add("ComplyWithin", "ComplyWithin");
                            bulkCopy.ColumnMappings.Add("SecuretheFF", "SecuretheFF");
                            bulkCopy.ColumnMappings.Add("AttendSeminar", "AttendSeminar");
                            bulkCopy.ColumnMappings.Add("MayorsPermit", "MayorsPermit");
                            bulkCopy.ColumnMappings.Add("EPPFee", "EPPFee");
                            bulkCopy.ColumnMappings.Add("ECCCNC", "ECCCNC");
                            bulkCopy.ColumnMappings.Add("ECCCNCNo", "ECCCNCNo");
                            bulkCopy.ColumnMappings.Add("ECCDateIssued", "ECCDateIssued");
                            bulkCopy.ColumnMappings.Add("WDP", "WDP");
                            bulkCopy.ColumnMappings.Add("WDPNo", "WDPNo");
                            bulkCopy.ColumnMappings.Add("WDPDateIssued", "WDPDateIssued");
                            bulkCopy.ColumnMappings.Add("PTO", "PTO");
                            bulkCopy.ColumnMappings.Add("PTONo", "PTONo");
                            bulkCopy.ColumnMappings.Add("PTODateIssued", "PTODateIssued");
                            bulkCopy.ColumnMappings.Add("HWID", "HWID");
                            bulkCopy.ColumnMappings.Add("HWIDNo", "HWIDNo");
                            bulkCopy.ColumnMappings.Add("HWIDDateIssued", "HWIDDateIssued");
                            bulkCopy.ColumnMappings.Add("HasPollutionOfficer", "HasPollutionOfficer");
                            bulkCopy.ColumnMappings.Add("PollutionOfficer", "PollutionOfficer");
                            bulkCopy.ColumnMappings.Add("Accreditation", "Accreditation");
                            bulkCopy.ColumnMappings.Add("ValidityOfPOC", "ValidityOfPOC");
                            bulkCopy.ColumnMappings.Add("Email", "Email");
                            bulkCopy.ColumnMappings.Add("HasWasteBin", "HasWasteBin");
                            bulkCopy.ColumnMappings.Add("BinsLabeled", "BinsLabeled");
                            bulkCopy.ColumnMappings.Add("BinsCovered", "BinsCovered");
                            bulkCopy.ColumnMappings.Add("BinsSegregated", "BinsSegregated");
                            bulkCopy.ColumnMappings.Add("MRF", "MRF");
                            bulkCopy.ColumnMappings.Add("WasteCollected", "WasteCollected");
                            bulkCopy.ColumnMappings.Add("FrequencyHauling", "FrequencyHauling");
                            bulkCopy.ColumnMappings.Add("Hauler", "Hauler");
                            bulkCopy.ColumnMappings.Add("HasSeptic", "HasSeptic");
                            bulkCopy.ColumnMappings.Add("LocationSeptic", "LocationSeptic");
                            bulkCopy.ColumnMappings.Add("FrequencyDesludge", "FrequencyDesludge");
                            bulkCopy.ColumnMappings.Add("DateDesludge", "DateDesludge");
                            bulkCopy.ColumnMappings.Add("ServiceProvider", "ServiceProvider");
                            bulkCopy.ColumnMappings.Add("HasGreaseTrap", "HasGreaseTrap");
                            bulkCopy.ColumnMappings.Add("LocationGrease", "LocationGrease");
                            bulkCopy.ColumnMappings.Add("CapacityGreaseTrap", "CapacityGreaseTrap");
                            bulkCopy.ColumnMappings.Add("FrequencyGrease", "FrequencyGrease");
                            bulkCopy.ColumnMappings.Add("HaulerGrease", "HaulerGrease");
                            bulkCopy.ColumnMappings.Add("HasWasteWater", "HasWasteWater");
                            bulkCopy.ColumnMappings.Add("UsedOilProperlyDisposed", "UsedOilProperlyDisposed");
                            bulkCopy.ColumnMappings.Add("TypeofOil", "TypeofOil");
                            bulkCopy.ColumnMappings.Add("FrequencyofHaulingOil", "FrequencyofHaulingOil");
                            bulkCopy.ColumnMappings.Add("HaulerOil", "HaulerOil");
                            bulkCopy.ColumnMappings.Add("HasAirPollutionManager", "HasAirPollutionManager");
                            bulkCopy.ColumnMappings.Add("DeviceType", "DeviceType");
                            bulkCopy.ColumnMappings.Add("MaintenanceProvider", "MaintenanceProvider");
                            bulkCopy.ColumnMappings.Add("PurposeOfInspection", "PurposeOfInspection");
                            bulkCopy.ColumnMappings.Add("ReinspectDate", "ReinspectDate");
                            bulkCopy.ColumnMappings.Add("LevelofInspection", "LevelofInspection");
                            bulkCopy.ColumnMappings.Add("LandUse", "LandUse");
                            bulkCopy.ColumnMappings.Add("OwnershipTerms", "OwnershipTerms");
                            bulkCopy.ColumnMappings.Add("Lessee", "Lessee");
                            bulkCopy.ColumnMappings.Add("StandAlone", "StandAlone");
                            bulkCopy.ColumnMappings.Add("InspectorObservation", "InspectorObservation");
                            bulkCopy.ColumnMappings.Add("Directives", "Directives");
                            bulkCopy.ColumnMappings.Add("Recommendations", "Recommendations");
                            bulkCopy.ColumnMappings.Add("Inspector", "Inspector");
                            bulkCopy.ColumnMappings.Add("Encoder", "Encoder");

                            DataTable dt = new DataTable();

                            foreach (var firstRowCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
                            {
                                dt.Columns.Add(firstRowCell.Text);
                            }

                            for (var rowNumber = 2; rowNumber <= worksheet.Dimension.End.Row; rowNumber++)
                            {
                                var worksheetRow = worksheet.Cells[rowNumber, 1, rowNumber, worksheet.Dimension.End.Column];
                                var row = dt.NewRow();
                                foreach (var cell in worksheetRow)
                                {
                                    if (cell.Text != null && dateColumns.Contains(cell.Text)) // Check if it's a date column
                                    {
                                        if (string.IsNullOrEmpty(cell.Text))
                                        {
                                            // Handle empty date values, e.g., set it to DBNull.Value
                                            row[cell.Start.Column - 1] = DBNull.Value;
                                        }
                                        else
                                        {
                                            if (DateTime.TryParseExact(cell.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateValue))
                                            {
                                                row[cell.Start.Column - 1] = dateValue;
                                            }
                                            else
                                            {
                                                // Handle invalid date format here, e.g., set it to DBNull.Value
                                                row[cell.Start.Column - 1] = DBNull.Value;

                                                // Print debug information to identify the problematic cell
                                                Console.WriteLine($"Invalid date format in cell {cell.Address}. Value: {cell.Text}");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (cell.Text == null)
                                        {
                                            // Handle the case where cell.Text is null, e.g., set it to an empty string or another default value
                                            row[cell.Start.Column - 1] = DBNull.Value; // or set it to another default value
                                        }
                                        else
                                        {
                                            row[cell.Start.Column - 1] = cell.Text;
                                        }
                                    }
                                }
                                dt.Rows.Add(row);
                            }
                            bulkCopy.WriteToServer(dt);
                        }
                    }

                    MessageBox.Show("Data imported successfully!");
                }
            }
        }
        private void menuItem14_Click(object sender, EventArgs e)
        {
            new Compliance().Show();
        }
        private void menuItem15_Click(object sender, EventArgs e)
        {
            new Violations().Show();
        }
    }
}
