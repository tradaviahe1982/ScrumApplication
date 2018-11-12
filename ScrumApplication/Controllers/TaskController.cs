using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScrumApplicationData.Models;
using ScrumApplicationServices;
using ScrumApplication.Models.StoryViewModels;
using ScrumApplication.Models.SprintViewModels;
using ScrumApplication.Models.ProjectViewModels;
using ScrumApplication.Models.RoleViewModels;
using ScrumApplication.Models.UserViewModels;
using ScrumApplication.Models.ScrumViewModels;
namespace ScrumApplication.Controllers
{
    public class TaskController : Controller
    {
        private readonly IStoryService _storyService;
        private readonly ISprintService _sprintService;
        private readonly IProjectService _projectService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public TaskController(IProjectService projectService, IStoryService storyService, ISprintService sprintService, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _sprintService = sprintService;
            _projectService = projectService;
            _storyService = storyService;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(string id)
        {
            var story = await _storyService.GetByIdAsync(int.Parse(id));
            if (story == null)
            {
                return NotFound();
            }

            var model = new BoardViewModel
            {
                StoryId = id,
                StorytName = story.Name,
                BacklogTasks = _storyService.GetTasks(int.Parse(id), 1),
                InProgressTasks = _storyService.GetTasks(int.Parse(id), 2),
                TestTasks = _storyService.GetTasks(int.Parse(id), 3),
                CompletedTasks = _storyService.GetTasks(int.Parse(id), 4)
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddTask(string id)
        {
            ViewData["TaskStatuses"] = _storyService.GetAllTaskStatus();
            var model = new BoardAddTaskViewModel
            {
                StoryId = id,
                Users = new List<ProjectUserDetailViewModel>()
            };


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

            var story = await _storyService.GetByIdAsync(int.Parse(id));
            var sprint = await _sprintService.GetByIdAsync(story.SprintId);
            //
            var userRoles = _projectService.GetProjectUserRoles(sprint.ProjectId.ToString());
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
                model.Users.Add(projectUser);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTask(BoardAddTaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var story = await _storyService.GetByIdAsync(int.Parse(model.StoryId));

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == model.UserId);

            var Task = new ScrumApplicationData.Models.Tasks
            {
                Story = story,
                ApplicationUser = user,
                Name = model.Name,
                Description = model.Description,
                Day = model.Day,
                TaskStatusId = model.TaskStatusId,
                UserId = model.UserId
            };

            await _storyService.AddTask(Task);

            return RedirectToAction(nameof(Index), new { story.Id });
        }

        public async Task<IActionResult> StartTask(string id)
        {
            var task = await _storyService.GetTaskById(int.Parse(id));

            await _storyService.StartTask(task);

            return RedirectToAction(nameof(Index), new { task.Story.Id });
        }

        public async Task<IActionResult> GetTask(string id)
        {
            string userId = _userManager.GetUserAsync(User).Result.Id;
            var task = await _storyService.GetTaskById(int.Parse(id));
            await _storyService.GetTask(task, userId);
            return RedirectToAction(nameof(Index), new { task.Story.Id });
        }

        public async Task<IActionResult> RemoveTask(string id)
        {
            var task = await _storyService.GetTaskById(int.Parse(id));

            await _storyService.RemoveTask(task);

            return RedirectToAction(nameof(Index), new { task.Story.Id });
        }

        public async Task<IActionResult> VerifyTask(string id)
        {
            var task = await _storyService.GetTaskById(int.Parse(id));

            await _storyService.VerifyTask(task);

            return RedirectToAction(nameof(Index), new { task.Story.Id });
        }

        public async Task<IActionResult> CompleteTask(string id)
        {
            var task = await _storyService.GetTaskById(int.Parse(id));

            await _storyService.CompleteTask(task);

            return RedirectToAction(nameof(Index), new { task.Story.Id });
        }
    }
}