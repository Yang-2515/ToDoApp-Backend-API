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
using ToDoApp.Domain.Models.ListTask;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Service
{
    public class BoardService : IBoardService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBoardRepository _boardRepository;
        private readonly IBoardMemberRepository _boardMemberRepository;
        private readonly IListTaskRepository _listTaskRepository;
        public BoardService(IUnitOfWork unitOfWork,
            IBoardRepository boardRepository,
            IBoardMemberRepository boardMemberRepository,
            IListTaskRepository listTaskRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _boardRepository = boardRepository;
            _boardMemberRepository = boardMemberRepository;
            _listTaskRepository = listTaskRepository;
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

        public async Task<List<BoardResponse>> GetAll()
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

        public async Task<BoardViewModel> GetOne(int boardId)
        {
            BoardViewModel boardViewModel = new BoardViewModel();
            var board = await _boardRepository.FindAsync(boardId);
            boardViewModel.Board = _mapper.Map<Board, BoardResponse>(board);
            boardViewModel.ListTasks = _mapper.Map<List<ListTask>, List<ListTaskDetail>>(await _listTaskRepository.GetListTasksByBoardIdAsync(boardId));
            boardViewModel.Board.Manage = board.Manage == null ? "" : board.Manage.Name;
            return boardViewModel;
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
