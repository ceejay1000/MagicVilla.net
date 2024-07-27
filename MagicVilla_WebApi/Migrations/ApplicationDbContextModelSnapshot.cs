﻿// <auto-generated />
using System;
using MagicVilla_WebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla_WebApi.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "Pool, WiFi, Air Conditioning",
                            CreatedDate = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "A beautiful villa with a stunning sunset view.",
                            ImageUrl = "https://example.com/images/sunset_retreat.jpg",
                            Name = "Sunset Retreat",
                            Occupancy = 6,
                            Rate = 350.5,
                            Sqft = 2500,
                            UpdatedDate = new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "Fireplace, Hiking Trails, WiFi",
                            CreatedDate = new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "A secluded villa nestled in the mountains.",
                            ImageUrl = "https://example.com/images/mountain_escape.jpg",
                            Name = "Mountain Escape",
                            Occupancy = 8,
                            Rate = 450.75,
                            Sqft = 3000,
                            UpdatedDate = new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "Beach Access, WiFi, Air Conditioning",
                            CreatedDate = new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "A luxurious villa right on the beach.",
                            ImageUrl = "https://example.com/images/beachfront_bliss.jpg",
                            Name = "Beachfront Bliss",
                            Occupancy = 4,
                            Rate = 500.0,
                            Sqft = 2000,
                            UpdatedDate = new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Amenity = "Pool, WiFi, Fitness Center",
                            CreatedDate = new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "A modern villa located in the heart of the city.",
                            ImageUrl = "https://example.com/images/urban_oasis.jpg",
                            Name = "Urban Oasis",
                            Occupancy = 5,
                            Rate = 325.25,
                            Sqft = 1800,
                            UpdatedDate = new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Amenity = "Garden, WiFi, Fireplace",
                            CreatedDate = new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "A charming villa surrounded by nature.",
                            ImageUrl = "https://example.com/images/countryside_charm.jpg",
                            Name = "Countryside Charm",
                            Occupancy = 7,
                            Rate = 400.0,
                            Sqft = 2200,
                            UpdatedDate = new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MagicVilla_WebApi.Models.VillaNumber", b =>
                {
                    b.Property<int>("VillaNo")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpecialDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("VillaNo");

                    b.ToTable("VillaNumbers");
                });
#pragma warning restore 612, 618
        }
    }
}
