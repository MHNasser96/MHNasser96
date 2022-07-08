using MediatR;
using UMS.Application.DTOs;

namespace UMS.Application.Entities.Users.Commands.RemoveUser;

public class RemoveUserCommand:IRequest<bool>
{
    public long Id { get; set; }
}