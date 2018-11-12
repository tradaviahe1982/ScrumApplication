using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScrumApplicationData.Models;
using ScrumApplicationServices;
using ScrumApplication.Models.SprintViewModels;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;
using System.ComponentModel.DataAnnotations;
namespace ScrumApplication.Controllers
{
    public class SprintController : Controller
    {
        private readonly ISprintService _sprintService;
        private readonly IProjectService _projectService;
        public SprintController(ISprintService sprintService, IProjectService projectService)
        {
            _projectService = projectService;
            _sprintService = sprintService;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult Index(string filter, int page = 1,
                                               string sortExpression = "Description")
        {
           
            var sprints = _sprintService.GetAll().Select(x => new SprintDetailViewModel
            {
                Id = x.Id.ToString(),
                Number = x.Number,
                Description = x.Description,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                SprintStatusId = x.SprintStatusId,
                ProjectId = x.ProjectId
            });
            
            //var model = new SprintIndexViewModel
            //{
            //    Sprints = sprints
            //};

            //return View(model);
            if (!string.IsNullOrWhiteSpace(filter))
            {
                sprints = sprints.Where(p => p.Description.Contains(filter));
            }
            var model = PagingList.Create(sprints, 5, page, sortExpression, "Description");
            model.RouteValue = new RouteValueDictionary {
                { "filter", filter}
            };
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Projects"] = _projectService.GetAll();
            ViewData["SprintStatuses"] = _sprintService.GetAllSprintStatus();
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SprintDetailViewModel model)
        {
            ViewData["Projects"] = _projectService.GetAll();
            ViewData["SprintStatuses"] = _sprintService.GetAllSprintStatus();
            bool isExist = _sprintService.IsExistSprintNumber(model.Number);
            if (isExist)
            {
                ModelState.AddModelError("model.Number", "Số sprint này đã tồn tại. Bạn vui lòng chọn số sprint khác!");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
          
            await _sprintService.Add(new Sprint
            {
                Number = model.Number,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                SprintStatusId = model.SprintStatusId,
                ProjectId = model.ProjectId
            });

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            ViewData["Projects"] = _projectService.GetAll();
            ViewData["SprintStatuses"] = _sprintService.GetAllSprintStatus();
            var sprint = await _sprintService.GetByIdAsync(int.Parse(id));
            if (sprint == null)
            {
                throw new ApplicationException($"Unable to load project with ID '{id}'.");
            }

            var model = new SprintDetailViewModel
            {
                Id = id,
                Number = sprint.Number,
                Description = sprint.Description,
                StartDate = sprint.StartDate,
                EndDate = sprint.EndDate,
                SprintStatusId = sprint.SprintStatusId,
                ProjectId = sprint.ProjectId
            };

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SprintDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var sprintID = model.Id;
            var sprint = await _sprintService.GetByIdAsync(int.Parse(sprintID));
            if (sprint == null)
            {
                ModelState.AddModelError("Error", "Unable to load the project");
                return View(model);
            }

            sprint.Number = model.Number;
            sprint.Description = model.Description;
            sprint.StartDate = model.StartDate;
            sprint.EndDate = model.EndDate;
            sprint.SprintStatusId = model.SprintStatusId;
            sprint.ProjectId = model.ProjectId;
            await _sprintService.Update(sprint);

            model.StatusMessage = $"{sprint.Number} sprint has been updated";

            return RedirectToAction(nameof(Index));
        }
        //
       
    }
}