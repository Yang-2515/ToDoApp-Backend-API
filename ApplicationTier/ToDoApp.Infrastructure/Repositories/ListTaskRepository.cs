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
    public class ListTaskRepository : Repository<ListTask>, IListTaskRepository
    {
        public ListTaskRepository(DbFactory dbFactory): base(dbFactory.DbContext)
        {

        }
        public override async Task<IList<ListTask>> GetAllAsync()
        {
            return await Entities.Where(c => c.IsDelete == false).ToListAsync();
        }

        public async Task<List<ListTask>> GetListTasksByBoardIdAsync(int boardId)
        {
            return await Entities.Where(c => c.BoardId == boardId && c.IsDelete == false).ToListAsync();
        }
    }
}
