using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }

        [Required]
        public int? RegisterID { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Mode Of Payment")]
        public string ModeOfPayment { get; set; }

#nullable enable
        [Display(Name = "Transaction ID")]
        public string? TransactionID { get; set; }
#nullable disable

        [Required(ErrorMessage = "Required")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Required")]
        public int GST { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Total Amount")]
        public int TotalAmount { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Discount Allowed")]
        public int DiscountAllowed { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Net Amount")]
        public int NetAmount { get; set; }

        [NotMapped]
        public string PatientName { get; set; }
        [NotMapped]
        public string TestName { get; set; }
        [NotMapped]
        public string PackageName { get; set; }

    }
}
