﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentCourseManagement.Entity.Models.ViewModels;

namespace StudentCourseManagementSystem.Controllers
{
    [Authorize]
    public class AdministrativeController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrativeController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)

        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new()
                {
                    Name = model.Name,
                };

                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(ListRoles));
                }
            }
            return View();
        }
    }
}
