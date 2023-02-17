using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace TickTick.Api;

public static class AuthenticationExtensions
{
    public static IServiceCollection ConfigureAuthentication(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var sKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:ServerSecret"]));
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = sKey,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Issuer"],
                };
            });
        
        return services;
    }
}