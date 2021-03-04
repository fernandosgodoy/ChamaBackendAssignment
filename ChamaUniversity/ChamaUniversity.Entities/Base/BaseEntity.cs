using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChamaUniversity.Entities.Base
{
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            this.CreatedAt = DateTime.Now;
        }
        
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
