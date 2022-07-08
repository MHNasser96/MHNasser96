using AutoMapper;
using MediatR;
using UMS.Application.DTOs;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Users.Commands.RemoveUser;

public class RemoveUserHandler:IRequestHandler<RemoveUserCommand,bool>
{
    private readonly UmsContext _context;
    private readonly IMapper _mapper;

    public RemoveUserHandler(UmsContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<bool> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            User user = _context.Users.Where(obj => obj.Id == request.Id).First();
            _context.Remove(user);
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