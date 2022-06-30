using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Models.Board;

namespace ToDoApp.Domain.Models.User
{
    public class UserViewModel
    {
        public UserResponse User { get; set; }
        public List<BoardDetail> Boards { get; set; }
    }
}
