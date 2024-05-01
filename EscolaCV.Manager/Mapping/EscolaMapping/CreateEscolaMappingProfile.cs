using AutoMapper;
using EscolaCV.Core.Domain.Entities;
using EscolaCV.Core.Share.AppSettings;
using EscolaCV.Core.Share.DTOs.EscolaDto;

namespace EscolaCV.Manager.Mapping.EscolaMapping
{
    public class CreateEscolaMappingProfile : Profile
    {
        public CreateEscolaMappingProfile()
        {
            CreateMap<CreateEscolaDto, Escola>()
              .ForMember(x => x.CreatedDate, c => c.MapFrom(x => DateTime.Now))
              .ForMember(x => x.CreateUserId, c => c.MapFrom(z => StringConst.UserId))
              .ForMember(x => x.UpdateUserId, c => c.MapFrom(z => StringConst.UserId))
              .ForMember(x => x.UpdateDate, c => c.MapFrom(x => DateTime.Now))
                .ForMember(x => x.provincia, opt => opt.Ignore())
              .ReverseMap();

        }
    }
}
