using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.ViewModel
{
    public class TemperatureViewModel
    {
        [Key]
        public int TemperatureId { get; set; }
        [DisplayName("Temperature")]
        public decimal TempuratureNumber { get; set; }
        [DisplayName("Verify status")]
        public int VerifyId { get; set; }
        [NotMapped]
        public SelectList VerifyList { get; set; }
        [NotMapped]
        public string VerifyName { get; set; }

        [DisplayName("Members")]
        public int MemberId { get; set; }
        [NotMapped]
        public SelectList MemberList { get; set; }
        [NotMapped]
        public string MemberName { get; set; }

        [DisplayName("Week")]
        public int WeekId { get; set; }
        [NotMapped]
        public SelectList WeekList { get; set; }
        [NotMapped]
        public string WeekName { get; set; }

        [DisplayName("Service category")]
        public int ServiceCategoryId { get; set; }
        public SelectList ServiceCategoryList { get; set; }
        [NotMapped]
        public string ServiceCategoryName { get; set; }

        [DisplayName("Date Checked")]
        public DateTime CurrentDate { get; set; }



    }
}
