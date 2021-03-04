using ChamaUniversity.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.Entities
{
    public class CourseStatistic
        : BaseEntity
    {

        public string Name { get; set; }
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public decimal AverageAge { get; set; }

    }
}
