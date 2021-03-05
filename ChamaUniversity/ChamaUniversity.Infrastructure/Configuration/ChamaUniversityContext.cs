using ChamaUniversity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.Data.Configuration
{
    public class ChamaUniversityContext
        : BaseContext
    {

        private readonly IServiceProvider serviceProvider;

        public ChamaUniversityContext(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ChamaUniversityContext(DbContextOptions<BaseContext> options, 
            IServiceProvider serviceProvider)
            : base(options)
        {
            this.serviceProvider = serviceProvider;
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }

        //public ChamaUniversityContext(DbContextOptions<BaseContext> options) 
        //    : base(options)
        //{
        //}
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
        }

    }
}
