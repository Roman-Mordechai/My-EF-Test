using CodeFirstApi.Domain.Models.DcFrame;
using CodeFirstApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Domain.Servicies
{
    public interface IDcFrameService
    {
        Task<ServiceResponse<GetDcFrameDto>> AddDcFrame(AddDcFrameDto dcFrameDto);
        Task<ServiceResponse<List<GetDcFrameDto>>> GetAllDcFrames();
        Task<ServiceResponse<GetDcFrameDto>> GetDcFrameById(int id);
        Task<ServiceResponse<GetDcFrameDto>> GetDcFrameByFrameCode(int id);
        Task<ServiceResponse<GetDcFrameDto>> UpdateDcFrame(UpdateDcFrameDto dcFrameDto);
        Task<ServiceResponse<GetDcFrameDto>> DeleteDcFrame(int id);
    }
}
