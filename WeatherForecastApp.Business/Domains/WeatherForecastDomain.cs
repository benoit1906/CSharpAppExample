// <copyright file="WeatherForecastDomain.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Business.Domains
{
    using WeatherForecastApp.Business.Interfaces;
    using WeatherForecastApp.Core.Models;

    /// <summary>
    /// Contains the definition of an object of type <see cref="WeatherForecastDomain"/>.
    /// </summary>
    public class WeatherForecastDomain : IWeatherForecastDomain
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        /// <inheritdoc/>
        public IEnumerable<WeatherForecast> GetAllWeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Description = Summaries[Random.Shared.Next(Summaries.Length)],
            })
            .ToArray();
        }
    }
}
