using System;
using System.Collections.Generic;

namespace ServiceAndSeatManagement.Models.Data.ServiceDBContext
{
    public partial class VerifyMember
    {
        public VerifyMember()
        {
            Temperature = new HashSet<Temperature>();
        }

        public int VerifyId { get; set; }
        public string VerifyName { get; set; }

        public virtual ICollection<Temperature> Temperature { get; set; }
    }
}
