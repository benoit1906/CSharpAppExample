// <copyright file="WeatherForecastController.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Site.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WeatherForecastApp.Business.Interfaces;
    using WeatherForecastApp.Core;
    using WeatherForecastApp.Site.ViewModels;

    /// <summary>
    /// Contains the definition of an object of type <see cref="WeatherForecastController"/>.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWeatherForecastDomain weatherForecastDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="weatherForecastDomain">The weather forecast domain.</param>
        public WeatherForecastController(IMapper mapper, IWeatherForecastDomain weatherForecastDomain)
        {
            this.mapper = mapper;
            this.weatherForecastDomain = weatherForecastDomain;
        }

        /// <summary>
        /// Gets all the weather forecasts.
        /// </summary>
        /// <returns>A list of weather forecasts.</returns>
        [HttpGet("GetWeatherForecast")]
        [Authorize(Roles = $"{Constants.MemberRole.Admin}, {Constants.MemberRole.Standard}")]
        public IEnumerable<WeatherForecast> GetAllWeatherForecast()
            => this.mapper.Map<IEnumerable<WeatherForecast>>(this.weatherForecastDomain.GetAllWeatherForecast());

        /// <summary>
        /// Gets the weather forecasts by search params.
        /// </summary>
        /// <param name="searchParams">The search params.</param>
        /// <returns>A list of weather forecasts.</returns>
        [HttpPost("GetWeatherForecastBySearchParams")]
        [Authorize(Roles = $"{Constants.MemberRole.Admin}, {Constants.MemberRole.Standard}")]
        public IEnumerable<WeatherForecast> GetWeatherForecastBySearchParams(WeatherForecastSearchParams searchParams)
            => this.mapper.Map<IEnumerable<WeatherForecast>>(
                this.weatherForecastDomain.GetWeatherForecastsBySearchParams(
                    this.mapper.Map<Core.Models.WeatherForecastSearchParams>(searchParams)));
    }
}