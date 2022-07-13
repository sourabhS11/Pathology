using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.Models
{
    public class TestMgmt
    {
        [Key]
        public int TestId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string TestName { get; set; }

        [Required(ErrorMessage = "Required")]
        public int TestPrice { get; set; }

        //Foreign key for TestCategory
        public int TestCategoryID { get; set; }
        [ForeignKey("TestCategoryID")]
        public TestCategory TestCategory { get; set; }

        //Foreign key for Package
        public int PackageID { get; set; }
        [ForeignKey("PackageID")]
        public Package Package { get; set; }
    }
}
