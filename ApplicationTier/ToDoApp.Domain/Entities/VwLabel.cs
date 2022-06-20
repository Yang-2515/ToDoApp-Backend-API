using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoApp.Domain.Base;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToDoApp.Domain.Entities
{
    [Keyless]
    public partial class VwLabel: EntityBase<int>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
    }
}
