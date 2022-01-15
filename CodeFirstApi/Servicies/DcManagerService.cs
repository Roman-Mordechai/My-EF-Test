using CodeFirstApi.Domain.Models.DcManager;
using CodeFirstApi.Domain.Servicies;
using CodeFirstApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Servicies
{
    public class DcManagerService : IDcManagerService
    {
        private readonly IDcManagerDataService _dcManagerDataService;
        private readonly ILogger<DcManagerService> _logger;

        public DcManagerService(
            IDcManagerDataService dcManagerDataService,
            ILogger<DcManagerService> logger)
        {
            _dcManagerDataService = dcManagerDataService;
            _logger = logger;
        }

        public async Task<ServiceResponse<GetDcManagerDto>> AddDcManager(AddDcManagerDto dcManagerDto)
        {
            var serviceResponse = new ServiceResponse<GetDcManagerDto>();

            try
            {
                serviceResponse.Data = await _dcManagerDataService.AddDcManager(dcManagerDto);
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "AddDcManager service failed! " + ex.Message;
                return serviceResponse;
            }

        }

        public async Task<ServiceResponse<List<GetDcManagerDto>>> GetAllDcManagers()
        {
            _logger.LogInformation("Started");

            var serviceResponse = new ServiceResponse<List<GetDcManagerDto>>();

            try
            {
                serviceResponse.Data = await _dcManagerDataService.GetAllDcManagers();
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "GetAllManagers service failed! " + ex.Message;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetDcManagerDto>> GetDcManagerById(int id)
        {
            var serviceResponse = new ServiceResponse<GetDcManagerDto>();

            try
            {
                serviceResponse.Data = await _dcManagerDataService.GetDcManagerById(id);
                if (serviceResponse.Data == null)
                {
                    serviceResponse.Message = $"Id {id} not found.";
                }
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "GetDcManagerById service failed! " + ex.Message;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetDcManagerDto>> GetDcManagerByManagerId(int id)
        {
            var serviceResponse = new ServiceResponse<GetDcManagerDto>();

            try
            {
                serviceResponse.Data = await _dcManagerDataService.GetDcManagerByManagerId(id);
                if (serviceResponse.Data == null)
                {
                    serviceResponse.Message = $"ManagerId {id} not found.";
                }
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "GetDcManagerByManagerId service failed! " + ex.Message;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetDcManagerDto>> UpdateDcManager(GetDcManagerDto dcManagerDto)
        {
            var serviceResponse = new ServiceResponse<GetDcManagerDto>();

            try
            {
                var managerData = await _dcManagerDataService.GetDcManagerById(dcManagerDto.Id, dcManagerDto.ManagerId);
                if (managerData != null)
                {
                    serviceResponse.Data = await _dcManagerDataService.UpdateDcManager(dcManagerDto);
                    serviceResponse.Message = $"ManagerId {dcManagerDto.ManagerId} was updated.";
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Record with Id = {dcManagerDto.Id} and ManagerId = {dcManagerDto.ManagerId} not found.";
                    return serviceResponse;
                }
                
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "UpdateDcManager service failed! " + ex.Message;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetDcManagerDto>> DeleteDcManager(int id)
        {
            var serviceResponse = new ServiceResponse<GetDcManagerDto>();

            try
            {
                var managerData = await _dcManagerDataService.GetDcManagerById(id);
                if (managerData != null)
                {
                    serviceResponse.Data = await _dcManagerDataService.DeleteDcManager(managerData);
                    serviceResponse.Message = $"Id {id} deleted.";
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Id {id} not found.";
                    return serviceResponse;
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "DeleteDcManager service failed! " + ex.Message;
                return serviceResponse;
            }
        }

    }
}
