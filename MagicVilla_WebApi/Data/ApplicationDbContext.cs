using MagicVilla_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_WebApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                 new Villa
                 {
                     Id = 1,
                     Name = "Sunset Retreat",
                     Sqft = 2500,
                     Occupancy = 6,
                     Rate = 350.50,
                     Details = "A beautiful villa with a stunning sunset view.",
                     ImageUrl = "https://example.com/images/sunset_retreat.jpg",
                     Amenity = "Pool, WiFi, Air Conditioning",
                     CreatedDate = DateTime.Parse("2024-01-01"),
                     UpdatedDate = DateTime.Parse("2024-06-01")
                 },
    new Villa
    {
        Id = 2,
        Name = "Mountain Escape",
        Sqft = 3000,
        Occupancy = 8,
        Rate = 450.75,
        Details = "A secluded villa nestled in the mountains.",
        ImageUrl = "https://example.com/images/mountain_escape.jpg",
        Amenity = "Fireplace, Hiking Trails, WiFi",
        CreatedDate = DateTime.Parse("2024-02-01"),
        UpdatedDate = DateTime.Parse("2024-06-15")
    },
    new Villa
    {
        Id = 3,
        Name = "Beachfront Bliss",
        Sqft = 2000,
        Occupancy = 4,
        Rate = 500.00,
        Details = "A luxurious villa right on the beach.",
        ImageUrl = "https://example.com/images/beachfront_bliss.jpg",
        Amenity = "Beach Access, WiFi, Air Conditioning",
        CreatedDate = DateTime.Parse("2024-03-01"),
        UpdatedDate = DateTime.Parse("2024-07-01")
    },
    new Villa
    {
        Id = 4,
        Name = "Urban Oasis",
        Sqft = 1800,
        Occupancy = 5,
        Rate = 325.25,
        Details = "A modern villa located in the heart of the city.",
        ImageUrl = "https://example.com/images/urban_oasis.jpg",
        Amenity = "Pool, WiFi, Fitness Center",
        CreatedDate = DateTime.Parse("2024-04-01"),
        UpdatedDate = DateTime.Parse("2024-07-15")
    },
    new Villa
    {
        Id = 5,
        Name = "Countryside Charm",
        Sqft = 2200,
        Occupancy = 7,
        Rate = 400.00,
        Details = "A charming villa surrounded by nature.",
        ImageUrl = "https://example.com/images/countryside_charm.jpg",
        Amenity = "Garden, WiFi, Fireplace",
        CreatedDate = DateTime.Parse("2024-05-01"),
        UpdatedDate = DateTime.Parse("2024-08-01")
    }
                );
        }
    }
}
