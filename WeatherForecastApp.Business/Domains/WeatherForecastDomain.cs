// <copyright file="WeatherForecastDomain.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Business.Domains
{
    using WeatherForecastApp.Business.Interfaces;
    using WeatherForecastApp.Core.Models;
    using WeatherForecastApp.Data.Interfaces;

    /// <summary>
    /// Contains the definition of an object of type <see cref="WeatherForecastDomain"/>.
    /// </summary>
    public class WeatherForecastDomain : IWeatherForecastDomain
    {
        private readonly IWeatherForecastRepository weatherForecastRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastDomain"/> class.
        /// </summary>
        /// <param name="weatherForecastRepository">The weather forecast repository.</param>
        public WeatherForecastDomain(IWeatherForecastRepository weatherForecastRepository)
        {
            this.weatherForecastRepository = weatherForecastRepository;
        }

        /// <inheritdoc/>
        public IEnumerable<WeatherForecast> GetAllWeatherForecast()
            => this.weatherForecastRepository.GetAllWeatherForecasts();

        /// <inheritdoc/>
        public IEnumerable<WeatherForecast> GetWeatherForecastsBySearchParams(WeatherForecastSearchParams searchParams)
            => this.weatherForecastRepository.GetWeatherForecastsBySearchParams(searchParams);
    }
}
