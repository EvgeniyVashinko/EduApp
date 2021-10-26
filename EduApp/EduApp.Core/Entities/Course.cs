using EduApp.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduApp.Core.Entities
{
    public class Course : BaseEntity
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        
        public DateTime CreationDate { get; set; }
        
        public DateTime UpdateDate { get; set; }

        [Column("AccountId")]
        public Guid OwnerId { get; set; }

        public Account Owner { get; set; }

        public ICollection<Account> Participants { get; set; }

        public ICollection<Rewiew> Rewiews { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
