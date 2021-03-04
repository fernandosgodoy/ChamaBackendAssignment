using ChamaUniversity.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.Infrastructure.Configuration
{
    public class ChamaUniversityContext
        : BaseContext
    {

        public DbSet<Course> Courses { get; set; }

        public ChamaUniversityContext(DbContextOptions<BaseContext> options) 
            : base(options)
        {
        }

    }
}
