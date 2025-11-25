using AulaWebApi.Models;
using AulaWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AulaWebApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T> : ControllerBase where T : BaseModel
    {
        protected IService<T> _service;
        public BaseController(IService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual List<T> Get()
        {
            return _service.Read();
        }


        [HttpGet("{id}")]
        public virtual T Get(int id)
        {
            return _service.ReadById(id);
        }

        [HttpGet("exist/{id}")]
        public virtual bool Exist(int id)
        {
            return _service.Exists(id);
        }

        [HttpPost]
        public virtual void Post([FromBody] T model)
        {
            _service.Create(model);
        }


        [HttpPut("{id}")]
        public virtual void Put(int id, [FromBody] T model)
        {
            if (id != model.Id)
            {
                throw new ArgumentException("O ID do Objeto Person não é igual ao Id da URL.");
            }
            _service.Update(model);
        }


        [HttpDelete("{id}")]
        public virtual StatusCodeResult Delete(int id)
        {
            try
            {
                this._service.Delete(id);
                StatusCodeResult result = new StatusCodeResult(204);
                return result;
            }
            catch (Exception)
            {
                StatusCodeResult result = new StatusCodeResult(500);
                return result;
            }

        }
    }
}
