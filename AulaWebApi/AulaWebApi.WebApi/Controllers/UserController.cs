using AulaWebApi.Models;
using AulaWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AulaWebApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<User> Get()
        {
            return _service.Read();
        }


        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _service.ReadById(id);
        }


        [HttpPost]
        public void Post([FromBody] User model)
        {
            _service.Create(model);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User model)
        {
            _service.Update(model);
        }


        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                this._service.Delete(id);
                StatusCodeResult result = new StatusCodeResult(204);
                return result;
            }
            catch (Exception ex)
            {
                StatusCodeResult result = new StatusCodeResult(500);
                return result;
            }

        }
    }
}

