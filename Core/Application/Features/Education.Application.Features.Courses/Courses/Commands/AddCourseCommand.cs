using AutoMapper;
using Education.Application.IStores.Courses;
using Education.Domain.Entities.Courses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Education.Application.Features.Courses.Courses.Commands
{
    public class AddCourseCommand: IRequest
    {
        public string Name { get; set; }
    }

    public class AddCourseCommandHandler : IRequestHandler<AddCourseCommand>
    {
        private readonly ICourseStore _courseStore;
        private readonly IMapper _mapper;

        public AddCourseCommandHandler(
            ICourseStore courseStore,
            IMapper mapper
            )
        {
            _courseStore = courseStore;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddCourseCommand request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request);
            await _courseStore.AddCourseAsync(course);
            await _courseStore.SaveChangeAsync();
            return Unit.Value;
        }
    }
}
