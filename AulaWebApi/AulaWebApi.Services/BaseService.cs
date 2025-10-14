
using System.Data;
using AulaWebApi.Data;
using AulaWebApi.Models;
using Npgsql;

namespace AulaWebApi.Services
{
    public  class BaseService<T> : IServece<T> where T : BaseModel
    {
        protected readonly DatabaseConfig _config;
        protected readonly string TableName;

        public BaseService(string tableName, DatabaseConfig config)
        {
            TableName = tableName;
            _config = config;
        }

        protected NpgsqlConnection GetConnection()
        {
            var db = new DatabaseConnetion(_config);
            return db.Open(); 
        }


        //método auxiliar para executar comandos com parâmetros(INSERT, UPDATE, DELETE)
        public void ExecuteNonQuery(string sql,Dictionary<string, object> parameters)
        {
            using var connection = GetConnection();
            using var command = new NpgsqlCommand(sql, connection);

            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }

            command.ExecuteNonQuery();
        }

        //método para executar SELECT, BYID e retornar
        public NpgsqlDataReader ExecuteReader(string sql, Dictionary<string, object>? parameters = null)
        {
             var connection = GetConnection();
             var command = new NpgsqlCommand(sql, connection);
             if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

             return command.ExecuteReader(CommandBehavior.CloseConnection);
            
        }

        // metodos CRUD virtuais podem ser sobrescritos
        public virtual void Create(T model) { }

        public virtual void Delete(int id) { }

        public virtual List<T> Read() => new List<T>();

        public virtual T ReadById(int id) => null;

        public virtual void Update(T model) { }
    }
}
