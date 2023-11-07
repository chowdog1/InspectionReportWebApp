using System;
using System.Data.SqlClient;
using System.Data;
using Wisej.Web;
using System.Collections.Generic;


namespace InspectionReportWebApp.ECNC
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
            PopulateDataGridView();
        }
        private void PopulateDataGridView()
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=Construction;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string selectQuery = "SELECT * FROM ConstructionApplications";

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
        private void Clear()
        {
            applicationnotxtBox.Clear();
            brgycmbBox.SelectedIndex = -1;
            projecttypecmbBox.SelectedIndex = -1;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=Construction;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string applicationno = applicationnotxtBox.Text;
                string brgy = brgycmbBox.Text;
                string projecttype = projecttypecmbBox.Text;

                List<string> searchCriteria = new List<string>();

                if (!string.IsNullOrEmpty(brgy))
                {
                    searchCriteria.Add($"Barangay LIKE @Brgy");
                }

                if (!string.IsNullOrEmpty(applicationno))
                {
                    searchCriteria.Add($"ApplicationNo LIKE @ApplicationNo");
                }

                if (!string.IsNullOrEmpty(projecttype))
                {
                    searchCriteria.Add($"TypeofProject LIKE @ProjectType");
                }

                string query = "SELECT * FROM ConstructionApplications";
                if (searchCriteria.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", searchCriteria);
                }

                SqlCommand cmd = new SqlCommand(query, con);

                if (!string.IsNullOrEmpty(brgy))
                {
                    cmd.Parameters.AddWithValue("@Brgy", "%" + brgy + "%");
                }

                if (!string.IsNullOrEmpty(applicationno))
                {
                    cmd.Parameters.AddWithValue("@ApplicationNo", "%" + applicationno + "%");
                }

                if (!string.IsNullOrEmpty(projecttype))
                {
                    cmd.Parameters.AddWithValue("@ProjectType", "%" + projecttype + "%");
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                Clear();

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
