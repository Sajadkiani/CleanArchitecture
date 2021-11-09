using Education.Domain.Entities.Courses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Education.Application.IStores.Courses
{
    public interface ICourseStore
    {
        Task<List<Course>> GetCoursesAsync();
        Task AddCourseAsync(Course course);
        Task SaveChangeAsync();
        void UpdateCourse(Course course);
    }
}
