using CodeFirstApi.Domain.Models.DcFrame;
using CodeFirstApi.Entities;
using CodeFirstApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Servicies
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
