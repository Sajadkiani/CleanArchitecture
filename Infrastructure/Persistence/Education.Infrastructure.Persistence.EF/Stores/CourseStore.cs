using Education.Application.IStores.Courses;
using Education.Domain.Entities.Courses;
using Education.Infrastructure.Persistence.EF.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Education.Infrastructure.Persistence.EF.Stores
{
    public class CourseStore : ICourseStore
    {
        private readonly EducationDbContext _context;

        public CourseStore(
            EducationDbContext context
            )
        {
            _context = context;
        }

        public Task AddCourseAsync(Course course)
        {
            return _context.Courses.AddAsync(course).AsTask();
        }

        public Task<List<Course>> GetCoursesAsync()
        {
            return _context.Courses.ToListAsync();
        }

        public Task SaveChangeAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
        }
    }
}
