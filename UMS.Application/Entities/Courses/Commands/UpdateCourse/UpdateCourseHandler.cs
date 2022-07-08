using MediatR;
using NpgsqlTypes;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Courses.Commands.UpdateCourse;

public class UpdateCourseHandler:IRequestHandler<UpdateCourseCommand,Course>
{

    private readonly UmsContext _context;

    public UpdateCourseHandler(UmsContext context)
    {
        _context = context;
    }

    public async Task<Course> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        Course course = _context.Courses.Where(obj => obj.Id == request.Id).First();
        course.Name = request.Name;
        course.MaxStudentsNumber = request.MaxStudentsNumber;
        course.EnrolmentDateRange = new NpgsqlRange<DateOnly>(
            new DateOnly(request.EnrolmentStart.Year, request.EnrolmentStart.Month, request.EnrolmentStart.Day),
            new DateOnly(request.EnrolmentEnd.Year, request.EnrolmentEnd.Month, request.EnrolmentEnd.Day));
        _context.Courses.Update(course);
        _context.SaveChanges();
        return course;
    }
}