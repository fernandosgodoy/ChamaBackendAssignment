using ChamaUniversity.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.Entities
{
    public class Student
        : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
