// <copyright file="ICityDomain.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Business.Interfaces
{
    using System.Collections.Generic;
    using WeatherForecastApp.Core.Models;

    /// <summary>
    /// Contains the definition of an object of type <see cref="ICityDomain"/>.
    /// </summary>
    public interface ICityDomain
    {
        /// <summary>
        /// Gets all the cities.
        /// </summary>
        /// <returns>A list of cities.</returns>
        IEnumerable<City> GetAllCities();
    }
}
