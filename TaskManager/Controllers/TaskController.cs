using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Data.DTOs;
using TaskManager.Service.Task;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [Authorize]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(string description, DateTime dueDate, string status, string taskType)
        {
            TaskDTO task = new TaskDTO()
            {
                TimeCreated = DateTime.Now,
                Description = description,
                DueDate = dueDate,
                Statuses = status,
                TaskTypes = taskType,
                Author = HttpContext.User.Identity.Name
            };

            await _taskService.AddTaskAsync(task);

            return Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Task = _taskService.GetTasks().FirstOrDefault(t => t.Id == id);

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id ,string description, DateTime dueDate, string status, string taskType)
        {
            var task = _taskService.GetTasks().FirstOrDefault(t => t.Id == id);
            await _taskService.UpdateTaskAsync(id, new TaskDTO()
            {
                Id = id,
                Description = description,
                DueDate = dueDate,
                Statuses = status,
                TaskTypes = taskType,
                Author = task.Author,
                Comments = task.Comments,
                TimeCreated = task.TimeCreated
            });

            return Redirect("/");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await _taskService.RemoveTaskAsync(id);

            return Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> AddComment(int id)
        {
            ViewBag.Task = _taskService.GetTasks().FirstOrDefault(t => t.Id == id);

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddComment(string text, int taskId)
        {
            await _taskService.AddCommentToTaskAsync(taskId, text, HttpContext.User.Identity.Name);

            return Redirect("/");
        }
    }
}
