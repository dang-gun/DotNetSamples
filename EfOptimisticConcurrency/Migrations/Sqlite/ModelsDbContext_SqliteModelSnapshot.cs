﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelsDB;

#nullable disable

namespace EfOptimisticConcurrency.Migrations.Sqlite
{
    [DbContext(typeof(ModelsDbContext_Sqlite))]
    partial class ModelsDbContext_SqliteModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ModelsDB.TestOC1", b =>
                {
                    b.Property<int>("idTestOC1")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idTestOC1"), 1L, 1);

                    b.Property<int>("Int")
                        .HasColumnType("int");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<Guid>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("idTestOC1");

                    b.ToTable("TestOC1");

                    b.HasData(
                        new
                        {
                            idTestOC1 = 1,
                            Int = 1,
                            Str = "str 1",
                            Version = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("ModelsDB.TestOC2", b =>
                {
                    b.Property<int>("idTestOC2")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idTestOC2"), 1L, 1);

                    b.Property<int>("Int")
                        .HasColumnType("int");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<byte[]>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("idTestOC2");

                    b.ToTable("TestOC2");

                    b.HasData(
                        new
                        {
                            idTestOC2 = 1,
                            Int = 2,
                            Str = "str 2"
                        });
                });

            modelBuilder.Entity("ModelsDB.TestOC3", b =>
                {
                    b.Property<int>("idTestOC3")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idTestOC3"), 1L, 1);

                    b.Property<int>("Int")
                        .HasColumnType("int");

                    b.Property<string>("Str")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("idTestOC3");

                    b.ToTable("TestOC3");

                    b.HasData(
                        new
                        {
                            idTestOC3 = 1,
                            Int = 3,
                            Str = "str 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}