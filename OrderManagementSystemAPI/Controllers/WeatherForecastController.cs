// <copyright file="WeatherForecastController.cs" company="Northwind">
// Copyright (c) Northwind. All rights reserved.
// </copyright>

namespace OrderManagementSystemAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for weather forecast operations.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Gets a collection of weather forecasts.
        /// </summary>
        /// <returns>An enumerable collection of weather forecasts.</returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = WeatherForecastController.Summaries[Random.Shared.Next(WeatherForecastController.Summaries.Length)],
            })
            .ToArray();
        }
    }
}
