using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pathology.Models;
using Pathology.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public UserManager<User> UserManager { get; }
        public SignInManager<User> SignInManager { get; }
        public RoleManager<Role> RoleManager { get; }

        public HomeController(ILogger<HomeController> logger,
                              UserManager<User>userManager,
                              SignInManager<User>signInManager,
                              RoleManager<Role>roleManager)
        {
            _logger = logger;
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Aboutus()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(model.email, model.pwd, model.rememberMe, false);
                
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                    
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");               
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var Newuser = new User { fName = model.fName, lName =model.lName, addrs=model.addrs,
                                   qualification=model.qualification, adharId=model.adharId, joinDate=model.joinDate,
                                    Email=model.email, UserName=model.email};
                var result = await UserManager.CreateAsync(Newuser, model.pwd);

                if (result.Succeeded)
                {
                    string roleName = model.role;
                    IdentityResult resultRole = null;
                    resultRole = await UserManager.AddToRoleAsync(Newuser, roleName);

                    if (!resultRole.Succeeded)
                    {
                        foreach (var error in resultRole.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }

                    await SignInManager.SignInAsync(Newuser, isPersistent:false );
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        //post gives 405 error
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
