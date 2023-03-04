// <copyright file="UserController.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherApp.Site.Controllers
{
    using System.Security.Claims;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WeatherForecastApp.Business.Interfaces;
    using WeatherForecastApp.Core;
    using WeatherForecastApp.Core.Models;

    /// <summary>
    /// Contains the definition of a class of type <see cref="UserController"/>.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserDomain userDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="userDomain">The user domain.</param>
        public UserController(IMapper mapper, IUserDomain userDomain)
        {
            this.mapper = mapper;
            this.userDomain = userDomain;
        }

        /// <summary>
        /// Logs the user in.
        /// </summary>
        /// <param name="userlogin">The user login.</param>
        /// <returns>The Json Web Token.</returns>
        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login(Login userlogin)
        {
            try
            {
                var tokenString = this.userDomain.Login(this.mapper.Map<WeatherForecastApp.Core.Models.Login>(userlogin));
                return this.Ok(tokenString);
            }
            catch (Exception e)
            {
                return this.NotFound(e.Message);
            }
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>The user.</returns>
        [HttpGet("GetCurrentUser")]
        [Authorize(Roles = $"{Constants.MemberRole.Admin}, {Constants.MemberRole.Standard}")]
        public IActionResult GetCurrentUser()
        {
            return this.Ok(new
            {
                Id = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Email = this.User.FindFirst(ClaimTypes.Email)?.Value,
                GivenName = this.User.FindFirst(ClaimTypes.GivenName)?.Value,
                Surname = this.User.FindFirst(ClaimTypes.Surname)?.Value,
                Role = this.User.FindFirst(ClaimTypes.Role)?.Value,
            });
        }
    }
}
