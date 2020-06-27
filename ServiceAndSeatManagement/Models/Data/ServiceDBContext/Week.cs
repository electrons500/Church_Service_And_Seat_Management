using System;
using System.Collections.Generic;

namespace ServiceAndSeatManagement.Models.Data.ServiceDBContext
{
    public partial class Week
    {
        public Week()
        {
            DailyReport = new HashSet<DailyReport>();
            Temperature = new HashSet<Temperature>();
        }

        public int WeekId { get; set; }
        public string WeekName { get; set; }

        public virtual ICollection<DailyReport> DailyReport { get; set; }
        public virtual ICollection<Temperature> Temperature { get; set; }
    }
}
