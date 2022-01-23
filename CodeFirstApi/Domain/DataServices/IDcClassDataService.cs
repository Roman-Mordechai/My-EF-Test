using CodeFirstApi.Domain.Entities;
using CodeFirstApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Domain.DataServices
{
    public interface IDcClassDataService
    {
        Task<ServiceResponse> AddDcClass(DcFrameEntity dcFrame);
        Task<ServiceResponse<DcClassEntity>> GetDcClassById(int id);
        Task<ServiceResponse<DcClassEntity>> GetDcClassById(int id, int frameId);
        Task<ServiceResponse<List<DcClassEntity>>> GetDcClassesByFrameId(int frameId);
        Task<ServiceResponse<List<DcClassEntity>>> GetDcClassesByFrameCode(int frameCode);
        Task<ServiceResponse> UpdateDcClass(DcClassEntity dcClass);
        Task<ServiceResponse> DeleteDcClass(DcClassEntity dcClass);
    }
}
