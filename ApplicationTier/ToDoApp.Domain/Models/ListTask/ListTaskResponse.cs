using ToDoApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Domain.Models.ListTask
{
    public class ListTaskResponse: EntityBaseId<int>
    {
        public string Name { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Color { get; set; }
        public int? BoardId { get; set; }
        public string Board { get; set; }
    }
}
