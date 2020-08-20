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
        [Required(ErrorMessage = "Please temperature record")]
        public decimal TempuratureNumber { get; set; }
        [DisplayName("Verify status")]
        [Required(ErrorMessage = "Please select verify")]
        public int VerifyId { get; set; }
        [NotMapped]
        public SelectList VerifyList { get; set; }
        [NotMapped]
        public string VerifyName { get; set; }

        [DisplayName("Member ID")]
        public int MemberId { get; set; }
        [NotMapped]
        public SelectList MemberList { get; set; }
        [NotMapped]
        public string MemberName { get; set; }

        [DisplayName("Date Checked")]
        public DateTime CurrentDate { get; set; }

    }
}
