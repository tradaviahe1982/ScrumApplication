using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScrumApplicationData.Models;
using ScrumApplication.Models.ManageViewModels;
using ScrumApplication.Models.RoleViewModels;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;
namespace ScrumApplication.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [HttpGet]
        public IActionResult Index(string filter, int page = 1,
                                               string sortExpression = "RoleName")
        {
            var roles = _roleManager.Roles
                .OrderBy(x => x.Name)
                .Select(r => new ApplicationRoleDetailViewModel
                {
                    Id = r.Id,
                    RoleName = r.Name,
                    Description = r.Description
                });

            //var model = new ApplicationRoleIndexViewModel
            //{
            //    Roles = roles
            //};

            //return View(model);
            if (!string.IsNullOrWhiteSpace(filter))
            {
                roles = roles.Where(p => p.RoleName.Contains(filter));
            }
            var model = PagingList.Create(roles, 5, page, sortExpression, "RoleName");
            model.RouteValue = new RouteValueDictionary {
                { "filter", filter}
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationRoleDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var createResult = await _roleManager.CreateAsync(new ApplicationRole
            {
                Name = model.RoleName,
                Description = model.Description,
                Status = true
            });

            if (!createResult.Succeeded)
            {
                throw new ApplicationException($"Unexpected error occurred during creating the role .");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                StatusMessage = "Role not found";
                return View();
            }

            var model = new ApplicationRoleDetailViewModel
            {
                Id = id,
                RoleName = role.Name,
                Description = role.Description
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationRoleDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var roleId = model.Id;

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                StatusMessage = "Role not found";
                return View();
            }

            role.Name = model.RoleName;
            role.Description = model.Description;

            var updateResult = await _roleManager.UpdateAsync(role);

            if (!updateResult.Succeeded)
            {
                throw new ApplicationException($"Unexpected error occurred during updating the role .");
            }

            model.StatusMessage = $"{role.Name} role has been updated";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                StatusMessage = "Role not found";
                return View();
            }

            var model = new ApplicationRoleDetailViewModel
            {
                Id = id,
                RoleName = role.Name,
                Description = role.Description
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ApplicationRoleDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var roleId = model.Id;

            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                StatusMessage = "Role not found";
                return View();
            }

            var updateResult = await _roleManager.DeleteAsync(role);

            if (!updateResult.Succeeded)
            {
                throw new ApplicationException($"Unexpected error occurred during deleting the role .");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}