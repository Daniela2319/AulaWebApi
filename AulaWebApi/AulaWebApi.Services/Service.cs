
using AulaWebApi.Infra.Context;
using AulaWebApi.Infra.Repositories;
using AulaWebApi.Models;

namespace AulaWebApi.Services
{
    public class Service<T> : IService<T> where T : BaseModel
    {
        private readonly IRepository<T> _repository;
       

        public Service(IRepository<T> repository) 
        {
            _repository = repository;
            
        }
        public virtual int Create(T model)
        {
            return _repository.Create(model);
            
        }

        public virtual void Delete(int id)
        {
            var entity = _repository.ReadById(id);

            if (entity == null)
                throw new Exception($"Registro {id} não encontrado.");

            _repository.Delete(id);
        }

        public bool Exists(int id)
        {
            return _repository.Exists(id);

        }

        public virtual List<T> Read()
        {
           return _repository.Read();
        }

        public virtual T ReadById(int id)
        {
            var entity = _repository.ReadById(id);

            if (entity == null)
                throw new Exception($"Registro ID {id} não encontrado.");

            return entity;
        }

        public virtual void Update(T model)
        {
            var existing = _repository.ReadById(model.Id);

            if (existing == null)
                throw new Exception($"Registro {model.Id} não encontrado.");

            _repository.Update(model);
        }
    }
}
