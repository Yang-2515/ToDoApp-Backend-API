using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Interfaces;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.IRepositories;
using ToDoApp.Domain.Models.Task;
using Task = System.Threading.Tasks.Task;
using TaskEntity = ToDoApp.Domain.Entities.Task;

namespace ToDoApp.Service
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskService(IUnitOfWork unitOfWork,
            ITaskRepository taskRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task Add(TaskRequest taskInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                TaskEntity task = _mapper.Map<TaskRequest, TaskEntity>(taskInput);
                task.CreateAt = DateTime.Now;
                task.IsDelete = false;

                await _taskRepository.InsertAsync(task);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int taskId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var task = await _taskRepository.FindAsync(taskId);
                if (task == null)
                    throw new KeyNotFoundException();
                task.DeleteAt = DateTime.Now;
                task.IsDelete = true;

                //await _labelRepository.DeleteAsync(label);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task<IList<TaskResponse>> GetAll()
        {
            List<TaskResponse> taskResponses = new List<TaskResponse>();
            var list = await _taskRepository.GetAllAsync();
            foreach (var item in list)
            {
                var task = _mapper.Map<TaskEntity, TaskResponse>(item);
                task.ListTask = item.ListTask == null ? "" : item.ListTask.Name;
                taskResponses.Add(task);
            }
            return taskResponses;
        }

        public async Task<TaskResponse> GetOne(int taskId)
        {
            var task = await _taskRepository.FindAsync(taskId);
            var taskResponse = _mapper.Map<TaskEntity, TaskResponse>(task);
            taskResponse.ListTask = task.ListTask == null ? "" : task.ListTask.Name;
            return taskResponse;
        }

        public async Task<IList<TaskResponse>> GetSubTasksByTaskIdAsync(int taskId)
        {
            List<TaskResponse> taskResponses = new List<TaskResponse>();
            var list = await _taskRepository.GetSubTasksByTaskIdAsync(taskId);
            foreach (var item in list)
            {
                var task = _mapper.Map<TaskEntity, TaskResponse>(item);
                task.ListTask = item.ListTask == null ? "" : item.ListTask.Name;
                taskResponses.Add(task);
            }
            return taskResponses;
        }

        public async Task<IList<TaskResponse>> GetTasksByListTaskIdAsync(int listTaskId)
        {
            List<TaskResponse> taskResponses = new List<TaskResponse>();
            var list = await _taskRepository.GetTasksByListTaskIdAsync(listTaskId);
            foreach (var item in list)
            {
                var task = _mapper.Map<TaskEntity, TaskResponse>(item);
                task.ListTask = item.ListTask == null ? "" : item.ListTask.Name;
                taskResponses.Add(task);
            }
            return taskResponses;
        }

        public async Task Update(TaskRequest taskInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var task = await _taskRepository.FindAsync(taskInput.Id);
                if (task == null)
                    throw new KeyNotFoundException();

                task.Name = taskInput.Name;
                task.Description = taskInput.Description;
                task.DueDate = taskInput.DueDate;
                task.StartDate = taskInput.StartDate;
                task.ParentId = taskInput.ParentId;

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task UpdateListTaskId(TaskRequest taskInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var task = await _taskRepository.FindAsync(taskInput.Id);
                if (task == null)
                    throw new KeyNotFoundException();

                task.ListTaskId = taskInput.ListTaskId;

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
