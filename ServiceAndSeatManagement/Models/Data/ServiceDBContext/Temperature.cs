using System;
using System.Collections.Generic;

namespace ServiceAndSeatManagement.Models.Data.ServiceDBContext
{
    public partial class Temperature
    {
        public int TemperatureId { get; set; }
        public int MemberId { get; set; }
        public decimal TempuratureNumber { get; set; }
        public DateTime CurrentDate { get; set; }
        public int VerifyId { get; set; }

        public virtual Members Member { get; set; }
        public virtual VerifyMember Verify { get; set; }
    }
}
