using WebGIS_API.Models.DAO;
using WebGIS_API.Models.DTO;

namespace WebGIS_API.Services
{
    public interface IPolylineService
    {
        Task<bool> CreatePolyline(RequestCreateLineString points);
        Task<IList<Polyline>> GetPolylines();
    }
}
