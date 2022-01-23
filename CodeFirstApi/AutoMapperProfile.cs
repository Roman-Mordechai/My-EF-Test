using AutoMapper;
using CodeFirstApi.Domain.Models.DcManager;
using CodeFirstApi.Domain.Models.DcFrame;
using CodeFirstApi.Domain.Models.DcClasses;
using CodeFirstApi.Domain.Entities;

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
            CreateMap<GetDcFrameDto, DcFrameEntity>();
            CreateMap<UpdateDcFrameDto, DcFrameEntity>();

            CreateMap<AddDcClassDto, DcClassEntity>();
            CreateMap<DcClassEntity, GetDcClassDto>();
            CreateMap<GetDcClassDto, DcClassEntity>();
            CreateMap<UpdateDcClassDto, DcClassEntity>();

        }
    }
}

