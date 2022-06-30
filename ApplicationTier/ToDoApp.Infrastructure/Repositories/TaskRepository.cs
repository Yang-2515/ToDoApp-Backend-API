using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = System.Threading.Tasks.Task;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.IRepositories;
using ToDoApp.Domain.Models.Task;
using TaskEntity = ToDoApp.Domain.Entities.Task;
using System.Threading.Tasks;

namespace ToDoApp.Infrastructure.Repositories
{
    public class TaskRepository : Repository<TaskEntity>, ITaskRepository
    {
        public TaskRepository(DbFactory dbFactory): base(dbFactory.DbContext)
        {

        }
        public override async Task<IList<TaskEntity>> GetAllAsync()
        {
            return await Entities.Where(c => c.IsDelete == false).ToListAsync();
        }

        public async Task<List<TaskEntity>> GetSubTasksByTaskIdAsync(int taskId)
        {
            return await Entities.Where(c => c.ParentId == taskId && c.IsDelete == false).ToListAsync();
        }

        public async Task<List<TaskEntity>> GetTasksByListTaskIdAsync(int listTaskId)
        {
            return await Entities.Where(c => c.ListTaskId == listTaskId && c.IsDelete == false).ToListAsync();
        }
    }
}
