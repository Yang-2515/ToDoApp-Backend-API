using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoApp.Domain.Base;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToDoApp.Domain.Entities
{
    [Table("Board")]
    public partial class Board: EntityBase<int>
    {
        public Board()
        {
            BoardMembers = new HashSet<BoardMember>();
            ListTasks = new HashSet<ListTask>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [StringLength(100)]
        public string LinkImage { get; set; }
        public int ManageId { get; set; }

        [ForeignKey(nameof(ManageId))]
        [InverseProperty(nameof(User.Boards))]
        public virtual User Manage { get; set; }

        [InverseProperty(nameof(BoardMember.Board))]
        public virtual ICollection<BoardMember> BoardMembers { get; set; }
        [InverseProperty(nameof(ListTask.Board))]
        public virtual ICollection<ListTask> ListTasks { get; set; }
    }
}
