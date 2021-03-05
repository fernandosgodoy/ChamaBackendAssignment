using ChamaUniversity.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChamaUniversity.Entities
{
    public class CourseStatistic
        : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Required]
        public int MinimumAge { get; set; }

        [Required]
        public int MaximumAge { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal AverageAge { get; set; }

    }
}
