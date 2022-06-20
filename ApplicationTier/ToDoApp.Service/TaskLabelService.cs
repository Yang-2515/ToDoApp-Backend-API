using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.IRepositories;
using ToDoApp.Domain.Models.TaskLabel;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Service
{
    public class TaskLabelService : ITaskLabelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITaskLabelRepository _taskLabelRepository;
        private readonly IMapper _mapper;
        public TaskLabelService(IUnitOfWork unitOfWork,
            ITaskLabelRepository taskLabelRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _taskLabelRepository = taskLabelRepository;
            _mapper = mapper;
        }
        public async Task Add(TaskLabelRequest taskLabelInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                TaskLabel taskLabel = _mapper.Map<TaskLabelRequest, TaskLabel>(taskLabelInput);
                taskLabel.CreateAt = DateTime.Now;
                taskLabel.IsDelete = false;

                await _taskLabelRepository.InsertAsync(taskLabel);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int taskLabelId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var taskLabel = await _taskLabelRepository.FindAsync(taskLabelId);
                if (taskLabel == null)
                    throw new KeyNotFoundException();
                taskLabel.DeleteAt = DateTime.Now;
                taskLabel.IsDelete = true;

                //await _labelRepository.DeleteAsync(label);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task DeleteByTaskIdAndLabelId(int taskId, int labelId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var taskLabel = await _taskLabelRepository.FindTaskLabelByTaskIdAndLabelId(taskId,labelId);
                if (taskLabel == null)
                    throw new KeyNotFoundException();
                taskLabel.DeleteAt = DateTime.Now;
                taskLabel.IsDelete = true;

                //await _labelRepository.DeleteAsync(label);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }
    }
}
