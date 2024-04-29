using Labb2WebbTemplate.StoreDataAccess.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labb2WebbTemplate.StoreDataAccess.EntitiesConfigurations;

public class AddressEntityConfiguration : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> builder)
    {
        builder.Navigation(a => a.City).AutoInclude();
        
        builder.Property(a => a.PostalCode)
            .HasMaxLength(5)
            .IsFixedLength();
    }
}