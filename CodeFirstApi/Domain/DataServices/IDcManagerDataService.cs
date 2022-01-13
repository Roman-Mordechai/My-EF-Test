using CodeFirstApi.Domain.Models.DcManager;
using CodeFirstApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Servicies
{
    public interface IDcManagerDataService
    {
        Task<GetDcManagerDto> AddDcManager(AddDcManagerDto dcManagerDto);
        Task<List<GetDcManagerDto>> GetAllDcManagers();
        Task<GetDcManagerDto> GetDcManagerById(int id);
        Task<GetDcManagerDto> GetDcManagerById(int id, int managerId);
        Task<GetDcManagerDto> GetDcManagerByManagerId(int id);
        Task<GetDcManagerDto> UpdateDcManager(GetDcManagerDto dcManagerDto);
        Task<GetDcManagerDto> DeleteDcManager(GetDcManagerDto dcManagerDto);
    }
}
