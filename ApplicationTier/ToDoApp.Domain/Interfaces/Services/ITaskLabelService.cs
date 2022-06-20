using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Models.TaskLabel;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Domain.Interfaces.Services
{
    public interface ITaskLabelService
    {
        Task Delete(int taskLabelId);
        Task Add(TaskLabelRequest taskLabel);
        Task DeleteByTaskIdAndLabelId(int taskId, int labelId);
    }
}
