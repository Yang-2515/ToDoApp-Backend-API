using ToDoApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoApp.Domain.Models.BoardMember
{
    public class BoardMemberRequest : EntityBaseId<int>
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int BoardId { get; set; }
    }
}
