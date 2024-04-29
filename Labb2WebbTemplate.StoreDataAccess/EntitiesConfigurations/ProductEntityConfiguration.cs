using Labb2WebbTemplate.StoreDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labb2WebbTemplate.StoreDataAccess.EntitiesConfigurations;

public class ProductEntityConfiguration 
    : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.Navigation(p => p.Category).AutoInclude();
    }
}