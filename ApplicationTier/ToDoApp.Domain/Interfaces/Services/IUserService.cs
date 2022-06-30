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
        Task<UserViewModel> GetOne(int userId);
        Task Update(UserRequest userInput);
    }
}
