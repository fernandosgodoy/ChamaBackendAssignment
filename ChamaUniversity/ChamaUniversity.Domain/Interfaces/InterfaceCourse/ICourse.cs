using ChamaUniversity.Dtos.Courses;
using ChamaUniversity.Entities;
using Domain.Interfaces.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.InterfaceCourse
{
    public interface ICourse
        : IGenericCrud<Course>
    {
    }
}
