using WebGIS_API.Models.DAO;

namespace WebGIS_API.Repositories
{
    public interface IPointRepository
    {
        Task<bool> CreatePoint(Point point);
        Task<IList<Point>> GetPoints();
    }
}
