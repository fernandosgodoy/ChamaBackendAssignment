using ChamaUniversity.Application.Courses;
using ChamaUniversity.Application.Statistics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChamaUniversity.Util.Application
{
    public static class BusinessExtentions
    {

        public static IServiceCollection AddBusiness(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddScoped<CourseBusiness>();
            services.AddScoped<StatisticsBusiness>();

            return services;
        }
    }
}
