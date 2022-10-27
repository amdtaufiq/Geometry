using WebGIS_API.Models.DAO;

namespace WebGIS_API.Repositories
{
    public interface IPolygonRepository
    {
        Task<bool> CreatePolygon(Polygon polygon);
        Task<IList<Polygon>> GetPolygons();
    }
}
