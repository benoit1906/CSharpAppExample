// <copyright file="Login.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Site.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    /// <summary>
    /// Contains the definition of a viewmodel of type <see cref="Login"/>.
    /// </summary>
    [DataContract]
    public class Login
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        [DataMember(Name = "username")]
        [Required(ErrorMessage = "The login must have a username.")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [DataMember(Name = "password")]
        [Required]
        public string Password { get; set; }
    }
}
