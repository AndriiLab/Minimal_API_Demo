using MinimalApiDemo.Modules.Core;
using MinimalApiDemo.Modules.Core.Interfaces;
using MinimalApiDemo.Modules.Weather.Dtos;

namespace MinimalApiDemo.Modules.Weather.Interfaces;

internal interface IWeatherForecastRepository : IRepository
{
    Task<WeatherForecastDto[]> GetForecastsAsync(int days);
}