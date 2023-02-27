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

        /// <inheritdoc/>
        public IEnumerable<WeatherForecast> GetWeatherForecastsBySearchParams(WeatherForecastSearchParams searchParams)
        {
            var query = this.FetchDataBase();

            if (searchParams.Date != null)
            {
                query = query.Where(wf => wf.Date.Date == ((DateTime)searchParams.Date).Date);
            }

            if (searchParams.MinimumTemperatureC != null)
            {
                query = query.Where(wf => wf.TemperatureC >= searchParams.MinimumTemperatureC);
            }

            if (searchParams.Description != null)
            {
                query = query.Where(wf => wf.Description == searchParams.Description);
            }

            if (searchParams.CityId != null)
            {
                query = query.Where(wf => wf.CityId == searchParams.CityId);
            }

            return query.OrderByDescending(wf => wf.Date);
        }

        private IEnumerable<WeatherForecast> FetchDataBase()
        {
            var rawData = File.ReadAllText(DatabasePath);

            return JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(rawData);
        }
    }
}
