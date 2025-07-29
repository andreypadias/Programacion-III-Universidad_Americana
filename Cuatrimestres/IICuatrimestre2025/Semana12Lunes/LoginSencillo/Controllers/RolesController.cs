using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginSencillo.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        // Listar roles
        public async Task<IActionResult> Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        // Crear un nuevo rol
        [HttpGet]
        public IActionResult Create()
        {
            var roles = _roleManager.Roles.ToList(); // Ensure _roleManager is properly configured
            return View(roles);
        }


        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                ModelState.AddModelError(string.Empty, "El nombre del rol no puede estar vacío.");
                return View();
            }

            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (roleExists)
            {
                ModelState.AddModelError(string.Empty, "El rol ya existe.");
                return View();
            }

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (result.Succeeded)
            {
                return RedirectToAction("Index"); // Redirige a la lista de roles
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View();
        }

        // Eliminar un rol
        [HttpPost]
        public async Task<IActionResult> Delete(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
