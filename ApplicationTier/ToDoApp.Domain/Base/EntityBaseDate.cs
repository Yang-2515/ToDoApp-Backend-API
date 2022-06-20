using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDoApp.Domain.Base
{
    public interface IEntityBaseDate
    {
        public DateTime? CreateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
    public abstract class EntityBaseDate : IEntityBaseDate
    {
        [Column(TypeName = "datetime")]
        public DateTime? CreateAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeleteAt { get; set; }
    }
}
