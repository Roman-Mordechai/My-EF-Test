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
        public async Task<ActionResult<ServiceResponse<List<DcFrameEntity>>>> AddFrame(AddDcFrameDto dcFrameDto)
        {
            var rsp = await _dcFrameService.AddDcFrame(dcFrameDto);
            return Ok(rsp);
        }

        [HttpGet("GetAllFrames")]
        public async Task<ActionResult<ServiceResponse<List<DcFrameEntity>>>> GetAllFrames()
        {
            var rsp = await _dcFrameService.GetAllDcFrames();
            return Ok(rsp);
        }

        [HttpGet("GetDcFrameById")]
        public async Task<ActionResult<ServiceResponse<DcFrameEntity>>> GetDcFrameById(int id)
        {
            var rsp = await _dcFrameService.GetDcFrameById(id);
            return Ok(rsp);
        }

        [HttpGet("GetDcFrameByFrameCode")]
        public async Task<ActionResult<ServiceResponse<DcFrameEntity>>> GetDcFrameByFrameCode(int frameCode)
        {
            var rsp = await _dcFrameService.GetDcFrameByFrameCode(frameCode);
            return Ok(rsp);
        }

        [HttpPost("UpdateDcFrame")]
        public async Task<ActionResult<ServiceResponse<DcFrameEntity>>> UpdateDcFrame(UpdateDcFrameDto dcFrameDto)
        {
            var rsp = await _dcFrameService.UpdateDcFrame(dcFrameDto);
            return Ok(rsp);
        }

        [HttpPost("DeleteDcFrame")]
        public async Task<ActionResult<ServiceResponse<DcFrameEntity>>> DeleteDcFrame(int id)
        {
            var rsp = await _dcFrameService.DeleteDcFrame(id);
            return Ok(rsp);
        }
    }
}
