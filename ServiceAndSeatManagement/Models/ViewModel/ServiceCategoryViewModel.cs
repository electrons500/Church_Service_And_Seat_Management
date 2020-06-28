using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.ViewModel
{
    public class ServiceCategoryViewModel
    {
        public int ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; }
        public decimal? MemberCounts { get; set; }
    }
}
