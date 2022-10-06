using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Data.DTOs;
using TaskManager.Service.Task;

namespace TaskManager.Service
{
    public class TaskService : ITaskService
    {
        public System.Threading.Tasks.Task AddTask()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDTO>> GetTasks()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task RemoveTask()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateTask()
        {
            throw new NotImplementedException();
        }
    }
}
