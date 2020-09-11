using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.ViewModel
{
    public class DailyTemperatureRecordsViewModel
    {
        [Key]
        public int DailytemperatureRecordsId { get; set; }
        public int MemberId { get; set; }
        [NotMapped]
        public string MemberName { get; set; }
        public int GenderId { get; set; }
        [NotMapped]
        public string GenderName { get; set; }
        public decimal Temperature { get; set; }
    }
}
