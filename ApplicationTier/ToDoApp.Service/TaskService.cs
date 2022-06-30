using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.IRepositories;
using ToDoApp.Domain.Models.Attackment;
using ToDoApp.Domain.Models.Label;
using ToDoApp.Domain.Models.Task;
using ToDoApp.Domain.Models.User;
using Task = System.Threading.Tasks.Task;
using TaskEntity = ToDoApp.Domain.Entities.Task;

namespace ToDoApp.Service
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILabelRepository _labelRepository;
        private readonly IAttackmentRepository _attackmentRepository;
        private readonly IMapper _mapper;
        public TaskService(IUnitOfWork unitOfWork,
            ITaskRepository taskRepository,
            IUserRepository userRepository,
            ILabelRepository labelRepository,
            IAttackmentRepository attackmentRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _labelRepository = labelRepository;
            _attackmentRepository = attackmentRepository;
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

        public async Task<TaskViewModel> GetOne(int taskId)
        {
            var task = await _taskRepository.FindAsync(taskId);
            var taskViewModel = _mapper.Map<TaskEntity, TaskViewModel>(task);
            taskViewModel.SubTasks = _mapper.Map < List<TaskEntity>, List<TaskDetail> > (await _taskRepository.GetSubTasksByTaskIdAsync(taskId));
            taskViewModel.AssignmentTasks = _mapper.Map<List<User>, List<UserResponse>>(await _userRepository.GetUsersByTaskId(taskId));
            taskViewModel.Attackments = _mapper.Map<List<Attackment>, List<AttackmentResponse>>(await _attackmentRepository.GetAttackmentsByTaskId(taskId));
            taskViewModel.LabelTasks = _mapper.Map<List<Label>, List<LabelResponse>>(await _labelRepository.GetLabelsByTaskIdAsync(taskId));
            taskViewModel.ListTask = task.ListTask == null ? "" : task.ListTask.Name;
            return taskViewModel;
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
