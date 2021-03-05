using ChamaUniversity.Application.Courses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChamaUniversity.UnitTest.Database_Validation
{
    public class CourseUnitTest
    {

        private readonly BaseDbContextFixture _dbContext;

        public CourseUnitTest(BaseDbContextFixture dbContext)
        {
            this._dbContext = dbContext;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetTheCourseIdWhenExists(long id)
        {
            using (var dbContext = this._dbContext.Create())
            {
                var courseBusiness = new CourseBusiness(dbContext);
                var expected = id;
                var actual = await courseBusiness.GetByIdAsync(expected);

                // Assert
                Assert.NotNull(actual);
                Assert.Equal(expected, actual.Id);
            }
        }

    }
}
