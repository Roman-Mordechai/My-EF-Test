using DbFirstApi.Domain.Entities;
using DbFirstApi.Domain.Models;
using DbFirstApi.Domain.Models.DcFrame;
using DbFirstApi.Domain.Servicies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbFirstApi.Controllers
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

        [HttpPost("AddDcFrame")]
        public async Task<ActionResult<ServiceResponse>> AddDcFrame(AddDcFrameDto dcFrameDto)
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
        public async Task<ActionResult<ServiceResponse>> UpdateDcFrame(UpdateDcFrameDto dcFrameDto)
        {
            var rsp = await _dcFrameService.UpdateDcFrame(dcFrameDto);
            return Ok(rsp);
        }

        [HttpPost("DeleteDcFrame")]
        public async Task<ActionResult<ServiceResponse>> DeleteDcFrame(int id)
        {
            var rsp = await _dcFrameService.DeleteDcFrame(id);
            return Ok(rsp);
        }
    }
}
