using ChamaUniversity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configuration
{
    public class BaseContext
        : DbContext
    {

        public DbSet<Course> Courses { get; set; }


        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetConnectionStringConfig());
            base.OnConfiguring(optionsBuilder);
        }

        private string GetConnectionStringConfig()
        {
            return "";
        }

    }
}
