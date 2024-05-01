using AutoMapper;
using EscolaCV.Core.Share.DTOs.EscolaDto;

namespace EscolaCV.Manager.Mapping.EscolaMapping
{
    public class ExcelEscolaMappingProfile : Profile
    {
        public ExcelEscolaMappingProfile()
        {
            CreateMap<ExcelEscolaDto, CreateEscolaDto>()
                .ReverseMap();
        }
    }
}
