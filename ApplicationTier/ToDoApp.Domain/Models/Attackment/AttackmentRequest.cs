using ToDoApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoApp.Domain.Models.Attackment
{
    public class AttackmentRequest: EntityBaseId<int>
    {
        [Required]
        [StringLength(100)]
        public string LinkFile { get; set; }
        [Required]
        public int TaskId { get; set; }
    }
}
