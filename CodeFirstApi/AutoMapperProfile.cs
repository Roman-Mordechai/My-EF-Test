using AutoMapper;
using CodeFirstApi.Domain.Models.DcManager;
using CodeFirstApi.Domain.Models.DcFrame;
using CodeFirstApi.Entities;
using CodeFirstApi.Models.DcClasses;
using CodeFirstApi.Models.DcFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddDcManagerDto, DcManagerEntity>();
            CreateMap<DcManagerEntity, GetDcManagerDto>();
            CreateMap<GetDcManagerDto, DcManagerEntity>();

            CreateMap<AddDcFrameDto, DcFrameEntity>();
            CreateMap<DcFrameEntity, GetDcFrameDto>();

            CreateMap<DcClassEntity, GetDcClassDto>();
            CreateMap<AddDcClassDto, DcClassEntity>();
        }
    }
}

