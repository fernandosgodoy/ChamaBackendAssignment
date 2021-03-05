using ChamaUniversity.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChamaUniversity.Entities
{
    public class Course
        : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public int TotalStudents { get; set; } = 0;

        [Required]
        public int NumberOfStudents { get; set; } = 0;

    }
}
