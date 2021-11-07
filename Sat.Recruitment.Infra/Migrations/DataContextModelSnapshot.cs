﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sat.Recruitment.Infra.Persistence;

namespace Sat.Recruitment.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sat.Recruitment.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("Address");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeleteBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("Email");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModificationAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Money")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m)
                        .HasColumnName("Money");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasColumnName("Name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)")
                        .HasColumnName("Phone");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("UserType");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("497b7118-dd73-42b7-bb72-6bd558783a53"),
                            Address = "Peru 2464",
                            CreateBy = "Seed Initial Data",
                            Email = "Juan@marmol.com",
                            IsDelete = false,
                            LastModificationAt = new DateTime(2021, 11, 7, 0, 13, 14, 447, DateTimeKind.Unspecified).AddTicks(774),
                            Money = 1234m,
                            Name = "Juan",
                            Phone = "+5491154762312",
                            UserType = "Normal"
                        },
                        new
                        {
                            Id = new Guid("df7cebf2-05f1-4780-bb5f-9266c6b0342b"),
                            Address = "Alvear y Colombres",
                            CreateBy = "Seed Initial Data",
                            Email = "Franco.Perez@gmail.com",
                            IsDelete = false,
                            LastModificationAt = new DateTime(2021, 11, 7, 0, 13, 14, 451, DateTimeKind.Unspecified).AddTicks(3980),
                            Money = 112234m,
                            Name = "Franco",
                            Phone = "+534645213542",
                            UserType = "Premium"
                        },
                        new
                        {
                            Id = new Guid("e5bf082e-c1d8-4bb5-98b5-6960bcf9af35"),
                            Address = "Garay y Otra Calle",
                            CreateBy = "Seed Initial Data",
                            Email = "Agustina@gmail.com",
                            IsDelete = false,
                            LastModificationAt = new DateTime(2021, 11, 7, 0, 13, 14, 451, DateTimeKind.Unspecified).AddTicks(5547),
                            Money = 112234m,
                            Name = "Agustina",
                            Phone = "+534645213542",
                            UserType = "SuperUser"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
