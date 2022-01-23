using AutoMapper;
using DbFirstApi.Domain.DataServices;
using DbFirstApi.Domain.Entities;
using DbFirstApi.Domain.Models;
using DbFirstApi.Domain.Models.DcManager;
using DbFirstApi.Domain.Servicies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbFirstApi.Servicies
{
    public class DcManagerService : IDcManagerService
    {
        private readonly IDcManagerDataService _dcManagerDataService;
        private readonly IMapper _mapper;

        public DcManagerService(
            IDcManagerDataService dcManagerDataService,
            IMapper mapper
            )
        {
            _dcManagerDataService = dcManagerDataService;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> AddDcManager(AddDcManagerDto dcManagerDto)
        {
            DcManagerEntity dcManager = _mapper.Map<DcManagerEntity>(dcManagerDto);
            return await _dcManagerDataService.AddDcManager(dcManager);
        }
        public async Task<ServiceResponse<List<GetDcManagerDto>>> GetAllDcManagers()
        {
            var serviceResponse = new ServiceResponse<List<GetDcManagerDto>>();
            var rsp = await _dcManagerDataService.GetAllDcManagers();
            if (rsp != null)
            {
                serviceResponse.Data = _mapper.Map<List<GetDcManagerDto>>(rsp.Data);
            }
            else
            {
                serviceResponse.Message = "No data found!";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetDcManagerDto>> GetDcManagerById(int id)
        {
            var serviceResponse = new ServiceResponse<GetDcManagerDto>();
            var rsp = await _dcManagerDataService.GetDcManagerById(id);
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
        public async Task<ServiceResponse<GetDcManagerDto>> GetDcManagerByManagerId(int id)
        {
            var serviceResponse = new ServiceResponse<GetDcManagerDto>();
            var rsp = await _dcManagerDataService.GetDcManagerByManagerId(id);
            if (rsp.Data != null)
            {
                serviceResponse.Data = _mapper.Map<GetDcManagerDto>(rsp.Data);
            }
            else
            {
                serviceResponse.Message = $"ManagerId {id} not found.";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse> UpdateDcManager(UpdateDcManagerDto dcManagerDto)
        {
            var serviceResponse = new ServiceResponse();
            var managerData = await _dcManagerDataService.GetDcManagerById(dcManagerDto.Id, dcManagerDto.ManagerId);
            if (managerData.Data != null)
            {
                _mapper.Map(dcManagerDto, managerData.Data);
                serviceResponse = await _dcManagerDataService.UpdateDcManager(managerData.Data);
                if (serviceResponse.Success)
                {
                    serviceResponse.Message = $"Id {dcManagerDto.Id} updated.";
                }
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Id {dcManagerDto.Id}, ManagerId {dcManagerDto.ManagerId} not found.";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse> DeleteDcManager(int id)
        {
            var serviceResponse = new ServiceResponse();
            var managerData = await _dcManagerDataService.GetDcManagerById(id);
            if (managerData.Data != null)
            {
                serviceResponse = await _dcManagerDataService.DeleteDcManager(managerData.Data);
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
