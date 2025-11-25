using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaWebApi.Services
{
    public interface IService<T>
    {
        int Create(T model);
        List<T> Read();
        void Update(T model);
        void Delete(int id);
        T ReadById(int id);
        bool Exists(int id);
    }
}
