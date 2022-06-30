using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Models.ListTask;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Domain.Interfaces.Services
{
    public interface IListTaskService
    {
        Task Delete(int boardId);
        Task<ListTaskViewModel> GetOne(int listTaskId);
        Task<IList<ListTaskResponse>> GetAll();
        Task Update(ListTaskRequest listTask);
        Task Add(ListTaskRequest listTask);
    }
}
