using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.Models
{
    public class Employee
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public string email { get; set; }
        public string addrs { get; set; }
        public string qualification { get; set; }
        public string role { get; set; }
        public int pwd { get; set; }
        public int adharId { get; set; }

        [Display(Name = "Date of joining")]
        [DataType(DataType.Date)]
        public DateTime joinDate { get; set; }

    }
}
