using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoApp.Domain.Base;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToDoApp.Domain.Entities
{
    [Table("User")]
    public partial class User: EntityBase<int>
    {
        public User()
        {
            Assignments = new HashSet<Assignment>();
            BoardMembers = new HashSet<BoardMember>();
            Boards = new HashSet<Board>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        [Column("Email Address")]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [Column("Home Address")]
        [StringLength(50)]
        public string HomeAddress { get; set; }
        public int? Age { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(100)]
        public string LinkImage { get; set; }

        [InverseProperty(nameof(Assignment.User))]
        public virtual ICollection<Assignment> Assignments { get; set; }
        [InverseProperty(nameof(BoardMember.User))]
        public virtual ICollection<BoardMember> BoardMembers { get; set; }
        [InverseProperty(nameof(Board.Manage))]
        public virtual ICollection<Board> Boards { get; set; }
    }
}
