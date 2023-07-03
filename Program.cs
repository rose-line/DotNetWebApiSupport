using DotNetWebApiSupport.EntityLayer;
using DotNetWebApiSupport.Interfaces;
using DotNetWebApiSupport.Models;
using DotNetWebApiSupport.RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("en-US");

var builder = WebApplication.CreateBuilder(args);

// Dependency Injection

builder.Services.AddSingleton<Settings, Settings>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();

// Configuration DB
builder.Services.AddDbContext<AWLTDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuration CORS
builder.Services.AddCors(options =>
{
  options.AddPolicy("MaPolitiqueCORS", builder =>
  {
    builder.AllowAnyOrigin();

    //builder.WithOrigins("localhost:5555", "http://unautredomaine.com")
    //  .WithMethods("GET", "POST", "PUT");
  });
});

// Serilog

builder.Host.UseSerilog((ctx, lc) =>
{
  lc.WriteTo.Console();
  lc.WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day);
  lc.WriteTo.File("Logs/logError-.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Error);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors("MaPolitiqueCORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
