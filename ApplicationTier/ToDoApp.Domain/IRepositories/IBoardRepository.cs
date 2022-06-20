using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Domain.IRepositories
{
    public interface IBoardRepository : IRepository<Board>
    {
        Task<IList<Board>> GetBoardsByManageId(int manageId);
        Task<List<Board>> GetBoardsByUserIdAsync(int userId);

    }
}
