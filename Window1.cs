
using System;
using System.Data.SqlClient;
using System.Data;
using Wisej.Web;

namespace InspectionReportWebApp
{
    public partial class inspectionReport : Form
    {
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
        }
    }
}
