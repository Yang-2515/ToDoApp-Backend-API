using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Models.BoardMember;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Domain.Interfaces.Services
{
    public interface IBoardMemberService
    {
        Task Add(BoardMemberRequest boardMemberInput);
        Task Delete(int boardMemberId);
        Task DeleteByUserIdAndBoardTd(int userId, int taskId);
    }
}
