using ChamaUniversity.Dtos.Courses;
using ChamaUniversity.Dtos.Messages;
using ChamaUniversity.Entities;
using ChamaUniversity.Infrastructure.Configuration;
using ChamaUniversity.Util.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ResultDto> SignUpStudentAsync(SignUpToCourseDto signupCourseParameter)
        {
            var result = new ResultDto();

            await EnsureIsValidAsync(signupCourseParameter);
            await EnsureTheBusinessRulesAsync(signupCourseParameter);

            var newStudentCourse = new StudentCourse()
            {
                CourseId = signupCourseParameter.CourseId,
                StudentId = signupCourseParameter.Student.Id
            };
            this.dbContext.StudentsCourses.Add(newStudentCourse);
            await this.dbContext.SaveChangesAsync();

            //Update the course info.
            var courseInfo = await this.dbContext.Courses
                .Where(c => c.Id == signupCourseParameter.CourseId)
                .FirstOrDefaultAsync();

            courseInfo.NumberOfStudents += 1;
            await this.dbContext.SaveChangesAsync();
            result.Success = true;

            return result;
        }

        private async Task EnsureIsValidAsync(SignUpToCourseDto signupCourseParameter)
        {
            var ex = new BusinessException();

            if (signupCourseParameter.Student == null)
                ex.AddError("Student not informed.");
            else
            {
                var student = await this.dbContext.Students
                    .Where(s => s.Email == signupCourseParameter.Student.Email)
                    .SingleOrDefaultAsync();

                if (student == null)
                    ex.AddError("There's no student with this email.");

                signupCourseParameter.Student.Id = student.Id;

                var course = await this.dbContext.Courses
                    .Where(c => c.Id == signupCourseParameter.CourseId)
                    .SingleOrDefaultAsync();

                if (course == null)
                    ex.AddError("The course doesn't exists.");
            }

            ex.ThrowIfHasErrors();
        }

        private async Task EnsureTheBusinessRulesAsync(SignUpToCourseDto signupCourseParameter)
        {
            var ex = new BusinessException();

            var courseInfo = await dbContext.Courses
                .Where(c => c.Id == signupCourseParameter.CourseId)
                .Select(c => new CourseDto()
                {
                    Capacity = c.Capacity,
                    NumberOfStudents = c.NumberOfStudents
                })
                .SingleOrDefaultAsync();

            

            if (courseInfo == null)
                ex.AddError("Course not found.");
            else if (courseInfo.Capacity == courseInfo.NumberOfStudents)
                ex.AddError("Hey buddy, the course is full, go home!!");

            ex.ThrowIfHasErrors();
        }

    }
}
