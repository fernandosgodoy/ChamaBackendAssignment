using ChamaUniversity.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.Application
{
    public class BaseBusiness
    {
        protected readonly ChamaUniversityContext dbContext;

        public BaseBusiness(ChamaUniversityContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
