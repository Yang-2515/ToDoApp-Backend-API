using ToDoApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoApp.Domain.Models.Attackment
{
    public class AttackmentResponse : EntityBaseId<int>
    {
        public string LinkFile { get; set; }
    }
}
