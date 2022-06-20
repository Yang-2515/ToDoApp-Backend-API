using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Interfaces;
using ToDoApp.Domain.Interfaces.Services;
using ToDoApp.Domain.IRepositories;
using ToDoApp.Domain.Models.Board;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Service
{
    public class BoardService : IBoardService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBoardRepository _boardRepository;
        private readonly IBoardMemberRepository _boardMemberRepository;
        public BoardService(IUnitOfWork unitOfWork,
            IBoardRepository boardRepository,
            IBoardMemberRepository boardMemberRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _boardRepository = boardRepository;
            _boardMemberRepository = boardMemberRepository;
            _mapper = mapper;
        }
        public async Task Add(BoardRequest boardInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                Board board = _mapper.Map<BoardRequest, Board>(boardInput);
                board.CreateAt = DateTime.Now;
                board.IsDelete = false;
                await _boardRepository.InsertAsync(board);
                await _boardMemberRepository.InsertAsync(new BoardMember
                {
                    UserId = boardInput.ManageId,
                    BoardId = board.Id
                });
                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int boardId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var board = await _boardRepository.FindAsync(boardId);
                if (board == null)
                    throw new KeyNotFoundException();
                board.DeleteAt = DateTime.Now;
                board.IsDelete = true;

                //await _labelRepository.DeleteAsync(label);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task<IList<BoardResponse>> GetAll()
        {
            List<BoardResponse> boardResponses = new List<BoardResponse>();
            var list = await _boardRepository.GetAllAsync();
            foreach (var item in list)
            {
                var board = _mapper.Map<Board, BoardResponse>(item);
                board.Manage = item.Manage == null ? "" : item.Manage.Name;
                boardResponses.Add(board);
            }
            return boardResponses;
        }

        public async Task<IList<BoardResponse>> GetBoardsByManageId(int manageId)
        {
            List<BoardResponse> boardResponses = new List<BoardResponse>();
            var list = await _boardRepository.GetBoardsByManageId(manageId);
            foreach (var item in list)
            {
                var board = _mapper.Map<Board, BoardResponse>(item);
                board.Manage = item.Manage == null ? "" : item.Manage.Name;
                boardResponses.Add(board);
            }
            return boardResponses;
        }

        public async Task<List<BoardResponse>> GetBoardsByUserIdAsync(int userId)
        {
            List<BoardResponse> boardResponses = new List<BoardResponse>();
            var list = await _boardRepository.GetBoardsByUserIdAsync(userId);
            foreach (var item in list)
            {
                var board = _mapper.Map<Board, BoardResponse>(item);
                board.Manage = item.Manage == null ? "" : item.Manage.Name;
                boardResponses.Add(board);
            }
            return boardResponses;
        }

        public async Task<BoardResponse> GetOne(int boardId)
        {
            var board = await _boardRepository.FindAsync(boardId);
            var boardResponses = _mapper.Map<Board, BoardResponse>(board);
            boardResponses.Manage = board.Manage == null ? "" : board.Manage.Name;
            return boardResponses;
        }

        public async Task Update(BoardRequest boardInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var board = await _boardRepository.FindAsync(boardInput.Id);
                if (board == null)
                    throw new KeyNotFoundException();

                board.Name = boardInput.Name;
                board.Description = boardInput.Description;
                board.LinkImage = boardInput.LinkImage;

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
