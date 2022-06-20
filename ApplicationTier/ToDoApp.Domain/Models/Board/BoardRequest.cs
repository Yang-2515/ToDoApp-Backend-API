using ToDoApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoApp.Domain.Models.Board
{
    public class BoardRequest : EntityBaseId<int>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [StringLength(100)]
        public string LinkImage { get; set; }
        [Required]
        public int ManageId { get; set; }
    }
}
