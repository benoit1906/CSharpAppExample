﻿// <copyright file="CityRepository.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Data.Repositories
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using WeatherForecastApp.Core.Models;
    using WeatherForecastApp.Data.Interfaces;

    /// <summary>
    /// Contains the definition of an object of type <see cref="CityRepository"/>.
    /// </summary>
    public class CityRepository : ICityRepository
    {
        /// <summary>
        /// Defines the path to the database. It should be a private const but for the purpose of tests, it must a public string.
        /// </summary>
        public string DatabasePath = "../WeatherForecastApp.Data/Databases/CityDataBase.json";

        /// <inheritdoc/>
        public void AddCities(IEnumerable<City> cities)
        {
            var existingData = this.FetchDataBase().ToList();

            cities = this.SetIdentifier(existingData, cities);

            existingData.AddRange(cities);
            var toJson = existingData;

            var jsonData = JsonConvert.SerializeObject(toJson, Formatting.Indented);
            File.WriteAllText(this.DatabasePath, jsonData);
        }

        /// <inheritdoc/>
        public IEnumerable<City> GetAllCities()
        {
            return this.FetchDataBase();
        }

        /// <inheritdoc/>
        public IEnumerable<City> SetIdentifier(IEnumerable<City> existingCities, IEnumerable<City> toAddCities)
        {
            var maxIdentifier = existingCities.Max(c => c.Id);
            foreach (var city in toAddCities)
            {
                city.Id = ++maxIdentifier;
            }

            return toAddCities;
        }

        private IEnumerable<City> FetchDataBase()
        {
            var rawData = File.ReadAllText(this.DatabasePath);

            var cities = JsonConvert.DeserializeObject<IEnumerable<City>>(rawData);

            foreach (var city in cities)
            {
                if (city.Latitude < 0 || city.Latitude > 90)
                {
                    throw new Exception("Latitude out of range.");
                }
                else if (city.Longitude < -180 || city.Longitude > 180)
                {
                    throw new Exception("Longitude out of range.");
                }
            }

            return cities;
        }
    }
}
