using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Goober.EntityFramework.PostgreSql
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterPostgreSqlDbContext<TContextService, TContextImplementation>(
            this IServiceCollection services,
            Func<string> GetConnectionString)
                where TContextService : class
                where TContextImplementation : DbContext, TContextService
        {
            services.AddDbContext<TContextImplementation>(options =>
            {
                options.UseNpgsql(GetConnectionString());
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddScoped<TContextService, TContextImplementation>();
        }
    }
}
