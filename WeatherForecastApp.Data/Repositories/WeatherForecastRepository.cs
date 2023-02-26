// <copyright file="WeatherForecastRepository.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Data.Repositories
{
    using Newtonsoft.Json;
    using WeatherForecastApp.Core.Models;
    using WeatherForecastApp.Data.Interfaces;

    /// <summary>
    /// Contains the definition of an object of type <see cref="WeatherForecastRepository"/>.
    /// </summary>
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private const string DatabasePath = "../WeatherForecastApp.Data/Databases/WeatherForecastDataBase.json";

        /// <inheritdoc/>
        public IEnumerable<WeatherForecast> GetAllWeatherForecasts()
            => this.FetchDataBase();

        private IEnumerable<WeatherForecast> FetchDataBase()
        {
            var rawData = File.ReadAllText(DatabasePath);

            return JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(rawData);
        }
    }
}
