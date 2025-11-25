using AulaWebApi.Infra.Repositories;
using AulaWebApi.Models;
using Microsoft.AspNetCore.Identity;

namespace AulaWebApi.Services
{
    public class UserService : Service<User>
    {
        private readonly PasswordHasher<User> _passwordHasher;

        public UserService(IRepository<User> repository, PasswordHasher<User> passwordHasher)
            : base(repository)
        {
            _passwordHasher = passwordHasher;
        }

        public override int Create(User model)
        {
            var hash = _passwordHasher.HashPassword(model, model.Password);
            model.Password = hash;
            return base.Create(model);
        }

    }
}
