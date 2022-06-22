using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult DashAD()
        {
            return View();
        }

        public IActionResult DashLA()
        {
            return View();
        }

        public IActionResult DashDS()
        {
            return View();
        }
    }
}
