using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebGIS_API.Models.DTO;
using WebGIS_API.Services;

namespace WebGIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly IPointService _pointService;
        public PointController(IPointService pointService)
        {
            _pointService = pointService;   
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPoint()
        {
            var result = await _pointService.GetPoints();
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGeometryPoint(RequestCreatePoint point)
        {
            if (point is null) return BadRequest("Please Insert all field");

            var result = await _pointService.CreatePoint(point);

            if (!result) return BadRequest("Any something wrong logic");

            return Ok("Success Created");
        }
    }
}
