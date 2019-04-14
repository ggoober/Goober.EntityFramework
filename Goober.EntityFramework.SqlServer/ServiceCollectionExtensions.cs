using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Goober.EntityFramework.SqlServer
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDbContext<TContextService, TContextImplementation>(
            this IServiceCollection services,
            Func<string> GetConnectionString,
            ServiceLifetime serviceLifetime = ServiceLifetime.Scoped,
            ILoggerFactory loggerFactory = null)
                where TContextService : class
                where TContextImplementation : DbContext, TContextService
        {
            services.AddDbContext<TContextImplementation>(options =>
            {
                if (loggerFactory != null) { options.UseLoggerFactory(loggerFactory); }

                options.UseSqlServer(GetConnectionString());
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddScoped<TContextService, TContextImplementation>();
        }
    }
}
