using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ToDoApp.Domain.Base;

namespace ToDoApp.Domain.Models.Assignment
{
    public class AssignmentRequest: EntityBaseId<int>
    {
        [Required]
        public int TaskId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
