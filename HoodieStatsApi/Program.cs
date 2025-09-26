using HoodieStatsApi.Data;
using HoodieStatsApi.Interfaces;
using HoodieStatsApi.Services;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;



var builder = WebApplication.CreateBuilder(args);

Env.Load();

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("TestDbConnection");
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IDataService, DataService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

