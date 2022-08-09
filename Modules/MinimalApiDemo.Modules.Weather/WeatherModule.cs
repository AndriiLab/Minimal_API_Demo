using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using MinimalApiDemo.Modules.Core.Extensions;
using MinimalApiDemo.Modules.Core.Interfaces;
using MinimalApiDemo.Modules.Weather.Dtos;
using MinimalApiDemo.Modules.Weather.Interfaces;
using MinimalApiDemo.Modules.Weather.Models;

namespace MinimalApiDemo.Modules.Weather;

public class WeatherModule : IModule
{
    public IServiceCollection RegisterServices(IServiceCollection builder)
    {
        return builder;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/weather/forecast", async (GetWeatherForecastRequest request, [FromServices] IWeatherForecastRepository repository) =>
            {
                var weather = await repository.GetForecastsAsync(request.Days);
                return Results.Ok(weather);
            })
            .WithValidator<GetWeatherForecastRequest>()
            .WithTags("Weather")
            .WithName("Get Forecast")
            .Produces<WeatherForecastDto[]>();

        return endpoints;
    }
}