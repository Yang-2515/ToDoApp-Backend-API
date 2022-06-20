using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ToDoApp.Domain.Base
{
    public interface IEntityBaseId<TKey>
    {
        TKey Id { get; set; }
    }
    public abstract class EntityBaseId<TKey> : IEntityBaseId<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TKey Id { get; set; }
    }
}
