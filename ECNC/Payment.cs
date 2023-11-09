using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using Wisej.Web;


namespace InspectionReportWebApp.ECNC
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();

            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=Construction;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string showtable = @"
                                    MERGE INTO Payment AS Target
                                    USING (SELECT c.ApplicationNo, c.NameofProject, c.LocationofProject, c.TypeofProject, c.ProponentName 
                                           FROM ConstructionApplications c) AS Source
                                    ON Target.ApplicationNo = Source.ApplicationNo
                                    WHEN MATCHED THEN
                                        UPDATE SET
                                            Target.NameofProject = Source.NameofProject,
                                            Target.LocationofProject = Source.LocationofProject,
                                            Target.TypeofProject = Source.TypeofProject,
                                            Target.ProponentName = Source.ProponentName
                                    WHEN NOT MATCHED BY TARGET THEN
                                        INSERT (ApplicationNo, NameofProject, LocationofProject, TypeofProject, ProponentName)
                                        VALUES (Source.ApplicationNo, Source.NameofProject, Source.LocationofProject, Source.TypeofProject, Source.ProponentName)
                                    WHEN NOT MATCHED BY SOURCE THEN
                                        DELETE;
                                ";
                using (SqlCommand command = new SqlCommand(showtable, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    PopulateDataGridView();
                }
                                    
            }
        }
        private void PopulateDataGridView()
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=Construction;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string selectQuery = "SELECT * FROM Payment";

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

        private void submitBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=Construction;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string applicationNo = applicationnotxtBox.Text;
                string isPaidText = paidyesradioBtn.Checked ? "Yes" : (paidnoradioBtn.Checked ? "No" : "");

                string updateQuery = "UPDATE Payment SET Paid = CASE WHEN @isPaid = 'Yes' THEN 'Yes' ELSE 'No' END WHERE ApplicationNo = @ApplicationNo";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@isPaid", isPaidText);
                    cmd.Parameters.AddWithValue("@ApplicationNo", applicationNo);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Handle success.
                        MessageBox.Show("Payment information updated successfully.");
                        applicationnotxtBox.Clear();
                        paidyesradioBtn.Checked = false;
                        paidnoradioBtn.Checked = false;
                        PopulateDataGridView();
                    }
                    else
                    {
                        // Handle failure.
                        MessageBox.Show("Record not found");
                        applicationnotxtBox.Clear();
                        paidyesradioBtn.Checked = false;
                        paidnoradioBtn.Checked = false;
                        PopulateDataGridView();
                    }
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
