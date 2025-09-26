using HoodieStatsApi.Data;
using HoodieStatsApi.Interfaces;
using HoodieStatsApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("TestDbConnection"),
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


 // TODO Doku richtig anpassen damit jeder checkt  = .WithName("playtime");

app.Run();

