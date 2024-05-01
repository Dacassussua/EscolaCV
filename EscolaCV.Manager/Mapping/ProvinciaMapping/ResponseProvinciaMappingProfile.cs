using AutoMapper;
using EscolaCV.Core.Domain.Entities;
using EscolaCV.Core.Share.DTOs.ProvinciaDto;

namespace EscolaCV.Manager.Mapping.ProvinciaMapping
{
    public class ResponseProvinciaMappingProfile : Profile
    {
        public ResponseProvinciaMappingProfile()
        {
            CreateMap<ResponseProvinciaDto, Provincia>()
                    .ReverseMap();
        }
    }
}
