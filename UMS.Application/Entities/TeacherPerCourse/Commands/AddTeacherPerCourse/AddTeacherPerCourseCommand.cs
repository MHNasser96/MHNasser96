using MediatR;

namespace UMS.Application.Entities.TeacherPerCourse.Commands.AddTeacherPerCourse;

public class AddTeacherPerCourseCommand:IRequest<Domain.Models.TeacherPerCourse>
{
    public long TeacherId { get; set; }
    public long CourseId { get; set; }
    
}