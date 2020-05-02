using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizApplication.Models;
using QuizApplication.WebApp.ViewModels;

namespace QuizApplication.WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        // GET: show all users
        [Authorize(Roles = "Admin")]

        public ActionResult IndexUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }


        // GET: Admin/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Indexroles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRoleToUser(string userId)
        {
            IdentityUser user = new IdentityUser();

            if (!string.IsNullOrEmpty(userId))
            {
                user = await _userManager.FindByIdAsync(userId);
            }
            if (user == null)
                return RedirectToAction("IndexRoles", _roleManager.Roles);


            //reeds toegekende rollen
            var assignRolesToUserVM = new RolesForUser_VM()
            {
                AssignedRoles = await _userManager.GetRolesAsync(user),
                UnAssignedRoles = new List<string>(),
                User = user,
                UserId = userId
            };

            //nog niet toegekende rollen
            foreach (var identityRole in _roleManager.Roles)
            {
                if (!await _userManager.IsInRoleAsync(user, identityRole.Name))
                {
                    assignRolesToUserVM.UnAssignedRoles.Add(identityRole.Name);
                }
            }

            return View(assignRolesToUserVM);

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRoleToUser(RolesForUser_VM rolesForUserVM)
        {
            var user = await _userManager.FindByIdAsync(rolesForUserVM.UserId);
            var role = await _roleManager.FindByNameAsync(rolesForUserVM.RoleId);
            var result = await _userManager.AddToRoleAsync(user, role.Name);
            if (result.Succeeded)
            {
                return RedirectToAction("IndexUsers", _roleManager.Roles);
            }
            else
            {
                Debug.WriteLine(result.Errors);
            }
            return View(rolesForUserVM);
        }
    }
}