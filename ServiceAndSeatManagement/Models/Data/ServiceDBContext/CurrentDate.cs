using System;
using System.Collections.Generic;

namespace ServiceAndSeatManagement.Models.Data.ServiceDBContext
{
    public partial class CurrentDate
    {
        public CurrentDate()
        {
            DailyReport = new HashSet<DailyReport>();
            Members = new HashSet<Members>();
        }

        public int CurrentDateId { get; set; }
        public DateTime DateName { get; set; }

        public virtual ICollection<DailyReport> DailyReport { get; set; }
        public virtual ICollection<Members> Members { get; set; }
    }
}
