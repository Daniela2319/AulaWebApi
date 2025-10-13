using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AulaWebApi.Models;
using Npgsql;

namespace AulaWebApi.Services
{
    public class PersonService : BaseService<Person>
    {
        //connectionstring tem dados necessários para se conectar ao banco de dados
        // Aqui são informados: servidor (Host), porta (Port), nome do banco (Database), usuário (Username) e senha (Password).
        private readonly string _connectionString = "Host=localhost;Port=5432;Database=person;Username=postgres;Password=123456";


        public override List<Person> Read()
        {
            //abre a conexão: Liga o C# ao PostgreSQL usando o Npgsql
            NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            //armazenada na variavel commandText o comando seleciona sql
            string commandText = "SELECT * FROM person";

            //executa o comando sql e conecta com banco
            NpgsqlCommand selectCommand = new NpgsqlCommand(commandText, connection);

            //lê os dados linha por linha 
            NpgsqlDataReader dataReader = selectCommand.ExecuteReader();

            //criada a lista onde os objetos Person vão ser guardados
            List<Person> list = new List<Person>();

            //para cada linha, Converte os dados do banco em objetos C#
            while (dataReader.Read())
            {
                Person person = new Person();
                person.Id = Convert.ToInt32(dataReader["id"]);
                person.FirstName = dataReader["first_name"].ToString();
                person.LastName = dataReader["last_name"].ToString();
                person.BirthDate = Convert.ToDateTime(dataReader["birth_date"]);
                person.CreatedAt = Convert.ToDateTime(dataReader["created_at"]);

                //adiciona na lista
                list.Add(person);
            }

            //fecha a conexão
            connection.Close();

            //retorna os dados na lista.
            return list;
            
        }

        public override Person ReadById(int id)
        {
            //abre a conexão: Liga o C# ao PostgreSQL usando o Npgsql
            NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            //armazenada na variavel commandText o comando seleciona sql
            string commandText = "SELECT * FROM person WHERE id = @id";

            //executa o comando sql e conecta com banco
            NpgsqlCommand selectCommand = new NpgsqlCommand(commandText, connection);

            //configura o parametro
            selectCommand.Parameters.AddWithValue("id", id);

            //lê os dados linha por linha 
            NpgsqlDataReader dataReader = selectCommand.ExecuteReader();

            Person person = new Person();
            if (dataReader.Read())
            {
                person.Id = Convert.ToInt32(dataReader["id"]);
                person.FirstName = dataReader["first_name"].ToString();
                person.LastName = dataReader["last_name"].ToString();
                person.BirthDate = Convert.ToDateTime(dataReader["birth_date"]);
                person.CreatedAt = Convert.ToDateTime(dataReader["created_at"]);

            }
            
            connection.Close();
            return person;

        }
        public override void Create(Person model)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            string commandText = "INSERT INTO person (first_name, last_name, birth_date, created_at) values (@first_name, @last_name, @birth_date, @created_at)";
            NpgsqlCommand insertCommand = new NpgsqlCommand(commandText, connection);

            insertCommand.Parameters.AddWithValue("first_name", model.FirstName);
            insertCommand.Parameters.AddWithValue("last_name", model.LastName);
            insertCommand.Parameters.AddWithValue("birth_date", model.BirthDate);
            insertCommand.Parameters.AddWithValue("created_at", model.CreatedAt);

            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public override void Update(Person model)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            string commandText = "UPDATE person SET fist_name = @fist_name, last_name = @last_name, birth_date = @birth_date, created_at = @created_At   WHERE id = @id";
            NpgsqlCommand updateCommand = new NpgsqlCommand(commandText, connection);

            updateCommand.Parameters.AddWithValue("fist_name", model.FirstName);
            updateCommand.Parameters.AddWithValue("last_name", model.LastName);
            updateCommand.Parameters.AddWithValue("birth_date", model.BirthDate);
            updateCommand.Parameters.AddWithValue("created_at", model.CreatedAt);
            updateCommand.Parameters.AddWithValue("id", model.Id);

            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public override void Delete(int id)
        {
            NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            string commandText = "DELETE FROM person WHERE id = @id";
            NpgsqlCommand deleteCommand = new NpgsqlCommand(commandText, connection);
            deleteCommand.Parameters.AddWithValue("id", id);

            deleteCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}
