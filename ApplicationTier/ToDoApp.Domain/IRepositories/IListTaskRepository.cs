using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Domain.IRepositories
{
    public interface IListTaskRepository : IRepository<ListTask>
    {
        Task<List<ListTask>> GetListTasksByBoardIdAsync(int boardId);
    }
}
