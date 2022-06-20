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
    public class AttackmentRepository : Repository<Attackment>, IAttackmentRepository
    {
        public AttackmentRepository(DbFactory dbFactory): base(dbFactory.DbContext)
        {

        }
        public override async Task<IList<Attackment>> GetAllAsync()
        {
            return await Entities.Where(c => c.IsDelete == false).ToListAsync();
        }

        public async Task<IList<Attackment>> GetAttackmentsByTaskId(int taskId)
        {
            return await Entities.Where(c => c.IsDelete == false && c.TaskId == taskId).ToListAsync();
        }
    }
}
