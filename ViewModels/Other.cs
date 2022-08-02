using Pathology.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.ViewModels
{
    public class Other
    {
        public string Key { get; set; }

        public int Count { get; set; }

        public List<int> Otherlist { get; set; }
    }
}
