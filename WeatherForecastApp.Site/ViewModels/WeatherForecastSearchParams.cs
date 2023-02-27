// <copyright file="WeatherForecastSearchParams.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Site.ViewModels
{
    using System;
    using System.Runtime.Serialization;
    using WeatherForecastApp.Core.Enums;

    /// <summary>
    /// Contains the definition of an object of type <see cref="WeatherForecastSearchParams"/>.
    /// </summary>
    [DataContract]
    public class WeatherForecastSearchParams
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        [DataMember(Name = "date")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or sets the temperature in Celcius.
        /// </summary>
        [DataMember(Name = "minimumTemperatureC")]
        public int? MinimumTemperatureC { get; set; }

        /// <summary>
        /// Gets or sets the description of the weather forecast.
        /// </summary>
        [DataMember(Name = "description")]
        public ForecastDescription? Description { get; set; }

        /// <summary>
        /// Gets or sets the city identifier.
        /// </summary>
        [DataMember(Name = "cityId")]
        public int CityId { get; set; }
    }
}
