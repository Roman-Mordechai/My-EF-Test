using CodeFirstApi.Domain.Models.DcFrame;
using CodeFirstApi.Domain.Servicies;
using CodeFirstApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ServiceResponse<List<GetDcFrameDto>>> AddFrame(AddDcFrameDto addDcFrame)
        {
            var serviceResponse = new ServiceResponse<List<GetDcFrameDto>>();

            try
            {
                return await _dcFrameDataService.AddFrame(addDcFrame);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "AddFrame service failed! " + ex.Message;
                return serviceResponse;
            }
            
        }

        public async Task<ServiceResponse<List<GetDcFrameDto>>> GetAllFrames()
        {
            var serviceResponse = new ServiceResponse<List<GetDcFrameDto>>();

            try
            {
                return await _dcFrameDataService.GetAllFrames();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "GetAllFrames service failed! " + ex.Message;
                return serviceResponse;
            }
        }
    }
}
