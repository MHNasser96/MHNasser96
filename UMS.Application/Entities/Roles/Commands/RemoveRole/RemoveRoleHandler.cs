using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Roles.Commands.RemoveRole;

public class RemoveRoleHandler: IRequestHandler<RemoveRoleCommand,bool>
{
    private UmsContext _context;

    public RemoveRoleHandler(UmsContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Role role = _context.Roles.Where(obj => obj.Id == request.Id).First();
            _context.Remove(role);
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