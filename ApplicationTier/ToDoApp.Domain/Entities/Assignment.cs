using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Base;

#nullable disable

namespace ToDoApp.Domain.Entities
{
    [Table("Assignment")]
    public partial class Assignment: EntityBase<int>
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        [InverseProperty("Assignments")]
        public virtual Task Task { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Assignments")]
        public virtual User User { get; set; }
    }
}
