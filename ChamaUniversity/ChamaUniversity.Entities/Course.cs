using ChamaUniversity.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.Entities
{
    public class Course
        : BaseEntity
    {

        public int Capacity { get; set; }
        public int NumberOfStudents { get; set; }

    }
}
