using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoApp.Domain.Base;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToDoApp.Domain.Entities
{
    [Table("ListTask")]
    public partial class ListTask: EntityBase<int>
    {
        public ListTask()
        {
            Tasks = new HashSet<Task>();
        }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FromDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ToDate { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        public int? BoardId { get; set; }

        [ForeignKey(nameof(BoardId))]
        [InverseProperty("ListTasks")]
        public virtual Board Board { get; set; }
        [InverseProperty(nameof(Task.ListTask))]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
