using CodeFirstApi.Domain.Models.DcManager;
using CodeFirstApi.Domain.Servicies;
using CodeFirstApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DcManagerController : ControllerBase
    {
        
        private readonly IDcManagerService _dcManagerService;

        public DcManagerController(IDcManagerService dcManagerService)
        {
            _dcManagerService = dcManagerService;
        }

        [HttpPost("AddManager")]
        public async Task<ActionResult<ServiceResponse<List<GetDcManagerDto>>>> AddDcManager(AddDcManagerDto dcManagerDto)
        {
            return Ok(await _dcManagerService.AddDcManager(dcManagerDto));
        }

        [HttpPost("GetAllManagers")]
        public async Task<ActionResult<ServiceResponse<GetDcManagerDto>>> GetAllDcManagers()
        {
            return Ok(await _dcManagerService.GetAllDcManagers());
        }

        [HttpPost("GetManagerById")]
        public async Task<ActionResult<ServiceResponse<GetDcManagerDto>>> GetDcManagerById(int id)
        {
            return Ok(await _dcManagerService.GetDcManagerById(id));
        }

        [HttpPost("GetDcManagerByManagerId")]
        public async Task<ActionResult<ServiceResponse<GetDcManagerDto>>> GetDcManagerByManagerId(int id)
        {
            return Ok(await _dcManagerService.GetDcManagerByManagerId(id));
        }

        [HttpPost("UpdateManager")]
        public async Task<ActionResult<ServiceResponse<GetDcManagerDto>>> UpdateDcManager(GetDcManagerDto dcManagerDto)
        {
            return Ok(await _dcManagerService.UpdateDcManager(dcManagerDto));
        }

        [HttpPost("DeleteDcManager")]
        public async Task<ActionResult<ServiceResponse<GetDcManagerDto>>> DeleteDcManager(int id)
        {
            return Ok(await _dcManagerService.DeleteDcManager(id));
        }
    }
}
