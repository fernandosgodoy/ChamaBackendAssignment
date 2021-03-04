using ChamaUniversity.Entities;
using ChamaUniversity.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChamaUniversity.Application.Courses
{
    public class CourseBusiness
        : BaseBusiness
    {
        public CourseBusiness(ChamaUniversityContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
