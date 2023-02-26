// <copyright file="WeatherForecast.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Site.ViewModels
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Contains the definition of an object of type <see cref="WeatherForecast"/>.
    /// </summary>
    [DataContract]
    public class WeatherForecast
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the temperature in Celsius.
        /// </summary>
        [DataMember(Name = "temperatureC")]
        public int TemperatureC { get; set; }

        /// <summary>
        /// Gets the temperature in Farhenheit.
        /// </summary>
        [DataMember(Name = "temperatureF")]
        public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [DataMember(Name = "description")]
        public string? Description { get; set; }
    }
}
