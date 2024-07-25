using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Pool, WiFi, Air Conditioning", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A beautiful villa with a stunning sunset view.", "https://example.com/images/sunset_retreat.jpg", "Sunset Retreat", 6, 350.5, 2500, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Fireplace, Hiking Trails, WiFi", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A secluded villa nestled in the mountains.", "https://example.com/images/mountain_escape.jpg", "Mountain Escape", 8, 450.75, 3000, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Beach Access, WiFi, Air Conditioning", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A luxurious villa right on the beach.", "https://example.com/images/beachfront_bliss.jpg", "Beachfront Bliss", 4, 500.0, 2000, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Pool, WiFi, Fitness Center", new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A modern villa located in the heart of the city.", "https://example.com/images/urban_oasis.jpg", "Urban Oasis", 5, 325.25, 1800, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Garden, WiFi, Fireplace", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A charming villa surrounded by nature.", "https://example.com/images/countryside_charm.jpg", "Countryside Charm", 7, 400.0, 2200, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
