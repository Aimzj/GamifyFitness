﻿// <auto-generated />
using System;
using GamifyFitness.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GamifyFitness.Migrations
{
    [DbContext(typeof(GfContext))]
    [Migration("20190401125124_UserAdditionalFields")]
    partial class UserAdditionalFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GamifyFitness.Data.Entities.User", b =>
                {
                    b.Property<string>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Friends");

                    b.Property<string>("Password");

                    b.Property<int>("age");

                    b.Property<float>("currCaloriesStored");

                    b.Property<float>("lifetimeCalories");

                    b.Property<string>("name");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            Friends = "Aimee,Riordan",
                            age = 22,
                            currCaloriesStored = 10f,
                            lifetimeCalories = 100f,
                            name = "Ronan,"
                        });
                });

            modelBuilder.Entity("GamifyFitness.Data.Entities.UserLogin", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Id");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Email");

                    b.ToTable("Logins");
                });
#pragma warning restore 612, 618
        }
    }
}
