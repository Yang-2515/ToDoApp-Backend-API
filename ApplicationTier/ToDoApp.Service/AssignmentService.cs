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
using ToDoApp.Domain.Models.Assignment;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Service
{
    public class AssignmentService: IAssignmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAssignmentRepository _assignmentRepository;
        public AssignmentService(IUnitOfWork unitOfWork,
            IAssignmentRepository assignmentRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }

        public async Task Add(AssignmentRequest assignmentInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                Assignment assignment = _mapper.Map<AssignmentRequest, Assignment>(assignmentInput);
                assignment.CreateAt = DateTime.Now;
                assignment.IsDelete = false;

                await _assignmentRepository.InsertAsync(assignment);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int assignmentId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var assignment = await _assignmentRepository.FindAsync(assignmentId);
                if (assignment == null)
                    throw new KeyNotFoundException();
                assignment.DeleteAt = DateTime.Now;
                assignment.IsDelete = true;

                await _assignmentRepository.DeleteAsync(assignment);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }
        public async Task DeleteByUserIdAndTaskTd(int userId, int taskId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var assignment = await _assignmentRepository.FindAssignmentByUserIdAndTaskIdAsync(userId, taskId);
                if (assignment == null)
                    throw new KeyNotFoundException();
                assignment.DeleteAt = DateTime.Now;
                assignment.IsDelete = true;

                await _assignmentRepository.DeleteAsync(assignment);

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
