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

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "only Alphabets allowed")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        public string PatientEmail { get; set; }

        [Required(ErrorMessage = "Required")]
        [StringLength(12, ErrorMessage = "12 digits only")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "only Numbers allowed")]
        public string PatientAadharID { get; set; }

        [Required(ErrorMessage = "Required")]
        public string PatientHealthIssues { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

    }
}
