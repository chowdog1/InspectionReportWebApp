using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Wisej.Web;


namespace InspectionReportWebApp
{
    public partial class LogForm : Form
    {
        private TextBox textBoxLog;
        public LogForm(List<string> logEntries, string logFilePath)
        {
            InitializeComponent();

            textBoxLog = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Font = new Font("Arial", 16),
            };
            Controls.Add(textBoxLog);

            foreach (string entry in logEntries)
            {
                textBoxLog.AppendText(entry + Environment.NewLine);
            }

            if (File.Exists(logFilePath))
            {
                string[] fileLogEntries = File.ReadAllLines(logFilePath);
                textBoxLog.Lines = fileLogEntries;
            }
        }

        public void AppendLog(string logEntry)
        {
            if (!textBoxLog.IsDisposed)
            {
                textBoxLog.AppendText(logEntry + Environment.NewLine);
            }
        }
    }
}
