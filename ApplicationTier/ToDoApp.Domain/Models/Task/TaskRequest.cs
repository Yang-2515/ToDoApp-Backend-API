using ToDoApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDoApp.Domain.Models.Task
{
    public class TaskRequest : EntityBaseId<int>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }
        [Required]
        public int ListTaskId { get; set; }
        [Required]
        public int? ParentId { get; set; }
    }
}
