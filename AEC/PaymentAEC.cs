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
                    string adjustment = $"UPDATE Payments SET " +
                                        $"DatePaid{paidselectedYear} = " +
                                        $"CASE " +
                                        $"    WHEN LEN(ISNULL(@DatePaid, '')) > 0 " +
                                        $"    THEN COALESCE(CONVERT(VARCHAR, @DatePaid, 121) + ', ', '') + DatePaid{paidselectedYear} " +
                                        $"    ELSE DatePaid{paidselectedYear} " +
                                        $"END, " +
                                        $"AmountPaid{paidselectedYear} = CASE " +
                                        $"WHEN LEN(ISNULL(@AmountPaid, '')) > 0 AND LEN(ISNULL(AmountPaid{paidselectedYear}, '')) > 0 " +
                                        $"THEN COALESCE(AmountPaid{paidselectedYear} + ', ', '') + @AmountPaid " +
                                        $"WHEN LEN(ISNULL(@AmountPaid, '')) > 0 " +
                                        $"THEN @AmountPaid " +
                                        $"ELSE AmountPaid{paidselectedYear} " +
                                        $"END, " +
                                        $"OR{paidselectedYear} = CASE " +
                                        $"WHEN LEN(ISNULL(@OR, '')) > 0 AND LEN(ISNULL(OR{paidselectedYear}, '')) > 0 " +
                                        $"THEN COALESCE(OR{paidselectedYear} + ', ', '') + @OR " +
                                        $"WHEN LEN(ISNULL(@OR, '')) > 0 " +
                                        $"THEN @OR " +
                                        $"ELSE OR{paidselectedYear} " +
                                        $"END, " +
                                        $"PaidForYear{paidselectedYear} = COALESCE(@PaidForYear, PaidForYear{paidselectedYear}) " +
                                        $"WHERE AccountNo = @AccountNo";
                    using (SqlCommand cmd = new SqlCommand(adjustment, con))
                    {
                        cmd.Parameters.AddWithValue("@AccountNo", accountnotxtBox.Text);
                        if (dop.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@DatePaid", dopdatetimePicker.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@DatePaid", DBNull.Value);
                        }
                        cmd.Parameters.AddWithValue("@AmountPaid", amounttxtBox.Text);
                        cmd.Parameters.AddWithValue("@OR", ornotxtBox.Text);
                        cmd.Parameters.AddWithValue("@PaidForYear", foryearcmbBox.Text);

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
                        }
                    }
                }
            }
        }
        private void dopdatetimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (dopdatetimePicker.Value == DateTimePicker.MinimumDateTime.Date)
            {
                dopdatetimePicker.CustomFormat = "--/--/----";
                dop = null;
            }
            else
            {
                dopdatetimePicker.CustomFormat = "dd/MM/yyyy";
                dop = dopdatetimePicker.Value.Date;
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 7 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 11 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 14 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 18 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 21 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 25 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 28 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 32 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 35 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 39 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }

            if (e.ColumnIndex == 42 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }
        }
    }
}
