using AutoMapper;
using EscolaCV.Core.Domain.Entities;
using EscolaCV.Core.Share.AppSettings;
using EscolaCV.Core.Share.DTOs.PaisDto;

namespace EscolaCV.Manager.Mapping.PaisMapping
{
    public class UpdatePaisMappingProfile : Profile
    {
        public UpdatePaisMappingProfile()
        {
            CreateMap<UpdatePaisDto, Pais>()
                        .ForMember(x => x.UpdateUserId, c => c.MapFrom(z => StringConst.UserId))
                        .ForMember(x => x.UpdateDate, c => c.MapFrom(x => DateTime.Now))
                        .ReverseMap();
        }
    }
}
