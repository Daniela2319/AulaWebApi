using AulaWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AulaWebApi.Infra.Context
{
    public class OrganizerContext : DbContext
    {
        public OrganizerContext(DbContextOptions<OrganizerContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
