using WebGIS_API.Models.DAO;
using WebGIS_API.Models.DTO;

namespace WebGIS_API.Services
{
    public interface IPointService
    {
        Task<bool> CreatePoint(RequestCreatePoint point);
        Task<IList<Point>> GetPoints();
    }
}
