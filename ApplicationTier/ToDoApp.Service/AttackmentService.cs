using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.IRepositories;
using ToDoApp.Domain.Models.Attackment;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Service
{
    public class AttackmentService : IAttackmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttackmentRepository _attackmentRepository;
        public AttackmentService(IUnitOfWork unitOfWork,
            IAttackmentRepository attackmentRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _attackmentRepository = attackmentRepository;
            _mapper = mapper;
        }
        public async Task Add(AttackmentRequest attackmentInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                Attackment attackment = _mapper.Map<AttackmentRequest, Attackment>(attackmentInput);
                attackment.CreateAt = DateTime.Now;
                attackment.IsDelete = false;

                await _attackmentRepository.InsertAsync(attackment);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int attackmentId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var attackment = await _attackmentRepository.FindAsync(attackmentId);
                if (attackment == null)
                    throw new KeyNotFoundException();
                attackment.DeleteAt = DateTime.Now;
                attackment.IsDelete = true;

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
