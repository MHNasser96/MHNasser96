using AutoMapper;
using MediatR;
using UMS.Application.DTOs;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Users.Queries.GetUsers;

public class GetUserHandler:IRequestHandler<GetUsersQuery,List<UserDTO>>
{
    private readonly UmsContext _context;
    private readonly IMapper _mapper;

    public GetUserHandler(UmsContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UserDTO>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<UserDTO>>(_context.Users.ToList());
    }
}