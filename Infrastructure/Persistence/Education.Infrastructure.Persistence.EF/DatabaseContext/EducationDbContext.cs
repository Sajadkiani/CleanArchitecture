using Education.Domain.Entities.Courses;
using Education.Infrastructure.Persistence.EF.EntityConfigurations.Courses;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Education.Infrastructure.Persistence.EF.DatabaseContext
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly assemblyWithConfigurations = new CourseConfiguration().GetType().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Course> Courses { get; set; }
    }
}
