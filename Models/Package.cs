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

        [Required]
        public string PackageName { get; set; }

        [Required]
        public string PackageDescription { get; set; }

        [Required]
        public int PackagrPrice { get; set; }
    }
}
