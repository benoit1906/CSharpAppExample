// <copyright file="CityController.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Site.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using WeatherForecastApp.Business.Interfaces;
    using WeatherForecastApp.Core.Models;

    /// <summary>
    /// Contains the definition of an object of type <see cref="CityController"/>.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICityDomain cityDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="CityController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="cityDomain">The city domain.</param>
        public CityController(IMapper mapper, ICityDomain cityDomain)
        {
            this.mapper = mapper;
            this.cityDomain = cityDomain;
        }

        /// <summary>
        /// Gets all the weather forecasts.
        /// </summary>
        /// <returns>A list of weather forecasts.</returns>
        [HttpGet("GetAllCities")]
        public IEnumerable<City> GetAllWeatherForecast()
            => this.mapper.Map<IEnumerable<City>>(this.cityDomain.GetAllCities());
    }
}
