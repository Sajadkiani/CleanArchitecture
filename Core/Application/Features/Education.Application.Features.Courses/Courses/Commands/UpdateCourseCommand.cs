using AutoMapper;
using Education.Application.IStores.Courses;
using Education.Domain.Entities.Courses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.Features.Courses.Courses.Commands
{
    public class UpdateCourseCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICourseStore _courseStore;

        public UpdateCourseCommandHandler(
            ICourseStore courseStore,
            IMapper mapper
            )
        {
            _mapper = mapper;
            _courseStore = courseStore;
        }
        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course= _mapper.Map<Course>(request);
            _courseStore.UpdateCourse(course);
            await _courseStore.SaveChangeAsync();
           return Unit.Value;
        }
    }

}
