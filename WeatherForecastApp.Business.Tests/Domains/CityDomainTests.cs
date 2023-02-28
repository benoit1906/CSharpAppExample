// <copyright file="CityDomainTests.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Business.Tests.Domains
{
    using System.Collections;
    using WeatherForecastApp.Business.Domains;
    using WeatherForecastApp.Core.Models;

    /// <summary>
    /// Contains the definition of the class <see cref="CityDomainTests"/>.
    /// </summary>
    public class CityDomainTests
    {
        /// <summary>
        /// Creates a list of values that are tested thanks to the memberData decorator
        /// in the function ShouldThrowExceptionForInvalidLatOrLong.
        /// </summary>
        /// <param name="offset">The offset to test the longitude and latitude.</param>
        /// <returns>A list of objects to test.</returns>
        public static IEnumerable<object[]> GetListOfCities(int offset)
        {
            var data = new List<object[]>()
            {
                new object[] { -5, 50 + offset, "Latitude not valid", },
                new object[] { 5, -189 + offset, "Longitude not valid", },
            };
            return data;
        }

        /// <summary>
        /// Tests that an exception is thrown if latitude or longtitude are not valid when adding cities.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="expectedErrorMessage">The expected error message.</param>
        // [InlineData(-5, 50, "Latitude not valid")]
        // [InlineData(5, -189, "Longitude not valid")]
        [MemberData(nameof(GetListOfCities), 2)]
        [MemberData(nameof(GetListOfCities), 3)]
        // [ClassData(typeof(ListOfCities))]
        [Theory]
        [Trait("Cities", "Latitude or longitude")]
        public void ShouldThrowExceptionForInvalidLatOrLong(int latitude, int longitude, string expectedErrorMessage)
        {
            // Arrange
            var cityRepository = new FakeCityRepository();
            var cityDomain = new CityDomain(cityRepository);
            IEnumerable<City> cities = new List<City>()
                {
                    new City()
                    {
                        Id = 9,
                        Name = "Toronto",
                        Latitude = latitude,
                        Longitude = longitude,
                    },
                };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => cityDomain.AddCities(cities));

            // Assert
            Assert.Equal(expectedErrorMessage, exception.Message);
        }
    }

    /// <summary>
    /// Contains the definition of the class <see cref="ListOfCities"/>.
    /// This class allows to test the method ShouldThrowExceptionForInvalidLatOrLong
    /// with the classData decorator.
    /// </summary>
    public class ListOfCities : IEnumerable<object[]>
    {
        private int offset = 2;

        /// <summary>
        /// Gets a list of objects to the the method ShouldThrowExceptionForInvalidLatOrLong.
        /// </summary>
        /// <returns>A list of objects for tests.</returns>
        public IEnumerator<object[]> GetEnumerator()
        {
            var offset = this.GetOffset();

            yield return new object[] { -5, 50 + offset, "Latitude not valid" };
            yield return new object[] { 5, -189 + offset, "Longitude not valid" };
        }

        /// <summary>
        /// Gets the enumerator for IEnumerable.
        /// </summary>
        /// <returns>The enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Gets the offset.
        /// </summary>
        /// <returns>The offset.</returns>
        public int GetOffset()
        {
            return this.offset;
        }
    }
}