using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;
using System.Threading.Tasks;

namespace ToDoApp.Domain.IRepositories
{
    public interface ITaskLabelRepository : IRepository<TaskLabel>
    {
        Task<TaskLabel> FindTaskLabelByTaskIdAndLabelId(int taskId, int labelId);
    }
}
