using Education.Domain.Entities.Courses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SankaPlus.Infrastructure.EF.EntityConfigurations;

namespace Education.Infrastructure.Persistence.EF.EntityConfigurations.Courses
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses", schema: SchemaNames.Course).HasKey(item => item.Id);
            builder.Property(item => item.Name).IsRequired().HasMaxLength(200);
        }
    }
}
