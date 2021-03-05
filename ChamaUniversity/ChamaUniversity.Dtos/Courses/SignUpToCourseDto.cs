using ChamaUniversity.Dtos.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.Dtos.Courses
{
    public class SignUpToCourseDto
    {

        public int CourseId { get; set; }
        public StudentDto Student { get; set; }

    }
}
