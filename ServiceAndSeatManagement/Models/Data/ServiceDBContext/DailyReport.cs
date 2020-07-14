using System;
using System.Collections.Generic;

namespace ServiceAndSeatManagement.Models.Data.ServiceDBContext
{
    public partial class DailyReport
    {
        public int ReportId { get; set; }
        public string Service1 { get; set; }
        public string Service2 { get; set; }
        public string Service3 { get; set; }
        public string Service4 { get; set; }
        public int  WeekId { get; set; }
        public DateTime CurrentDate { get; set; }

        public virtual Week Week { get; set; }
    }
}
