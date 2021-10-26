using System;
using System.ComponentModel.DataAnnotations;

namespace EduApp.Core.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
