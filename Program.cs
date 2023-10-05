using System;
using Wisej.Web;

namespace InspectionReportWebApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Application.Desktop = new MyDesktop();

            inspectionReport window = new inspectionReport();
            window.Show();
        }

        //
        // You can use the entry method below
        // to receive the parameters from the URL in the args collection.
        //
        //static void Main(NameValueCollection args)
        //{
        //}
    }
}