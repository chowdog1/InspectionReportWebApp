using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Wisej.Web;


namespace InspectionReportWebApp
{
    public partial class Compliance : Form
    {
        public Compliance()
        {
            InitializeComponent();
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertOrUpdateQuery = @"
                        MERGE INTO Compliance AS target
                        USING (
                            SELECT i.AccountNo, i.BusinessName, i.Address, i.Barangay, i.BusinessStatus, i.SecuretheFF AS Compliances
                            FROM InspectionReport i
                            WHERE i.EstablishmentHas IN ('Violated City Ordinances', 'Notice/Warning')
                        ) AS source
                        ON target.AccountNo = source.AccountNo
                        WHEN MATCHED THEN
                            UPDATE SET
                                target.BusinessName = source.BusinessName,
                                target.Address = source.Address,
                                target.Barangay = source.Barangay,
                                target.BusinessStatus = source.BusinessStatus,
                                target.Compliances = source.Compliances
                        WHEN NOT MATCHED BY TARGET THEN
                            INSERT (AccountNo, BusinessName, Address, Barangay, BusinessStatus, Compliances)
                            VALUES (source.AccountNo, source.BusinessName, source.Address, source.Barangay, source.BusinessStatus, source.Compliances)
                        WHEN NOT MATCHED BY SOURCE THEN
                            DELETE;
                    ";
                using (SqlCommand insertOrUpdateCommand = new SqlCommand(insertOrUpdateQuery, connection))
                {
                    int rowsAffected = insertOrUpdateCommand.ExecuteNonQuery();
                    // rowsAffected will contain the total number of rows affected by INSERT, UPDATE, and DELETE operations
                    PopulateDataGridView();
                }
            }
        }
        private void PopulateDataGridView()
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string selectQuery = "SELECT * FROM Compliance";

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

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string update = "Update Compliance SET " +
                                "Compliances = " +
                                "CASE " +
                                "WHEN LEN(ISNULL(@Compliances, '')) > 0 AND LEN(ISNULL(Compliances, '')) > 0 " +
                                "THEN COALESCE(Compliances + ', ', '') + @Compliances " +
                                "WHEN LEN(ISNULL(@Compliances, '')) > 0 " +
                                "THEN @Compliances " +
                                "ELSE Compliances " +
                                "END, " +
                                "Others = " +
                                "CASE " +
                                "WHEN LEN(ISNULL(@Others, '')) > 0 AND LEN(ISNULL(Others, '')) > 0 " +
                                "THEN COALESCE(Others + ', ', '') + @Others " +
                                "WHEN LEN(ISNULL(@Others, '')) > 0 " +
                                "THEN @Others " +
                                "ELSE Others " +
                                "END, " +
                                "IsComplied = CASE " +
                                "WHEN LEN(ISNULL(@IsComplied, '')) > 0 THEN @IsComplied " +
                                "ELSE IsComplied " +
                                "END " +
                                "WHERE AccountNo = @AccountNo";
                using (SqlCommand cmd = new SqlCommand(update, con))
                {
                    cmd.Parameters.AddWithValue("@AccountNo", acctnotextBox.Text);
                    cmd.Parameters.AddWithValue("@Compliances", string.Join(", ", compliancechklistBox.CheckedItems.Cast<string>()));
                    cmd.Parameters.AddWithValue("@Others", otherstextBox.Text);
                    cmd.Parameters.AddWithValue("@IsComplied", GetSelectedRadioButtonText(submittedyesradioBtn, submittednoradioBtn));

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();


                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Successfully Updated!");
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

        private void menuItem2_Click(object sender, EventArgs e)
        {
            new PrintCompliance().Show();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
