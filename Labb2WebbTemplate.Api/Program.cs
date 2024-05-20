using FastEndpoints;
using Labb2WebbTemplate.StoreDataAccess;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var machineName = Environment.MachineName;

var connectionString = machineName == "FELIX-DESKTOP"
    ? builder.Configuration.GetConnectionString("Desktop") 
    : builder.Configuration.GetConnectionString("Laptop");

builder.Services
    .AddJWTBearerAuth("fg2gfsuoyq74ogfoqGS7o8GFOyHEHL#UWO/#(ODDHEILWYOFGyrgfghKGHJKGhjkgYKGyKGRKgyKUG")
    .AddAuthorization()
    .AddFastEndpoints()
    .AddScoped<UnitOfWork>()
    .AddDbContext<StoreDbContext>(
    options =>
    {
        options.UseSqlServer(connectionString);
    });

var app = builder.Build();

app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints();

app.Run();
