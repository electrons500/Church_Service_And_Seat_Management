using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.ViewModel
{
    public class ServiceCategoryViewModel
    {
        [Key]
        [DisplayName("S/No")]
        public int ServiceCategoryId { get; set; }
        [DisplayName("Service name")]
        public string ServiceCategoryName { get; set; }
        [DisplayName("Number of members")]
        public decimal? MemberCounts { get; set; }
    }
}
