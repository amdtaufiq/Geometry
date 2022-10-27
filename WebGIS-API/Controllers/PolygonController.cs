using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebGIS_API.Models.DTO;
using WebGIS_API.Services;

namespace WebGIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolygonController : ControllerBase
    {
        private readonly IPolygonService _polygonService;
        public PolygonController(IPolygonService polygonService)
        {
            _polygonService = polygonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPolygon()
        {
            var result = await _polygonService.GetPolygons();
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGeometryPolygon(RequestCreatePolygon polygon)
        {
            if (polygon is null) return BadRequest("Please Insert all field");

            if (polygon.Points.Length < 3) return BadRequest("Please Insert minimum 3 point");

            var result = await _polygonService.CreatePolygon(polygon);

            if (!result) return BadRequest("Any something wrong logic");

            return Ok("Success Created");
        }
    }
}
