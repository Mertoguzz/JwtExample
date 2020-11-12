using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTExample.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JWTExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private IUserService _userService;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpGet("getWeather")]
        public IActionResult Get()
        {
            var request = Request;
            var headers = request.Headers;
            string token = "";
            if (headers.Keys.Contains("Custom"))
            {
                token = headers["Custom"];
            }

            var user = _userService.GetUserByJwt(token);

            if (user == null)
            {
                return Unauthorized();
            }


            var rng = new Random();
            return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray());
        }
    }
}
