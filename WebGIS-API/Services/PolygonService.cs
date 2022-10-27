using NetTopologySuite.Geometries;
using WebGIS_API.Models.DTO;
using WebGIS_API.Repositories;
using Polygon = NetTopologySuite.Geometries.Polygon;

namespace WebGIS_API.Services
{
    public class PolygonService : IPolygonService
    {
        private readonly IPolygonRepository _polygonRepository;
        public PolygonService(IPolygonRepository polygonRepository)
        {
            _polygonRepository = polygonRepository;
        }

        public async Task<bool> CreatePolygon(RequestCreatePolygon polygon)
        {
            Coordinate[] coordinates = new Coordinate[polygon.Points.Length];
            LinearRing linearRingCoordinate;
            for (int i = 0; i < polygon.Points?.Length; i++)
            {
                var coordinate = new Coordinate(polygon.Points[i].Latitude, polygon.Points[i].Longitude);
                coordinates[i] = coordinate;
            }
            try
            {
                linearRingCoordinate = new LinearRing(coordinates);
            }catch
            {
                return false;
            }
            var polygonCoordinate = new Polygon(linearRingCoordinate);
            var geoMapData = new Models.DAO.Polygon
            {
                Geometry = polygonCoordinate
            };

            return await _polygonRepository.CreatePolygon(geoMapData);
        }

        public async Task<IList<Models.DAO.Polygon>> GetPolygons()
        {
            return await _polygonRepository.GetPolygons();
        }

    }
}
