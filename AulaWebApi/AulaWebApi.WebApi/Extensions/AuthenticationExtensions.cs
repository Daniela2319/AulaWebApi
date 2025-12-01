using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace AulaWebApi.WebApi.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
        {
<<<<<<< HEAD
            var jwtKey = config["Jwt:Key"] ?? throw new InvalidOperationException("JWT key is not configured.");
=======
            //var jwtKey = config["Jwt:Key"] ?? throw new InvalidOperationException("JWT key is not configured.");
>>>>>>> c81122567c387ab5275a1d9a3cebfa9a5bfcf14a
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = config["Jwt:Issuer"],
                        ValidAudience = config["Jwt:Audience"],
<<<<<<< HEAD
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
=======
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),
>>>>>>> c81122567c387ab5275a1d9a3cebfa9a5bfcf14a
                        RoleClaimType = ClaimTypes.Role
                    };
                });

            return services;
        }

    }
}
