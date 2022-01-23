using AutoMapper;
using DbFirstApi.Domain.Entities;
using DbFirstApi.Domain.Models.DcClasses;
using DbFirstApi.Domain.Models.DcFrame;
using DbFirstApi.Domain.Models.DcManager;

namespace DbFirstApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddDcManagerDto, DcManagerEntity>();
            CreateMap<UpdateDcManagerDto, DcManagerEntity>();
            CreateMap<DcManagerEntity, GetDcManagerDto>();
            CreateMap<GetDcManagerDto, DcManagerEntity>();
            

            CreateMap<AddDcFrameDto, DcFrameEntity>();
            CreateMap<UpdateDcFrameDto, DcFrameEntity>();
            CreateMap<DcFrameEntity, GetDcFrameDto>();
            CreateMap<GetDcFrameDto, DcFrameEntity>();
            

            CreateMap<AddDcClassDto, DcClassEntity>();
            CreateMap<UpdateDcClassDto, DcClassEntity>();
            CreateMap<DcClassEntity, GetDcClassDto>();
            CreateMap<GetDcClassDto, DcClassEntity>();
            

        }
    }
}
