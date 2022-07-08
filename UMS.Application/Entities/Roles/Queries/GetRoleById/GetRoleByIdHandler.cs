using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Roles.Queries.GetRoleById;

public class GetRoleByIdHandler:IRequestHandler<GetRoleByIdQuery,Role>
{

    private readonly UmsContext _context;

    public GetRoleByIdHandler(UmsContext context)
    {
        _context = context;
    }

    public async Task<Role> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        Role role = _context.Roles.Where(obj => obj.Id == request.Id).First();
        return role;
    }
}