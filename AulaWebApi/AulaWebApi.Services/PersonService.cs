using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AulaWebApi.Data;
using AulaWebApi.Models;
using Npgsql;

namespace AulaWebApi.Services
{
    public class PersonService : BaseService<Person>
    {   
        
        public PersonService(DatabaseConfig config) :base("person", config){}

        public override List<Person> Read()
        {
            string commandText = SqlQuery.SelectAll(TableName);

            var dataReader = ExecuteReader(commandText);

            List<Person> list = new List<Person>();
            while (dataReader.Read())
            {
                Person person = new Person();
                person.Id = Convert.ToInt32(dataReader["id"]);
                person.FirstName = dataReader["first_name"].ToString();
                person.LastName = dataReader["last_name"].ToString();
                person.BirthDate = Convert.ToDateTime(dataReader["birth_date"]);
                person.CreatedAt = Convert.ToDateTime(dataReader["created_at"]);

                list.Add(person);
            }
            return list;
            
        }

        public override Person ReadById(int id)
        {
            string commandText = SqlQuery.SelectById(TableName);
            var parameters = new Dictionary<string, object>() { {  "id", id } };
            
            var dataReader = ExecuteReader(commandText, parameters);

            Person person = new Person();
            if (dataReader.Read())
            {
                person.Id = Convert.ToInt32(dataReader["id"]);
                person.FirstName = dataReader["first_name"].ToString();
                person.LastName = dataReader["last_name"].ToString();
                person.BirthDate = Convert.ToDateTime(dataReader["birth_date"]);
                person.CreatedAt = Convert.ToDateTime(dataReader["created_at"]);

            }
            return person;

        }
        public override void Create(Person model)
        {
            string commandText = SqlQuery.Insert(TableName, new[] { "first_name", "last_name", "birth_date", "created_at" });
            var parameters = new Dictionary<string, object>
            {
                { "first_name", model.FirstName },
                { "last_name", model.LastName },
                { "birth_date", model.BirthDate },
                { "created_at", model.CreatedAt }

            };
            ExecuteNonQuery(commandText, parameters);
            
        }

        public override void Update(Person model)
        {
            string commandText = SqlQuery.Update(TableName, new[] { "first_name", "last_name", "birth_date", "created_at" } );
            var parameters = new Dictionary<string, object>
            {
                { "first_name", model.FirstName },
                { "last_name", model.LastName },
                { "birth_date", model.BirthDate },
                { "created_at", model.CreatedAt },
                { "id", model.Id }
            };
            ExecuteNonQuery(commandText, parameters);
            
        }

        public override void Delete(int id)
        {
            string commandText = SqlQuery.Delete(TableName);
            var parameters = new Dictionary<string, object> { { "id", id } };
            ExecuteNonQuery(commandText, parameters);   
        }
    }
}
