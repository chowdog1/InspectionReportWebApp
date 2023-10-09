using System;
using System.Data;
using System.Data.SqlClient;
using Wisej.Web;


namespace InspectionReportWebApp
{
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=InspectionReport;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        private void registerBtn_Click(object sender, EventArgs e)
        {
            string username = usernametxtBox.Text;
            string password = passwordtxtBox.Text;
            string confirmPassword = confirmpasswordtxtBox.Text;
            bool IsAdmin = false;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Username and Password fields cannot be empty", "Sign up Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordtxtBox.Clear();
                confirmpasswordtxtBox.Clear();
                passwordtxtBox.Focus();
                return;
            }

            try
            {
                string salt = BCrypt.Net.BCrypt.GenerateSalt();

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

                con.Open();
                string register = "INSERT INTO Users (Username, Salt, Password, IsAdmin) VALUES (@Username, @Salt, @Password, @IsAdmin)";
                using (SqlCommand cmd = new SqlCommand(register, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Salt", salt);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    cmd.Parameters.AddWithValue("@IsAdmin", IsAdmin);
                    cmd.ExecuteNonQuery();
                }
                con.Close();

                usernametxtBox.Clear();
                passwordtxtBox.Clear();
                confirmpasswordtxtBox.Clear();

                MessageBox.Show("Your account has been successfully created!", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        private void showchkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showchkBox.Checked)
            {
                passwordtxtBox.PasswordChar = '\0';
                confirmpasswordtxtBox.PasswordChar = '\0';
            }
            else
            {
                passwordtxtBox.PasswordChar = '•';
                confirmpasswordtxtBox.PasswordChar = '•';
            }
        }
        private void clearBtn_Click(object sender, EventArgs e)
        {
            usernametxtBox.Focus();
            usernametxtBox.Clear();
            passwordtxtBox.Clear();
            confirmpasswordtxtBox.Clear();
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
