using DbFirstApi.Domain.Models;
using DbFirstApi.Domain.Models.DcManager;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbFirstApi.Domain.Servicies
{
    public interface IDcManagerService
    {
        Task<ServiceResponse> AddDcManager(AddDcManagerDto dcManagerDto);
        Task<ServiceResponse<List<GetDcManagerDto>>> GetAllDcManagers();
        Task<ServiceResponse<GetDcManagerDto>> GetDcManagerById(int id);
        Task<ServiceResponse<GetDcManagerDto>> GetDcManagerByManagerId(int id);
        Task<ServiceResponse> UpdateDcManager(UpdateDcManagerDto dcManagerDto);
        Task<ServiceResponse> DeleteDcManager(int id);

    }
}
