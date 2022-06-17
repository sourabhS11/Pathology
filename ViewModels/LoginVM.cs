using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string pwd { get; set; }
    }
}
