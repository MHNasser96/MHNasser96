using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UMS.Application.Entities.Auth.Queries.Login;
using UMS.Application.Entities.Roles.Queries.GetRoleById;
using UMS.Domain.Models;

namespace UMS.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SignInController : Controller
{
    private readonly IMediator _mediator;
    public SignInController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("login")]
    public async Task<User> Login([Required]String username,[Required]String password)
    {
        var result = await _mediator.Send(new LoginQuery()
        {
            Name = username,
            KeycloakId = password,
        });
        return (result);
    }

}