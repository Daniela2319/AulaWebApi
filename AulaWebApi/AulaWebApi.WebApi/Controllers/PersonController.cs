using AulaWebApi.Models;
using AulaWebApi.Services;
namespace AulaWebApi.WebApi.Controllers
{
    public class PersonController : BaseController<Person>
    {
        public PersonController(IService<Person> service) : base(service)
        {
        }
    }
}
