using MagicVilla_WebApi.Models.DTO;

namespace MagicVilla_WebApi.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> VillaList = new List<VillaDto>
            {
                new VillaDto { Id = 1, Name = "Pool View", Sqft=100, Occupancy=4},
                new VillaDto { Id = 2, Name = "Ocean View", Sqft=100, Occupancy=4}
            };
    }
}
