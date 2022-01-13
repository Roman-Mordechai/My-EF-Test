using CodeFirstApi.Domain.Models.DcManager;
using CodeFirstApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Domain.Servicies
{
    public interface IDcManagerService
    {
        Task<ServiceResponse<GetDcManagerDto>> AddDcManager(AddDcManagerDto dcManagerDto);
        Task<ServiceResponse<List<GetDcManagerDto>>> GetAllDcManagers();
        Task<ServiceResponse<GetDcManagerDto>> GetDcManagerById(int id);
        Task<ServiceResponse<GetDcManagerDto>> GetDcManagerByManagerId(int id);
        Task<ServiceResponse<GetDcManagerDto>> UpdateDcManager(GetDcManagerDto dcManagerDto);
        Task<ServiceResponse<GetDcManagerDto>> DeleteDcManager(int id);
    }
}
