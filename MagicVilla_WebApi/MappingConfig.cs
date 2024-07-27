using AutoMapper;
using MagicVilla_WebApi.Models;
using MagicVilla_WebApi.Models.DTO;

namespace MagicVilla_WebApi
{
    public class MappingConfig: Profile
    {

        public MappingConfig()
        {
            CreateMap<Villa, VillaDto>().ReverseMap();
            CreateMap<Villa, VillaCreateDto>().ReverseMap();

            CreateMap<Villa, VillaUpdateDto>().ReverseMap();
            
            CreateMap<VillaNumber, VillaNumberDto>().ReverseMap();
            CreateMap<VillaNumber, VillaCreateDto>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberUpdateDto>().ReverseMap();
        }
    }
}
