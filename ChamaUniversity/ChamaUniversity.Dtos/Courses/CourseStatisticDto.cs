using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.Dtos.Courses
{
    public class CourseStatisticDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public decimal AverageAge { get; set; }
    }
}
