// <copyright file="CityController.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Site.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using WeatherForecastApp.Business.Interfaces;
    using WeatherForecastApp.Site.ViewModels;

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
        /// Adds cities to the city domain.
        /// </summary>
        /// <param name="cities">A list of cities.</param>
        /// <returns>An action result.</returns>
        [HttpPost("AddCities")]
        public ActionResult AddCities(IEnumerable<City> cities)
        {
            try
            {
                var coreCities = this.mapper.Map<IEnumerable<Core.Models.City>>(cities);
                this.cityDomain.AddCities(coreCities);
                return this.Ok();
            }
            catch (Exception err)
            {
                return this.BadRequest(err.Message);
            }
        }

        /// <summary>
        /// Gets all the weather forecasts.
        /// </summary>
        /// <returns>A list of weather forecasts.</returns>
        [HttpGet("GetAllCities")]
        public IActionResult GetAllWeatherForecast()
        {
            try
            {
                return this.Ok(this.mapper.Map<IEnumerable<City>>(this.cityDomain.GetAllCities()));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}