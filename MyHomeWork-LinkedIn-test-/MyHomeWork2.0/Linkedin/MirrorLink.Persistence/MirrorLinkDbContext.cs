using Microsoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MirrorLink.Persistence
{
    public class MirrorLinkDbContext : DbContext
    {
        public MirrorLinkDbContext(DbContextOptions<MirrorLinkDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(MirrorLinkDbContext).Assembly);

            builder.Entity<Person>().HasData(new Person
            {
                Id = 1,
                FirstName = "TestPersonName",
                LastName = "TestPersonLastName"
            });
        }
    }
}

