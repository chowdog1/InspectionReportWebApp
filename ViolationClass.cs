using System;

namespace InspectionReportWebApp
{
    public class ViolationClass
    {
        public string AccountNo { get; set; }
        public string BusinessName { get; set; }
        public DateTime? ApprehensionDate { get; set; }
        public string Inspector { get; set; }
        public string ViolationCommitted { get; set; }
        public string OVR { get; set; }
    }
}
