using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Models.Attackment;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Domain.Interfaces.Services
{
    public interface IAttackmentService
    {
        Task<IList<AttackmentResponse>> GetAttackmentsByTaskId(int taskId);
        Task Add(AttackmentRequest attackmentInput);
        Task Delete(int attackmentId);
        Task<AttackmentResponse> GetOne(int attackmentId);
    }
}
