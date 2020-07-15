using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.ViewModel
{
    public class VerifyMemberViewModel
    {
        [Key]
        public int VerifyId { get; set; }
        public string VerifyName { get; set; }
    }
}
