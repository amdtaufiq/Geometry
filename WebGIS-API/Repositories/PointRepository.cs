using Microsoft.EntityFrameworkCore;
using WebGIS_API.Models;
using WebGIS_API.Models.DAO;

namespace WebGIS_API.Repositories
{
    public class PointRepository : IPointRepository
    {
        private readonly GeoDBContext _ctx;
        public PointRepository(GeoDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> CreatePoint(Point point)
        {
            try
            {
                await _ctx.Points.AddAsync(point);
                return await _ctx.SaveChangesAsync() == 1;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Point>> GetPoints()
        {
            return await _ctx.Points.ToListAsync();
        }
    }
}
