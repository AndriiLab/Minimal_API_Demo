using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace MinimalApiDemo.Modules.Weather.Models;

public class GetWeatherForecastRequest
{
    public int Days { get; }

    public GetWeatherForecastRequest()
    {
    }

    public GetWeatherForecastRequest(int days)
    {
        Days = days;
    }
    
    // NET Core 6 does not support direct binding FromQuery in model, this approach can be used to fetch parameters from the request
    // In NET Core 7 attribute AsParameters would be added, which make binding parameters in model more straightforward
    public static ValueTask<GetWeatherForecastRequest?> BindAsync(HttpContext httpContext)
    {
        var result = new GetWeatherForecastRequest(
            int.TryParse(httpContext.Request.Query["days"], out var level) ? level : 1);

        return ValueTask.FromResult<GetWeatherForecastRequest?>(result);
    }
}

internal class GetWeatherForecastRequestValidator : AbstractValidator<GetWeatherForecastRequest>
{
    public GetWeatherForecastRequestValidator()
    {
        RuleFor(_ => _.Days)
            .GreaterThan(0)
            .LessThanOrEqualTo(7);
    }
}