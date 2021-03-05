using ChamaUniversity.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChamaUniversity.Entities
{
    public class Lecturer
        : BaseEntity
    {

        [Required]
        public string Name { get; set; }

    }
}
