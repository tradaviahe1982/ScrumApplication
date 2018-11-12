using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScrumApplication.Models;
using ScrumApplicationServices;
using Hangfire;
using Hangfire.AspNetCore;
using Hangfire.SqlServer;
namespace ScrumApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStoredProcedureService _iStoredProcedureService;


        public HomeController(IStoredProcedureService iStoredProcedureService)
        {
            _iStoredProcedureService = iStoredProcedureService;
        }
        public IActionResult Index()
        {
            //var stories = _iStoredProcedureService.GetAllStoryFromProjectId(1);
            //BackgroundJob.Schedule(() => _iStoredProcedureService.RecurringJobInsertStudent(DateTime.Now.ToString(), "Nguyễn Việt Anh", "3b Hàng Tre"), DateTime.Parse("0:00 AM").TimeOfDay);
            RecurringJob.AddOrUpdate(() => _iStoredProcedureService.RecurringJobInsertStudent(DateTime.Now.ToString(), "Nguyễn Việt Anh", "3b Hàng Tre"), Cron.Daily);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
