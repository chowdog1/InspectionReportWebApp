﻿using System;
using Wisej.Web;


namespace InspectionReportWebApp
{
    public partial class HomePageAdmin : Form
    {
        public HomePageAdmin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new UserManagement().Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new ChangePassword().Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new registerForm().Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Loginpage().Show();
            this.Close();
        }

        private void IRMSBtn_Click(object sender, EventArgs e)
        {
            inspectionReport mainPage = new inspectionReport();
            mainPage.EnableMainMenuItem();
            mainPage.Show();
            this.Close();
        }
    }
}