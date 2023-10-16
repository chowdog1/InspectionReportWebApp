using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using Wisej.Web;


namespace InspectionReportWebApp
{
    public partial class Violations : Form
    {
        private DateTime? dopdate;
        private DateTime? apprehension;
        public Violations()
        {
            InitializeComponent();

            dopdate = null;
            apprehension = null;

            dopdatetimePicker.Format = DateTimePickerFormat.Custom;
            dopdatetimePicker.CustomFormat = "dd/MM/yyyy";

            apprehensiondatetimePicker.Format = DateTimePickerFormat.Custom;
            apprehensiondatetimePicker.CustomFormat = "dd/MM/yyyy";

            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertOrUpdateQuery = @"
                                    MERGE INTO Violations AS target
                                    USING (
                                        SELECT i.AccountNo, i.BusinessName, i.Address, i.Barangay, i.BusinessStatus, i.Date AS ApprehensionDate, i.Violations, i.Inspector, i.OVR
                                        FROM InspectionReport i
                                        WHERE i.EstablishmentHas = 'Violated City Ordinances'
                                    ) AS source
                                    ON target.AccountNo = source.AccountNo
                                    WHEN MATCHED THEN
                                        UPDATE SET
                                            target.BusinessName = source.BusinessName,
                                            target.Address = source.Address,
                                            target.Barangay = source.Barangay,
                                            target.BusinessStatus = source.BusinessStatus,
                                            target.ApprehensionDate = source.ApprehensionDate,
                                            target.Violation = source.Violations,
                                            target.InspectorEEandEO = source.Inspector,
                                            target.OVR = source.OVR
                                    WHEN NOT MATCHED BY TARGET THEN
                                        INSERT (AccountNo, BusinessName, Address, Barangay, BusinessStatus, ApprehensionDate, Violation, InspectorEEandEO, OVR)
                                        VALUES (source.AccountNo, source.BusinessName, source.Address, source.Barangay, source.BusinessStatus, source.ApprehensionDate, source.Violations, source.Inspector, source.OVR)
                                    WHEN NOT MATCHED BY SOURCE THEN
                                        DELETE;
                                ";

                using (SqlCommand insertOrUpdateCommand = new SqlCommand(insertOrUpdateQuery, connection))
                {
                    int rowsAffected = insertOrUpdateCommand.ExecuteNonQuery();
                    // rowsAffected will contain the total number of rows affected by INSERT, UPDATE, and DELETE operations
                }

                PopulateDataGridView();
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
            dopdate = null;
            apprehension = null;

            acctnotextBox.Clear();
            ornotextBox.Clear();
            paidyesradioBtn.Checked = false;
            paidnoradioBtn.Checked = false;
            ClearSelectedItems(violationschklistBox);
            ClearSelectedItems(eoeechklistBox);
            dopdatetimePicker.Format = DateTimePickerFormat.Custom;
            dopdatetimePicker.CustomFormat = " ";
            apprehensiondatetimePicker.Format = DateTimePickerFormat.Custom;
            apprehensiondatetimePicker.CustomFormat = " ";
        }
        private void PopulateDataGridView()
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string selectQuery = "SELECT * FROM Violations";

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
        private void apprehensiondatetimePicker_ValueChanged(object sender, EventArgs e)
        {
            apprehensiondatetimePicker.CustomFormat = "dd/MM/yyyy";
            apprehension = apprehensiondatetimePicker.Value;
        }
        private void dopdatetimePicker_ValueChanged(object sender, EventArgs e)
        {
            dopdatetimePicker.CustomFormat = "dd/MM/yyyy";
            dopdate = dopdatetimePicker.Value;
        }
        private void submitBtn_Click(object sender, EventArgs e)
        {
            string accountNo = acctnotextBox.Text;

            if (string.IsNullOrEmpty(accountNo))
            {
                MessageBox.Show("Please enter an account number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the function
            }

            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string update = "UPDATE Violations SET " +
                                "ApprehensionDate = CASE " +
                                "WHEN LEN(ISNULL(@ApprehensionDate, '')) > 0 " +
                                "THEN COALESCE(CONVERT(NVARCHAR(MAX), ApprehensionDate, 120) + ', ', '') + CONVERT(NVARCHAR(MAX), @ApprehensionDate, 120) " +
                                "ELSE COALESCE(CONVERT(NVARCHAR(MAX), ApprehensionDate, 120), '') " +
                                "END, " +
                                "InspectorEEandEO = CASE " +
                                "WHEN LEN(ISNULL(@InspectorEEandEO, '')) > 0 AND LEN(ISNULL(InspectorEEandEO, '')) > 0 " +
                                "THEN COALESCE(InspectorEEandEO + ', ', '') + @InspectorEEandEO " +
                                "WHEN LEN(ISNULL(@InspectorEEandEO, '')) > 0 " +
                                "THEN @InspectorEEandEO " +
                                "ELSE InspectorEEandEO " +
                                "END, " +
                                "Violation = CASE " +
                                "WHEN LEN(ISNULL(@Violation, '')) > 0 AND LEN(ISNULL(Violation, '')) > 0 " +
                                "THEN COALESCE(Violation + ', ', '') + @Violation " +
                                "WHEN LEN(ISNULL(@Violation, '')) > 0 " +
                                "THEN @Violation " +
                                "ELSE Violation " +
                                "END, " +
                                "OVR = CASE " +
                                "WHEN LEN(ISNULL(@OVR, '')) > 0 AND LEN(ISNULL(OVR, '')) > 0 " +
                                "THEN COALESCE(OVR + ', ', '') + @OVR " +
                                "WHEN LEN(ISNULL(@OVR, '')) > 0 " +
                                "THEN @OVR " +
                                "ELSE OVR " +
                                "END, " +
                                "Paid = CASE " +
                                "WHEN LEN(ISNULL(@Paid, '')) > 0 THEN @Paid " +
                                "ELSE Paid " +
                                "END, " +
                                "ReceiptNo = CASE " +
                                "WHEN LEN(ISNULL(@ReceiptNo, '')) > 0 AND LEN(ISNULL(ReceiptNo, '')) > 0 " +
                                "THEN COALESCE(ReceiptNo + ', ', '') + @ReceiptNo " +
                                "WHEN LEN(ISNULL(@ReceiptNo, '')) > 0 " +
                                "THEN @ReceiptNo " +
                                "ELSE ReceiptNo " +
                                "END, " +
                                "DatePaid = CASE " +
                                "WHEN LEN(ISNULL(@DatePaid, '')) > 0 " +
                                "THEN COALESCE(CONVERT(NVARCHAR(MAX), DatePaid, 120) + ', ', '') + CONVERT(NVARCHAR(MAX), @DatePaid, 120) " +
                                "ELSE COALESCE(CONVERT(NVARCHAR(MAX), DatePaid, 120), '') " +
                                "END " +
                                "WHERE AccountNo = @AccountNo";

                using (SqlCommand cmd = new SqlCommand(update, con))
                {
                    cmd.Parameters.AddWithValue("@AccountNo", acctnotextBox.Text);
                    if (apprehension.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@ApprehensionDate", apprehensiondatetimePicker.Value.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ApprehensionDate", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@InspectorEEandEO", string.Join(", ", eoeechklistBox.CheckedItems.Cast<string>()));
                    cmd.Parameters.AddWithValue("@Violation", string.Join(", ", violationschklistBox.CheckedItems.Cast<string>()));
                    cmd.Parameters.AddWithValue("@OVR", ovrtextBox.Text);
                    cmd.Parameters.AddWithValue("@Paid", GetSelectedRadioButtonText(paidyesradioBtn, paidnoradioBtn));
                    cmd.Parameters.AddWithValue("@ReceiptNo", ornotextBox.Text);
                    if (dopdate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@DatePaid", dopdatetimePicker.Value.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DatePaid", DBNull.Value);
                    }

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Successfully Updated!");
                            PopulateDataGridView();
                            ClearForm();
                        }
                        else
                        {
                            MessageBox.Show("No record found for the specified Account No.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occured: " + ex.Message);
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
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void paymentbreakdownBtn_Click(object sender, EventArgs e)
        {
            string accountNo = acctnotextBox.Text;

            if (string.IsNullOrEmpty(accountNo))
            {
                MessageBox.Show("Please enter an account number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the function
            }

            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";

            // Assuming you have a database connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SQL command to retrieve violations for the specified account number
                string sqlQuery = "SELECT AccountNo, BusinessName, ApprehensionDate, Violation, InspectorEEandEO, OVR FROM Violations WHERE AccountNo = @AccountNo";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@AccountNo", accountNo);

                List<ViolationClass> violationsList = new List<ViolationClass>();

                // Execute the query and populate the violations list
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ViolationClass violation = new ViolationClass
                        {
                            AccountNo = reader["AccountNo"].ToString(),
                            BusinessName = reader["BusinessName"].ToString(),
                            ApprehensionDate = DateTime.TryParseExact(reader["ApprehensionDate"].ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime apprehensionDate)
                            ? (DateTime?)apprehensionDate
                            : null,
                            Inspector = reader["InspectorEEandEO"].ToString(),
                            ViolationCommitted = reader["Violation"].ToString(),
                            OVR = reader["OVR"].ToString()
                        };

                        violationsList.Add(violation);
                    }
                }

                // Close the database connection
                connection.Close();

                // Open the Payment Breakdown Form and pass the accountNo and violationsList as parameters
                PaymentBreakdown paymentBreakdownForm = new PaymentBreakdown(accountNo, violationsList);
                paymentBreakdownForm.ShowDialog();
            }
        }
    }
}
