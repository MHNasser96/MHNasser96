using MediatR;
using UMS.Application.DTOs;

namespace UMS.Application.Entities.Users.Queries.GetUserById;

public class GetUserByIdQuery: IRequest<UserDTO>
{
    public long Id { get; set; }
}