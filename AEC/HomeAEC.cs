using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using Wisej.Web;


namespace InspectionReportWebApp.AEC
{
    public partial class HomeAEC : Form
    {
        private DateTime? dateapplication;
        private DateTime? dateassessed;
        private DateTime? datepaid;
        public HomeAEC()
        {
            InitializeComponent();

            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=AEC;Integrated Security=True";

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string showtable = "SELECT * FROM AECData";

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


            doadatetimePicker.Format = DateTimePickerFormat.Custom;
            doadatetimePicker.CustomFormat = "--/--/----";
            doadatetimePicker.ValueChanged += doadatetimePicker_ValueChanged;

            dateassesseddatetimePicker.Format = DateTimePickerFormat.Custom;
            dateassesseddatetimePicker.CustomFormat = "--/--/----";
            dateassesseddatetimePicker.ValueChanged += dateassesseddatetimePicker_ValueChanged;

            datepaiddatetimePicker.Format = DateTimePickerFormat.Custom;
            datepaiddatetimePicker.CustomFormat = "--/--/----";
            datepaiddatetimePicker.ValueChanged += datepaiddatetimePicker_ValueChanged;

        }
        private void ClearForm()
        {
            accountnotxtBox.Clear();
            businessnametxtBox.Clear();
            nameownertxtBox.Clear();
            addresstxtBox.Clear();
            amountassessedtxtBox.Clear();
            amountpaidtxtBox.Clear();

            brgycmbBox.SelectedIndex = -1;
            natureofbusinesscmbBox.SelectedIndex = -1;
            businesstypecmbBox.SelectedIndex = -1;
            applicationstatuscmbBox.SelectedIndex = -1;
            yearassessedcmbBox.SelectedIndex -= 1;
            amountpaidyearcmbBox.SelectedIndex -= 1;

            doadatetimePicker.Enabled = false;
            businessnametxtBox.Enabled = false;
            addresstxtBox.Enabled = false;
            nameownertxtBox.Enabled = false;
            brgycmbBox.Enabled = false;
            natureofbusinesscmbBox.Enabled = false;
            businesstypecmbBox.Enabled = false;

            doadatetimePicker.Format = DateTimePickerFormat.Custom;
            doadatetimePicker.CustomFormat = "--/--/----";
            doadatetimePicker.ValueChanged += doadatetimePicker_ValueChanged;

            dateassesseddatetimePicker.Format = DateTimePickerFormat.Custom;
            dateassesseddatetimePicker.CustomFormat = "--/--/----";
            dateassesseddatetimePicker.ValueChanged += dateassesseddatetimePicker_ValueChanged;

            datepaiddatetimePicker.Format = DateTimePickerFormat.Custom;
            datepaiddatetimePicker.CustomFormat = "--/--/----";
            datepaiddatetimePicker.ValueChanged += datepaiddatetimePicker_ValueChanged;

        }

