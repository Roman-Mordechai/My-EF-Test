using CodeFirstApi.Entities;
using CodeFirstApi.Models;
using CodeFirstApi.Models.DcFrame;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Servicies
{
    public interface IDcFrameDataService
    {
        Task<ServiceResponse<List<GetDcFrameDto>>> AddFrame(AddDcFrameDto addDcFrame);
        Task<ServiceResponse<List<GetDcFrameDto>>> GetAllFrames();
    }
}
