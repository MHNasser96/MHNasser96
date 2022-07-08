using MediatR;
using UMS.Application.DTOs;

namespace UMS.Application.Entities.Users.Queries.GetUsers;

public class GetUsersQuery:IRequest<List<UserDTO>>
{
    
}