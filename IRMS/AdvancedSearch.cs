using System;
using System.Collections.Generic;
using Wisej.Web;


namespace InspectionReportWebApp
{
    public partial class AdvancedSearch : Form
    {
        private bool datePickersChanged = false;
        private DateTime? fddate;
        private DateTime? tddate;
        public string SearchQuery { get; private set; }
        public AdvancedSearch()
        {
            InitializeComponent();
            SearchQuery = "";

            fddate = null;
            tddate = null;

            fddateTimePicker.Format = DateTimePickerFormat.Custom;
            fddateTimePicker.CustomFormat = "--/--/----";

            tddateTimePicker.Format = DateTimePickerFormat.Custom;
            tddateTimePicker.CustomFormat = "--/--/----";

        }
        private void advsearchBtn_Click(object sender, EventArgs e)
        {
            string barangay = brgyadvcmbBox.Text;
            string businessstatus = advstatusbusscmbBox.Text;
            string establishmentstatus = establishmenthasadvcmbBox.Text;
            string establishmentis = establishmentisadvcmbBox.Text;
            string violations = advviolatedcmbBox.Text;
            DateTime startdate = fddateTimePicker.Value;
            DateTime enddate = tddateTimePicker.Value;

            List<string> searchCriteria = new List<string>();

            if (!string.IsNullOrEmpty(barangay))
            {
                searchCriteria.Add($"Barangay LIKE '%{barangay}%'");
            }

            if (!string.IsNullOrEmpty(businessstatus))
            {
                searchCriteria.Add($"BusinessStatus LIKE '%{businessstatus}%'");
            }

            if (!string.IsNullOrEmpty(establishmentstatus))
            {
                searchCriteria.Add($"EstablishmentHas LIKE '%{establishmentstatus}%'");
            }

            if (!string.IsNullOrEmpty(establishmentis))
            {
                searchCriteria.Add($"EstablishmentIs = '{establishmentis}'");
            }

            if (!string.IsNullOrEmpty(violations))
            {
                searchCriteria.Add($"Violations LIKE '%{violations}%'");
            }

            if (datePickersChanged)
            {
                searchCriteria.Add($"Date >= '{startdate:yyyy-MM-dd}' AND Date <= '{enddate:yyyy-MM-dd}'");
            }

            SearchQuery = "SELECT * FROM InspectionReport WHERE " + string.Join(" AND ", searchCriteria);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void fddateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            datePickersChanged = true;
            fddateTimePicker.CustomFormat = "dd-MM-yyyy";
            fddate = fddateTimePicker.Value;
        }

        private void tddateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            datePickersChanged = true;
            tddateTimePicker.CustomFormat = "dd-MM-yyyy";
            tddate = tddateTimePicker.Value;
        }

        private void advclearBtn_Click(object sender, EventArgs e)
        {
            brgyadvcmbBox.SelectedIndex = -1;
            advstatusbusscmbBox.SelectedIndex = -1;
            advviolatedcmbBox.SelectedIndex = -1;
            establishmentisadvcmbBox.SelectedIndex = -1;
            establishmenthasadvcmbBox.SelectedIndex = -1;
            fddate = null;
            tddate = null;

            fddateTimePicker.Format = DateTimePickerFormat.Custom;
            fddateTimePicker.CustomFormat = "--/--/----";

            tddateTimePicker.Format = DateTimePickerFormat.Custom;
            tddateTimePicker.CustomFormat = "--/--/----";
        }
    }
}
