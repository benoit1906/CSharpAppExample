// <copyright file="CityRepository.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using WeatherForecastApp.Core.Models;
    using WeatherForecastApp.Data.Interfaces;

    /// <summary>
    /// Contains the definition of an object of type <see cref="CityRepository"/>.
    /// </summary>
    public class CityRepository : ICityRepository
    {
        private const string DatabasePath = "../WeatherForecastApp.Data/Databases/CityDataBase.json";

        /// <inheritdoc/>
        public IEnumerable<City> GetAllCities()
        {
            return this.FetchDataBase();
        }

        private IEnumerable<City> FetchDataBase()
        {
            var rawData = File.ReadAllText(DatabasePath);

            var cities = JsonConvert.DeserializeObject<IEnumerable<City>>(rawData);

            // foreach (var city in cities)
            // {
            //    if (city.Latitude < 0 || city.Latitude > 90)
            //    {
            //        throw new Exception("Latitude or longitude out of range");
            //    }
            //    else if (city.Longitude < -180 || city.Longitude > 180)
            //    {
            //        throw new Exception("Latitude or longitude out of range");
            //    }
            // }
            return cities;
        }
    }
}
