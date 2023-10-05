using System;
using System.Data.SqlClient;
using System.Data;
using Wisej.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Linq;

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
        //private LogForm? logform;
        private List<string> logEntries = new List<string>();
        private string logFilePath = "log.txt";
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

            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
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
                        //LogEvent("Added Data");
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
    }
}
