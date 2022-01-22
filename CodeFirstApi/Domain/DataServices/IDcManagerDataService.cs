using CodeFirstApi.Domain.Models.DcManager;
using CodeFirstApi.Entities;
using CodeFirstApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Domain.DataServices
{
    public interface IDcManagerDataService
    {
        Task<ServiceResponse> AddDcManager(DcManagerEntity dcManager);
        Task<ServiceResponse<List<DcManagerEntity>>> GetAllDcManagers();
        Task<ServiceResponse<DcManagerEntity>> GetDcManagerById(int id);
        Task<ServiceResponse<DcManagerEntity>> GetDcManagerById(int id, int managerId);
        Task<ServiceResponse<DcManagerEntity>> GetDcManagerByManagerId(int id);
        Task<ServiceResponse> UpdateDcManager(DcManagerEntity dcManager);
        Task<ServiceResponse> DeleteDcManager(DcManagerEntity dcManager);
    }
}
