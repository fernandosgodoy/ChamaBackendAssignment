using ChamaUniversity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChamaUniversity.Data.Configuration
{
    public class ChamaUniversityContext
        : DbContext
    {

        private readonly IServiceProvider serviceProvider;

        public ChamaUniversityContext(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ChamaUniversityContext(DbContextOptions<ChamaUniversityContext> options)
            : base(options)
        {
        }

        public ChamaUniversityContext(DbContextOptions<ChamaUniversityContext> options, 
            IServiceProvider serviceProvider)
            : base(options)
        {
            this.serviceProvider = serviceProvider;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //           .SetBasePath(Directory.GetCurrentDirectory())
        //           .AddJsonFile("appsettings.json")
        //           .Build();
        //        var connectionString = configuration.GetConnectionString("DefaultConnection");
        //        optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<CourseStatistic> CourseStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<CourseStatistic>()
                .HasOne(cs => cs.Course)
                .WithMany()
                .HasPrincipalKey(cs => cs.Id)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
