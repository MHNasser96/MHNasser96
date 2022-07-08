using MediatR;
using UMS.Application.DTOs;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Roles.Commands.AddRole;

public class AddRoleCommand:IRequest<RoleDTO>
{
    public string Name{ get; set; }
}