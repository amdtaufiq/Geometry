using Microsoft.EntityFrameworkCore;
using WebGIS_API.Models;
using WebGIS_API.Repositories;
using WebGIS_API.Services;
using NetTopologySuite.IO.Converters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDbContext<GeoDBContext>(options => 
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Connection"), x => 
        x.UseNetTopologySuite()));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new GeoJsonConverterFactory());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repository
builder.Services.AddTransient<IPointRepository, PointRepository>();
builder.Services.AddTransient<IPolylineRepository, PolylineRepository>();
builder.Services.AddTransient<IPolygonRepository, PolygonRepository>();

//Serice
builder.Services.AddTransient<IPointService, PointService>();
builder.Services.AddTransient<IPolylineService, PolylineService>();
builder.Services.AddTransient<IPolygonService, PolygonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
