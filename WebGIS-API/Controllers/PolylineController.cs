using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebGIS_API.Models.DTO;
using WebGIS_API.Services;

namespace WebGIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolylineController : ControllerBase
    {
        private readonly IPolylineService _polylineService;
        public PolylineController(IPolylineService polylineService)
        {
            _polylineService = polylineService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPolyline()
        {
            var result = await _polylineService.GetPolylines();
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGeometryPolyline(RequestCreateLineString polyline)
        {
            if (polyline is null) return BadRequest("Please Insert all field");

            if (polyline.Points.Length < 2) return BadRequest("Please Insert minimum 2 point");

            var result = await _polylineService.CreatePolyline(polyline);

            if (!result) return BadRequest("Any something wrong logic");

            return Ok("Success Created");
        }
    }
}
