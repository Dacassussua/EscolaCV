﻿using AutoMapper;
using EscolaCV.Core.Domain.Entities;
using EscolaCV.Core.Share.AppSettings;
using EscolaCV.Core.Share.DTOs.PaisDto;

namespace EscolaCV.Manager.Mapping.PaisMapping
{
    public class CreatePaisMappingProfile : Profile
    {
        public CreatePaisMappingProfile()
        {
            CreateMap<CreatePaisDto, Pais>()
                           .ForMember(x => x.CreatedDate, c => c.MapFrom(x => DateTime.Now))
                          .ForMember(x => x.CreateUserId, c => c.MapFrom(z => StringConst.UserId))
                          .ForMember(x => x.UpdateUserId, c => c.MapFrom(z => StringConst.UserId))
                          .ForMember(x => x.UpdateDate, c => c.MapFrom(x => DateTime.Now))
                          .ReverseMap();
        }
    }
}
