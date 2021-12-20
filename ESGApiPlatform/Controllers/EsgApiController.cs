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
        public async Task<IActionResult> GetAggregation([FromQuery] int industries=3, int districts=3, int years=5)
        {
            var data = await _esgApiService.GetAggregationData(industries, districts, years);
            if (data==null) return StatusCode(StatusCodes.Status500InternalServerError, new { status = false, message = "Information is unable to load."});
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "Information has been loaded successfully.", esgData = data });
        }

        [HttpGet]
        [Route("sdgData")]
        public async Task<IActionResult> GetSDG([FromQuery] string type)
        {
            string[] types = { "goal1", "goal2", "goal3", "goal4", "goal5", "goal6", "goal7", "goal8", "goal9", "goal10", "goal11", "goal12", "goal13", "goal14", "goal15", "goal16", "goal17" };            

            if (String.IsNullOrEmpty(type) || !types.Contains(type)) return StatusCode(StatusCodes.Status400BadRequest, new { status = false, message = "Bad Request, 'type' Parameter Required with Accurate value." });
            var data = await _esgApiService.GetSDGData(type);
            if (data == null) return StatusCode(StatusCodes.Status500InternalServerError, new { status = false, message = "Information is unable to load."});
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "Information has been loaded successfully.", sdgData = data });
        }
    }
}
