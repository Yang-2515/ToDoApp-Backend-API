using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Domain.Base;

namespace ToDoApp.Domain.Models.Board
{
    public class BoardDetail: EntityBaseId<int>
    {
        public string Name { get; set; }
    }
}
