using AutoMapper;
using EscolaCV.Core.Domain.Entities;
using EscolaCV.Core.Share.DTOs.EscolaDto;

namespace EscolaCV.Manager.Mapping.EscolaMapping
{
    public class ResponseEscolaMappingProfile:Profile
    {
        public ResponseEscolaMappingProfile()
        {
            CreateMap<ResponseEscolaDto, Escola>()
           .ReverseMap();
        }
    }
}
