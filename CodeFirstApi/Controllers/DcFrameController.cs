using CodeFirstApi.Domain.Servicies;
using CodeFirstApi.Entities;
using CodeFirstApi.Models;
using CodeFirstApi.Models.DcFrame;
using CodeFirstApi.Servicies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost("AddCharacter")]
        public async Task<ActionResult<ServiceResponse<List<DcFrameEntity>>>> AddCharacter(AddDcFrameDto addDcFrame)
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
