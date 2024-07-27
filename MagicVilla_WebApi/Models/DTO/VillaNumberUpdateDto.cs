using System.ComponentModel.DataAnnotations;

namespace MagicVilla_WebApi.Models
{
    public class VillaNumberUpdateDto
    {
        [Required]
        public int VillaNumber { get; set; }

        public string SpecialDetails { get; set; }
    }
}
