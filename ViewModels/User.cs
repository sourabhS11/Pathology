using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Pathology.ViewModels
{
    public class User:IdentityUser<Guid>
    {
        public string fName { get; set; }

        public string lName { get; set; }

        public string addrs { get; set; }

        public string qualification { get; set; }

        public string adharId { get; set; }

        [DataType(DataType.Date)]
        public DateTime joinDate { get; set; }
    }
}
