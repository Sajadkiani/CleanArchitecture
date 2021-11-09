using AutoMapper;
using Education.Application.Features.Courses.Courses.Commands;
using Education.Application.Features.Courses.Courses.Queries;
using Education.Application.Models.DTOs.Courses;
using Education.Application.Models.VMs.Courses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Education.Presentation.WebApi.Controllers.Courses
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CourseController(
            IMediator mediator,
            IMapper mapper
            )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task AddCourseAsync(AddCourseVm vm)
        {
            var courseCmd = _mapper.Map<AddCourseCommand>(vm);
            await _mediator.Send(courseCmd);
        }

        [HttpGet("all")]
        public async Task<List<GetCoursesDto>> GetCoursesAsync()
        {
            return await _mediator.Send(new GetCoursesQuery());
        }

        [HttpPut("{courseId}")]
        public async Task GetCoursesAsync(int courseId,UpdateCourseVm vm)
        {
            var courseCmd = _mapper.Map<UpdateCourseCommand>(vm);
            courseCmd.Id = courseId;
            await _mediator.Send(courseCmd);
        }
    }
}
