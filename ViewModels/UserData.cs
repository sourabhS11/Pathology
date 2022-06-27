using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.ViewModels
{
    public class UserData : IdentityUser<Guid>
    {
        public UserData()
        {
            Roles = new List<string>();
        }
        [Required]
        public string fName { get; set; }

        [Required]
        public string lName { get; set; }

        public string addrs { get; set; }

        public string qualification { get; set; }

        public string adharId { get; set; }

        public DateTime joinDate { get; set; }

        public IList<string> Roles { get; set; }
    }
}
