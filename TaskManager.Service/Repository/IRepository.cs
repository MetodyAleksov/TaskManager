using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.DTOs;

namespace TaskManager.Service.Repository
{
    public interface IRepository
    {
        System.Threading.Tasks.Task AddAsync<T>(T entity) where T : class;

        IQueryable<T> All<T>() where T : class;

        Task<int> SaveChangesAsync();

        System.Threading.Tasks.Task UpdateTask(Data.Models.Task newTask, int id);

        System.Threading.Tasks.Task RemoveTask(int id);

        System.Threading.Tasks.Task AddCommentToTask(int taskId, CommentDTO comment);
    }
}
