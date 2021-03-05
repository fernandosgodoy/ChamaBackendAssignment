﻿using ChamaUniversity.Data.Configuration;
using ChamaUniversity.Dtos.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChamaUniversity.Application.Statistics
{
    public class StatisticsBusiness
        : BaseBusiness
    {
        public StatisticsBusiness(ChamaUniversityContext dbContext)
            : base(dbContext)
        {
        }

        public async Task UpdateAsync(CancellationToken cancellationToken)
        {
            var allCourses = await this.dbContext.Courses
                .ToArrayAsync();

            foreach (var course in allCourses)
            {
                this.dbContext.StudentsCourses
                    .Join(dbContext.Students,
                        statistics => statistics.StudentId,
                        student => student.Id,
                        (statistic, student) => new { Statistic = statistic, Student = student })
                    .Where(sc => sc.Statistic.CourseId == course.Id)
                    .GroupBy(st => st.Student.Email)
                    .Select((a, b) => new { a = a.Key, b = b });


                if (await this.dbContext.CourseStatistics
                    .AnyAsync(sc => sc.CourseId == course.Id))  //The course average was created.
                {

                }
                else
                {

                }
            }

            //var newStudentCourse = new StudentCourse()
            //{
            //    CourseId = signupCourseParameter.CourseId,
            //    StudentId = signupCourseParameter.Student.Id
            //};
            //this.dbContext.StudentsCourses.Add(newStudentCourse);
            //await this.dbContext.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
