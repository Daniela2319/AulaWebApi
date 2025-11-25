using AulaWebApi.Infra.Repositories;
using AulaWebApi.Models;


namespace AulaWebApi.Services
{
    public class PersonService : Service<Person>
    {
        public PersonService(IRepository<Person> repository) : base(repository)
        {
        }

        public override int Create(Person model)
        {
            model.CreatedAt = DateTime.UtcNow;
            return base.Create(model);
        }

        public override void Update(Person model)
        {
            var existingPerson = ReadById(model.Id);
            existingPerson.FirstName = model.FirstName;
            existingPerson.LastName = model.LastName;
            existingPerson.BirthDate = model.BirthDate;

            base.Update(existingPerson);
        }
    }
}
