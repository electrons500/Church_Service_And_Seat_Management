using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.ViewModel
{
    public class MembersViewModel
    {
        [Key]
        public int MemberId { get; set; }
        public string Surname { get; set; }
        public string Othernames { get; set; }
        public string FullName { get; set; }
        public string Age { get; set; }
        [DisplayName("Gender")]
        public int GenderId { get; set; }
        public SelectList GenderList { get; set; }
        [NotMapped]
        public string GenderName { get; set; }
        [DisplayName("Digital Address")]
        public string DigitalAddress { get; set; }
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public SelectList DepartmentList { get; set; }
        [NotMapped]
        public string DepartmentName { get; set; }

        [DisplayName("Service category")]
        public int ServiceCategoryId { get; set; }
        public SelectList ServiceCategoryList { get; set; }
        [NotMapped]
        public string ServiceCategoryName { get; set; }

        [DisplayName("Seat number")]
        public string SeatNumber { get; set; }
        [DisplayName("Registered Date")]
        public DateTime CurrentDate { get; set; }

    }
}
