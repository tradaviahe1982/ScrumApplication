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
//
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;
namespace ScrumApplication.Controllers
{
    public class StoryController : Controller
    {
        //
        private readonly IStoryService _storyService;
        private readonly ISprintService _sprintService;
        private readonly IProjectService _projectService;

        public StoryController(IStoryService storyService, ISprintService sprintService, IProjectService projectService)
        {
            _storyService = storyService;
            _sprintService = sprintService;
            _projectService = projectService;
        }

        [TempData]
        public string StatusMessage { get; set; }
       
       
        public IActionResult Index(string filter, int page = 1,
                                               string sortExpression = "Name")
        {
            var stories = _storyService.GetAll().Select(x => new StoryDetailViewModel
            {
                Id = x.Id.ToString(),
                Name = x.Name,
                Reporter = x.Reporter,
                Description = x.Description,
                Point = x.Point
            });

            //var model = new StoryIndexViewModel
            //{
            //    Stories = stories
            //};

            //return View(model);
            if (!string.IsNullOrWhiteSpace(filter))
            {
                stories = stories.Where(p => p.Name.Contains(filter));
            }
            var model = PagingList.Create(stories, 5, page, sortExpression, "Name");
            model.RouteValue = new RouteValueDictionary {
                { "filter", filter}
            };
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["StoryStatuses"] = _storyService.GetAllStoryStatus();
            ViewData["StoryType"] = _storyService.GetAllStoryType();
           
            ViewData["Sprints"] = _sprintService.GetAll();
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StoryDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var story = new Story
            {
                Name = model.Name,
                Reporter = model.Reporter,
                Description = model.Description,
                Point = model.Point,
                StoryStatusId = model.StoryStatusId,
                StoryTypeId = model.StoryTypeId,
                SprintId = model.SprintId
            };


            await _storyService.Add(story);


            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ViewData["StoryStatuses"] = _storyService.GetAllStoryStatus();
            ViewData["StoryType"] = _storyService.GetAllStoryType();
           
            ViewData["Sprints"] = _sprintService.GetAll();
            var story = await _storyService.GetByIdAsync(int.Parse(id));
            if (story == null)
            {
                throw new ApplicationException($"Unable to load project with ID '{id}'.");
            }

            var model = new StoryDetailViewModel
            {
                Id = id,
                Name = story.Name,
                Reporter = story.Reporter,
                Description = story.Description,
                Point = story.Point,
                SprintId = story.SprintId,
                StoryTypeId = story.StoryTypeId,
                StoryStatusId = story.StoryStatusId
            };

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StoryDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var storyID = model.Id;
            var story = await _storyService.GetByIdAsync(int.Parse(storyID));
            if (story == null)
            {
                ModelState.AddModelError("Error", "Unable to load the project");
                return View(model);
            }

            story.Name = model.Name;
            story.Reporter = model.Reporter;
            story.Description = model.Description;
            story.Point = model.Point;
            story.StoryStatusId = model.StoryStatusId;
            story.StoryTypeId = model.StoryTypeId;
            story.SprintId = model.SprintId;
            await _storyService.Update(story);

            model.StatusMessage = $"{story.Name} has been updated";

            return View(model);
        }
        //
    }
}