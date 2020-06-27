﻿using System;
using System.Collections.Generic;

namespace ServiceAndSeatManagement.Models.Data.ServiceDBContext
{
    public partial class ServiceCategory
    {
        public ServiceCategory()
        {
            Members = new HashSet<Members>();
        }

        public int ServiceCategoryId { get; set; }
        public string ServiceCategoryName { get; set; }
        public decimal? MemberCounts { get; set; }

        public virtual ICollection<Members> Members { get; set; }
    }
}
