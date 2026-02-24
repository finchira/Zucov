using Microsoft.AspNetCore.Mvc;

namespace Zucov.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class WeatherController : ControllerBase
{
    [HttpGet("WeatherForcast")]
    public WeatherForcast[] Get()
    {
        var forcast = Enumerable.Range(1, 5).Select(Index =>
            new WeatherForcast(
                DateOnly.FromDateTime(DateTime.Now.AddDays(Index)),
                Random.Shared.Next(-20, 55))
            ).ToArray();

        return forcast;
    }

}

public record WeatherForcast(DateOnly Date, int TemperatureC)
{
    public int TemperatureK => TemperatureC + 273;
}