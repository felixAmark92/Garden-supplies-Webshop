using Labb2WebbTemplate.StoreDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Labb2WebbTemplate.StoreDataAccess.EntitiesConfigurations;

internal class UserEntityConfiguration 
    : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.Navigation(u => u.Address).AutoInclude();

        builder.Property(u => u.Salt)
            .HasColumnType("binary")
            .HasMaxLength(32)
            .IsFixedLength();
        
        builder.Property(u => u.Hash)
            .HasColumnType("binary")
            .HasMaxLength(32)
            .IsFixedLength();

    }
}