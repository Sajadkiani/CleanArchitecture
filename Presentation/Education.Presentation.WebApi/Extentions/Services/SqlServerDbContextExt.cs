using System;
using Education.Infrastructure.Persistence.EF.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Education.Presentation.WebApi.Extentions.Services
{
    public static class SqlServerDbContextExt
    {
        public static void AddAppSqlServerDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContextPool<EducationDbContext>(options =>
            {
                var connectionString = Configuration["db:ConnectionString"];

                options.UseSqlServer(
                        connectionString,
                        sqlServerOptionsBuilder =>
                        {
                            sqlServerOptionsBuilder.CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                        });

                options.ConfigureWarnings(warnings =>
                {
                    warnings.Throw();
                });

            });
        }
    }
}
