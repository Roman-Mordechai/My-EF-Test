using DbFirstApi.Domain.Entities;
using DbFirstApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbFirstApi.Domain.DataServices
{
    public interface IDcClassDataService
    {
        Task<ServiceResponse> AddDcClass(DcClassEntity dcClass);
        Task<ServiceResponse<DcClassEntity>> GetDcClassById(int id);
        Task<ServiceResponse<DcClassEntity>> GetDcClassById(int id, int frameId);
        Task<ServiceResponse<List<DcClassEntity>>> GetDcClassesByFrameId(int frameId);
        Task<ServiceResponse<List<DcClassEntity>>> GetDcClassesByFrameCode(int frameCode);
        Task<ServiceResponse> UpdateDcClass(DcClassEntity dcClass);
        Task<ServiceResponse> DeleteDcClass(DcClassEntity dcClass);
    }
}
