﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModelsDB;

#nullable disable

namespace EfMultiMigrations.Migrations.Mssql
{
    [DbContext(typeof(DbModel_MssqlContext))]
    partial class DbModel_MssqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("ModelsDB.DbData1Model", b =>
                {
                    b.Property<int>("idDbData1Model")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idDbData1Model");

                    b.ToTable("DbData1Model");

                    b.HasData(
                        new
                        {
                            idDbData1Model = 1,
                            Age = 1,
                            Name = "Test"
                        });
                });

            modelBuilder.Entity("ModelsDB.DbData2Model", b =>
                {
                    b.Property<int>("idDbData2Model")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("idDbData2Model");

                    b.ToTable("DbData2Model");

                    b.HasData(
                        new
                        {
                            idDbData2Model = 1,
                            FirstName = "T",
                            LastName = "est"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
