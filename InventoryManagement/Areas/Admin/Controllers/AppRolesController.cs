using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace InventoryManagement.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AppRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AppRolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = _userManager.Users;
            return View("~/Areas/Admin/Views/AppRoles/ListUsers.cshtml", users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View("~/Areas/Admin/Views/AppRoles/EditUser.cshtml", user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(IdentityUser user)
        {
            var userToUpdate = await _userManager.FindByIdAsync(user.Id);
            if (userToUpdate == null)
            {
                return NotFound();
            }

            userToUpdate.Email = user.Email;
            userToUpdate.UserName = user.UserName;
            userToUpdate.Id = user.Id;

            var result = await _userManager.UpdateAsync(userToUpdate);
            if (result.Succeeded)
            {
                return RedirectToAction("ListUsers");
            }

            return View("~/Areas/Admin/Views/AppRoles/EditUser.cshtml", user);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                ViewBag.Message = "User has been deleted successfully.";
                return RedirectToAction(nameof(ListUsers));
            }

            return BadRequest();
        }

        //List all the roles
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View("~/Areas/Admin/Views/AppRoles/Index.cshtml", roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            //avoid duplicate role
            if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
            }

            return View("~/Areas/Admin/Views/AppRoles/Create.cshtml", model);
        }
    }
}
