using AutoMapper;
using MediatR;
using UMS.Application.DTOs;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Roles.Commands.AddRole;

public class AddRoleHandler : IRequestHandler<AddRoleCommand,RoleDTO>
{
    private readonly UmsContext _context;
    private readonly IMapper _mapper;

    public AddRoleHandler(UmsContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RoleDTO> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        Role role = new Role()
        {
            Name = request.Name
        };
        try
        { 
            _context.Add(role);
           _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return _mapper.Map<RoleDTO>(role);
    }
}