using AulaWebApi.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaWebApi.Infra.Repositories
{
    public class UserRepository : RepositoryInDbPostgres
    {
        public UserRepository(OrganizerContext organizerContext) : base(organizerContext)
        {
        }
    }
}
