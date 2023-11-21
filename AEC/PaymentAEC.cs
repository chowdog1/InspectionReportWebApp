using System;
using System.Data;
using System.Data.SqlClient;
using Wisej.Web;


namespace InspectionReportWebApp.AEC
{
    public partial class PaymentAEC : Form
    {
        private DateTime? dop;
        public PaymentAEC()
        {
            InitializeComponent();

            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=AEC;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string showtable = "SELECT * From Payments";
                using (SqlCommand cmd = new SqlCommand(showtable, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }

            dopdatetimePicker.Format = DateTimePickerFormat.Custom;
            dopdatetimePicker.CustomFormat = "--/--/----";
            dopdatetimePicker.ValueChanged += dopdatetimePicker_ValueChanged;
        }
        private void PopulateDataGridView()
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=AEC;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string showtable = "SELECT * From Payments";
                using (SqlCommand cmd = new SqlCommand(showtable, con))
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
        private void ClearForm()
        {
            accountnotxtBox.Clear();

            dopdatetimePicker.Format = DateTimePickerFormat.Custom;
            dopdatetimePicker.CustomFormat = "--/--/----";

            // Subscribe to the ValueChanged event
            dopdatetimePicker.ValueChanged += dopdatetimePicker_ValueChanged;

            amounttxtBox.Clear();
            ornotxtBox.Clear();
            foryearcmbBox.SelectedIndex = -1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=AEC;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string searchQuery = "SELECT * FROM Payments where AccountNo=@AccountNo";

                using (SqlCommand cmd = new SqlCommand(searchQuery, con))
                {
                    cmd.Parameters.AddWithValue("@AccountNo", accountnotxtBox.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=AEC;Integrated Security=True";
            string accountno = accountnotxtBox.Text;

            if (string.IsNullOrEmpty(accountno))
            {
                MessageBox.Show("Please fill in the Account No.", "Required Field Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string selectedYear = foryearcmbBox.SelectedItem.ToString();

            DialogResult result = MessageBox.Show("Are you sure you want to adjust the payment for year " + selectedYear + "?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    int paidselectedYear = Convert.ToInt32(foryearcmbBox.SelectedItem);
                    string adjustment = $"UPDATE Payments SET AdjustmentDatePaid{paidselectedYear} = @AdjustmentDatePaid, " +
                                        $"AdjustmentAmountPaid{paidselectedYear} = @AdjustmentAmountPaid, " +
                                        $"AdjustmentOR{paidselectedYear} = @AdjustmentOR " +
                                        $"WHERE AccountNo = @AccountNo";
                    using (SqlCommand cmd = new SqlCommand(adjustment, con))
                    {
                        cmd.Parameters.AddWithValue("@AccountNo", accountnotxtBox.Text);
                        if (dop.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@AdjustmentDatePaid", dopdatetimePicker.Value.ToString("yyyy/MM/dd"));
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@AdjustmentDatePaid", DBNull.Value);
                        }
                        cmd.Parameters.AddWithValue("@AdjustmentAmountPaid", amounttxtBox.Text);
                        cmd.Parameters.AddWithValue("@AdjustmentOR", ornotxtBox.Text);

                        try
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Successfully Updated!");
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
                            Console.WriteLine("Error Number: " + ex.Number);
                            Console.WriteLine("Error Procedure: " + ex.Procedure);
                            Console.WriteLine("Error Line Number: " + ex.LineNumber);
                        }
                    }
                }
            }
        }
        private void dopdatetimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (dopdatetimePicker.Value == DateTimePicker.MinimumDateTime)
            {
                dopdatetimePicker.CustomFormat = "--/--/----";
                dop = null;
            }
            else
            {
                dopdatetimePicker.CustomFormat = "yyyy/MM/dd";
                dop = dopdatetimePicker.Value;
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 7 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 10 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 14 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 17 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 20 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 24 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 27 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 30 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 34 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 37 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 40 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 44 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 47 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 50 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 54 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 57 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 60 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
