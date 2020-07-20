using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
       [DataType(DataType.Date)]
        public DateTime CurrentDate { get; set; }
        public string Total { get; set; }

        public virtual Week Week { get; set; }
    }
}
