using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using TaskEntity = ToDoApp.Domain.Entities.Task;
using Task = System.Threading.Tasks.Task;
using ToDoApp.Domain.Models.Task;

namespace ToDoApp.Domain.Interfaces.Services
{
    public interface ITaskService
    {
        Task Delete(int taskId);
        Task<TaskViewModel> GetOne(int taskId);
        Task Update(TaskRequest task);
        Task Add(TaskRequest task);
        Task UpdateListTaskId(TaskRequest task);
    }
}
