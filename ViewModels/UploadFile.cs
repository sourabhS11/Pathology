using Microsoft.AspNetCore.Http;
using Pathology.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.ViewModels
{
    public class UploadFile
    {
        public int Id { get; set; }

        public IFormFile File { get; set; }
    }
}
