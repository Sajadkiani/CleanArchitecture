using Education.Application.IStores.Courses;
using Education.Infrastructure.Persistence.EF.Stores;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.Presentation.WebApi.Extentions.Services
{
    public static class ServiceCollectionExt
    {
        public static void AddEducationServices(this IServiceCollection services)
        {
            services.AddScoped<ICourseStore, CourseStore>();
        }
    }
}
