using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "only Alphabets allowed")]
        public string fName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "only Alphabets allowed")]
        public string lName { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string addrs { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "only Alphabets allowed")]
        public string qualification { get; set; }

        [Required]
        public string role { get; set; }

        [Required]
        public string pwd { get; set; }
        [Required]
        [Compare("pwd", ErrorMessage = "Passwords dont match")]
        public string Cpwd { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "12 digits only")]
        public string adharId { get; set; }

        [Required]
        [Display(Name = "Date of joining")]
        [DataType(DataType.Date)]
        public DateTime joinDate { get; set; }
    }
}
