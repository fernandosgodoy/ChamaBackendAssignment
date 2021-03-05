using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChamaUniversity.Entities
{
    public class StudentCourse
    {

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

    }
}
