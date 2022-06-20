using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Domain.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetUsersByTaskId(int taskId);
        Task<List<User>> GetUsersByBoardId(int boardId);
    }
}
