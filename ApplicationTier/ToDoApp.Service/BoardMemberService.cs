using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.IRepositories;
using ToDoApp.Domain.Models.BoardMember;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Service
{
    public class BoardMemberService : IBoardMemberService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBoardMemberRepository _boardMemberRepository;
        public BoardMemberService(IUnitOfWork unitOfWork,
            IBoardMemberRepository boardMemberRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _boardMemberRepository = boardMemberRepository;
            _mapper = mapper;
        }
        public async Task Add(BoardMemberRequest boardMemberInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                BoardMember boardMember = _mapper.Map<BoardMemberRequest, BoardMember>(boardMemberInput);
                boardMember.CreateAt = DateTime.Now;
                boardMember.IsDelete = false;

                await _boardMemberRepository.InsertAsync(boardMember);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int boardMemberId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var boardMember = await _boardMemberRepository.FindAsync(boardMemberId);
                if (boardMember == null)
                    throw new KeyNotFoundException();
                boardMember.DeleteAt = DateTime.Now;
                boardMember.IsDelete = true;

                //await _labelRepository.DeleteAsync(label);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task DeleteByUserIdAndBoardTd(int userId, int boardId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var assignment = await _boardMemberRepository.FindBoardMemberByUserIdAndBoardIdAsync(userId, boardId);
                if (assignment == null)
                    throw new KeyNotFoundException();
                assignment.DeleteAt = DateTime.Now;
                assignment.IsDelete = true;

                await _boardMemberRepository.DeleteAsync(assignment);

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
