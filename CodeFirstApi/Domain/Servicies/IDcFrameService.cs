using CodeFirstApi.Models;
using CodeFirstApi.Models.DcFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Domain.Servicies
{
    public interface IDcFrameService
    {
        Task<ServiceResponse<List<GetDcFrameDto>>> AddFrame(AddDcFrameDto addDcFrame);
        Task<ServiceResponse<List<GetDcFrameDto>>> GetAllFrames();
    }
}
