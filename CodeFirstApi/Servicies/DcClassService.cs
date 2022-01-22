using CodeFirstApi.Domain.DataServices;
using CodeFirstApi.Domain.Models.DcClasses;
using CodeFirstApi.Domain.Servicies;
using CodeFirstApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Servicies
{
    public class DcClassService : IDcClassService
    {
        private readonly IDcClassDataService _dcClassDataService;
        private readonly ILogger<DcClassService> _logger;
        public DcClassService(
            IDcClassDataService dcClassDataService,
            ILogger<DcClassService> logger
            )
        {
            _dcClassDataService = dcClassDataService;
            _logger = logger;
        }

        public async Task<ServiceResponse<GetDcClassDto>> AddDcClass(AddDcClassDto dcClassDto)
        {
            var serviceResponse = new ServiceResponse<GetDcClassDto>();

            try
            {
                serviceResponse.Data = await _dcClassDataService.AddDcClass(dcClassDto);
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "AddDcClass service failed! " + ex.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<GetDcClassDto>> GetDcClassById(int id)
        {
            var serviceResponse = new ServiceResponse<GetDcClassDto>();

            try
            {
                serviceResponse.Data = await _dcClassDataService.GetDcClassById(id);
                if (serviceResponse.Data == null)
                {
                    serviceResponse.Message = $"Id {id} not found.";
                }
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "GetDcClassById service failed! " + ex.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<List<GetDcClassDto>>> GetDcClassesByFrameId(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetDcClassDto>>();

            try
            {
                serviceResponse.Data = await _dcClassDataService.GetDcClassesByFrameId(id);
                if (serviceResponse.Data == null)
                {
                    serviceResponse.Message = $"Id {id} not found.";
                }
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "GetDcClassesByFrameId service failed! " + ex.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<List<GetDcClassDto>>> GetDcClassesByFrameCode(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetDcClassDto>>();

            try
            {
                serviceResponse.Data = await _dcClassDataService.GetDcClassesByFrameCode(id);
                if (serviceResponse.Data == null)
                {
                    serviceResponse.Message = $"Id {id} not found.";
                }
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "GetDcClassesByFrameCode service failed! " + ex.Message;
                return serviceResponse;
            }

        }
        public async Task<ServiceResponse<GetDcClassDto>> UpdateDcClass(UpdateDcClassDto dcClassDto)
        {
            var serviceResponse = new ServiceResponse<GetDcClassDto>();

            try
            {
                var classData = await _dcClassDataService.GetDcClassById(dcClassDto.Id, dcClassDto.DcFrameId);
                if (classData != null)
                {
                    serviceResponse.Data = await _dcClassDataService.UpdateDcClass(dcClassDto);
                    serviceResponse.Message = $"ClassId {dcClassDto.Id} was updated.";
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Record with Id = {dcClassDto.Id} and FrameId = {dcClassDto.DcFrameId} not found.";
                    return serviceResponse;
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "UpdateDcClass service failed! " + ex.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<GetDcClassDto>> DeleteDcClass(int id)
        {
            var serviceResponse = new ServiceResponse<GetDcClassDto>();

            try
            {
                var classData = await _dcClassDataService.GetDcClassById(id);
                if (classData != null)
                {
                    serviceResponse.Data = await _dcClassDataService.DeleteDcClass(classData);
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
                serviceResponse.Message = "DeleteDcClass service failed! " + ex.Message;
                return serviceResponse;
            }
        }
    }

}
