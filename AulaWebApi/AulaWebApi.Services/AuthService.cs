using AulaWebApi.Infra.Auth;
using AulaWebApi.Infra.Repositories;
using AulaWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;


namespace AulaWebApi.Services
{
    public class AuthService
    {   
        private readonly AuthRepository _repositoryService;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly JwtTokenGenerator _tokenGenerator;
        

        public AuthService(AuthRepository repositoryService, PasswordHasher<User> passwordHasher, IConfiguration config, JwtTokenGenerator tokenGenerator)
        {
            _repositoryService = repositoryService;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
        }

        public string Login(string email, string password)
        {
            var model = _repositoryService.GetUserByEmail(email);

            if (model == null)
                return "Usuário ou senha inválido";

            // ===== Verifica Senha =====
            var result = _passwordHasher.VerifyHashedPassword(model, model.Password, password);
            if (result != PasswordVerificationResult.Success)
                return "Usuário ou senha inválido";

            // ===== Claims do Token =====
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim("UserId", model.Id.ToString()),
                new Claim("PersonId", model.PersonId.ToString()),
                new Claim(ClaimTypes.Role, "Admin")
            };

            return _tokenGenerator.GenerateToken(claims);
        }
        public string Logout(int userId)
        {
            return "Logout realizado com sucesso.";
        }

    }
}
