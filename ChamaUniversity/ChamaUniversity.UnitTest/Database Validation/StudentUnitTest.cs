using ChamaUniversity.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChamaUniversity.UnitTest.Database_Validation
{

    public class StudentUnitTest
    {

        private readonly BaseDbContextFixture _dbContext;

        public StudentUnitTest(BaseDbContextFixture dbContext)
        {
            this._dbContext = dbContext;
        }
        
    }
    
}
