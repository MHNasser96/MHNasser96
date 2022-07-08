using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Courses.Commands.UpdateCourse;

public class UpdateCourseCommand:IRequest<Course>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int MaxStudentsNumber { get; set; }
    
    public DateTime EnrolmentStart { get; set; } 
    public DateTime EnrolmentEnd { get; set; } 
}