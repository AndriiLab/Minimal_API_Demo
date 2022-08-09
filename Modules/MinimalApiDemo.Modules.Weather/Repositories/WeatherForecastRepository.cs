using MinimalApiDemo.Modules.Weather.Dtos;
using MinimalApiDemo.Modules.Weather.Interfaces;

namespace MinimalApiDemo.Modules.Weather.Repositories;

internal class WeatherForecastRepository : IWeatherForecastRepository
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<WeatherForecastDto[]> GetForecastsAsync(int days)
    {
        var forecast = Enumerable.Range(1, days).Select(index =>
                new WeatherForecastDto
                (
                    DateTime.UtcNow.AddDays(index),
                    Random.Shared.Next(-20, 55),
                    Summaries[Random.Shared.Next(Summaries.Length)]
                ))
            .ToArray();
        return Task.FromResult(forecast);
    }
}