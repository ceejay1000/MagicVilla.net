﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_WebApi.Models
{
    public class Villa
    {
      //  [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int Sqft { get;  set; }
        public int Occupancy { get;  set; }

        public double Rate { get; set; }

        public string Details { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Amenity { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
