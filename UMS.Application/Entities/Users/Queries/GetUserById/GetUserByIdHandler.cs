using AutoMapper;
using MediatR;
using UMS.Application.DTOs;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Users.Queries.GetUserById;

public class GetUserByIdHandler:IRequestHandler<GetUserByIdQuery,UserDTO>
{

    private readonly UmsContext _context;
    private readonly IMapper _mapper;

    public GetUserByIdHandler(UmsContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User user = _context.Users.Where(obj => obj.Id == request.Id).First();
        return _mapper.Map<UserDTO>(user);
    }
}