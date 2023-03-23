// <copyright file="LoginRefreshToken.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Site.ViewModels
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Contains the definition of an object of type <see cref="LoginRefreshToken"/>.
    /// </summary>
    public class LoginRefreshToken
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the refresh token.
        /// </summary>
        public RefreshToken RefreshToken { get; set; }
    }
}
