using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;

namespace ToDoApp.Domain.IRepositories
{
    public interface IBoardMemberRepository: IRepository<BoardMember>
    {
        Task<IList<BoardMember>> GetBoardMembersByBoardId(int boardId);
        Task<BoardMember> FindBoardMemberByUserIdAndBoardIdAsync(int userId, int boardId);
    }
}
