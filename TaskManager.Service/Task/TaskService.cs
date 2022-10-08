using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Data.DTOs;
using TaskManager.Service.Repository;
using TaskManager.Service.Task;

namespace TaskManager.Service
{
    public class TaskService : ITaskService
    {
        private IRepository _repo;

        public TaskService(IRepository repo)
        {
            _repo = repo;
        }

        public async System.Threading.Tasks.Task AddTaskAsync(TaskDTO task)
        {
            await _repo.AddAsync<Data.Models.Task>(new Data.Models.Task()
            {
                TimeCreated = task.TimeCreated,
                DueDate = task.DueDate,
                Description = task.Description,
                Statuses = task.Statuses,
                TaskTypes = task.TaskTypes,
                User = _repo.All<Data.Models.User>().FirstOrDefault(u => u.Username == task.Author)
            });

            await _repo.SaveChangesAsync();
        }

        public IEnumerable<TaskDTO> GetTasks()
        {
            var tasks = _repo.All<Data.Models.Task>()
                .Select(t => new TaskDTO()
                {
                    Id = t.Id,
                    DueDate = t.DueDate,
                    TimeCreated = t.TimeCreated,
                    TaskTypes = t.TaskTypes,
                    Statuses = t.Statuses,
                    Author = t.User.Username,
                    Description = t.Description,
                });

            return tasks;
        }

        public async System.Threading.Tasks.Task RemoveTaskAsync(int id)
        {
            await _repo.RemoveTask(id);

            await _repo.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateTaskAsync(int id, TaskDTO newTask)
        {
            var task = _repo.All<Data.Models.Task>().FirstOrDefault(t => t.Id == id);

            await _repo.UpdateTask(new Data.Models.Task()
            {
                Id = id,
                DueDate = newTask.DueDate,
                TaskTypes = newTask.TaskTypes,
                Comments = task.Comments,
                Description = newTask.Description,
                Statuses = newTask.Statuses,
                TimeCreated = task.TimeCreated,
                UserId = task.UserId
            }, id);

            await _repo.SaveChangesAsync();
        }
    }
}
