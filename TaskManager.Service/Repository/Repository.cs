using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Data;

namespace TaskManager.Service.Repository
{
    public class Repository : IRepository
    {

        private readonly DbContext dbContext;

        public Repository(TaskManagerContext context)
        {
            dbContext = context;
        }

        public async System.Threading.Tasks.Task AddAsync<T>(T entity) where T : class
        {
            await dbContext.AddAsync(entity);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateTask(Data.Models.Task newTask, int id)
        {
            var oldTask = await DbSet<Data.Models.Task>().FindAsync(id);

            oldTask.Description = newTask.Description;
            oldTask.DueDate = newTask.DueDate;
            oldTask.Statuses = newTask.Statuses;
            oldTask.TaskTypes = newTask.TaskTypes;

            await SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task RemoveTask(int id)
        {
            var task = await this.DbSet<Data.Models.Task>()
                .FirstOrDefaultAsync(x => x.Id == id);
            if (task != null)
            {
                this.dbContext.Remove(task);
            }
        }

        private DbSet<T> DbSet<T>() where T : class
        { 
            return dbContext.Set<T>();
        }
    }
}
