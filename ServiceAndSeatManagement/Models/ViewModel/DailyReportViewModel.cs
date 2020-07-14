using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.ViewModel
{
    public class DailyReportViewModel
    {
        [Key]
        [DisplayName("S/No")]
        public int ReportId { get; set; }
        [DisplayName("1st Service")]
        public string Service1 { get; set; }
        [DisplayName("2nd Service")]
        public string Service2 { get; set; }
        [DisplayName("3rd Service")]
        public string Service3 { get; set; }
        [DisplayName("4th Service")]
        public string Service4 { get; set; }
        [DisplayName("Week")]
        public int WeekId { get; set; }
        [NotMapped]
        public SelectList WeekList { get; set; }
        [NotMapped]
        public string WeekName { get; set; }
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime CurrentDate { get; set; }

    }
}
