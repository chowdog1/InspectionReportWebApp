using System;
using Wisej.Web;
using BCrypt.Net;
using System.Data.SqlClient;

namespace InspectionReportWebApp
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            string oldPassword = oldpwtextBox.Text;
            string newPassword = newpwtextBox.Text;
            string confirmPassword = confirmnewtextBox.Text;
            string loggedInUsername = AuthenticatedUser.UserName;

            if (string.IsNullOrEmpty(loggedInUsername))
            {
                MessageBox.Show("User not authenticated");
                return;
            }

            if (!VerifyCurrentPassword(loggedInUsername, oldPassword))
            {
                MessageBox.Show("Incorrect old password");
                oldpwtextBox.Focus();
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirmed password do not match");
                newpwtextBox.Focus();
                return;
            }

            string newSalt = BCrypt.Net.BCrypt.GenerateSalt(12);

            string newHashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword, newSalt);

            if (UpdatePasswordInDatabase(loggedInUsername, newHashedPassword, newSalt))
            {
                MessageBox.Show("Password Changed");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update password");
            }
        }
        private bool VerifyCurrentPassword(string username, string oldPassword)
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Password FROM Users WHERE Username = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);

                    string storedHashedPassword = (string)command.ExecuteScalar();

                    return BCrypt.Net.BCrypt.Verify(oldPassword, storedHashedPassword);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    return false;
                }
            }
        }
        private bool UpdatePasswordInDatabase(string username, string newHashedPassword, string newSalt)
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Users SET Password = @Password, Salt = @Salt WHERE Username = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Password", newHashedPassword);
                    command.Parameters.AddWithValue("@Salt", newSalt);
                    command.Parameters.AddWithValue("@Username", username);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
