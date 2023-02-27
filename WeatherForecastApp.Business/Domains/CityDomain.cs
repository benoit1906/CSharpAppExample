// <copyright file="CityDomain.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Business.Domains
{
    using System.Collections.Generic;
    using WeatherForecastApp.Business.Interfaces;
    using WeatherForecastApp.Core.Models;
    using WeatherForecastApp.Data.Interfaces;

    /// <summary>
    /// Contains the definition of an object of type <see cref="CityDomain"/>.
    /// </summary>
    public class CityDomain : ICityDomain
    {
        private readonly ICityRepository cityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CityDomain"/> class.
        /// </summary>
        /// <param name="cityRepository">The city repository.</param>
        public CityDomain(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        /// <inheritdoc/>
        public IEnumerable<City> GetAllCities()
            => this.cityRepository.GetAllCities();
    }
}
