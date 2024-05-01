using AutoMapper;
using EscolaCV.Core.Domain.Entities;
using EscolaCV.Core.Share.DTOs.PaisDto;

namespace EscolaCV.Manager.Mapping.PaisMapping
{
    public class ResponsePaisMappingProfile:Profile
    {
        public ResponsePaisMappingProfile()
        {
            CreateMap<ResponsePaisDto, Pais>()
                    .ReverseMap();
        }
    }
}
