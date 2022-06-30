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
    public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(DbFactory dbFactory): base(dbFactory.DbContext)
        {

        }
        public override async Task<IList<Assignment>> GetAllAsync()
        {
            return await Entities.Where(c => c.IsDelete == false).ToListAsync();
        }

        public async Task<IList<Assignment>> GetAssignmentsByTaskId(int taskId)
        {
            return await Entities.Where(c => c.TaskId == taskId && c.IsDelete == false).ToListAsync();
        }
        public async Task<Assignment> FindAssignmentByUserIdAndTaskIdAsync(int userId, int taskId)
        {
            return await Entities.FirstOrDefaultAsync(c => c.TaskId == taskId && c.UserId == userId && c.IsDelete == false);
        }
    }
}
