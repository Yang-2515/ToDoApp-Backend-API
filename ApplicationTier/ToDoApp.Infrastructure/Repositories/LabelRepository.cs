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
    public class LabelRepository : Repository<Label>, ILabelRepository
    {
        private readonly ITaskLabelRepository _taskLabelRepository;
        public LabelRepository(DbFactory dbFactory,
            ITaskLabelRepository taskLabelRepository
            ): base(dbFactory.DbContext)
        {
            _taskLabelRepository = taskLabelRepository;
        }
        public override async Task<IList<Label>> GetAllAsync()
        {
            return await Entities.Where(c => c.IsDelete == false).ToListAsync();
        }

        public async Task<List<Label>> GetLabelsByTaskIdAsync(int taskId)
        {
            var query = from label in await GetAllAsync()
                        join taskLabel in _taskLabelRepository.GetAllAsync().Result.Where(c => c.TaskId == taskId).ToList() on label.Id equals taskLabel.Label.Id
                        select label;
            return query.ToList();
        }
    }
}
