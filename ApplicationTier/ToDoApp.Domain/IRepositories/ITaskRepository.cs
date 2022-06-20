using System;
using System.Collections.Generic;
using System.Text;
using Task = System.Threading.Tasks.Task;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;
using ToDoApp.Domain.Models.Task;
using TaskEntity = ToDoApp.Domain.Entities.Task;
using System.Threading.Tasks;

namespace ToDoApp.Domain.IRepositories
{
    public interface ITaskRepository : IRepository<TaskEntity>
    {
        Task<IList<TaskEntity>> GetSubTasksByTaskIdAsync(int taskId);
        Task<IList<TaskEntity>> GetTasksByListTaskIdAsync(int listTaskId);
    }
}
