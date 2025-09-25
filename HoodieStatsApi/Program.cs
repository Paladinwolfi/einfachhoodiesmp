using HoodieStatsApi.Data;
using HoodieStatsApi.Interfaces;
using HoodieStatsApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    )
);

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IDataService, DataService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/serverstats", async (IDataService dataService) =>
{
    var stats = await dataService.GetServerStatsAsync();
    return Results.Ok(stats);
});

app.MapGet("/player/{playername}", async (string playername, AppDbContext db) =>
    await db.Players.FirstOrDefaultAsync(p => p.Name == playername)
);



 // TODO Doku richtig anpassen damit jeder checkt  = .WithName("playtime");

app.Run();

