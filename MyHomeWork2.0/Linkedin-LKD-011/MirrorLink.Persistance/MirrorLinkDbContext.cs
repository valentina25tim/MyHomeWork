using Microsoft.EntityFrameworkCore;
using MirrorLink.Business.Entities;
using MirrorLink.Domain.Entities;

namespace MirrorLink.Persistence
{
    public class MirrorLinkDbContext : DbContext
    {
        public MirrorLinkDbContext(DbContextOptions<MirrorLinkDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(MirrorLinkDbContext).Assembly);

            builder.Entity<Person>().HasData(new Person
            {
                Id = 1,
                FirstName = "TestPersonName",
                LastName = "TestPersonLastName"
            });
            builder.Entity<Address>().HasData(new Address
            {
                Id = 1,
                Country = "TestCountry",
                City = "TestCity"
            });
        }
    }
}