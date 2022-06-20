using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoApp.Domain.Base;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToDoApp.Domain.Entities
{
    [Table("Label")]
    public partial class Label: EntityBase<int>
    {
        public Label()
        {
            TaskLabels = new HashSet<TaskLabel>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Color { get; set; }

        [InverseProperty(nameof(TaskLabel.Label))]
        public virtual ICollection<TaskLabel> TaskLabels { get; set; }
    }
}
