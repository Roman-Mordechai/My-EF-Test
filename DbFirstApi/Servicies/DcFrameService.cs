using AutoMapper;
using DbFirstApi.Domain.DataServices;
using DbFirstApi.Domain.Entities;
using DbFirstApi.Domain.Models;
using DbFirstApi.Domain.Models.DcFrame;
using DbFirstApi.Domain.Servicies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbFirstApi.Servicies
{
    public class DcFrameService : IDcFrameService
    {
        private readonly IDcFrameDataService _dcFrameDataService;
        private readonly IDcManagerDataService _dcManagerDataService;
        private readonly IMapper _mapper;

        public DcFrameService(
            IDcFrameDataService dcFrameDataService,
            IDcManagerDataService dcManagerDataService,
            IMapper mapper
            )
        {
            _dcFrameDataService = dcFrameDataService;
            _dcManagerDataService = dcManagerDataService;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> AddDcFrame(AddDcFrameDto dcFrameDto)
        {
            DcFrameEntity dcFrame = _mapper.Map<DcFrameEntity>(dcFrameDto);
            return await _dcFrameDataService.AddDcFrame(dcFrame);
        }
        public async Task<ServiceResponse<List<GetDcFrameDto>>> GetAllDcFrames()
        {
            var serviceResponse = new ServiceResponse<List<GetDcFrameDto>>();
            var rsp = await _dcFrameDataService.GetAllDcFrames();
            if (rsp != null)
            {
                serviceResponse.Data = _mapper.Map<List<GetDcFrameDto>>(rsp.Data);
            }
            else
            {
                serviceResponse.Message = "No data found!";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetDcFrameDto>> GetDcFrameById(int id)
        {
            var serviceResponse = new ServiceResponse<GetDcFrameDto>();
            var rsp = await _dcFrameDataService.GetDcFrameById(id);
            if (rsp != null)
            {
                serviceResponse.Data = _mapper.Map<GetDcFrameDto>(rsp.Data);
            }
            else
            {
                serviceResponse.Message = "No data found!";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetDcFrameDto>> GetDcFrameByFrameCode(int frameCode)
        {
            var serviceResponse = new ServiceResponse<GetDcFrameDto>();
            var rsp = await _dcFrameDataService.GetDcFrameByFrameCode(frameCode);
            if (rsp != null)
            {
                serviceResponse.Data = _mapper.Map<GetDcFrameDto>(rsp.Data);
            }
            else
            {
                serviceResponse.Message = "No data found!";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse> UpdateDcFrame(UpdateDcFrameDto dcFrameDto)
        {
            var serviceResponse = new ServiceResponse();

            var frameData = await _dcFrameDataService.GetDcFrameById(dcFrameDto.Id, dcFrameDto.FrameCode);
            if (frameData.Data != null)
            {
                _mapper.Map(dcFrameDto, frameData.Data);
                serviceResponse = await _dcFrameDataService.UpdateDcFrame(frameData.Data);
                if (serviceResponse.Success)
                {
                    serviceResponse.Message = $"Id {dcFrameDto.Id} updated.";
                }
            }
            else
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Id {dcFrameDto.Id}, FrameCode {dcFrameDto.FrameCode} not found.";
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse> DeleteDcFrame(int id)
        {
            var serviceResponse = new ServiceResponse();

            var frameData = await _dcFrameDataService.GetDcFrameById(id);
            if (frameData.Data != null)
            {
                serviceResponse = await _dcFrameDataService.DeleteDcFrame(frameData.Data);
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
