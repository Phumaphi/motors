﻿// <auto-generated />
using LagoMotors.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LagoMotors.Migrations
{
    [DbContext(typeof(AppDbcontext))]
    [Migration("20200507121812_removedFeatureModel")]
    partial class removedFeatureModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LagoMotors.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Features");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AirBag"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Breaks Lights"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Baby Seat"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Power Steering"
                        });
                });

            modelBuilder.Entity("LagoMotors.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Makes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Toyota"
                        },
                        new
                        {
                            Id = 2,
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Audi"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Mercedese Benz"
                        });
                });

            modelBuilder.Entity("LagoMotors.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MakeId = 1,
                            Name = "Corolla"
                        },
                        new
                        {
                            Id = 2,
                            MakeId = 1,
                            Name = "Staurt"
                        },
                        new
                        {
                            Id = 3,
                            MakeId = 1,
                            Name = "Hilux"
                        },
                        new
                        {
                            Id = 4,
                            MakeId = 2,
                            Name = " BMW_i8"
                        },
                        new
                        {
                            Id = 5,
                            MakeId = 2,
                            Name = " BMW_x5"
                        },
                        new
                        {
                            Id = 6,
                            MakeId = 3,
                            Name = "Q8"
                        },
                        new
                        {
                            Id = 7,
                            MakeId = 4,
                            Name = "C-Class"
                        });
                });

            modelBuilder.Entity("LagoMotors.Models.Model", b =>
                {
                    b.HasOne("LagoMotors.Models.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
