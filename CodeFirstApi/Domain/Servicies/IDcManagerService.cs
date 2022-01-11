using CodeFirstApi.Models;
using CodeFirstApi.Models.DcManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Domain.Servicies
{
    public interface IDcManagerService
    {
        Task<ServiceResponse<List<GetDcManagerDto>>> AddDcManager(AddDcManagerDto addDcManager);
    }
}
