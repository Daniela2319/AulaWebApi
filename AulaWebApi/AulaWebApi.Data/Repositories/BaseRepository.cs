using AulaWebApi.Infra.Context;
using AulaWebApi.Models;
using Microsoft.EntityFrameworkCore;


namespace AulaWebApi.Infra.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly OrganizerContext _organizerContext;
       
        public BaseRepository(OrganizerContext organizerContext)
        {
            _organizerContext = organizerContext;
        }
        public int Create(T entity)
        {
            _organizerContext.Set<T>().Add(entity);
            _organizerContext.SaveChanges();
            return entity.Id;
        }

        public void Delete(int id)
        {
            var entity = ReadById(id);

            if (entity == null)
                return;

            _organizerContext.Set<T>().Remove(entity);
            _organizerContext.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _organizerContext.Set<T>().Any(e => e.Id == id);
             
        }

        public List<T> Read()
        {
            return _organizerContext.Set<T>().ToList();

        }

        public T ReadById(int id)
        {
            var entity = _organizerContext.Set<T>().FirstOrDefault(e => e.Id == id);
            if (entity is null)
                throw new KeyNotFoundException($"Entity com id {id} não encontrada.");
            return entity;
        }


        public void Update(T entity)
        {
            var modelOriginal = ReadById(entity.Id);
            if (modelOriginal == null)
                return;
            _organizerContext.Entry(modelOriginal).CurrentValues.SetValues(entity);
            _organizerContext.SaveChanges();
        }
    }
}
