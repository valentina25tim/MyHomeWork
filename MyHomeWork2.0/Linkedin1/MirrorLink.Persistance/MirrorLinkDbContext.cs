using Microsoft.EntityFrameworkCore;
using MirrorLink.Business.Entities;
using MirrorLink.Domain.Entities;
using System.Collections.Generic;

namespace MirrorLink.Persistence
{
    public class MirrorLinkDbContext : DbContext
    {
        public MirrorLinkDbContext(DbContextOptions<MirrorLinkDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(MirrorLinkDbContext).Assembly);

            builder.Entity<Person>().HasData(new Person
            {
                Id = 1,
                FirstName = "TestPersonName",
                LastName = "TestPersonLastName",
                Age = 1,
                //Pets = new List<Pet>(2) {
                //    new Pet { Type = "Gog", Name = "NamePet-1", Age = 1 } ,
                //    new Pet { Type = "Cat", Name = "NamePet-2", Age = 1 } }
            });
            builder.Entity<Pet>().HasData(new Pet
            {
                Id = 1,
                Type = "TestCountry",
                Name = "TestCity",
                Age = 1
            });
            //builder.Entity<Person>(b =>
            //    {
            //        b.HasData(new Person
            //        {
            //            Id = 1,
            //            FirstName = "TestPersonName",
            //            LastName = "TestPersonLastName",
            //            Age = 1,
            //        });
            //        b.OwnsMany(p => p.Pets).HasData(new
            //        {
            //            Id = 1,
            //            Type = "Dog",
            //            Name = "DogName",
            //            Age = 1
            //        });

            //    });
        }
    }
}