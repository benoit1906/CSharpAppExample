// <copyright file="RefreshToken.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Site.ViewModels
{
    /// <summary>
    /// Contains the definition of an object of type <see cref="RefreshToken"/>.
    /// </summary>
    public class RefreshToken
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        public DateTime CreationDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddDays(1);
    }
}
