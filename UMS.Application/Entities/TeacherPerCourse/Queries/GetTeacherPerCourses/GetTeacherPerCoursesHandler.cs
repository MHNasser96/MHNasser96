using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.TeacherPerCourse.Queries.GetTeacherPerCourses;

public class GetTeacherPerCoursesHandler:IRequestHandler<GetTeacherPerCoursesQuery,List<Domain.Models.TeacherPerCourse>>
{

    private readonly UmsContext _context;

    public GetTeacherPerCoursesHandler(UmsContext context)
    {
        _context = context;
    }

    public async Task<List<Domain.Models.TeacherPerCourse>> Handle(GetTeacherPerCoursesQuery request, CancellationToken cancellationToken)
    {
        return _context.TeacherPerCourses.ToList();
    }
}