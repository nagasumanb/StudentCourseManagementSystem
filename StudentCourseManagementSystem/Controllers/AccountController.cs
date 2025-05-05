using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentCourseManagement.Entity.Models.ViewModels;

namespace StudentCourseManagementSystem.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [Authorize]
        public IActionResult ListUsers()
        {
            var user = _userManager.Users;
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
     
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (result.Succeeded)
                {
                     if (model.UserName == "Mishel@gmail.com" || model.UserName == "BijjuKumar@gmail.com")
                    {
                        return RedirectToAction("Index", "Instructor");
                    }
                    return RedirectToAction("Index", "Student");
                }

                ModelState.AddModelError(string.Empty, "Invalid credentials");
            }
            return View();
        }

        [HttpGet]
        
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new()
                {
                    UserName = model.UserName,
                    Email = model.UserName
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }

            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AccessDenied(string ReturnUrl)
        {
            return View();

        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddRemoveRoles(string id)
        {
            List<UserRoleViewModel> model = new();

            var user = await _userManager.FindByIdAsync(id);

            ViewBag.UserName = user.UserName;
            ViewBag.Id = user.Id;

            foreach (var role in _roleManager.Roles.ToList())
            {
                UserRoleViewModel roleViewModel = new()
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    IsSelected = await _userManager.IsInRoleAsync(user, role.Name),
                };

                model.Add(roleViewModel);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddRemoveRoles(List<UserRoleViewModel> model, string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            ViewBag.UserName = user.UserName;
            ViewBag.Id = user.Id;

            foreach (var role in model)
            {
                if (role.IsSelected && !await _userManager.IsInRoleAsync(user, role.RoleName))
                {
                    var result = await _userManager.AddToRoleAsync(user, role.RoleName);
                }
                else if (!role.IsSelected && await _userManager.IsInRoleAsync(user, role.RoleName))
                {
                    var result = await _userManager.RemoveFromRoleAsync(user, role.RoleName);
                }
            }

            return RedirectToAction(nameof(ListUsers));
        }
    }
}
