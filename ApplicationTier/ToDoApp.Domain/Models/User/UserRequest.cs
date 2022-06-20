using ToDoApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDoApp.Domain.Models.User
{
    public class UserRequest : EntityBaseId<int>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Phone { get; set; }
        [Required]
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
    }
}
