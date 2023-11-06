using System;
using System.Data.SqlClient;
using Wisej.Web;


namespace InspectionReportWebApp
{
    public partial class Loginpage : Form
    {
        public string Username { get; private set; }
        public event EventHandler AdminLoggedIn;
        public event EventHandler RegularLoggedIn;
        public inspectionReport inspectionReportInstance { get; set; }
        public Loginpage()
        {
            Username = "defaultusername";
            InitializeComponent();
            this.AcceptButton = loginBtn;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = usernametxtBox.Text;
            string password = passwordtxtBox.Text;

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True"))
            {
                con.Open();

                string loginQuery = "SELECT * FROM Users WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(loginQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        bool isLocked = DBNull.Value.Equals(dr["IsLocked"]) ? false : (bool)dr["IsLocked"];
                        if (isLocked)
                        {
                            MessageBox.Show("Account locked due to multiple failed login attempts. Contact an administrator.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string storedHashedPassword = dr["Password"]?.ToString() ?? string.Empty;
                        bool IsAdmin = (bool)dr["IsAdmin"];
                        int failedLoginAttempts = dr["FailedLoginAttempts"] != DBNull.Value ? Convert.ToInt32(dr["FailedLoginAttempts"]) : 0;

                        if (BCrypt.Net.BCrypt.Verify(password, storedHashedPassword))
                        {
                            UpdateFailedLoginAttempts(username, 0);

                            AuthenticatedUser.UserName = username;
                            AuthenticatedUser.IsAdmin = IsAdmin;
                            //inspectionReport mainPage = new inspectionReport();
                            HomePageAdmin homePageAdmin = new HomePageAdmin();
                            HomePageRegular homePageRegular = new HomePageRegular();
                            if (!IsAdmin)
                            {
                                RegularLoggedIn?.Invoke(this, EventArgs.Empty);
                                homePageRegular.Show();
                                this.Hide();
                            }
                            else if (IsAdmin)
                            {
                                AdminLoggedIn?.Invoke(this, EventArgs.Empty);
                                homePageAdmin.Show();
                                this.Hide();
                            }


                            UpdateFailedLoginAttempts(username, 0);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password. Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            usernametxtBox.Clear();
                            passwordtxtBox.Clear();
                            usernametxtBox.Focus();

                            failedLoginAttempts++;
                            if (failedLoginAttempts >= 5)
                            {
                                LockAccount(username);
                                MessageBox.Show("Account locked due to multiple failed login attempts. Contact an administrator.", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                UpdateFailedLoginAttempts(username, failedLoginAttempts);
                            }
                        }
                    }
                    else
                    {
                        // User with the given username doesn't exist
                        MessageBox.Show("User does not exist", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        usernametxtBox.Clear();
                        passwordtxtBox.Clear();
                        usernametxtBox.Focus();
                    }
                }
            }
        }
        private void UpdateFailedLoginAttempts(string username, int attempts)
        {
            // Update the FailedLoginAttempts column in the database
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True"))
            {
                con.Open();

                string updateQuery = "UPDATE Users SET FailedLoginAttempts = @Attempts WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Attempts", attempts);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void LockAccount(string username)
        {
            // Implement account locking logic here (e.g., set a flag in the database)
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True"))
            {
                con.Open();

                string lockQuery = "UPDATE Users SET IsLocked = 1 WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(lockQuery, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void showchkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showchkBox.Checked)
            {
                passwordtxtBox.PasswordChar = '\0';
            }
            else
            {
                passwordtxtBox.PasswordChar = '•';
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new Request().Show();
            this.Hide();
        }
    }
}
