using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Courses.Queries.GetCourses;

public class GetCoursesQuery:IRequest<List<Course>>
{
    
}