using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.DTOs;

namespace TaskManager.Service.Task
{
    public interface ITaskService
    {
        IEnumerable<TaskDTO> GetTasks();
        System.Threading.Tasks.Task AddTaskAsync(TaskDTO task);
        System.Threading.Tasks.Task RemoveTaskAsync(int id);
        System.Threading.Tasks.Task UpdateTaskAsync(int id, TaskDTO newTask);
        System.Threading.Tasks.Task AddCommentToTaskAsync(int id, string text, string author);
    }
}
