using System;
using System.Collections.Generic;

namespace ServiceAndSeatManagement.Models.Data.ServiceDBContext
{
    public partial class Members
    {
        public Members()
        {
            Temperature = new HashSet<Temperature>();
        }

        public int MemberId { get; set; }
        public string FullName { get; set; }
        public string Age { get; set; }
        public int GenderId { get; set; }
        public string Residence { get; set; }
        public string DigitalAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public string SeatNumber { get; set; }
        public DateTime CurrentDate { get; set; }

        public virtual Department Department { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<Temperature> Temperature { get; set; }
    }
}
