using DbFirstApi.Domain.Models.DcClasses;
using DbFirstApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbFirstApi.Domain.Servicies
{
    public interface IDcClassService
    {
        Task<ServiceResponse> AddDcClass(AddDcClassDto dcClassDto);
        Task<ServiceResponse<GetDcClassDto>> GetDcClassById(int id);
        Task<ServiceResponse<List<GetDcClassDto>>> GetDcClassesByFrameId(int frameId);
        Task<ServiceResponse<List<GetDcClassDto>>> GetDcClassesByFrameCode(int frameCode);
        Task<ServiceResponse> UpdateDcClass(UpdateDcClassDto dcClassDto);
        Task<ServiceResponse> DeleteDcClass(int id);
    }
}
