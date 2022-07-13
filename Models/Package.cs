using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.Models
{
    public class Package
    {
        [Key]
        public int PackageID { get; set; }

        [Required(ErrorMessage = "Required")]
        public string PackageName { get; set; }

        [Required(ErrorMessage = "Required")]
        public string PackageDescription { get; set; }

        [Required(ErrorMessage = "Required")]
        public int PackagrPrice { get; set; }
    }
}
