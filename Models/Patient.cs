using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        public string PatientName { get; set; }

        public string PatientEmail { get; set; }

        public string PatientAadharID { get; set; }

        public string PatientHealthIssues { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}
