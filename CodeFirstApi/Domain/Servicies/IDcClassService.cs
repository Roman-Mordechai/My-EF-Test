using CodeFirstApi.Domain.Models;
using CodeFirstApi.Domain.Models.DcClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Domain.Servicies
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
