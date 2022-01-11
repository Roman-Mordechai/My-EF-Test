using CodeFirstApi.Entities;
using CodeFirstApi.Models;
using CodeFirstApi.Models.DcManager;
using CodeFirstApi.Servicies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DcManagerController : ControllerBase
    {
        
        private readonly IDcManagerDataService _dcManagerService;

        public DcManagerController(IDcManagerDataService dcManagerService)
        {
            _dcManagerService = dcManagerService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<DcManagerEntity>>>> AddCharacter(AddDcManagerDto addDcManager)
        {

            return Ok(await _dcManagerService.AddDcManager(addDcManager));
        }

    }
}
