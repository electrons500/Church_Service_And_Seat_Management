using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.ViewModel
{
    public class WeekViewModel
    {
        [Key]
        public int WeekId { get; set; }
        public string WeekName { get; set; }

    }
}
