using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.Models
{
    public class TestCategory
    {
        [Key]
        public int TestCategoryID { get; set; }

        public string TestCategoryName { get; set; }

        public string TestCategoryDescription { get; set; }

    }
}
