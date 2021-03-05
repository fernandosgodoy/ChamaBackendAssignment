using ChamaUniversity.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChamaUniversity.UnitofWork.MethodExtensions
{
    public static class UnitOfWorkServiceExtensions
    {

        public static void RegisterTheUnityOfWork(this IServiceCollection services,
            ChamaUniversityContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));

            services.AddScoped<IUnitOfWork, UnitOfWork>(uow => new UnitOfWork(dbContext));

        }
    }
}
