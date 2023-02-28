// <copyright file="FakeCityRepository.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Business.Tests
{
    using WeatherForecastApp.Core.Models;
    using WeatherForecastApp.Data.Interfaces;

    /// <summary>
    /// Contains the definition of a class of type <see cref="FakeCityRepository"/>.
    /// The class allows to use the repository during tests without altering the database.
    /// </summary>
    public class FakeCityRepository : ICityRepository
    {
        /// <inheritdoc/>
        public void AddCities(IEnumerable<City> cities)
        {
            Console.WriteLine("Saving to Json Database");
        }

        /// <inheritdoc/>
        public IEnumerable<City> GetAllCities()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public IEnumerable<City> SetIdentifier(IEnumerable<City> existingCities, IEnumerable<City> toAddCities)
        {
            throw new NotImplementedException();
        }
    }
}
