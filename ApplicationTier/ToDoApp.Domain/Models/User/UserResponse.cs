using ToDoApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Domain.Models.User
{
    public class UserResponse: EntityBaseId<int>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string HomeAddress { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string LinkImage { get; set; }
    }
}
