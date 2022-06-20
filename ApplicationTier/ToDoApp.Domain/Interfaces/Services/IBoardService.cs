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
        Task<IList<BoardResponse>> GetAll();
        Task Add(BoardRequest boardInput);
        Task Delete(int boardId);
        Task<BoardResponse> GetOne(int boardId);
        Task Update(BoardRequest boardInput);
        Task<IList<BoardResponse>> GetBoardsByManageId(int manageId);
        Task<List<BoardResponse>> GetBoardsByUserIdAsync(int userId);
    }
}
