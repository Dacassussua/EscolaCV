using AutoMapper;
using EscolaCV.Core.Domain.Entities;
using EscolaCV.Core.Share.AppSettings;
using EscolaCV.Core.Share.DTOs.ProvinciaDto;

namespace EscolaCV.Manager.Mapping.ProvinciaMapping
{
    public class UpdateProvinciaMappingProfile:Profile
    {
        public UpdateProvinciaMappingProfile()
        {
            CreateMap<UpdateProvinciaDto, Provincia>()
                  .ForMember(x => x.UpdateUserId, c => c.MapFrom(z => StringConst.UserId))
                  .ForMember(x => x.UpdateDate, c => c.MapFrom(x => DateTime.Now))
                  .ReverseMap();
        }
    }
}
