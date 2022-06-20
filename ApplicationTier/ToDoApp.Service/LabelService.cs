using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.IRepositories;
using ToDoApp.Domain.Models.Label;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Service
{
    public class LabelService: ILabelService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILabelRepository _labelRepository; 
        public LabelService(IUnitOfWork unitOfWork,
            ILabelRepository labelRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _labelRepository = labelRepository;
            _mapper = mapper;
        }

        public async Task<IList<LabelResponse>> GetAll()
        {
            return _mapper.Map<IList<Label>, IList<LabelResponse>>(await _labelRepository.GetAllAsync());
        }

        public async Task<LabelResponse> GetOne(int labelId)
        {
            return _mapper.Map<Label, LabelResponse>(await _labelRepository.FindAsync(labelId));
        }

        public async Task Update(LabelRequest labelInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var label = await _labelRepository.FindAsync(labelInput.Id);
                if (label == null)
                    throw new KeyNotFoundException();

                label.Name = labelInput.Name;
                label.Color = labelInput.Color;

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Add(LabelRequest labelInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                var label = _mapper.Map<LabelRequest, Label>(labelInput);
                label.CreateAt = DateTime.Now;
                label.IsDelete = false;

                await _labelRepository.InsertAsync(label);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int labelId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var label = await _labelRepository.FindAsync(labelId);
                if (label == null)
                    throw new KeyNotFoundException();
                label.DeleteAt = DateTime.Now;
                label.IsDelete = true;

                //await _labelRepository.DeleteAsync(label);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task<List<LabelResponse>> GetLabelsByTaskIdAsync(int taskId)
        {
            return _mapper.Map<List<Label>, List<LabelResponse>>(await _labelRepository.GetLabelsByTaskIdAsync(taskId));
        }
    }
}
