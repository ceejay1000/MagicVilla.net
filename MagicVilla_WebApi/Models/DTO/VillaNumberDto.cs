﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_WebApi.Models
{
    public class VillaNumberDto
    {
        [Required]
        public int VillaNumber { get; set; }

        [Required]
        public int VillaID { get; set; }

        public string SpecialDetails { get; set; }
    }
}
