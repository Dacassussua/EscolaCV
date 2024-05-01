using AutoMapper;
using EscolaCV.Core.Domain.Entities;
using EscolaCV.Core.Share.AppSettings;
using EscolaCV.Core.Share.DTOs.EscolaDto;

namespace EscolaCV.Manager.Mapping.EscolaMapping
{
    public class UpdateEscolaMappingProfile:Profile
    {
        public UpdateEscolaMappingProfile()
        {
            CreateMap<UpdateEscolaDto, Escola>()
                  .ForMember(x => x.UpdateUserId, c => c.MapFrom(z => StringConst.UserId))
                  .ForMember(x => x.UpdateDate, c => c.MapFrom(x => DateTime.Now))
                  .ReverseMap();
        }
    }
}
