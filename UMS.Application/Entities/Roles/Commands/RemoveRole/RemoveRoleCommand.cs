using MediatR;
using UMS.Application.DTOs;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Roles.Commands.RemoveRole;

public class RemoveRoleCommand:IRequest<bool>
{
    public long Id { get; set; }
}