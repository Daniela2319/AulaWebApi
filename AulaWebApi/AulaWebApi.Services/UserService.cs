using AulaWebApi.Infra.Repositories;
using AulaWebApi.Models;


namespace AulaWebApi.Services
{
    public class UserService : Service<User>
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
        }
    }
}
