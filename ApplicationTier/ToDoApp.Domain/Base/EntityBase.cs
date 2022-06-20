using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Put into the same namespace of Entities to skip using its reference namespace on inherit
namespace ToDoApp.Domain.Base
{
    public interface IEntityBase<TKey> : IEntityBaseId<TKey>, IEntityBaseDelete, IEntityBaseDate
    {
    }
    public abstract class EntityBase<TKey>: IEntityBase<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DefaultValue("0")]
        public virtual TKey Id { get; set; }
        [DefaultValue("false")]
        public bool IsDelete { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateAt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DeleteAt { get; set; }
    }
}