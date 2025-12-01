using AulaWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AulaWebApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _userService;
        public AuthController(AuthService userService)
        {
            _userService = userService;
        }
        [HttpPost("Login")]
        public string Login(string email, string password)
        {
            string retorno = this._userService.Login(email, password);
            return retorno;
        }

        [HttpPost("Logout")]
        public string Logout(int userId)
        {
            string message = this._userService.Logout(userId);
            return message;
        }
    }
}
