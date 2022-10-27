using WebGIS_API.Models.DAO;
using WebGIS_API.Models.DTO;

namespace WebGIS_API.Services
{
    public interface IPolygonService
    {
        Task<bool> CreatePolygon(RequestCreatePolygon point);
        Task<IList<Polygon>> GetPolygons();
    }
}
