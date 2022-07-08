using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Roles.Queries.GetRoleById;

public class GetRoleByIdQuery:IRequest<Role>
{
    public long Id { get; set; }
}