using CarMgmtMVCApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarMgmtMVCApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager,
                                 UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return Redirect("/Identity/Account/Login");
        }

        public IActionResult Register()
        {
            return Redirect("/Identity/Account/Register");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Users()
        {
            var users = _userManager.Users.ToList();
            var model = new List<UserRoleViewModel>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                model.Add(new UserRoleViewModel
                {
                    UserId = user.Id,
                    Email = user.Email,
                    Role = roles.FirstOrDefault() ?? "User"
                });
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRole(string userId, string newRole)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRoleAsync(user, newRole);
            }
            return RedirectToAction("Users");
        }
    }
}