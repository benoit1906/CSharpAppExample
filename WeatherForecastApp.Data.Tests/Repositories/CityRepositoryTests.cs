// <copyright file="CityRepositoryTests.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Data.Tests.Repositories
{
    using Newtonsoft.Json;
    using WeatherForecastApp.Core.Models;
    using WeatherForecastApp.Data.Repositories;

    /// <summary>
    /// Contains the definition of an object of type <see cref="CityRepositoryTests"/>.
    /// </summary>
    public class CityRepositoryTests : IDisposable
    {
        private const string DatabasePath = "../../../FakeCityDataBase.json";

        /// <summary>
        /// Initializes a new instance of the <see cref="CityRepositoryTests"/> class.
        /// </summary>
        public CityRepositoryTests()
        {
            File.Create(DatabasePath).Close();
        }

        /// <summary>
        /// Tests whether the database has an error in the latitude or longitude.
        /// This tests works only if the database has a mistake in itself.
        /// </summary>
        [Fact(Skip = "true")]
        [Trait("Cities", "Latitude or longitude")]
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

        /// <summary>
        /// Tests that GetAllCities throws an exception when the latitude is not valid.
        /// </summary>
        [Fact]
        [Trait("Cities", "Latitude or longitude")]
        public void ShouldThrowExceptionWhenLatInvalid()
        {
            // Arrange
            var cityRepository = new CityRepository();
            cityRepository.DatabasePath = DatabasePath;
            var cities = new List<City>();
            cities.Add(
                new City()
                {
                    Id = 2,
                    Name = "Stockholm",
                    Latitude = -15,
                    Longitude = 16,
                });

            var rawData = JsonConvert.SerializeObject(cities);
            File.WriteAllText(DatabasePath, rawData);

            // Act
            var exception = Assert.Throws<Exception>(() => cityRepository.GetAllCities());

            // Assert
            Assert.Equal("Latitude out of range.", exception.Message);
        }

        /// <summary>
        /// Tests that GetAllCities throws an exception when the longitude is not valid.
        /// </summary>
        [Fact]
        [Trait("Cities", "Latitude or longitude")]
        public void ShouldThrowExceptionWhenLonInvalid()
        {
            // Arrange
            var cityRepository = new CityRepository();
            cityRepository.DatabasePath = DatabasePath;
            var cities = new List<City>();
            cities.Add(
                new City()
                {
                    Id = 4,
                    Name = "Berlin",
                    Latitude = 25,
                    Longitude = 189,
                });
            var rawData = JsonConvert.SerializeObject(cities);
            File.WriteAllText(DatabasePath, rawData);

            // Act
            var exception = Assert.Throws<Exception>(() => cityRepository.GetAllCities());

            // Assert
            Assert.Equal("Longitude out of range.", exception.Message);
        }

        /// <summary>
        /// Tests that the identifier is superior by one to the maximum existing identifier in the database.
        /// </summary>
        [Fact]
        [Trait("Cities", "Identifier")]
        public void ShouldIncrementIdentifier()
        {
            // Arrange
            var existingCities = new List<City>
            {
                new City()
                {
                    Id = 2,
                    Name = "New York",
                    Latitude = 15,
                    Longitude = 16,
                },
                new City()
                {
                    Id = 4,
                    Name = "Los Angeles",
                    Latitude = 25,
                    Longitude = 56,
                },
            };
            var toAddCities = new List<City>
            {
                new City()
                {
                    Id = 0,
                    Name = "San Francisco",
                    Latitude = 75,
                    Longitude = 23,
                },
            };
            var cityRepository = new CityRepository();

            // Act
            var result = cityRepository.SetIdentifier(existingCities, toAddCities);

            // Assert
            Assert.Equal(5, result.First().Id);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (File.Exists(DatabasePath))
            {
                File.Delete(DatabasePath);
            }
        }
    }
}
