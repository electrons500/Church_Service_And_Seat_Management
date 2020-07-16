using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.ViewModel
{
    public class WeekViewModel
    {
        [Key]
        [DisplayName("S/No")]
        public int WeekId { get; set; }
        [DisplayName("Week")]
        [Required(ErrorMessage ="Please enter current week number")]
        public string WeekName { get; set; }

    }
}
