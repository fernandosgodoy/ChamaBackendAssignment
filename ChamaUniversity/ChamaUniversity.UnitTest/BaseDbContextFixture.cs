using ChamaUniversity.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.UnitTest
{
    public abstract class BaseDbContextFixture
    {
        protected DbContextOptions<ChamaUniversityContext> options;

        public BaseDbContextFixture(string databaseName)
        {
            this.options = new DbContextOptionsBuilder<ChamaUniversityContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;

            using (var dbContext = new ChamaUniversityContext(this.options, null))
            {
                this.Initialize(dbContext);
            }
        }

        protected abstract void Initialize(ChamaUniversityContext dbContext);

        public ChamaUniversityContext Create()
        {
            return new ChamaUniversityContext(this.options, null);
        }
    }
}
