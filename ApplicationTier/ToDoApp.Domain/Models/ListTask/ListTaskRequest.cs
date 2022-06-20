using ToDoApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDoApp.Domain.Models.ListTask
{
    public class ListTaskRequest : EntityBaseId<int>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FromDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ToDate { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        [Required]
        public int? BoardId { get; set; }
    }
}
