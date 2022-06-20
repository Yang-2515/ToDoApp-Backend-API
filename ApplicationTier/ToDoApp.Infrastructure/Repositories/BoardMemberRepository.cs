using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.IRepositories;

namespace ToDoApp.Infrastructure.Repositories
{
    public class BoardMemberRepository : Repository<BoardMember>, IBoardMemberRepository
    {
        public BoardMemberRepository(DbFactory dbFactory): base(dbFactory.DbContext)
        {

        }
        public override async Task<IList<BoardMember>> GetAllAsync()
        {
            return await Entities.Where(c => c.IsDelete == false).ToListAsync();
        }

        public async Task<BoardMember> FindBoardMemberByUserIdAndBoardIdAsync(int userId, int boardId)
        {
            return await Entities.FirstOrDefaultAsync(c => c.BoardId == boardId && c.UserId == userId && c.IsDelete == false);
        }

        public async Task<IList<BoardMember>> GetBoardMembersByBoardId(int boardId)
        {
            return await Entities.Where(c => c.BoardId == boardId && c.IsDelete == false).ToListAsync();
        }
    }
}
