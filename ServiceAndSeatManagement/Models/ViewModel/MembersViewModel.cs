using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public SelectList GenderList { get; set; }
        [NotMapped]
        public string GenderName { get; set; }

        public string DigitalAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int DepartmentId { get; set; }
        public SelectList DepartmentList { get; set; }
        [NotMapped]
        public string DepartmentName { get; set; }

        public int ServiceCategoryId { get; set; }
        public SelectList ServiceCategoryList { get; set; }
        [NotMapped]
        public string ServiceCategoryName { get; set; }

        public string SeatNumber { get; set; }
        public DateTime CurrentDate { get; set; }

    }
}
