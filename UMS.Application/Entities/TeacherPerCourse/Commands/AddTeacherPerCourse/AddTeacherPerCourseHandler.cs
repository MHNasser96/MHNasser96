using System.Data.Entity;
using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.TeacherPerCourse.Commands.AddTeacherPerCourse;

public class AddTeacherPerCourseHandler : IRequestHandler<AddTeacherPerCourseCommand, Domain.Models.TeacherPerCourse>
{
    private readonly UmsContext _context;

    public AddTeacherPerCourseHandler(UmsContext context)
    {
        _context = context;
    }

    public async Task<Domain.Models.TeacherPerCourse> Handle(AddTeacherPerCourseCommand request,
        CancellationToken cancellationToken)
    {
        Role role = await _context.Roles.FirstOrDefaultAsync(obj => obj.Name == "Teacher", cancellationToken);
        User user = await _context.Users.FirstOrDefaultAsync(obj => obj.Id == request.TeacherId, cancellationToken);

        Domain.Models.TeacherPerCourse teacherPerCourse = new Domain.Models.TeacherPerCourse()
        {
            TeacherId = request.TeacherId,
            CourseId = request.CourseId
        };
        if (role.Id == user.RoleId)

        {
            _context.TeacherPerCourses.Add(teacherPerCourse);
            _context.SaveChanges();
            return teacherPerCourse;
        }

        return null;
    }
}