namespace WebGIS_API.Models.DTO
{
    public class RequestCreatePoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class RequestCreateLineString
    {
        public RequestCreatePoint[]? Points { get; set; }
    }

    public class RequestCreatePolygon
    {
        public RequestCreatePoint[]? Points { get; set; }
    }
}
