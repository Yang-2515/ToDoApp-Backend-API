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
using ToDoApp.Domain.Models.User;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.Service
{
    public class UserService: IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IBoardRepository _boardRepository;
        public UserService(IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IBoardRepository boardRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _boardRepository = boardRepository;
            _mapper = mapper;
        }

        public async Task<IList<UserResponse>> GetAll()
        {
            return _mapper.Map<IList<User>, IList<UserResponse>>(await _userRepository.GetAllAsync());
        }

        public async Task<UserViewModel> GetOne(int userId)
        {
            UserViewModel userViewModel = new UserViewModel();
            var user = await _userRepository.FindAsync(userId);
            userViewModel.User = _mapper.Map<User, UserResponse>(user);
            userViewModel.Boards = _mapper.Map < List<Board>, List<BoardDetail>>(await _boardRepository.GetBoardsByUserIdAsync(userId));
            return userViewModel;
        }

        public async Task Update(UserRequest userInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var user = await _userRepository.FindAsync(userInput.Id);
                if (user == null)
                    throw new KeyNotFoundException();

                user.Name = userInput.Name;
                user.Age = userInput.Age;
                user.Gender = userInput.Gender;
                user.HomeAddress = userInput.HomeAddress;
                user.EmailAddress = userInput.EmailAddress;
                user.LinkImage = userInput.LinkImage;

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Add(UserRequest userInput)
        {
            try
            {
                await _unitOfWork.BeginTransaction();
                var user = _mapper.Map<UserRequest, User>(userInput);
                user.CreateAt = DateTime.Now;
                user.IsDelete = false;

                await _userRepository.InsertAsync(user);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task Delete(int userId)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var user = await _userRepository.FindAsync(userId);
                if (user == null)
                    throw new KeyNotFoundException();

                await _userRepository.DeleteAsync(user);

                await _unitOfWork.CommitTransaction();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task<List<UserResponse>> GetUsersByTaskId(int taskId)
        {
            return _mapper.Map<List<User>, List<UserResponse>>(await _userRepository.GetUsersByTaskId(taskId));
        }

        public async Task<List<UserResponse>> GetUsersByBoardId(int boardId)
        {
            return _mapper.Map<List<User>, List<UserResponse>>(await _userRepository.GetUsersByBoardId(boardId));
        }
    }
}
