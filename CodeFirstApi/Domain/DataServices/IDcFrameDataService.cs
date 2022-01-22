using CodeFirstApi.Domain.Models.DcFrame;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Domain.DataServices
{
    public interface IDcFrameDataService
    {
        Task<GetDcFrameDto> AddDcFrame(AddDcFrameDto dcFrameDto);
        Task<List<GetDcFrameDto>> GetAllDcFrames();
        Task<GetDcFrameDto> GetDcFrameById(int id);
        Task<GetDcFrameDto> GetDcFrameById(int id, int frameCode);
        Task<GetDcFrameDto> GetDcFrameByFrameCode(int frameCode);
        Task<GetDcFrameDto> UpdateDcFrame(UpdateDcFrameDto dcFrameDto);
        Task<GetDcFrameDto> DeleteDcFrame(GetDcFrameDto dcFrameDto);
    }
}
