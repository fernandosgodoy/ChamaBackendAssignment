using ChamaUniversity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.Data.Configuration
{
    public class BaseContext
        : DbContext
    {

        public BaseContext() { }

        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }


    }
}
