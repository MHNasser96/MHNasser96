using AutoMapper;
using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Roles.Queries.GetRoles;

public class GetRolesHandler : IRequestHandler<GetRolesQuery,List<Role>>
{
    private UmsContext _context;
    private readonly IMapper _mapper;

    public GetRolesHandler(UmsContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Role>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        return _context.Roles.ToList();
    }
}