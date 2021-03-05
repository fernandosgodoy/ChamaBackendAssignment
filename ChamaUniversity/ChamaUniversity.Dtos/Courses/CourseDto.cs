using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.Dtos.Courses
{
    public class CourseDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int NumberOfStudents { get; set; }

    }
}
