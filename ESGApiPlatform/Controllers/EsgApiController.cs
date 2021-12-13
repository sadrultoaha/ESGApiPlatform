using ESGApiPlatform.Model;
using ESGApiPlatform.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESGApiPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EsgApiController : ControllerBase
    {
        private readonly IEsgApiService _esgApiService;
        public EsgApiController(IEsgApiService esgApiService)
        {
            _esgApiService = esgApiService;
        }

        [HttpGet]
        [Route("test")]
        public ActionResult GetMessage()
        {
            return StatusCode(StatusCodes.Status200OK, "Esg Api Service started successfully!");
        }

        [HttpGet]
        [Route("esgData")]
        public async Task<IActionResult> GetData()
        {
            var data = await _esgApiService.GetData();
            if(data==null) return StatusCode(StatusCodes.Status500InternalServerError, new { status = false, message = "Information is unable to load.", esgData = data });
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "Information has been loaded successfully.", esgData = data });
        }
    }
}
