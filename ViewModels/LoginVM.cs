using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "Required")]
        public string pwd { get; set; }

        [Display(Name = "Remember Me")]
        public bool rememberMe { get; set; }
    }
}
