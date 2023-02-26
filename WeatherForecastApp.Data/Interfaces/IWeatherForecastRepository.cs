// <copyright file="IWeatherForecastRepository.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Data.Interfaces
{
    using WeatherForecastApp.Core.Models;

    /// <summary>
    /// Contains the definition of an object of type <see cref="IWeatherForecastRepository"/>.
    /// </summary>
    public interface IWeatherForecastRepository
    {
        /// <summary>
        /// Gets all the weather forecasts.
        /// </summary>
        /// <returns>A list of all weather forecasts.</returns>
        IEnumerable<WeatherForecast> GetAllWeatherForecasts();

        /// <summary>
        /// Gets the weather forecasts by search params.
        /// </summary>
        /// <param name="searchParams">The search parameters.</param>
        /// <returns>A list of weather forecasts.</returns>
        IEnumerable<WeatherForecast> GetWeatherForecastsBySearchParams(WeatherForecastSearchParams searchParams);
    }
}
