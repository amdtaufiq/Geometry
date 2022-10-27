using WebGIS_API.Models.DAO;
using WebGIS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace WebGIS_API.Repositories
{
    public class PolygonRepository : IPolygonRepository
    {
        private readonly GeoDBContext _ctx;
        public PolygonRepository(GeoDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> CreatePolygon(Polygon polygon)
        {
            try
            {
                await _ctx.Polygons.AddAsync(polygon);
                return await _ctx.SaveChangesAsync() == 1;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Polygon>> GetPolygons()
        {
            return await _ctx.Polygons.ToListAsync();
        }
    }
}
