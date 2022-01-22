using CodeFirstApi.Domain.Models.DcClasses;
using CodeFirstApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Domain.Servicies
{
    public interface IDcClassService
    {
        Task<ServiceResponse<GetDcClassDto>> AddDcClass(AddDcClassDto dcClassDto);
        Task<ServiceResponse<GetDcClassDto>> GetDcClassById(int id);
        Task<ServiceResponse<List<GetDcClassDto>>> GetDcClassesByFrameId(int frameId);
        Task<ServiceResponse<List<GetDcClassDto>>> GetDcClassesByFrameCode(int frameCode);
        Task<ServiceResponse<GetDcClassDto>> UpdateDcClass(UpdateDcClassDto dcClassDto);
        Task<ServiceResponse<GetDcClassDto>> DeleteDcClass(int id);
    }
}
