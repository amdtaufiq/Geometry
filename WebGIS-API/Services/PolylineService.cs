using NetTopologySuite.Geometries;
using WebGIS_API.Models.DAO;
using WebGIS_API.Models.DTO;
using WebGIS_API.Repositories;

namespace WebGIS_API.Services
{
    public class PolylineService : IPolylineService
    {
        private readonly IPolylineRepository _polylineRepository;
        public PolylineService(IPolylineRepository polylineRepository)
        {
            _polylineRepository = polylineRepository;
        }

        public async Task<bool> CreatePolyline(RequestCreateLineString polyline)
        {
            Coordinate[] coordinates = new Coordinate[polyline.Points.Length];

            for (int i = 0; i < polyline.Points?.Length; i++)
            {
                var coordinate = new Coordinate(polyline.Points[i].Latitude, polyline.Points[i].Longitude);
                coordinates[i] = coordinate;
            }

            var lineCoordinate = new LineString(coordinates);
            var geoMapData = new Models.DAO.Polyline
            {
                Geometry = lineCoordinate
            };

            return await _polylineRepository.CreatePolyline(geoMapData);
        }

        public async Task<IList<Models.DAO.Polyline>> GetPolylines()
        {
            return await _polylineRepository.GetPolylines();
        }

    }
}
