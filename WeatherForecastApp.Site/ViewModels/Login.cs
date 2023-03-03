// <copyright file="Login.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Site.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Contains the definition of a viewmodel of type <see cref="Login"/>.
    /// </summary>
    public class Login
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [Required(ErrorMessage = "The login must have a username.")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
