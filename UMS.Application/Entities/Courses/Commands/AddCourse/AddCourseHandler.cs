using MediatR;
using NpgsqlTypes;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Courses.Commands.AddCourse;

public class AddCourseHandler:IRequestHandler<AddCourseCommand,Course>
{
    private readonly UmsContext _context;

    public AddCourseHandler(UmsContext context)
    {
        _context = context;
    }

    public async Task<Course> Handle(AddCourseCommand request, CancellationToken cancellationToken)
    {
        Course course = new Course()
        {
            Name = request.Name,
            MaxStudentsNumber = request.MaxStudentsNumber,
            EnrolmentDateRange = new NpgsqlRange<DateOnly>(
                new DateOnly(request.EnrolmentStart.Year,request.EnrolmentStart.Month,request.EnrolmentStart.Day),
                new DateOnly(request.EnrolmentEnd.Year,request.EnrolmentEnd.Month,request.EnrolmentEnd.Day))
        };
        try
        { 
            _context.Courses.Add(course);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return course;
    }
}