        private void PopulateDataGridView()
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=AEC;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string showtable = "SELECT * FROM AECData";

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
        private void submitBtn_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=AEC;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                if (applicationstatuscmbBox.Text == "NEW")
                {
                    string insert = "INSERT INTO AECData (AccountNo, DateofApplication, BusinessName, NameofOwner, Address, Barangay, NatureofBusiness, BusinessType) " +
                                    "VALUES (@AccountNo, @DateofApplication, @BusinessName, @NameofOwner, @Address, @Barangay, @NatureofBusiness, @BusinessType)";

                    using (SqlCommand cmd = new SqlCommand(insert, con))
                    {
                        cmd.Parameters.AddWithValue("@AccountNo", accountnotxtBox.Text);
                        if (dateapplication.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@DateofApplication", doadatetimePicker.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@DateofApplication", DBNull.Value);
                        }
                        cmd.Parameters.AddWithValue("@BusinessName", businessnametxtBox.Text);
                        cmd.Parameters.AddWithValue("@NameofOwner", nameownertxtBox.Text);
                        cmd.Parameters.AddWithValue("@Address", addresstxtBox.Text);
                        cmd.Parameters.AddWithValue("@Barangay", brgycmbBox.Text);
                        cmd.Parameters.AddWithValue("@NatureofBusiness", natureofbusinesscmbBox.Text);
                        cmd.Parameters.AddWithValue("@BusinessType", businesstypecmbBox.Text);

                        int assessedselectedYear = Convert.ToInt32(yearassessedcmbBox.SelectedItem);
                        int paidselectedYear = Convert.ToInt32(amountpaidyearcmbBox.SelectedItem);
                        string insertPayment = $"INSERT INTO Payments (AccountNo, BusinessName, NameofOwner, BusinessAddress, " +
                                               $"AssessedDate{assessedselectedYear}, AssessedAmount{assessedselectedYear}, AssessedFor{assessedselectedYear}, " +
                                               $"DatePaid{paidselectedYear}, AmountPaid{paidselectedYear}, OR{paidselectedYear}, PaidForYear{paidselectedYear}) " +
                                               $"VALUES (@AccountNo, @BusinessName, @NameofOwner, @BusinessAddress, @AssessedDate, @AssessedAmount, @AssessedForYear, " +
                                               $"@DatePaid, @AmountPaid, @OR, @PaidForYear)";

                        using (SqlCommand cmd2 = new SqlCommand(insertPayment, con))
                        {
                            cmd2.Parameters.AddWithValue("@AccountNo", accountnotxtBox.Text);
                            cmd2.Parameters.AddWithValue("@BusinessName", businessnametxtBox.Text);
                            cmd2.Parameters.AddWithValue("@NameofOwner", nameownertxtBox.Text);
                            cmd2.Parameters.AddWithValue("@BusinessAddress", businessnametxtBox.Text);
                            if (dateassessed.HasValue)
                            {
                                cmd2.Parameters.AddWithValue("@AssessedDate", dateassesseddatetimePicker.Value);
                            }
                            else
                            {
                                cmd2.Parameters.AddWithValue("@AssessedDate", DBNull.Value);
                            }
                            cmd2.Parameters.AddWithValue("@AssessedAmount", amountassessedtxtBox.Text);
                            cmd2.Parameters.AddWithValue("@AssessedForYear", yearassessedcmbBox.Text);
                            if (datepaid.HasValue)
                            {
                                cmd2.Parameters.AddWithValue("@DatePaid", datepaiddatetimePicker.Value);
                            }
                            else
                            {
                                cmd2.Parameters.AddWithValue("@DatePaid", DBNull.Value);
                            }
                            cmd2.Parameters.AddWithValue("@AmountPaid", amountpaidtxtBox.Text);
                            cmd2.Parameters.AddWithValue("@OR", ornotxtBox.Text);
                            cmd2.Parameters.AddWithValue("@PaidForYear", amountpaidyearcmbBox.Text);

                            try
                            {
                                cmd.ExecuteNonQuery();
                                cmd2.ExecuteNonQuery();
                                MessageBox.Show("Successfully Saved!");
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
                else if (applicationstatuscmbBox.Text == "RENEWAL")
                {
                    int assessedselectedYear = Convert.ToInt32(yearassessedcmbBox.SelectedItem);
                    int paidselectedYear = Convert.ToInt32(amountpaidyearcmbBox.SelectedItem);
                    string insertPayment = $"UPDATE Payments SET " +
                                           $"BusinessName = @BusinessName, NameofOwner = @NameofOwner, " +
                                           $"BusinessAddress = @BusinessAddress, " +
                                           $"AssessedDate{assessedselectedYear} = @AssessedDate, AssessedAmount{assessedselectedYear} = @AssessedAmount, AssessedFor{assessedselectedYear} = @AssessedForYear, " +
                                           $"DatePaid{paidselectedYear} = @DatePaid, AmountPaid{paidselectedYear} = @AmountPaid, OR{paidselectedYear} = @OR, PaidForYear{paidselectedYear} = @PaidForYear " +
                                           $"WHERE AccountNo = @AccountNo";

                    using (SqlCommand cmd2 = new SqlCommand(insertPayment, con))
                    {
                        cmd2.Parameters.AddWithValue("@AccountNo", accountnotxtBox.Text);
                        cmd2.Parameters.AddWithValue("@BusinessName", businessnametxtBox.Text);
                        cmd2.Parameters.AddWithValue("@NameofOwner", nameownertxtBox.Text);
                        cmd2.Parameters.AddWithValue("@BusinessAddress", businessnametxtBox.Text);
                        if (dateassessed.HasValue)
                        {
                            cmd2.Parameters.AddWithValue("@AssessedDate", dateassesseddatetimePicker.Value);
                        }
                        else
                        {
                            cmd2.Parameters.AddWithValue("@AssessedDate", DBNull.Value);
                        }
                        cmd2.Parameters.AddWithValue("@AssessedAmount", amountassessedtxtBox.Text);
                        cmd2.Parameters.AddWithValue("@AssessedForYear", yearassessedcmbBox.Text);
                        if (datepaid.HasValue)
                        {
                            cmd2.Parameters.AddWithValue("@DatePaid", datepaiddatetimePicker.Value);
                        }
                        else
                        {
                            cmd2.Parameters.AddWithValue("@DatePaid", DBNull.Value);
                        }
                        cmd2.Parameters.AddWithValue("@AmountPaid", amountpaidtxtBox.Text);
                        cmd2.Parameters.AddWithValue("@OR", ornotxtBox.Text);
                        cmd2.Parameters.AddWithValue("@PaidForYear", amountpaidyearcmbBox.Text);

                        try
                        {
                            cmd2.ExecuteNonQuery();
                            MessageBox.Show("Successfully Saved!");
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
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void doadatetimePicker_ValueChanged(object sender, EventArgs e)
        {
            if(doadatetimePicker.Value == DateTimePicker.MinimumDateTime.Date)
            {
                doadatetimePicker.CustomFormat = "--/--/----";
                dateapplication = null;
            }
            else
            {
                doadatetimePicker.CustomFormat = "yyyy/MM/dd";
                dateapplication = doadatetimePicker.Value.Date;
            }
        }
        private void dateassesseddatetimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (dateassesseddatetimePicker.Value == DateTimePicker.MinimumDateTime.Date)
            {
                dateassesseddatetimePicker.CustomFormat = "--/--/----";
                dateassessed = null;
            }
            else
            {
                dateassesseddatetimePicker.CustomFormat = "yyyy/MM/dd";
                dateassessed = dateassesseddatetimePicker.Value.Date;
            }
        }
        private void datepaiddatetimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (datepaiddatetimePicker.Value == DateTimePicker.MinimumDateTime.Date)
            {
                datepaiddatetimePicker.CustomFormat = "--/--/----";
                datepaid = null;
            }
            else
            {
                datepaiddatetimePicker.CustomFormat = "yyyy/MM/dd";
                datepaid = datepaiddatetimePicker.Value.Date;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            new PaymentAEC().Show();
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.Value is DateTime)
            {
                e.Value = ((DateTime)e.Value).ToString("yyyy/MM/dd");
                e.FormattingApplied = true;
            }
        }
        private void RetrieveData(string accountno)
        {
            using(SqlConnection con = new SqlConnection("Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=AEC;Integrated Security=True"))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM AECData WHERE AccountNo = @AccountNo", con))
                {
                    cmd.Parameters.AddWithValue("@AccountNo", accountno);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            doadatetimePicker.Value = Convert.ToDateTime(reader["DateofApplication"]);
                            businessnametxtBox.Text = reader["BusinessName"].ToString();
                            addresstxtBox.Text = reader["Address"].ToString();
                            nameownertxtBox.Text = reader["NameofOwner"].ToString();
                            brgycmbBox.Text = reader["Barangay"].ToString();
                            natureofbusinesscmbBox.Text = reader["NatureofBusiness"].ToString();
                            businesstypecmbBox.Text = reader["BusinessType"].ToString();
                        }
                    }
                }
            }
        }
        private void applicationstatuscmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(applicationstatuscmbBox.Text == "NEW")
            {
                doadatetimePicker.Enabled = true;
                businessnametxtBox.Enabled = true;
                addresstxtBox.Enabled = true;
                nameownertxtBox.Enabled = true;
                brgycmbBox.Enabled = true;
                natureofbusinesscmbBox.Enabled = true;
                businesstypecmbBox.Enabled = true;
            }
            else if(applicationstatuscmbBox.Text == "RENEWAL")
            {
                doadatetimePicker.Enabled = false;
                businessnametxtBox.Enabled = false;
                addresstxtBox.Enabled = false;
                nameownertxtBox.Enabled = false;
                brgycmbBox.Enabled = false;
                natureofbusinesscmbBox.Enabled = false;
                businesstypecmbBox.Enabled = false;
                string accountno = accountnotxtBox.Text;
                RetrieveData(accountno);
            }    
        }

        private void label2_Click(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                this.Close();
                Loginpage Loginpage = new Loginpage();
                Loginpage.Show();
            }
        }
    }
}
