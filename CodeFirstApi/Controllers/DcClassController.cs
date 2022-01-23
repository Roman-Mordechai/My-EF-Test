﻿using CodeFirstApi.Domain.Models.DcClasses;
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
        public async Task<ActionResult<ServiceResponse>> AddDcClass(AddDcClassDto dcClassDto)
        {
            return Ok(await _dcClassService.AddDcClass(dcClassDto));
        }

        [HttpGet("GetDcClassById")]
        public async Task<ActionResult<ServiceResponse<GetDcClassDto>>> GetDcClassById(int id)
        {
            return Ok(await _dcClassService.GetDcClassById(id));
        }

        [HttpPost("GetDcClassesByFrameId")]
        public async Task<ActionResult<ServiceResponse<List<GetDcClassDto>>>> GetDcClassesByFrameId(int frameId)
        {
            return Ok(await _dcClassService.GetDcClassesByFrameId(frameId));
        }

        [HttpPost("GetDcClassesByFrameCode")]
        public async Task<ActionResult<ServiceResponse<List<GetDcClassDto>>>> GetDcClassesByFrameCode(int frameCode)
        {
            return Ok(await _dcClassService.GetDcClassesByFrameCode(frameCode));
        }

        [HttpPost("UpdateDcClass")]
        public async Task<ActionResult<ServiceResponse>> UpdateDcClass(UpdateDcClassDto dcClassDto)
        {
            return Ok(await _dcClassService.UpdateDcClass(dcClassDto));
        }

        [HttpPost("DeleteDcClass")]
        public async Task<ActionResult<ServiceResponse>> DeleteDcClass(int classId)
        {
            return Ok(await _dcClassService.DeleteDcClass(classId));
        }

    }
}
