﻿// <auto-generated />
using GamifyFitness.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GamifyFitness.Migrations
{
    [DbContext(typeof(GfContext))]
    [Migration("20190401065332_SeedData")]
    partial class SeedData
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

                    b.Property<string>("Friends");

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
#pragma warning restore 612, 618
        }
    }
}