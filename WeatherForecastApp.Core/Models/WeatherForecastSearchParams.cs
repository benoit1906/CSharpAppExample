// <copyright file="WeatherForecastSearchParams.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Core.Models
{
    using System;
    using System.Runtime.Serialization;
    using System.Xml.Linq;
    using WeatherForecastApp.Core.Enums;

    /// <summary>
    /// Contains the definition of an object of type <see cref="WeatherForecastSearchParams"/>.
    /// </summary>
    public class WeatherForecastSearchParams
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or sets the temperature in Celcius.
        /// </summary>
        public int? MinimumTemperatureC { get; set; }

        /// <summary>
        /// Gets or sets the summary of the weather forecast.
        /// </summary>
        public ForecastDescription? Description { get; set; }

        /// <summary>
        /// Gets or sets the city identifier.
        /// </summary>
        public int? CityId { get; set; }
    }
}
