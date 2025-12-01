using AulaWebApi.Models;
using AulaWebApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace AulaWebApi.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PersonController : BaseController<Person>
    {
        public PersonController(IService<Person> service) : base(service)
        {
        }
    }
}
