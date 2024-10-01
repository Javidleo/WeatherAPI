using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WeatherAPI.Model;

namespace WeatherAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly WeatherHandler _handler;
    public WeatherController(WeatherHandler handler)
    {
        _handler = handler;
    }
    
    [HttpGet("weather")]
    public IActionResult GetWeather()
    {
        var weatherHandler = new WeatherHandler();

        var content = weatherHandler.GetWeather();
        return Ok(content);
    }
}
