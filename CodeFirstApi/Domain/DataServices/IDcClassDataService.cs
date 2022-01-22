using CodeFirstApi.Domain.Models.DcClasses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Domain.DataServices
{
    public interface IDcClassDataService
    {
        Task<GetDcClassDto> AddDcClass(AddDcClassDto dcClassDto);
        Task<GetDcClassDto> GetDcClassById(int id);
        Task<GetDcClassDto> GetDcClassById(int id, int frameId);
        Task<List<GetDcClassDto>> GetDcClassesByFrameId(int frameId);
        Task<List<GetDcClassDto>> GetDcClassesByFrameCode(int frameCode);
        Task<GetDcClassDto> UpdateDcClass(UpdateDcClassDto dcClassDto);
        Task<GetDcClassDto> DeleteDcClass(GetDcClassDto dcClassDto);
    }
}
