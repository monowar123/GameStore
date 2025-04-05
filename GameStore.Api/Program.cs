using GameStore.Api.Data;
using GameStore.Api.EndPoints;
using Microsoft.EntityFrameworkCore;
using MinimalApis.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Configure database connection
var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddDbContext<GameStoreContext>(options =>
{
    options.UseSqlite(connString);
});

//Add Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Map endpoints
app.MapGamesEndPoints();

app.Run();