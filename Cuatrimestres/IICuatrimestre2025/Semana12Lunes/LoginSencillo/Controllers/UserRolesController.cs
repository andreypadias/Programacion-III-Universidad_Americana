using LoginSencillo.Areas.Identity.Data;
using LoginSencillo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginSencillo.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Usuario> _userManager;

        public UserRolesController(RoleManager<IdentityRole> roleManager, UserManager<Usuario> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: Listar usuarios y sus roles
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var userRoles = users.Select(user => new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = _userManager.GetRolesAsync(user).Result
            }).ToList();

            return View(userRoles);
        }

        // GET: Asignar un rol a un usuario
        public async Task<IActionResult> AssignRole(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var roles = _roleManager.Roles.Select(r => r.Name).ToList();
            var model = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignRole(UserRolesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);
                if (user == null)
                {
                    return NotFound();
                }

                if (!string.IsNullOrWhiteSpace(model.RoleName))
                {
                    var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // MEJORA: Recargar los roles disponibles si hay error
            var roles = _roleManager.Roles.Select(r => r.Name).ToList();
            model.Roles = roles;
            return View(model);
        }

        // POST: Eliminar un rol de un usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(roleName))
            {
                var result = await _userManager.RemoveFromRoleAsync(user, roleName);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
