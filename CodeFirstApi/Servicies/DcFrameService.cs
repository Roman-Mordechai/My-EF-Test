using CodeFirstApi.Domain.DataServices;
using CodeFirstApi.Domain.Models.DcFrame;
using CodeFirstApi.Domain.Servicies;
using CodeFirstApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Servicies
{
    public class DcFrameService : IDcFrameService
    {
        private readonly IDcFrameDataService _dcFrameDataService;

        public DcFrameService(IDcFrameDataService dcFrameDataService)
        {
            _dcFrameDataService = dcFrameDataService;
        }

        public async Task<ServiceResponse<GetDcFrameDto>> AddDcFrame(AddDcFrameDto dcFrameDto)
        {
            var serviceResponse = new ServiceResponse<GetDcFrameDto>();

            try
            {
                serviceResponse.Data = await _dcFrameDataService.AddDcFrame(dcFrameDto);
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "AddFrame service failed! " + ex.Message;
                return serviceResponse;
            }
            
        }
        public async Task<ServiceResponse<List<GetDcFrameDto>>> GetAllDcFrames()
        {
            var serviceResponse = new ServiceResponse<List<GetDcFrameDto>>();

            try
            {
                serviceResponse.Data = await _dcFrameDataService.GetAllDcFrames();
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "GetAllFrames service failed! " + ex.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<GetDcFrameDto>> GetDcFrameById(int id)
        {
            var serviceResponse = new ServiceResponse<GetDcFrameDto>();

            try
            {
                serviceResponse.Data = await _dcFrameDataService.GetDcFrameById(id);
                if (serviceResponse.Data == null)
                {
                    serviceResponse.Message = $"Id {id} not found.";
                }
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "GetDcFrameById service failed! " + ex.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<GetDcFrameDto>> GetDcFrameByFrameCode(int frameCode)
        {
            var serviceResponse = new ServiceResponse<GetDcFrameDto>();

            try
            {
                serviceResponse.Data = await _dcFrameDataService.GetDcFrameByFrameCode(frameCode);
                if (serviceResponse.Data == null)
                {
                    serviceResponse.Message = $"Frame code {frameCode} not found.";
                }
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "GetDcFrameByFrameCode service failed! " + ex.Message;
                return serviceResponse;
            }
        }
        public async Task<ServiceResponse<GetDcFrameDto>> UpdateDcFrame(UpdateDcFrameDto dcFrameDto)
        {
            var serviceResponse = new ServiceResponse<GetDcFrameDto>();

            try
            {
                var frameData = await _dcFrameDataService.GetDcFrameById(dcFrameDto.Id, dcFrameDto.FrameCode);
                if (frameData != null)
                {
                    serviceResponse.Data = await _dcFrameDataService.UpdateDcFrame(dcFrameDto);
                    serviceResponse.Message = $"Frame code {dcFrameDto.FrameCode} was updated.";
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Record with Id = {dcFrameDto.Id} and Frame code = {dcFrameDto.FrameCode} not found.";
                    return serviceResponse;
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "UpdateDcFrame service failed! " + ex.Message;
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<GetDcFrameDto>> DeleteDcFrame(int id)
        {
            var serviceResponse = new ServiceResponse<GetDcFrameDto>();

            try
            {
                var frameData = await _dcFrameDataService.GetDcFrameById(id);
                if (frameData != null)
                {
                    serviceResponse.Data = await _dcFrameDataService.DeleteDcFrame(frameData);
                    serviceResponse.Message = $"Id {id} was deleted.";
                    return serviceResponse;
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Id = {id} not found.";
                    return serviceResponse;
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "UpdateDcFrame service failed! " + ex.Message;
                return serviceResponse;
            }
        }
    }
}
