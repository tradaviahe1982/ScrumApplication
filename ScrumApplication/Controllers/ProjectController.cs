using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScrumApplicationData.Models;
using ScrumApplicationServices;
using ScrumApplication.Models.ProjectViewModels;
using ScrumApplication.Models.RoleViewModels;
using ScrumApplication.Models.UserViewModels;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;
namespace ScrumApplication.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;


        public ProjectController(IProjectService projectService, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _projectService = projectService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
       
        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult Index(string filter, int page = 1,
                                               string sortExpression = "Name")
        {
            var projects = _projectService.GetAll().Select(x => new ProjectDetailViewModel
            {
                Id = x.Id.ToString(),
                Name = x.Name,
                Description = x.Description,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                ProjectStatusID = x.ProjectStatusID
            });

            //var model = new ProjectIndexViewModel
            //{
            //    Projects = projects
            //};
            //var projectIndexVM = new ProjectIndexViewModel
            //{
            //    Projects = projects
            //};
            if (!string.IsNullOrWhiteSpace(filter))
            {
                projects = projects.Where(p => p.Name.Contains(filter));
            }
            var model = PagingList.Create(projects, 5, page, sortExpression, "Name");
            model.RouteValue = new RouteValueDictionary {
                { "filter", filter}
            };
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ProjectStatuses"] = _projectService.GetAllProjectStatus();
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _projectService.Add(new Project
            {
                Name = model.Name,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                ProjectStatusID = model.ProjectStatusID
            });

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ViewData["ProjectStatuses"] = _projectService.GetAllProjectStatus();
            var project = await _projectService.GetByIdAsync(int.Parse(id));
            if (project == null)
            {
                throw new ApplicationException($"Unable to load project with ID '{id}'.");
            }

            var users = _userManager.Users.Select(user => new UserDetailViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                ImageUrl = user.ImageUrl
            });

            var roles = _roleManager.Roles
                .Where(x => x.Name != "Admin")
                .OrderBy(x => x.Name)
                .Select(r => new ApplicationRoleDetailViewModel
                {
                    Id = r.Id,
                    RoleName = r.Name,
                    Description = r.Description
                });

            var model = new ProjectDetailViewModel
            {
                Id = id,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                ProjectStatusID = project.ProjectStatusID,
                ProjectUsers = new List<ProjectUserDetailViewModel>(),
                Users = users,
                Roles = roles
            };

            var userRoles = _projectService.GetProjectUserRoles(id);
            foreach (var userRole in userRoles)
            {
                var user = await users.FirstOrDefaultAsync(x => x.Id == userRole.UserId);
                var role = await roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
                var projectUser = new ProjectUserDetailViewModel
                {
                    ProjectId = id,
                    UserId = userRole.UserId,
                    RoleId = userRole.RoleId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ImageUrl = user.ImageUrl,
                    UserRoleName = role.RoleName
                };
                model.ProjectUsers.Add(projectUser);
            }

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var projectId = model.Id;
            var project = await _projectService.GetByIdAsync(int.Parse(projectId));
            if (project == null)
            {
                ModelState.AddModelError("Error", "Unable to load the project");
                return View(model);
            }

            project.Name = model.Name;
            project.Description = model.Description;
            project.StartDate = model.StartDate;
            project.EndDate = model.EndDate;
            project.ProjectStatusID = model.ProjectStatusID;
            await _projectService.Update(project);

            model.StatusMessage = $"{project.Name} project has been updated";

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(ProjectUserDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error");
                return RedirectToAction(nameof(Edit), new { model.ProjectId });
            }

            var userRole = new ApplicationUserRole
            {
                ProjectId = model.ProjectId,
                UserId = model.UserId,
                RoleId = model.RoleId
            };

            await _projectService.AddUser(userRole);

            return RedirectToAction(nameof(Edit), new { id = model.ProjectId });
        }
        [Authorize(Roles = "Admin")]
        //DeleteProjectUsers
        public async Task<IActionResult> DeleteProjectUsers(string ProjectId, string UserId, string RoleId)
        {
            var userRole = new ApplicationUserRole
            {
                ProjectId = ProjectId,
                UserId = UserId,
                RoleId = RoleId
            };
            await _projectService.DeleteUser(userRole);
            return RedirectToAction(nameof(Edit), new { id = ProjectId });
        }
    }
}