using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Courses.Queries.GetCourseById;

public class GetCourseByIdQuery:IRequest<Course>
{
    public long Id { get; set; }
}