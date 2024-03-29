﻿// <copyright file="WeatherForecast.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Core.Models
{
    using WeatherForecastApp.Core.Enums;

    /// <summary>
    /// Contains the definition of an object of type <see cref="WeatherForecast"/>.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the temperature in Celsius.
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Gets the temperature in Fahrenheit.
        /// </summary>
        public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public ForecastDescription Description { get; set; }

        /// <summary>
        /// Gets or sets the city identifier.
        /// </summary>
        public int CityId { get; set; }
    }
}
