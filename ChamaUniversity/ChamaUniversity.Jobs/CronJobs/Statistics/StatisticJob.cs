using ChamaUniversity.Application.Statistics;
using ChamaUniversity.Data.Configuration;
using ChamaUniversity.Util.Jobs;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChamaUniversity.Jobs.CronJobs.Statistics
{
    public class StatisticJob
        : CronJobService
    {

        private readonly ILogger<StatisticJob> _logger;

        public StatisticJob(IScheduleConfig<StatisticJob> config, ILogger<StatisticJob> logger)
            : base(config.CronExpression, config.TimeZoneInfo, config.UnitOfWork)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Statistic Job Started.");
            return base.StartAsync(cancellationToken);
        }

        [DisableConcurrentExecution(1)]
        public async override Task DoWork(CancellationToken cancellationToken,
            StatisticsBusiness statisticsBusiness)
        {
            _logger.LogInformation($"{DateTime.Now:hh:mm:ss} Statistic Job Working.");
            await statisticsBusiness.UpdateAsync(cancellationToken);
            await Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Statistic Job Stoped.");
            return base.StopAsync(cancellationToken);
        }

        //public async Task UpdateAsync(CancellationToken cancellationToken)
        //{
        //    var allCourses = await this._dbContext.Courses
        //        .ToArrayAsync();

        //    foreach (var course in allCourses)
        //    {
        //        this._dbContext.StudentsCourses
        //            .Join(_dbContext.Students,
        //                statistics => statistics.StudentId,
        //                student => student.Id,
        //                (statistic, student) => new { Statistic = statistic, Student = student })
        //            .Where(sc => sc.Statistic.CourseId == course.Id)
        //            .GroupBy(st => st.Student.Email)
        //            .Select((a, b) => new { a = a.Key, b = b });


        //        if (await this._dbContext.CourseStatistics
        //            .AnyAsync(sc => sc.CourseId == course.Id))  //The course average was created.
        //        {

        //        }
        //        else
        //        {

        //        }
        //    }

        //    //var newStudentCourse = new StudentCourse()
        //    //{
        //    //    CourseId = signupCourseParameter.CourseId,
        //    //    StudentId = signupCourseParameter.Student.Id
        //    //};
        //    //this.dbContext.StudentsCourses.Add(newStudentCourse);
        //    //await this.dbContext.SaveChangesAsync();

        //    await Task.CompletedTask;
        //}

    }
}
