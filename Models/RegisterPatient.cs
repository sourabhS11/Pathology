using Microsoft.AspNetCore.Http;
using Pathology.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.Models
{
    public class RegisterPatient
    {
        [Key]
        public int RegisterID { get; set; }

        public int? PatientID { get; set; }
        [ForeignKey("PatientID")]
        public Patient Patient { get; set; }

        public int? TestId { get; set; }
        [ForeignKey("TestId")]
        public TestMgmt TestMgmt { get; set; }

        public int? PackageID { get; set; }
        [ForeignKey("PackageID")]
        public Package Package { get; set; }

        public DateTime RegDateTime { get; set; }

        public int TotalAmount { get; set; }

        public Guid? Id { get; set; }
        [ForeignKey("Id")]
        public User User { get; set; }

        public bool IsReportGenerated { get; set; }

        public byte[] RoportPDF { get; set; }

    }
}
