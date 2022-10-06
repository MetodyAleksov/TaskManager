using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.DTOs;

namespace TaskManager.Service.Task
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDTO>> GetTasks();
        System.Threading.Tasks.Task AddTask();
        System.Threading.Tasks.Task UpdateTask();
        System.Threading.Tasks.Task RemoveTask();
    }
}
