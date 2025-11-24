using AulaWebApi.Models;
using AulaWebApi.Services;
using AulaWebApi.WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AulaWebApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IService<User> _service;
        private IService<Person> _personService;
        public UserController(IService<User> service, IService<Person> personService)
        {
            _service = service;
            _personService = personService;
        }

        [HttpGet]
        public List<UserViewModel> Get()
        {
            List<User> users = _service.Read();
            List<UserViewModel> listViewModel = new List<UserViewModel>();
            foreach (var user in users)
            {
                UserViewModel userViewModel = new UserViewModel();
                userViewModel.Id = user.Id;
                userViewModel.Email = user.Email;
                userViewModel.Password = user.Password;
                userViewModel.PersonId = user.PersonId;
                userViewModel.CreatedAt = user.CreatedAt;
                userViewModel.Person = _personService.ReadById(user.PersonId);
                listViewModel.Add(userViewModel);
            }
            return listViewModel;
        }

        [HttpGet("exist/{id}")]
        public bool Exist(int id)
        {
            return _service.Exists(id);
        }

        [HttpGet("{id}")]
        public UserViewModel Get(int id)
        {
            User user = _service.ReadById(id);
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.Id = user.Id;
            userViewModel.Email = user.Email;
            userViewModel.Password = user.Password;
            userViewModel.PersonId = user.PersonId;
            userViewModel.CreatedAt = user.CreatedAt;
            userViewModel.Person = _personService.ReadById(user.PersonId);
            return userViewModel;
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

