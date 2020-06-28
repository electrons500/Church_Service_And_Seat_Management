using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.ViewModel
{
    public class TemperatureViewModel
    {
        public int TemperatureId { get; set; }
        public decimal TempuratureNumber { get; set; }
        public bool? Verified { get; set; }
        public int MemberId { get; set; }
        public int WeekId { get; set; }
    }
}
