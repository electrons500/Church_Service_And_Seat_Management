using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.ViewModel
{
    public class DailyReportViewModel
    {
        public string ReportId { get; set; }
        public string Service1 { get; set; }
        public string Service2 { get; set; }
        public string Service3 { get; set; }
        public string Service4 { get; set; }
        public int? WeekId { get; set; }
        public int? CurrentDateId { get; set; }

    }
}
