using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaWebApi.Services
{
    public interface IServece<T>
    {
        void Create(T model); 
        List<T> Read();
        void Update(T model);
        void Delete(int id);
        T ReadById(int id);
    }
}
