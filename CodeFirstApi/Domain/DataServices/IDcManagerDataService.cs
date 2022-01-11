using CodeFirstApi.Entities;
using CodeFirstApi.Models;
using CodeFirstApi.Models.DcManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Servicies
{
    public interface IDcManagerDataService
    {
        Task<ServiceResponse<List<GetDcManagerDto>>> AddManager(AddDcManagerDto addDcManager);
        Task<ServiceResponse<List<GetDcManagerDto>>> GetAllManagers();
    }
}
