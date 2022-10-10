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

        public async System.Threading.Tasks.Task AddCommentToTaskAsync(int id, string text, string author)
        {
            await _repo.AddCommentToTask(id, new CommentDTO()
            {
                Author = author,
                Content = text,
            });
        }

        public async System.Threading.Tasks.Task AddTaskAsync(TaskDTO task)
        {
            //INSER INTO [dbo].[Tasks] (datetime timeCreated, datetime dueDate, varchar description, varchar statuses, varchar tasktypes, int userId)
            //VALUES({timeCreated}, {dueDate}, {description}, {taskTypes}, {statuses}, {userId})
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
            //SQL Query would look something like this:
            //SELECT * [Tasks].[id], [Tasks].[TimeCreated], [Tasks].[DueDate], [Tasks].[TaskTypes], [Tasks].[Statuses], [Users].[Username]
            //FROM [TaskManager].[dbo].[Tasks]
            //INNER JOIN [TaskManager].[dbo].[Users] ON ([Tasks].[UserId] = [Users].[Id])

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
                    Comments = t.Comments.Select(c => new CommentDTO
                    {
                        Author = t.User.Username,
                        Content = c.Content,
                        TaskId = c.TaskId
                    }).ToList()
                });

            return tasks;
        }

        public async System.Threading.Tasks.Task RemoveTaskAsync(int id)
        {
            //DELETE FROM [dbo].[Tasks]
            //WHERE [Id]  [Id]
            await _repo.RemoveTask(id);

            await _repo.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateTaskAsync(int id, TaskDTO newTask)
        {
            //UPDATE [Tasks]
            //SET DueDate = '{dueDate}', ...
            //WHERE Id = {id}
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
