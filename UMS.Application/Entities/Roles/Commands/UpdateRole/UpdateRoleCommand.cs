using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Roles.Commands.UpdateRole;

public class UpdateRoleCommand:IRequest<Role>
{
    public long Id { get; set; }
    public string Name { get; set; }
}