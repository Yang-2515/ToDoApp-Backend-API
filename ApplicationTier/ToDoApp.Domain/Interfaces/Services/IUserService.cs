using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Models.User;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IList<UserResponse>> GetAll();
        Task Add(UserRequest userInput);
        Task Delete(int userId);
        Task<User> GetOne(int userId);
        Task Update(UserRequest userInput);
        Task<List<UserResponse>> GetUsersByTaskId(int taskId);
        Task<List<UserResponse>> GetUsersByBoardId(int boardId);
    }
}
