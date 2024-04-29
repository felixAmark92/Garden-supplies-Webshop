using Labb2WebbTemplate.StoreDataAccess.Entities.Address;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labb2WebbTemplate.StoreDataAccess.EntitiesConfigurations;

public class CityEntityConfiguration : IEntityTypeConfiguration<CityEntity>
{
    public void Configure(EntityTypeBuilder<CityEntity> builder)
    {
        builder.Navigation(c => c.Region).AutoInclude();
    }
}