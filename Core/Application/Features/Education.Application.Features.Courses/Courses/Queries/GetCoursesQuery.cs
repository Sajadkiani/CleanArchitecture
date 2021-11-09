using AutoMapper;
using Education.Application.IStores.Courses;
using Education.Application.Models.DTOs.Courses;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.Features.Courses.Courses.Queries
{
    public class GetCoursesQuery : IRequest<List<GetCoursesDto>>
    {
    }

    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery,List<GetCoursesDto>>
    {
        private readonly ICourseStore _courseStore;
        private readonly IMapper _mapper;

        public GetCoursesQueryHandler(
            ICourseStore courseStore,
            IMapper mapper
            )
        {
            _courseStore = courseStore;
            _mapper = mapper;
        }

        public async Task<List<GetCoursesDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseStore.GetCoursesAsync();
            if (courses.Any() == false) return new List<GetCoursesDto>();

            var coursesDtos = _mapper.Map<List<GetCoursesDto>>(courses);
            return coursesDtos;
        }
    }
}
