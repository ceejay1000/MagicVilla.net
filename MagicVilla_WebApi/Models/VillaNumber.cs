﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_WebApi.Models
{
    public class VillaNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNo { get; set; }

        [ForeignKey("Villa")]
        public int VillaID { get; set; }

        public Villa? Villa { get; set; }
        public string SpecialDetails { get; set; } = string.Empty;

        public DateTime? CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

    }
}
