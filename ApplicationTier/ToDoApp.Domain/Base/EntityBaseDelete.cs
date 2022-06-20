using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ToDoApp.Domain.Base
{
    public interface IEntityBaseDelete
    {
        public bool IsDelete { get; set; }
    }
    public abstract class EntityBaseDelete : IEntityBaseDelete
    {
        public bool IsDelete { get; set; }
    }
}
