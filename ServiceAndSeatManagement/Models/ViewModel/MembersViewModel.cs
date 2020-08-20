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
        [DataType(DataType.Text)]
        public int MemberId { get; set; }
       
        [Required(ErrorMessage = "Please enter your Full name")]
        
        [DisplayName("Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter your age")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Enter only numbers")]
        [StringLength(4, ErrorMessage = "Age length exceeded")]
        public string Age { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Please select gender")]
        public int GenderId { get; set; }
        [NotMapped]
        public SelectList GenderList { get; set; }
        [NotMapped]
        public string GenderName { get; set; }


        [DisplayName("Digital Address")]
        public string DigitalAddress { get; set; }

        [DisplayName("Contact number")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "Enter only numbers")]
        //[StringLength(15,ErrorMessage ="Phone number cannot exceed 10")]
        public string PhoneNumber { get; set; }


        [DisplayName("Department")]
        [Required(ErrorMessage = "Please your department")]
        public int DepartmentId { get; set; }
        [NotMapped]
        public SelectList DepartmentList { get; set; }
        [NotMapped]
        public string DepartmentName { get; set; }

        [DisplayName("Seat number")]
        [StringLength(6, ErrorMessage = "seat number cannot exceed 5 digits")]
        //[RegularExpression("^[0-9]*$",ErrorMessage ="Enter only numbers")]
        public string SeatNumber { get; set; }
        [DisplayName("Registered Date")]
        [DataType(DataType.Date)]
        public DateTime CurrentDate { get; set; }


    }
}
