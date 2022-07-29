using Pathology.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.ViewModels
{
    public class StatisticsVM
    {
        public IEnumerable<RegisterPatient> RegisterPatients { get; set; }

        public IEnumerable<Payment> Payments { get; set; }
        
        public IEnumerable<Patient> Patients { get; set; }

        public IEnumerable<TestMgmt> TestMgmts { get; set; }

        public IEnumerable<TestCategory> TestCategories { get; set; }

        public IEnumerable<Package> Packages { get; set; }

        public IEnumerable<Other> Others { get; set; }

    }
}
