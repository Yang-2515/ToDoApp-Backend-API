using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Domain.IRepositories
{
    public interface IAssignmentRepository: IRepository<Assignment>
    {
        Task<IList<Assignment>> GetAssignmentsByTaskId(int taskId);
        Task<Assignment> FindAssignmentByUserIdAndTaskIdAsync(int userId, int taskId);
    }
}
