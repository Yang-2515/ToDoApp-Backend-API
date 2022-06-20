using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Models.Label;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Domain.Interfaces.Services
{
    public interface ILabelService
    {
        Task<IList<LabelResponse>> GetAll();
        Task Add(LabelRequest label);
        Task Delete(int id);
        Task<LabelResponse> GetOne(int labelId);
        Task Update(LabelRequest label);
        Task<List<LabelResponse>> GetLabelsByTaskIdAsync(int taskId);
    }
}
