using AulaWebApi.Infra.Context;
using AulaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaWebApi.Infra.Repositories
{
    public class PersonRepository : RepositoryInDbPostgres
    {
        public PersonRepository(OrganizerContext organizerContext) : base(organizerContext)
        {
        }
    }
}
