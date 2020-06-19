﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test2.Models;

namespace Test2.Migrations
{
    [DbContext(typeof(PetStoreDbContext))]
    partial class PetStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.5.20278.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Test2.Models.BreedType", b =>
                {
                    b.Property<int>("IdBreedType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBreedType");

                    b.ToTable("BreedType");
                });

            modelBuilder.Entity("Test2.Models.Pet", b =>
                {
                    b.Property<int>("IdPet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateAdopted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdBreedType")
                        .HasColumnType("int");

                    b.Property<bool>("IsMale")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPet");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("Test2.Models.Volunteer", b =>
                {
                    b.Property<int>("IdVolunteer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdSupervisor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVolunteer");

                    b.ToTable("Volunteer");
                });

            modelBuilder.Entity("Test2.Models.Volunteer_Pet", b =>
                {
                    b.Property<int>("IdVolunteer")
                        .HasColumnType("int");

                    b.Property<int>("IdPet")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAccepted")
                        .HasColumnType("datetime2");

                    b.HasKey("IdVolunteer", "IdPet");

                    b.ToTable("Volunteer_Pet");
                });
#pragma warning restore 612, 618
        }
    }
}
