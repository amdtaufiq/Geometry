using WebGIS_API.Models.DAO;

namespace WebGIS_API.Repositories
{
    public interface IPolylineRepository
    {
        Task<bool> CreatePolyline(Polyline polyline);
        Task<IList<Polyline>> GetPolylines();
    }
}
