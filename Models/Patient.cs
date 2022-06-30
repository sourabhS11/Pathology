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

        [Required]
        public string PatientName { get; set; }

        [Required]
        public string PatientEmail { get; set; }

        [Required]
        public string PatientAadharID { get; set; }

        [Required]
        public string PatientHealthIssues { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

    }
}
