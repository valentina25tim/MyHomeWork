using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MirrorLink.Domain.Entities;

namespace MirrorLink.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(p => p.Country) 
                .IsRequired().HasMaxLength(50); // TODO use shared constants for maxLen
        }
    }
}