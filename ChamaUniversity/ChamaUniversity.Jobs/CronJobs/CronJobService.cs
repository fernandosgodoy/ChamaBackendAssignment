using ChamaUniversity.Application;
using ChamaUniversity.Application.Statistics;
using ChamaUniversity.Data.Configuration;
using ChamaUniversity.UnitofWork;
using Cronos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChamaUniversity.Jobs.CronJobs
{
    public class CronJobService 
        : IHostedService, IDisposable
    {
        
        private System.Timers.Timer _timer;
        private readonly CronExpression _expression;
        private readonly TimeZoneInfo _timeZoneInfo;
        private readonly IUnitOfWork _unitOfWork;

        protected CronJobService(string cronExpression, 
            TimeZoneInfo timeZoneInfo,
            IUnitOfWork unitOfWork)
        {
            _expression = CronExpression.Parse(cronExpression);
            _timeZoneInfo = timeZoneInfo;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task StartAsync(CancellationToken cancellationToken)
        {
            await ScheduleJob(cancellationToken);
        }

        protected virtual async Task ScheduleJob(CancellationToken cancellationToken)
        {
            var next = _expression.GetNextOccurrence(DateTimeOffset.Now, _timeZoneInfo);
            if (next.HasValue)
            {
                var delay = next.Value - DateTimeOffset.Now;
                if (delay.TotalMilliseconds <= 0)   
                    await ScheduleJob(cancellationToken);
                
                _timer = new System.Timers.Timer(delay.TotalMilliseconds);
                _timer.Elapsed += async (sender, args) =>
                {
                    _timer.Dispose();  // reset and dispose timer
                    _timer = null;

                    if (!cancellationToken.IsCancellationRequested)
                        await DoWork(cancellationToken, new StatisticsBusiness(_unitOfWork));

                    if (!cancellationToken.IsCancellationRequested)
                        await ScheduleJob(cancellationToken);    // reschedule next
                };
                _timer.Start();
            }
            await Task.CompletedTask;
        }

        public virtual async Task DoWork(CancellationToken cancellationToken,
            StatisticsBusiness business)
        {
            await Task.Delay(5000, cancellationToken);  // do the work
        }

        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Stop();
            await Task.CompletedTask;
        }

        public virtual void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
