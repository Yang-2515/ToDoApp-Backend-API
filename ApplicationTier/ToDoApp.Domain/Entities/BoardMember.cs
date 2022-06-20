using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoApp.Domain.Base;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToDoApp.Domain.Entities
{
    [Table("BoardMember")]
    public partial class BoardMember: EntityBase<int>
    {
        public int UserId { get; set; }
        public int BoardId { get; set; }

        [ForeignKey(nameof(BoardId))]
        [InverseProperty("BoardMembers")]
        public virtual Board Board { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("BoardMembers")]
        public virtual User User { get; set; }
    }
}
