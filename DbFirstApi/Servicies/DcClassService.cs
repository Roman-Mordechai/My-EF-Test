using AutoMapper;
using DbFirstApi.Domain.DataServices;
using DbFirstApi.Domain.Entities;
using DbFirstApi.Domain.Models;
using DbFirstApi.Domain.Models.DcClasses;
using DbFirstApi.Domain.Servicies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbFirstApi.Servicies
{
    public class DcClassService : IDcClassService
    {
        private readonly IDcClassDataService _dcClassDataService;
        private readonly IDcFrameDataService _dcFrameDataService;
        private readonly IMapper _mapper;
        public DcClassService(
            IDcClassDataService dcClassDataService,
            IDcFrameDataService dcFrameDataService,
            IMapper mapper
            )
        {
            _dcClassDataService = dcClassDataService;
            _dcFrameDataService = dcFrameDataService;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> AddDcClass(AddDcClassDto dcClassDto)
        {
            var dcClass = _mapper.Map<DcClassEntity>(dcClassDto);
            return await _dcClassDataService.AddDcClass(dcClass);
        }
        public async Task<ServiceResponse<GetDcClassDto>> GetDcClassById(int id)
        {
            var serviceResponse = new ServiceResponse<GetDcClassDto>();

            var rsp = await _dcClassDataService.GetDcClassById(id);
            if (rsp.Data != null)
            {
                serviceResponse.Data = _mapper.Map(rsp.Data, serviceResponse.Data);
            }
            else
            {
                serviceResponse.Message = $"Id {id} not found.";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<GetDcClassDto>>> GetDcClassesByFrameId(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetDcClassDto>>();

            var rsp = await _dcClassDataService.GetDcClassesByFrameId(id);
            if (rsp.Data != null)
            {
                serviceResponse.Data = _mapper.Map(rsp.Data, serviceResponse.Data);
            }
            else
            {
                serviceResponse.Message = $"Id {id} not found.";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse> UpdateDcClass(UpdateDcClassDto dcClassDto)
        {
            var serviceResponse = new ServiceResponse();

            var classData = await _dcClassDataService.GetDcClassById(dcClassDto.Id);
            if (classData.Data != null)
            {
                _mapper.Map(dcClassDto, classData.Data);
                serviceResponse = await _dcClassDataService.UpdateDcClass(classData.Data);
                if (serviceResponse.Success)
                {
                    serviceResponse.Message = $"Id {dcClassDto.Id} updated.";
                }
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Id {dcClassDto.Id} not found.";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse> DeleteDcClass(int id)
        {
            var serviceResponse = new ServiceResponse();

            var classData = await _dcClassDataService.GetDcClassById(id);
            if (classData.Data != null)
            {
                serviceResponse = await _dcClassDataService.DeleteDcClass(classData.Data);
                serviceResponse.Message = $"Id {id} deleted.";
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Id {id} not found.";
            }
            return serviceResponse;
        }
    }

}
