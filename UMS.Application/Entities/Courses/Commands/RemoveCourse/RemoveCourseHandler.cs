using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Courses.Commands.RemoveCourse;

public class RemoveCourseHandler:IRequestHandler<RemoveCourseCommand,bool>
{

    private readonly UmsContext _context;

    public RemoveCourseHandler(UmsContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(RemoveCourseCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Course course = _context.Courses.Where(obj => obj.Id == request.Id).First();
            _context.Remove(course);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}