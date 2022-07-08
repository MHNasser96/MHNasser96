using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Courses.Queries.GetCourses;

public class GetCoursesHandler:IRequestHandler<GetCoursesQuery,List<Course>>
{
    private readonly UmsContext _context;

    public GetCoursesHandler(UmsContext context)
    {
        _context = context;
    }

    public async Task<List<Course>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        return _context.Courses.ToList();
    }
}