﻿using System;
using Wisej.Web;


namespace InspectionReportWebApp
{
    public partial class Request : Form
    {
        public Request()
        {
            InitializeComponent();
        }

        private async void sendBtn_Click(object sender, EventArgs e)
        {
            string name = nametextBox.Text;
            string dept = depttextBox.Text;
            string email = emailtextBox.Text;
            string reason = reasontextBox.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(dept) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(reason))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            await EmailHelper.SendRequestEmail(name, dept, email, reason);

            MessageBox.Show("Request successfully sent.");
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            new Loginpage().Show();
        }
    }
}
