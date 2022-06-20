using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoApp.Domain.Base;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToDoApp.Domain.Entities
{
    [Table("Task")]
    public partial class Task: EntityBase<int>
    {
        public Task()
        {
            Assignments = new HashSet<Assignment>();
            Attackments = new HashSet<Attackment>();
            TaskLabels = new HashSet<TaskLabel>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }
        public int ListTaskId { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey(nameof(ListTaskId))]
        [InverseProperty("Tasks")]
        public virtual ListTask ListTask { get; set; }
        [InverseProperty(nameof(Assignment.Task))]
        public virtual ICollection<Assignment> Assignments { get; set; }
        [InverseProperty(nameof(Attackment.Task))]
        public virtual ICollection<Attackment> Attackments { get; set; }
        [InverseProperty(nameof(TaskLabel.Task))]
        public virtual ICollection<TaskLabel> TaskLabels { get; set; }
    }
}
