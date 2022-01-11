using AutoMapper;
using CodeFirstApi.Entities;
using CodeFirstApi.Models.DcClasses;
using CodeFirstApi.Models.DcFrame;
using CodeFirstApi.Models.DcManager;
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
            CreateMap<AddDcFrameDto, DcFrameEntity>();
            CreateMap<AddDcClassDto, DcClassEntity>();
            
            CreateMap<DcManagerEntity, GetDcManagerDto>();
            CreateMap<DcFrameEntity, GetDcFrameDto>();
            CreateMap<DcClassEntity, GetDcClassDto>();

        }
    }
}

