using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.TeacherPerCourse.Queries.GetTeacherPerCourses;

public class GetTeacherPerCoursesQuery : IRequest<List<Domain.Models.TeacherPerCourse>>
{
    
}