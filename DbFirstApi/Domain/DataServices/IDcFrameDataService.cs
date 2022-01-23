using DbFirstApi.Domain.Entities;
using DbFirstApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbFirstApi.Domain.DataServices
{
    public interface IDcFrameDataService
    {
        Task<ServiceResponse> AddDcFrame(DcFrameEntity dcFrame);
        Task<ServiceResponse<List<DcFrameEntity>>> GetAllDcFrames();
        Task<ServiceResponse<DcFrameEntity>> GetDcFrameById(int id);
        Task<ServiceResponse<DcFrameEntity>> GetDcFrameById(int id, int frameCode);
        Task<ServiceResponse<DcFrameEntity>> GetDcFrameByFrameCode(int frameCode);
        Task<ServiceResponse> UpdateDcFrame(DcFrameEntity dcFrame);
        Task<ServiceResponse> DeleteDcFrame(DcFrameEntity dcFrame);
    }
}
