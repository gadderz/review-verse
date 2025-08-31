using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReviewVerse.Persistence.Data;
using ReviewVerse.Persistence.DependencyInjection;

var builder = Host.CreateApplicationBuilder();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddPersistenceServices(
    builder.Configuration.GetConnectionString("DefaultConnection")!,
    "ReviewVerse.Persistence.Migrations"
);
var host = builder.Build();

var dbService = host.Services.GetRequiredService<AppDbContext>();

if (dbService.Database.GetPendingMigrations().Any())
{
    dbService.Database.Migrate();
}
