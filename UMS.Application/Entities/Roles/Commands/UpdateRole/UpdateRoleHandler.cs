using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Roles.Commands.UpdateRole;

public class UpdateRoleHandler:IRequestHandler<UpdateRoleCommand,Role>
{
    private readonly UmsContext _context;

    public UpdateRoleHandler(UmsContext context)
    {
        _context = context;
    }

    public async Task<Role> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        Role role = _context.Roles.Where(obj => obj.Id == request.Id).First();
        role.Name = request.Name;
        _context.Roles.Update(role);
        _context.SaveChanges();
        return role;
    }
}