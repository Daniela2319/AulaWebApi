using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaWebApi.Data
{
    public class DatabaseConfig
    {
        public string ConnectionString { get; set; }

        public DatabaseConfig()
        {
            ConnectionString = "Host=localhost;Port=5432;Database=person;Username=postgres;Password=123456";
        }
    }
}
