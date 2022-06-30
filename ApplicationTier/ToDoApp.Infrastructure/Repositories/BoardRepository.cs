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
    public class BoardRepository : Repository<Board>, IBoardRepository
    {
        private readonly IBoardMemberRepository _boardMemberRepository;
        public BoardRepository(DbFactory dbFactory,
            IBoardMemberRepository boardMemberRepository
            ) : base(dbFactory.DbContext)
        {
            _boardMemberRepository = boardMemberRepository;
        }
        public override async Task<IList<Board>> GetAllAsync()
        {
            return await Entities.Where(c => c.IsDelete == false).ToListAsync();
        }

        public async Task<IList<Board>> GetBoardsByManageId(int manageId)
        {
            return await Entities.Where(c => c.ManageId == manageId && c.IsDelete == false).ToListAsync();
        }

        public async Task<List<Board>> GetBoardsByUserIdAsync(int userId)
        {
            var query = from board in await GetAllAsync()
                        join boardMember in _boardMemberRepository.GetAllAsync().Result.Where(c => c.UserId == userId).ToList() on board.Id equals boardMember.Board.Id 
                        select board;
            return query.ToList();
        }
    }
}
