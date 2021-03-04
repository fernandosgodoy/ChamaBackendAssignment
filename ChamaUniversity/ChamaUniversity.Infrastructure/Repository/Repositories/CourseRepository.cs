using ChamaUniversity.Dtos.Courses;
using ChamaUniversity.Entities;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceCourse;
using Infrastructure.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class CourseRepository
        : RepositoryGenerics<Course>, ICourse
    {
        
    }
}
