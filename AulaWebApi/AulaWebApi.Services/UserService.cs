using AulaWebApi.Infra.Repositories;
using AulaWebApi.Models;
using Microsoft.AspNetCore.Identity;

namespace AulaWebApi.Services
{
    public class UserService : Service<User>
    {
        private readonly PasswordHasher<string> _passwordHasher;

        public UserService(IRepository<User> repository, PasswordHasher<string> passwordHasher)
            : base(repository)
        {
            _passwordHasher = passwordHasher;
        }

        public override int Create(User model)
        {
            var hash = _passwordHasher.HashPassword(null, model.Password);
            model.Password = hash;
            return base.Create(model);
        }

    }
}
