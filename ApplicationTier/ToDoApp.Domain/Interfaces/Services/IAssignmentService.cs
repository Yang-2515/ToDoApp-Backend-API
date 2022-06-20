using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Models.Assignment;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Domain.Interfaces.Services
{
    public interface IAssignmentService
    {
        Task Add(AssignmentRequest assignmentInput);
        Task Delete(int assignmentId);
        Task DeleteByUserIdAndTaskTd(int userId, int taskId);
    }
}
