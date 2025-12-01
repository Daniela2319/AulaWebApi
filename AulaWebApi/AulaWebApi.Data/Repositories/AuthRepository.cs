using AulaWebApi.Infra.Context;
using AulaWebApi.Models;


namespace AulaWebApi.Infra.Repositories
{
    public class AuthRepository
    {
        private readonly OrganizerContext _organizerContext;
        
        public AuthRepository(OrganizerContext organizerContext)
        {
            _organizerContext = organizerContext;
            
        }
        public User? GetUserByEmail(string email)
        {
            var retorno = _organizerContext.Users.FirstOrDefault(u => u.Email == email);
            return retorno;

        }
    }
}
