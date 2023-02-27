// <copyright file="CityRepositoryTests.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Data.Tests.Repositories
{
    using WeatherForecastApp.Data.Repositories;

    /// <summary>
    /// Contains the definition of an object of type <see cref="CityRepositoryTests"/>.
    /// </summary>
    public class CityRepositoryTests
    {
        /// <summary>
        /// Tests whether the database has an error in the latitude or longitude.
        /// This tests works only if the database has a mistake in itself.
        /// </summary>
        public void LongitudeAndLatitudeShouldBevalid()
        {
            // Arrange
            var cityRepository = new CityRepository();

            // Act
            var cities = cityRepository.GetAllCities();

            // Assert
            foreach (var city in cities)
            {
                // Assert.InRange(city.Latitude, 0, 90);
                // Assert.InRange(city.Longitude, -180, 180);
                Assert.True(city.Latitude >= 0 && city.Latitude <= 90, "latitude out of range");
                Assert.True(city.Longitude >= -180 && city.Longitude <= 180);
            }
        }
    }
}
