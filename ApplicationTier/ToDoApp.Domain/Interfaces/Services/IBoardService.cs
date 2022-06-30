using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Models.Board;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Domain.Interfaces.Services
{
    public interface IBoardService
    {
        Task<List<BoardResponse>> GetAll();
        Task Add(BoardRequest boardInput);
        Task Delete(int boardId);
        Task<BoardViewModel> GetOne(int boardId);
        Task Update(BoardRequest boardInput);
    }
}
