using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Courses.Queries.GetCourseById;

public class GetCourseByIdHandler:IRequestHandler<GetCourseByIdQuery,Course>
{
    private readonly UmsContext _context;

    public GetCourseByIdHandler(UmsContext context)
    {
        _context = context;
    }

    public async Task<Course> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        Course course = _context.Courses.Where(obj => obj.Id == request.Id).First();
        return course;
    }
}