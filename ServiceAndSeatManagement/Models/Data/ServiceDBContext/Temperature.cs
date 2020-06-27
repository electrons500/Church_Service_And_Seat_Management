using System;
using System.Collections.Generic;

namespace ServiceAndSeatManagement.Models.Data.ServiceDBContext
{
    public partial class Temperature
    {
        public int TemperatureId { get; set; }
        public decimal TempuratureNumber { get; set; }
        public bool? Verified { get; set; }
        public int MemberId { get; set; }
        public int WeekId { get; set; }

        public virtual Members Member { get; set; }
        public virtual Week Week { get; set; }
    }
}
