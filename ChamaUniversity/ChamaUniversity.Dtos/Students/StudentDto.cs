using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.Dtos.Students
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
