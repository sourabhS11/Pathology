using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.ViewModels
{
    public class RegisterVM
    {
        public int ID { get; set; }

        [Required]
        public string fName { get; set; }

        [Required]
        public string lName { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string addrs { get; set; }

        [Required]
        public string qualification { get; set; }

        [Required]
        public string role { get; set; }

        [Required]
        [Compare("Cpwd", ErrorMessage = "Passwords dont match")]
        public string pwd { get; set; }
        [Required]
        public string Cpwd { get; set; }

        [Required]
        [MaxLength(12, ErrorMessage = "12 digits only")]
        [MinLength(12, ErrorMessage = "12 digits only")]
        public int adharId { get; set; }

        [Required]
        [Display(Name = "Date of joining")]
        [DataType(DataType.Date)]
        public DateTime joinDate { get; set; }

    }


}
