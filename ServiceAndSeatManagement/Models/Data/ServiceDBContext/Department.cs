using System;
using System.Collections.Generic;

namespace ServiceAndSeatManagement.Models.Data.ServiceDBContext
{
    public partial class Department
    {
        public Department()
        {
            Members = new HashSet<Members>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Members> Members { get; set; }
    }
}
