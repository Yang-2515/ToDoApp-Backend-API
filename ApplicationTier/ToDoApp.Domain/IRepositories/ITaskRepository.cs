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
        Task<List<TaskEntity>> GetSubTasksByTaskIdAsync(int taskId);
        Task<List<TaskEntity>> GetTasksByListTaskIdAsync(int listTaskId);
    }
}
