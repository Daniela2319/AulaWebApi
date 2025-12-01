using AulaWebApi.Infra.Auth;
using AulaWebApi.Infra.Repositories;
using AulaWebApi.Models;
using AulaWebApi.Services;
using Microsoft.AspNetCore.Identity;

namespace AulaWebApi.WebApi.Extensions
{
    public static class DependencyInjectionExtensions
    {
       
        public static IServiceCollection AddAppDependencies(this IServiceCollection services)
        {
            // ===== Services =====
            services.AddScoped<IService<Person>, PersonService>();
            services.AddScoped<IService<User>, UserService>();
            services.AddScoped<AuthService>();
            services.AddScoped<UserService>();
            services.AddScoped<PasswordHasher<User>>();
            services.AddScoped<JwtTokenGenerator>();


            // ===== Repositories =====
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<AuthRepository>();

            return services;
        }
    }
}
