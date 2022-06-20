using ToDoApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Models.User;

namespace ToDoApp.Domain.Models.Board
{
    public class BoardResponse: EntityBaseId<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LinkImage { get; set; }
        public string ManageId { get; set; }
        public string Manage { get; set; }
    }
}
