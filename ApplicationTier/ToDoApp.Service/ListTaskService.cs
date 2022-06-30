using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.IRepositories;
using ToDoApp.Domain.Models.ListTask;
using ToDoApp.Domain.Models.Task;
using Task = System.Threading.Tasks.Task;
using TaskEntity = ToDoApp.Domain.Entities.Task;

namespace ToDoApp.Service
{
    public class ListTaskService : IListTaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IListTaskRepository _listTaskRepository;
        private readonly ITaskRepository _taskRepository;
        private readonly IAttackmentRepository _attackmentRepository;
        private readonly IMapper _mapper;
        public ListTaskService(IUnitOfWork unitOfWork,
            IListTaskRepository listTaskRepository,
            ITaskRepository taskRepository,
            IAttackmentRepository attackmentRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _listTaskRepository = listTaskRepository;
            _taskRepository = taskRepository;
            _attackmentRepository = attackmentRepository;
            _mapper = mapper;
        }
        public async Task Add(ListTaskRequest listTaskInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                ListTask listTask = _mapper.Map<ListTaskRequest, ListTask>(listTaskInput);
                listTask.CreateAt = DateTime.Now;
                listTask.IsDelete = false;

                await _listTaskRepository.InsertAsync(listTask);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int listTaskId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var listTask = await _listTaskRepository.FindAsync(listTaskId);
                if (listTask == null)
                    throw new KeyNotFoundException();
                listTask.DeleteAt = DateTime.Now;
                listTask.IsDelete = true;

                //await _labelRepository.DeleteAsync(label);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task<IList<ListTaskResponse>> GetAll()
        {
            List<ListTaskResponse> listTaskResponses = new List<ListTaskResponse>();
            var list = await _listTaskRepository.GetAllAsync();
            foreach (var item in list)
            {
                var listTask = _mapper.Map<ListTask, ListTaskResponse>(item);
                listTask.Board = item.Board == null ? "" : item.Board.Name;
                listTaskResponses.Add(listTask);
            }
            return listTaskResponses;
        }

        public async Task<IList<ListTaskResponse>> GetListTasksByBoardIdAsync(int boardId)
        {
            List<ListTaskResponse> listTaskResponses = new List<ListTaskResponse>();
            var list = await _listTaskRepository.GetListTasksByBoardIdAsync(boardId);
            foreach (var item in list)
            {
                var listTask = _mapper.Map<ListTask, ListTaskResponse>(item);
                listTask.Board = item.Board == null ? "" : item.Board.Name;
                listTaskResponses.Add(listTask);
            }
            return listTaskResponses;
        }

        public async Task<ListTaskViewModel> GetOne(int listTaskId)
        {
            ListTaskViewModel listTaskViewModel = new ListTaskViewModel();
            var listTask = await _listTaskRepository.FindAsync(listTaskId);
            listTaskViewModel.ListTask = _mapper.Map<ListTask, ListTaskResponse>(listTask);
            listTaskViewModel.ListTask.Board = listTask.Board == null ? "" : listTask.Board.Name;
            listTaskViewModel.Tasks = _mapper.Map<List<TaskEntity>, List<TaskDetail>>(await _taskRepository.GetTasksByListTaskIdAsync(listTaskId));
            foreach(TaskDetail task in listTaskViewModel.Tasks)
            {
                task.SubTasksCount = (await _taskRepository.GetSubTasksByTaskIdAsync(task.Id)).Count();
                task.AttackmentsCount = (await _attackmentRepository.GetAttackmentsByTaskId(task.Id)).Count();
            }
            return listTaskViewModel;
        }

        public async Task Update(ListTaskRequest listTaskInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var listTask = await _listTaskRepository.FindAsync(listTaskInput.Id);
                if (listTask == null)
                    throw new KeyNotFoundException();

                listTask.Name = listTaskInput.Name;
                listTask.Color = listTaskInput.Color;
                listTask.ToDate = listTask.ToDate;
                listTask.FromDate = listTask.FromDate;

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
