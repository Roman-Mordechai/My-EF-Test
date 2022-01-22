using CodeFirstApi.Domain.Models.DcManager;
using CodeFirstApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Domain.Servicies
{
    public interface IDcManagerService
    {
        Task<ServiceResponse> AddDcManager(AddDcManagerDto dcManagerDto);
        Task<ServiceResponse<List<GetDcManagerDto>>> GetAllDcManagers();
        Task<ServiceResponse<GetDcManagerDto>> GetDcManagerById(int id);
        Task<ServiceResponse<GetDcManagerDto>> GetDcManagerByManagerId(int id);
        Task<ServiceResponse> UpdateDcManager(GetDcManagerDto dcManagerDto);
        Task<ServiceResponse> DeleteDcManager(int id);
    }
}
