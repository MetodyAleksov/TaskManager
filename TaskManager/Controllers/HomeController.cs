using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Service.Task;

namespace TaskManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskService _taskService;
        public HomeController(ILogger<HomeController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewData["User"] = HttpContext.User.Identity.Name;
            ViewData["Tasks"] = _taskService.GetTasks().ToArray();
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
