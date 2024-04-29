﻿// <auto-generated />
using System;
using Labb2WebbTemplate.StoreDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb2WebbTemplate.StoreDataAccess.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20240319083539_test2")]
    partial class test2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.1.24081.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.Address.AddressEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nchar(5)")
                        .IsFixedLength();

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.Address.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.Address.RegionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDiscontinued")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.ProductOrderEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("ProductOrderEntity");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Hash")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("binary")
                        .IsFixedLength();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("binary")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.Address.AddressEntity", b =>
                {
                    b.HasOne("Labb2WebbTemplate.StoreDataAccess.Entities.Address.CityEntity", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2WebbTemplate.StoreDataAccess.Entities.UserEntity", "User")
                        .WithOne("Address")
                        .HasForeignKey("Labb2WebbTemplate.StoreDataAccess.Entities.Address.AddressEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.Address.CityEntity", b =>
                {
                    b.HasOne("Labb2WebbTemplate.StoreDataAccess.Entities.Address.RegionEntity", "Region")
                        .WithMany("Cities")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.OrderEntity", b =>
                {
                    b.HasOne("Labb2WebbTemplate.StoreDataAccess.Entities.UserEntity", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.ProductEntity", b =>
                {
                    b.HasOne("Labb2WebbTemplate.StoreDataAccess.Entities.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.ProductOrderEntity", b =>
                {
                    b.HasOne("Labb2WebbTemplate.StoreDataAccess.Entities.OrderEntity", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Labb2WebbTemplate.StoreDataAccess.Entities.ProductEntity", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.Address.RegionEntity", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.OrderEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.ProductEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Labb2WebbTemplate.StoreDataAccess.Entities.UserEntity", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
