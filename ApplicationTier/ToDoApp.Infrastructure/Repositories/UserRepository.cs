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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IBoardMemberRepository _boardMemberRepository;
        public UserRepository(DbFactory dbFactory,
            IAssignmentRepository assignmentRepository,
            IBoardMemberRepository boardMemberRepository
            ): base(dbFactory.DbContext)
        {
            _assignmentRepository = assignmentRepository;
            _boardMemberRepository = boardMemberRepository;
        }
        public override async Task<IList<User>> GetAllAsync()
        {
            return await Entities.Where(c => c.IsDelete == false).ToListAsync();
        }

        public async Task<List<User>> GetUsersByBoardId(int boardId)
        {
            var query = from user in await GetAllAsync()
                        join boardMember in _boardMemberRepository.GetAllAsync().Result.Where(c => c.BoardId == boardId ).ToList() on user.Id equals boardMember.User.Id
                        select user;
            return query.ToList();
        }

        public async Task<List<User>> GetUsersByTaskId(int taskId)
        {
            var query = from user in await GetAllAsync()
                        join assignment in _assignmentRepository.GetAllAsync().Result.Where(c => c.TaskId == taskId).ToList() on user.Id equals assignment.User.Id
                        select user;
            return query.ToList();
        }

    }
}
