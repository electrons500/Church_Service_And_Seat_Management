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
        [Required(ErrorMessage ="Please your surname")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter your othernames")]
        public string Othernames { get; set; }
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter your age")]
        public string Age { get; set; }
        [DisplayName("Gender")]
        [Required(ErrorMessage = "Please select gender")]
        public int GenderId { get; set; }
        public SelectList GenderList { get; set; }
        [NotMapped]
        public string GenderName { get; set; }
        [DisplayName("Digital Address")]
        public string DigitalAddress { get; set; }
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }
        [DisplayName("Department")]
        [Required(ErrorMessage = "Please your department")]
        public int DepartmentId { get; set; }
        public SelectList DepartmentList { get; set; }
        [NotMapped]
        public string DepartmentName { get; set; }

        [DisplayName("Service category")]
        [Required(ErrorMessage = "Please your service category")]
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
