// <copyright file="WeatherForecastController.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Site.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using WeatherForecastApp.Business.Interfaces;
    using WeatherForecastApp.Business.Models;

    /// <summary>
    /// Contains the definition of an object of type <see cref="WeatherForecastController"/>.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="weatherForecastDomain">The weather forecast domain.</param>
        public WeatherForecastController(IWeatherForecastDomain weatherForecastDomain)
        {
            this.WeatherForecastDomain = weatherForecastDomain;
        }

        /// <summary>
        /// Gets the weather forecast domain.
        /// </summary>
        public IWeatherForecastDomain WeatherForecastDomain { get; }

        /// <summary>
        /// Gets all the weather forecasts.
        /// </summary>
        /// <returns>A list of weather forecasts.</returns>
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> GetAllWeatherForecast()
            => this.WeatherForecastDomain.GetAllWeatherForecast();
    }
}