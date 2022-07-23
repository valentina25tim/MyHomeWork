using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MirrorLink.Domain.Entities;

namespace MirrorLink.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.FirstName)
                .IsRequired().HasMaxLength(50); // TODO use shared constants for maxLen
        }
    }
}