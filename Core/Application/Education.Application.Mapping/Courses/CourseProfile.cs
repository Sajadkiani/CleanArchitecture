using AutoMapper;
using Education.Application.Features.Courses.Courses.Commands;
using Education.Application.Models.DTOs.Courses;
using Education.Application.Models.VMs.Courses;
using Education.Domain.Entities.Courses;

namespace Education.Application.Mapping.Courses
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<AddCourseVm, AddCourseCommand>();
            CreateMap<Course, AddCourseCommand>().ReverseMap();
            CreateMap<Course, UpdateCourseCommand>().ReverseMap();
            CreateMap<GetCoursesDto, Course>().ReverseMap();
            CreateMap<UpdateCourseVm, UpdateCourseCommand>().ReverseMap();
        }
    }
}
