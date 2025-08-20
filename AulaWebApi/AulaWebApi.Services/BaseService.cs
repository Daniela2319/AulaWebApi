
using AulaWebApi.Models;

namespace AulaWebApi.Services
{
    public class BaseService<T> : IServece<T> where T : BaseModel
    {
        public List<T> list { get; set; } = new List<T>();
        public void Create(T model)
        {
            this.list.Add(model);
        }

        public void Delete(int id)
        {
            T item = this.ReadById(id);
            this.list.Remove(item);
        }

        public List<T> Read()
        {
           return this.list;
        }

        public T ReadById(int id)
        {
            T item = this.list.FirstOrDefault(i => i.Id == id);
            return item;
        }

        public void Update(T model)
        {
            T olditem = this.ReadById(model.Id);
            this.Delete(olditem.Id);
            this.Create(model);
        }
    }
}
