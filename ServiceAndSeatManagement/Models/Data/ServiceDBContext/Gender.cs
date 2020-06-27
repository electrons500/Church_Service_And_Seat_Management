using System;
using System.Collections.Generic;

namespace ServiceAndSeatManagement.Models.Data.ServiceDBContext
{
    public partial class Gender
    {
        public Gender()
        {
            Members = new HashSet<Members>();
        }

        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public virtual ICollection<Members> Members { get; set; }
    }
}
