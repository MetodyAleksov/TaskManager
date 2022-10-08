﻿using System;
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
        System.Threading.Tasks.Task RemoveTask(int id);
    }
}
