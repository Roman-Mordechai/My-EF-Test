using CodeFirstApi.Domain.Models;
using CodeFirstApi.Domain.Models.DcFrame;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Domain.Servicies
{
    public interface IDcFrameService
    {
        Task<ServiceResponse> AddDcFrame(AddDcFrameDto dcFrameDto);
        Task<ServiceResponse<List<GetDcFrameDto>>> GetAllDcFrames();
        Task<ServiceResponse<GetDcFrameDto>> GetDcFrameById(int id);
        Task<ServiceResponse<GetDcFrameDto>> GetDcFrameByFrameCode(int id);
        Task<ServiceResponse> UpdateDcFrame(UpdateDcFrameDto dcFrameDto);
        Task<ServiceResponse> DeleteDcFrame(int id);
    }
}
