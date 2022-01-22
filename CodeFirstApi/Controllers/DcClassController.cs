using CodeFirstApi.Domain.Models.DcClasses;
using CodeFirstApi.Domain.Servicies;
using CodeFirstApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DcClassController : ControllerBase
    {
        private readonly IDcClassService _dcClassService;

        public DcClassController(IDcClassService dcClassService)
        {
            _dcClassService = dcClassService;
        }

        [HttpPost("AddClass")]
        public async Task<ActionResult<ServiceResponse<List<GetDcClassDto>>>> AddDcClass(AddDcClassDto dcClassDto)
        {
            return Ok(await _dcClassService.AddDcClass(dcClassDto));
        }

        [HttpGet("GetDcClassById")]
        public async Task<ActionResult<ServiceResponse<List<GetDcClassDto>>>> GetDcClassById(int id)
        {
            return Ok(await _dcClassService.GetDcClassById(id));
        }

        [HttpPost("GetDcClassesByFrameId")]
        public async Task<ActionResult<ServiceResponse<List<GetDcClassDto>>>> GetDcClassesByFrameId(int frameId)
        {
            return Ok(await _dcClassService.GetDcClassesByFrameId(frameId));
        }

    }
}
