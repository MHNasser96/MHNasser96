using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UMS.Domain.Models;

namespace UMS.Application.Entities.Auth.Queries.Login;

public class LoginHandler:IRequestHandler<LoginQuery,User>
{
    private readonly UmsContext _context;
    private readonly IConfiguration _configuration;

    public LoginHandler(UmsContext context,IConfiguration configuration)
    {
        _configuration = configuration;
        _context = context;
    }
    public async Task<User> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        User user = _context.Users.Where(obj => obj.Name == request.Name && obj.KeycloakId == request.KeycloakId)
            .First();
        
        /*List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);*/
        
        return user;
    }
    
}