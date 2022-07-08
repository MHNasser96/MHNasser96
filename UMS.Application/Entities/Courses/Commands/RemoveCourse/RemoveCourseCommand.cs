using MediatR;

namespace UMS.Application.Entities.Courses.Commands.RemoveCourse;

public class RemoveCourseCommand:IRequest<bool>
{
    public long Id { get; set; }
}