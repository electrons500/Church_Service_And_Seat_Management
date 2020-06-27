using System;
using System.Collections.Generic;

namespace ServiceAndSeatManagement.Models.Data.ServiceDBContext
{
    public partial class DailyReport
    {
        public string ReportId { get; set; }
        public string Service1 { get; set; }
        public string Service2 { get; set; }
        public string Service3 { get; set; }
        public string Service4 { get; set; }
        public int? WeekId { get; set; }
        public int? CurrentDateId { get; set; }

        public virtual CurrentDate CurrentDate { get; set; }
        public virtual Week Week { get; set; }
    }
}
