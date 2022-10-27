using NetTopologySuite.Geometries;
using WebGIS_API.Models.DTO;
using WebGIS_API.Repositories;
using Point = NetTopologySuite.Geometries.Point;

namespace WebGIS_API.Services
{
    public class PointService : IPointService
    {
        private readonly IPointRepository _pointRepository;
        public PointService(IPointRepository pointRepository)
        {
            _pointRepository = pointRepository; 
        }

        public async Task<bool> CreatePoint(RequestCreatePoint point)
        {
            var coordinate = new Coordinate(point.Latitude, point.Longitude);
            var pointCoordinate = new Point(coordinate);
            var geoMapData = new Models.DAO.Point
            {
                Geometry = pointCoordinate
            };

            return await _pointRepository.CreatePoint(geoMapData);
        }

        public async Task<IList<Models.DAO.Point>> GetPoints()
        {
            return await _pointRepository.GetPoints();
        }

    }
}
