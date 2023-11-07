using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using Wisej.Web;


namespace InspectionReportWebApp.ECNC
{
    public partial class ConstructionMain : Form
    {
        private DateTime? doadate;
        private DateTime? datecompleted;
        public ConstructionMain()
        {
            InitializeComponent();

            doadate = null;
            datecompleted = null;

            doadateTimePicker.Format = DateTimePickerFormat.Custom;
            doadateTimePicker.CustomFormat = "dd/MM/yyyy";

            datecompletedateTimePicker.Format = DateTimePickerFormat.Custom;
            datecompletedateTimePicker.CustomFormat = "dd/MM/yyyy";
        }
        private void label3_Click(object sender, EventArgs e)
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
        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            Loginpage Loginpage = new Loginpage();
            Loginpage.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            if (AuthenticatedUser.IsAdmin)
            {
                HomePageAdmin homePageAdmin = new HomePageAdmin();
                homePageAdmin.Show();
            }
            else
            {
                HomePageRegular homePageRegular = new HomePageRegular();
                homePageRegular.Show();
            }
            this.Close();
        }
        private void ClearForm()
        {
            applicationnotxtBox.Clear();
            projectnametxtBox.Clear();
            locationprojecttxtBox.Clear();
            brieftxtBox.Clear();
            proponentnametxtBox.Clear();
            evaluationtxtBox.Clear();
            otherstxtBox.Clear();

            ClearSelectedItems(recommendationchkListBox);

            brgycmbBox.SelectedIndex = -1;

            completedocsradioBtn.Checked = false;
            incompletedocsradioBtn.Checked = false;

            doadate = null;
            datecompleted = null;

            doadateTimePicker.Format = DateTimePickerFormat.Custom;
            doadateTimePicker.CustomFormat = "dd/MM/yyyy";

            datecompletedateTimePicker.Format = DateTimePickerFormat.Custom;
            datecompletedateTimePicker.CustomFormat = "dd/MM/yyyy";

        }
        private void ClearSelectedItems(CheckedListBox listBox)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                listBox.SetItemChecked(i, false);
            }
        }
        private string GetSelectedRadioButtonText(params RadioButton[] radioButtons)
        {
            foreach (var radioButton in radioButtons)
            {
                if (radioButton.Checked)
                {
                    return radioButton.Text;
                }
            }
            return string.Empty;
        }
        private bool CheckDataExists(string applicationno)
        {
            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=Construction;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM ConstructionApplications WHERE ApplicationNo = @ApplicationNo";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ApplicationNo", applicationno);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void submitBtn_Click(object sender, EventArgs e)
        {
            string applicationno = applicationnotxtBox.Text;
            string projectname = projectnametxtBox.Text;
            string location = locationprojecttxtBox.Text;
            string brgy = brgycmbBox.Text;

            if (string.IsNullOrEmpty(applicationno) || string.IsNullOrEmpty(projectname) || string.IsNullOrEmpty(location) || string.IsNullOrEmpty(brgy))
            {
                MessageBox.Show("Please fill the required fields (Application No, Project Name, Location of the Project, Barangay","Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool dataexists = CheckDataExists(applicationno);

            string connectionString = "Data Source=DESKTOP-HTKIB76\\SQLEXPRESS01;Initial Catalog=Construction;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string insertQuery = "INSERT INTO ConstructionApplications (ApplicationNo, DateofApplication, NameofProject, Barangay, LocationofProject, BriefofProject, " +
                                     "ProponentName, Documents, DocsDateCompleted, Evaluation, Recommendations, Others) " +
                                     "VALUES (@ApplicationNo, @DateofApplication, @NameofProject, @Barangay, @LocationofProject, @BriefofProject, " +
                                     "@ProponentName, @Documents, @DocsDateCompleted, @Evaluation, @Recommendations, @Others)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@ApplicationNo", applicationnotxtBox.Text);
                    if (doadate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@DateofApplication", doadateTimePicker.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DateofApplication", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@NameofProject", projectnametxtBox.Text);
                    cmd.Parameters.AddWithValue("@Barangay", brgycmbBox.Text);
                    cmd.Parameters.AddWithValue("@LocationofProject", locationprojecttxtBox.Text);
                    cmd.Parameters.AddWithValue("@BriefofProject", brieftxtBox.Text);
                    cmd.Parameters.AddWithValue("@Evaluation", evaluationtxtBox.Text);
                    cmd.Parameters.AddWithValue("@ProponentName", proponentnametxtBox.Text);
                    cmd.Parameters.AddWithValue("@Documents", GetSelectedRadioButtonText(completedocsradioBtn, incompletedocsradioBtn));
                    if (datecompleted.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@DocsDateCompleted", datecompletedateTimePicker.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DocsDateCompleted", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@Recommendations", string.Join(", ", recommendationchkListBox.CheckedItems.Cast<string>()));
                    cmd.Parameters.AddWithValue("@Others", otherstxtBox.Text);


                    if (dataexists)
                    {
                        DialogResult result = MessageBox.Show("Data with the same Application No.: " + applicationnotxtBox.Text + " already exists!", "Data already existed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ClearForm();
                    }
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully Saved!");
                        ClearForm();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Sql Error: " + ex.Message);
                    }
                }
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void doadateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            doadateTimePicker.CustomFormat = "dd/MM/yyyy";
            doadate = doadateTimePicker.Value;
        }

        private void datecompletedateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            datecompletedateTimePicker.CustomFormat = "dd/MM/yyyy";
            datecompleted = datecompletedateTimePicker.Value;
        }
    }
}
