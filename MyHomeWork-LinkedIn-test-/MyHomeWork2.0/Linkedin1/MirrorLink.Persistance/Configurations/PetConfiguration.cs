using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MirrorLink.Domain.Entities;

namespace MirrorLink.Persistence.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired().HasMaxLength(50); // TODO use shared constants for maxLen
        }
    }
}