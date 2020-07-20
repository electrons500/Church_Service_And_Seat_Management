using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.ViewModel
{
    public class DepartmentViewModel
    {   
        [Key]
        [DisplayName("S/No")]
        public int DepartmentId { get; set; }
        [DisplayName("Department")]
        public string DepartmentName { get; set; }
    }
}
