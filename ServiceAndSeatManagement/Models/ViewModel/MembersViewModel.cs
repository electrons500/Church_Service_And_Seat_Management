using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.ViewModel
{
    public class MembersViewModel
    {
        public int MemberId { get; set; }
        public string Surname { get; set; }
        public string Othernames { get; set; }
        public string FullName { get; set; }
        public string Age { get; set; }
        public int GenderId { get; set; }
        public string DigitalAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public int ServiceCategoryId { get; set; }
        public string SeatNumber { get; set; }
        public int CurrentDateId { get; set; }

    }
}
