using ChamaUniversity.Data.Configuration;
using ChamaUniversity.Jobs.CronJobs;
using ChamaUniversity.Jobs.CronJobs.Statistics;
using ChamaUniversity.UnitofWork.MethodExtensions;
using ChamaUniversity.Util.Application;
using ChamaUniversity.Util.Data;
using ChamaUniversity.Util.Jobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamaUniversity.Jobs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ChamaUniversityContext>(this.Configuration, "DefaultConnection");
            //services.AddDbContextPool<ChamaUniversityContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DbContext, ChamaUniversityContext>();

            services.AddDbContext<DbContext>(option =>
                option.UseSqlServer(
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ChamaUniversity;Persist Security Info=True;"
                    ));

            services.AddControllers();

            services.AddBusiness(this.Configuration);

            RegisterTheUnitOfWork(services);

            services.AddCronJob<StatisticJob>(c =>
            {
                c.TimeZoneInfo = TimeZoneInfo.Local;
                c.CronExpression = @"*/1 * * * *";      // ==> You can define your schedule time.
                //I defined 1 minute for tests.
            });
        }

        private void RegisterTheUnitOfWork(IServiceCollection services)
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            ChamaUniversityContext appDbContext = serviceProvider.GetService<ChamaUniversityContext>();
            services.RegisterTheUnityOfWork(appDbContext);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ServiceLocator.Instance = app.ApplicationServices;
        }
    }
}
