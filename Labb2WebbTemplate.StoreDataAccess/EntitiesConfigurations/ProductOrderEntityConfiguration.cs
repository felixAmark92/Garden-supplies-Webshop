using Labb2WebbTemplate.StoreDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labb2WebbTemplate.StoreDataAccess.EntitiesConfigurations;

public class ProductOrderEntityConfiguration : IEntityTypeConfiguration<ProductOrderEntity>
{
    public void Configure(EntityTypeBuilder<ProductOrderEntity> builder)
    {
        builder.Navigation(p => p.Product).AutoInclude();
    }
}