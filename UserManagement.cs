using System;
using System.Data.SqlClient;
using System.Data;
using Wisej.Web;


namespace InspectionReportWebApp
{
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Users", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewUsers.DataSource = dt;
        }
        private void PopulateDataGridView()
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewUsers.DataSource = dt;
            }
        }
        private void promoteuserDatabase(string username, bool isAdmin)
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string updateQuery = "UPDATE Users SET IsAdmin = @IsAdmin WHERE Username = @Username";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@IsAdmin", isAdmin);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Sql Error: " + ex.Message);
                    }
                }
            }
        }

        private void promoteuserBtn_Click(object sender, EventArgs e)
        {
            string searchUsername = usernametxtBox.Text.Trim();

            if (!string.IsNullOrEmpty(searchUsername))
            {
                DataTable dt = (DataTable)dataGridViewUsers.DataSource;

                if (dt != null)
                {
                    DataRow[] foundRows = dt.Select($"Username = '{searchUsername}'");

                    if (foundRows.Length > 0)
                    {
                        if (!(bool)foundRows[0]["IsAdmin"])
                        {
                            foundRows[0]["IsAdmin"] = true;
                            promoteuserDatabase(searchUsername, true);
                            dataGridViewUsers.Refresh();
                            MessageBox.Show($"{searchUsername} has been promoted to Admin.");
                            PopulateDataGridView();
                            usernametxtBox.Clear();
                            usernametxtBox.Focus();
                        }
                        else
                        {
                            MessageBox.Show($"{searchUsername} is already an Admin.");
                            usernametxtBox.Clear();
                            usernametxtBox.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"User '{searchUsername}' not found.");
                        usernametxtBox.Clear();
                        usernametxtBox.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter a username to search.");
            }
        }

        private void dltuserBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernametxtBox.Text))
            {
                MessageBox.Show("Please insert a username before attempting to delete.");
                return; // Exit the method
            }
            DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string DeleteQuery = "DELETE FROM Users WHERE Username=@Username";

                    using (SqlCommand cmd = new SqlCommand(DeleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", usernametxtBox.Text);

                        try
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                string message = usernametxtBox.Text + " has been successfully deleted!";
                                MessageBox.Show(message);
                                PopulateDataGridView();
                                usernametxtBox.Clear();
                                usernametxtBox.Focus();
                            }
                            else
                            {
                                MessageBox.Show("No records found for the given username.");
                            }
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine("Sql Error: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }
        private void demoteuserDatabase(string username, bool isAdmin)
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string updateQuery = "UPDATE Users SET IsAdmin = @IsAdmin WHERE Username = @Username";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@IsAdmin", isAdmin);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Sql Error: " + ex.Message);
                    }
                }
            }
        }
        private void removeadminBtn_Click(object sender, EventArgs e)
        {
            string searchUsername = usernametxtBox.Text.Trim();

            if (!string.IsNullOrEmpty(searchUsername))
            {
                DataTable dt = (DataTable)dataGridViewUsers.DataSource;

                if (dt != null)
                {
                    DataRow[] foundRows = dt.Select($"Username = '{searchUsername}'");

                    if (foundRows.Length > 0)
                    {
                        if ((bool)foundRows[0]["IsAdmin"])
                        {
                            foundRows[0]["IsAdmin"] = false;
                            demoteuserDatabase(searchUsername, false);

                            dataGridViewUsers.Refresh();

                            MessageBox.Show($"{searchUsername} admin rights removed.");
                            usernametxtBox.Clear();
                            usernametxtBox.Focus();
                        }
                        else
                        {
                            MessageBox.Show($"{searchUsername} is already a regular user.");
                            usernametxtBox.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"User '{searchUsername}' not found.");
                        usernametxtBox.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter a username to search.");
                usernametxtBox.Focus();
            }
        }

        private void unlockBtn_Click(object sender, EventArgs e)
        {
            string usernameToUnlock = usernametxtBox.Text;

            UnlockResult result = UnlockAccount(usernameToUnlock);

            if (result == UnlockResult.Success)
            {
                MessageBox.Show("Account unlocked successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopulateDataGridView();
                usernametxtBox.Clear();
            }
            else if (result == UnlockResult.AccountNotLocked)
            {
                MessageBox.Show("Failed to unlock account. Username not found or account is not locked.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("An error occurred while unlocking the account. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private enum UnlockResult
        {
            Success,
            AccountNotLocked,
            Error
        }
        private UnlockResult UnlockAccount(string username)
        {
            // This typically involves setting the IsLocked flag to 0 for the specified username.
            // Return true if the account is successfully unlocked; otherwise, return false.

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True"))
            {
                con.Open();

                string checkLockQuery = "SELECT IsLocked FROM Users WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(checkLockQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    bool isLocked = Convert.ToBoolean(cmd.ExecuteScalar());

                    if (!isLocked)
                    {
                        // Account is not locked
                        return UnlockResult.AccountNotLocked;
                    }
                }

                string unlockQuery = "UPDATE Users SET IsLocked = 0, FailedLoginAttempts = 0 WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(unlockQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return UnlockResult.Success;
                    }
                    else
                    {
                        return UnlockResult.Error;
                    } // Account was successfully unlocked if rowsAffected > 0
                }
            }
        }
    }
}
