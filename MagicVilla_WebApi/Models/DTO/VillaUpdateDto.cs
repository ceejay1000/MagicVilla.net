using System.ComponentModel.DataAnnotations;

namespace MagicVilla_WebApi.Models.DTO
{
    public class VillaUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int VillaID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        public int Sqft { get; internal set; }
        public int Occupancy { get; internal set; }

        [Required]
        public double Rate { get; set; }

        public string Details { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public string Amenity { get; set; } = string.Empty;
    }
}
