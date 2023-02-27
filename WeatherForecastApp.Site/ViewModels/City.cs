// <copyright file="City.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Site.ViewModels
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Contains the definition of an object of type <see cref="City"/>.
    /// </summary>
    [DataContract]
    public class City
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        [DataMember(Name = "latitude")]
        public int Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        [DataMember(Name = "longitude")]
        public int Longitude { get; set; }
    }
}
