using AutoMapper;
using MediatR;
using UMS.Application.DTOs;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Users.Commands.AddUser;

public class AddUserHandler:IRequestHandler<AddUserCommand,UserDTO>
{
    private readonly UmsContext _context;
    private readonly IMapper _mapper;

    public AddUserHandler(UmsContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserDTO> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        User user = new User()
        {
            Name = request.Name,
            Email = request.Email,
            RoleId = request.RoleId,
            KeycloakId = request.KeycloakId
        };
        try
        {
            _context.Add(user);
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return _mapper.Map<UserDTO>(user);
    }
}