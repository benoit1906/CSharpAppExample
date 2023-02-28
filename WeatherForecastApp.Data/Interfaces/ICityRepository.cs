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

        /// <summary>
        /// Sets the identifier to the cities to add to the database.
        /// </summary>
        /// <param name="existingCities">The existing cities.</param>
        /// <param name="toAddCities">The cities to add.</param>
        /// <returns>The cities to add with the correct identifier.</returns>
        IEnumerable<City> SetIdentifier(IEnumerable<City> existingCities, IEnumerable<City> toAddCities);
    }
}
