using AulaWebApi.Models;
using AulaWebApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AulaWebApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController<Person>
    {
        public PersonController(IService<Person> service) : base(service)
        {
        }
    }
}
