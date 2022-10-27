using Microsoft.EntityFrameworkCore;
using WebGIS_API.Models.DAO;

namespace WebGIS_API.Models
{
    public class GeoDBContext : DbContext
    {
        public GeoDBContext(DbContextOptions<GeoDBContext> options) : base(options)
        {

        }

        public DbSet<Point> Points{ get; set; }
        public DbSet<Polyline> Polylines{ get; set; }
        public DbSet<Polygon> Polygons{ get; set; }
    }
}
