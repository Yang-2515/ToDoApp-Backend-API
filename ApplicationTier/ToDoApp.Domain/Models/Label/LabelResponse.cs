using ToDoApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Domain.Models.Label
{
    public class LabelResponse: EntityBaseId<int>
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
