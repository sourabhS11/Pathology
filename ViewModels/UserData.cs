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

        public UserData(Guid Id, string fName, string lName, string Email, DateTime joinDate, IList<string> Roles)
        {
            this.Id = Id;
            this.fName = fName;
            this.lName = lName;
            this.Email = Email;
            this.joinDate = joinDate;
            this.Roles = Roles;

        }
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "only Alphabets allowed")]
        public string fName { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "only Alphabets allowed")]
        public string lName { get; set; }

        public string addrs { get; set; }

        public string qualification { get; set; }

        public string adharId { get; set; }

        [DataType(DataType.Date)]
        public DateTime joinDate { get; set; }

        [Required(ErrorMessage = "Required")]
        public IList<string> Roles { get; set; }
    }
}
