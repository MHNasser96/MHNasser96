using MediatR;
using UMS.Domain.Models;
namespace UMS.Application.Entities.Auth.Queries.Login;

public class LoginQuery: IRequest<User>
{
    public string Name { get; set; }
    public string KeycloakId { get; set; }
}