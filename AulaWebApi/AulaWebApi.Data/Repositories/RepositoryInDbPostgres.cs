using AulaWebApi.Infra.Context;
using AulaWebApi.Models;


namespace AulaWebApi.Infra.Repositories
{
    public class RepositoryInDbPostgres : BaseRepository<Person>
    {
        public RepositoryInDbPostgres(OrganizerContext organizerContext) : base(organizerContext)
        {
        }
    }
}
