﻿// <copyright file="IWeatherForecastDomain.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Business.Interfaces
{
    using WeatherForecastApp.Core.Models;

    /// <summary>
    /// Contains the definition of an object of type <see cref="IWeatherForecastDomain"/>.
    /// </summary>
    public interface IWeatherForecastDomain
    {
        /// <summary>
        /// Gets all the weather forecasts.
        /// </summary>
        /// <returns>A list of all weather forecasts.</returns>
        IEnumerable<WeatherForecast> GetAllWeatherForecast();

        /// <summary>
        /// Gets the weather forecasts by search params.
        /// </summary>
        /// <param name="searchParams">The search parameters.</param>
        /// <returns>A list of weather forecasts.</returns>
        IEnumerable<WeatherForecast> GetWeatherForecastsBySearchParams(WeatherForecastSearchParams searchParams);
    }
}
