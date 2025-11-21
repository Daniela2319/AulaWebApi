using AulaWebApi.Models;
using AulaWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AulaWebApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T> : ControllerBase where T : BaseModel
    {
        private IService<T> _service;
        public BaseController(IService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public List<T> Get()
        {
            return _service.Read();
        }


        [HttpGet("{id}")]
        public T Get(int id)
        {
            return _service.ReadById(id);
        }

        [HttpGet("exist/{id}")]
        public bool Exist(int id)
        {
            return _service.Exists(id);
        }

        [HttpPost]
        public void Post([FromBody] T model)
        {
            _service.Create(model);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] T model)
        {
            if (id != model.Id)
            {
                throw new ArgumentException("O ID do Objeto Person não é igual ao Id da URL.");
            }
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
