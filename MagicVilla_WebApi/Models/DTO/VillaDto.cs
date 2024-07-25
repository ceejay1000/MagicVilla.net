using System.ComponentModel.DataAnnotations;

namespace MagicVilla_WebApi.Models.DTO
{
    public class VillaDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        public int Sqft { get; internal set; }
        public int Occupancy { get; internal set; }

        [Required]
        public double Rate { get; set; }

        public string Details { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Amenity { get; set; } = string.Empty;
    }
}
