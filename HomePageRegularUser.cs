using InspectionReportWebApp.AEC;
using InspectionReportWebApp.ECNC;
using System;
using Wisej.Web;


namespace InspectionReportWebApp
{
    public partial class HomePageRegular : Form
    {
        public HomePageRegular()
        {
            InitializeComponent();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            new ChangePassword().Show();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            new Loginpage().Show();
            this.Close();
        }

        private void IRMSBtn_Click(object sender, EventArgs e)
        {
            inspectionReport mainPage = new inspectionReport();
            mainPage.DisableMainMenuItem();
            mainPage.Show();
            this.Close();
        }

        private void ecncBtn_Click(object sender, EventArgs e)
        {
            ConstructionMain constructionMain = new ConstructionMain();
            constructionMain.Show();
            this.Close();
        }

        private void aecBtn_Click(object sender, EventArgs e)
        {
            HomeAEC homeAEC = new HomeAEC();
            homeAEC.Show();
            this.Close();
        }
    }
}
