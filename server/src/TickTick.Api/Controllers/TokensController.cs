using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TickTick.Api.Dtos.Authentication;

namespace TickTick.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class TokensController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public TokensController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult CreateToken(LoginModel loginModel)
    {
        var resnponse = Unauthorized();

        var userModel = Authenticate(loginModel);

        if (userModel is not null)
        {
            string tokenString = BuildToken();
            return Ok(tokenString);
        }

        return resnponse;
    }

    private string BuildToken()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:ServerSecret"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _configuration["JWT:Issuer"],
            _configuration["JWT:Issuer"],
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private UserModel? Authenticate(LoginModel loginModel)
    {
        if (loginModel.UserName == "liam" && loginModel.Password == "AZERTY")
        {
            return new UserModel
            {
                Email = loginModel.UserName,
                Name = "liam@gmail.com"
            };
        }

        return null;
    }
}