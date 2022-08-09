using MinimalApiDemo.Modules.Core;
using MinimalApiDemo.Modules.Core.Extensions;
using MinimalApiDemo.Modules.Weather;

var builder = WebApplication.CreateBuilder(args);

// Register application modules
builder.Services.RegisterModule<WeatherModule>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Map module endpoints
app.MapEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();