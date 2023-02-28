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
        public void AddCities(IEnumerable<City> cities)
        {
            foreach (var city in cities)
            {
                if (city.Latitude <= 0 || city.Latitude >= 90)
                {
                    throw new Exception("Latitude not valid");
                }

                if (city.Longitude <= -180 || city.Longitude >= 180)
                {
                    throw new Exception("Longitude not valid");
                }
            }

            this.cityRepository.AddCities(cities);
        }

        /// <inheritdoc/>
        public IEnumerable<City> GetAllCities()
            => this.cityRepository.GetAllCities();
    }
}
