// <copyright file="UserDomain.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace Technocite.Irm.Weather.Business.Domains
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using WeatherForecastApp.Business.Interfaces;
    using WeatherForecastApp.Core.Models;
    using WeatherForecastApp.Data.Interfaces;

    /// <summary>
    /// Contains the definition of a class of type <see cref="UserDomain"/>.
    /// </summary>
    public class UserDomain : IUserDomain
    {
        private readonly IConfiguration configuration;
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDomain"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="userRepository">The user repository.</param>
        public UserDomain(IConfiguration configuration, IUserRepository userRepository)
        {
            this.configuration = configuration;
            this.userRepository = userRepository;
        }

        /// <inheritdoc/>
        public string Login(Login userLogin)
        {
            var user = this.userRepository.GetUserByLogin(userLogin) ?? throw new Exception("User or password incorrect.");
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.EmailAddress),
                new Claim(ClaimTypes.GivenName, user.GivenName),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var token = new JwtSecurityToken(
                issuer: this.configuration["Jwt:Issuer"],
                audience: this.configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddSeconds(15),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"])),
                    SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
