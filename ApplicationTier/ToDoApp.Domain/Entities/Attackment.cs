using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoApp.Domain.Base;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToDoApp.Domain.Entities
{
    [Table("Attackment")]
    public partial class Attackment: EntityBase<int>
    {
        [Required]
        [StringLength(100)]
        public string LinkFile { get; set; }
        public int TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        [InverseProperty("Attackments")]
        public virtual Task Task { get; set; }
    }
}
