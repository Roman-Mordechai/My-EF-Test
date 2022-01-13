using CodeFirstApi.Domain.Models.DcFrame;
using CodeFirstApi.Domain.Servicies;
using CodeFirstApi.Entities;
using CodeFirstApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFirstApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DcFrameController : ControllerBase
    {
        private readonly IDcFrameService _dcFrameService;

        public DcFrameController(IDcFrameService dcFrameService)
        {
            _dcFrameService = dcFrameService;
        }

        [HttpPost("AddFrame")]
        public async Task<ActionResult<ServiceResponse<List<DcFrameEntity>>>> AddFrame(AddDcFrameDto addDcFrame)
        {

            var rsp = await _dcFrameService.AddFrame(addDcFrame);
            return Ok(rsp);

        }

        [HttpGet("GetAllFrames")]
        public async Task<ActionResult<ServiceResponse<List<DcFrameEntity>>>> GetAllFrames()
        {

            var rsp = await _dcFrameService.GetAllFrames();
            return Ok(rsp);

        }


    }
}
