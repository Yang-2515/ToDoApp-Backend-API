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
    public class TaskLabelRepository : Repository<TaskLabel>, ITaskLabelRepository
    {
        public TaskLabelRepository(DbFactory dbFactory): base(dbFactory.DbContext)
        {

        }
        public override async Task<IList<TaskLabel>> GetAllAsync()
        {
            return await Entities.Where(c => c.IsDelete == false).ToListAsync();
        }
        public async Task<TaskLabel> FindTaskLabelByTaskIdAndLabelId(int taskId, int labelId)
        {
            return await Entities.FirstOrDefaultAsync(c => c.TaskId == taskId && c.LabelId == labelId);
        }
    }
}
