// <copyright file="ICityRepository.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Data.Interfaces
{
    using System.Collections.Generic;
    using WeatherForecastApp.Core.Models;

    /// <summary>
    /// Contains the definition of an object of type <see cref="ICityRepository"/>.
    /// </summary>
    public interface ICityRepository
    {
        /// <summary>
        /// Adds cities to the database.
        /// </summary>
        /// <param name="cities">A list of cities.</param>
        void AddCities(IEnumerable<City> cities);

        /// <summary>
        /// Gets all the cities.
        /// </summary>
        /// <returns>A list of cities.</returns>
        IEnumerable<City> GetAllCities();
    }
}
