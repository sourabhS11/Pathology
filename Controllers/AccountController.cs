using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pathology.Services;
using Pathology.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pathology.Extensions;

namespace Pathology.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IUserService _userService;

        public AccountController(UserManager<User> userManager,
                                RoleManager<Role> roleManager,
                                IUserService userService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this._userService = userService;
        }

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

        public async Task<IActionResult> UserMgmtAsync()
        {
            var users = userManager.Users;
            var userID = _userService.GetUserID();
            var uID = new Guid(userID);
            List<UserData> UserDataList = new List<UserData>();

            foreach (var u in users)
            {
                var uRole = await userManager.GetRolesAsync(u);
                UserDataList.Add(new UserData(u.Id, u.fName, u.lName, u.Email, Convert.ToDateTime(DateTimeFormat.GetDate(u.joinDate)), uRole));
            }

            var UserList = UserDataList.Where(U => U.Id != uID);

            return View(UserList);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            var userRoles = await userManager.GetRolesAsync(user);

            var model = new UserData
            (
                user.Id,
                user.fName,
                user.lName,
                user.Email,
                user.joinDate,
                userRoles
            );

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserData model)
        {
            string ID = model.Id.ToString();
            var user = await userManager.FindByIdAsync(ID);

            if (user == null)
            {
                ViewBag.ErrorMessage = "User not found";
                return View("NotFound");
            }
            else
            {
                var roles = await userManager.GetRolesAsync(user);
                var result = await userManager.RemoveFromRolesAsync(user, roles);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot remove user existing role");
                    return View(model);
                }

                result = await userManager.AddToRolesAsync(user, model.Roles);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot add selected role to user");
                    return View(model);
                }

                user.fName = model.fName;
                user.lName = model.lName;

                result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("UserMgmt");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = "User not found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("UserMgmt");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("UserMgmt");
            }
        }
    }
}
