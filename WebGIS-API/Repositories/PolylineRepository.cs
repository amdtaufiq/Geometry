using Microsoft.EntityFrameworkCore;
using WebGIS_API.Models;
using WebGIS_API.Models.DAO;

namespace WebGIS_API.Repositories
{
    public class PolylineRepository : IPolylineRepository
    {
        private readonly GeoDBContext _ctx;
        public PolylineRepository(GeoDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> CreatePolyline(Polyline polyline)
        {
            try
            {
                await _ctx.Polylines.AddAsync(polyline);
                return await _ctx.SaveChangesAsync() == 1;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Polyline>> GetPolylines()
        {
            return await _ctx.Polylines.ToListAsync();
        }
    }
}
