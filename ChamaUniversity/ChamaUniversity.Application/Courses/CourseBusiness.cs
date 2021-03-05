using ChamaUniversity.Data.Configuration;
using ChamaUniversity.Dtos.Courses;
using ChamaUniversity.Dtos.Messages;
using ChamaUniversity.Entities;
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
            var valid = await EnsureIsValidAsync(signupCourseParameter);
            var businessValidation = await EnsureTheBusinessRulesAsync(signupCourseParameter);

            if (valid.Success && businessValidation.Success)
            {
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
            }
            else
            {
                //The worker tries to sign up the student then notifies the student whether signing up succeeded or not
                result.Messages.AddRange(valid.Messages);
                result.Messages.AddRange(businessValidation.Messages);
            }

            return result;
        }

        public async Task<CourseDto> GetByIdAsync(long id)
        {
            return await this.dbContext.Courses
                .Where(fsf => fsf.Id == id)
                .Select(c => new CourseDto()
                {
                    Capacity = c.Capacity,
                    Id = c.Id,
                    NumberOfStudents = c.NumberOfStudents
                })
                .FirstOrDefaultAsync();
        }

        #region Private Methods

        private async Task<ResultDto> EnsureIsValidAsync(SignUpToCourseDto signupCourseParameter)
        {
            var result = new ResultDto();

            if (signupCourseParameter.Student == null)
                result.Messages.Add("Student not informed.");
            else
            {
                var student = await this.dbContext.Students
                    .Where(s => s.Email == signupCourseParameter.Student.Email)
                    .SingleOrDefaultAsync();

                if (student == null)
                    result.Messages.Add("There's no student with this email.");
                else
                {
                    signupCourseParameter.Student.Id = student.Id;

                    var course = await this.dbContext.Courses
                        .Where(c => c.Id == signupCourseParameter.CourseId)
                        .SingleOrDefaultAsync();

                    if (course == null)
                        result.Messages.Add("The course doesn't exists.");
                    else 
                        result.Success = true;
                }
            }

            return result;
        }

        private async Task<ResultDto> EnsureTheBusinessRulesAsync(SignUpToCourseDto signupCourseParameter)
        {
            var result = new ResultDto();

            var courseInfo = await dbContext.Courses
                .Where(c => c.Id == signupCourseParameter.CourseId)
                .Select(c => new CourseDto()
                {
                    Capacity = c.Capacity,
                    NumberOfStudents = c.NumberOfStudents
                })
                .SingleOrDefaultAsync();

            if (courseInfo == null)
                result.Messages.Add("Course not found.");
            else if (courseInfo.Capacity == courseInfo.NumberOfStudents)
                result.Messages.Add("Hey buddy, the course is full, go home!!");
            else
            {
                if (await dbContext.StudentsCourses.AnyAsync(sc => sc.StudentId == signupCourseParameter.Student.Id
                    && sc.CourseId == signupCourseParameter.CourseId))
                    result.Messages.Add("You can't signup for this course again");
                else
                    result.Success = true;
            }

            

            return result;
        }

        #endregion

    }
}
