using Education.Application.Features.Courses.Courses.Commands;
using Education.Application.Mapping.Courses;
using Education.Presentation.WebApi.Extentions.Services;
using Education.Presentation.WebApi.Extentions.Uses;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Education.Presentation.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(environment.ContentRootPath, "Settings"))
            .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAppSqlServerDbContext(Configuration);
            services.AddMediatR(typeof(AddCourseCommand));
            services.AddControllers();
            services.AddEducationServices();
            services.AddSwagger();
            services.AddAutoMapper(typeof(CourseProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseAppSwagger();
        }
    }
}
