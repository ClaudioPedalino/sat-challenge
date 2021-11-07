﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sat.Recruitment.Infra.Persistence;

namespace Sat.Recruitment.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211107195903_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sat.Recruitment.Domain.Entities.AuthUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AuthUsers");
                });

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
                            Id = new Guid("ba6f8779-b4f2-4a8c-a0d8-2a4b64324d50"),
                            Address = "Peru 2464",
                            CreateBy = "Seed Initial Data",
                            Email = "Juan@marmol.com",
                            IsDelete = false,
                            LastModificationAt = new DateTime(2021, 11, 7, 16, 59, 3, 385, DateTimeKind.Unspecified).AddTicks(3758),
                            Money = 1234m,
                            Name = "Juan",
                            Phone = "+5491154762312",
                            UserType = "Normal"
                        },
                        new
                        {
                            Id = new Guid("b079b96b-0cd5-4dd2-ae81-46f402827962"),
                            Address = "Alvear y Colombres",
                            CreateBy = "Seed Initial Data",
                            Email = "Franco.Perez@gmail.com",
                            IsDelete = false,
                            LastModificationAt = new DateTime(2021, 11, 7, 16, 59, 3, 387, DateTimeKind.Unspecified).AddTicks(5735),
                            Money = 112234m,
                            Name = "Franco",
                            Phone = "+534645213542",
                            UserType = "Premium"
                        },
                        new
                        {
                            Id = new Guid("086e013d-f9fc-464f-b939-e370e3945d1c"),
                            Address = "Garay y Otra Calle",
                            CreateBy = "Seed Initial Data",
                            Email = "Agustina@gmail.com",
                            IsDelete = false,
                            LastModificationAt = new DateTime(2021, 11, 7, 16, 59, 3, 387, DateTimeKind.Unspecified).AddTicks(5972),
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