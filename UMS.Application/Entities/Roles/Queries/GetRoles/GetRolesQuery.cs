using MediatR;
using UMS.Application.DTOs;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Roles.Queries.GetRoles;

public class GetRolesQuery : IRequest<List<Role>>
{
    
}