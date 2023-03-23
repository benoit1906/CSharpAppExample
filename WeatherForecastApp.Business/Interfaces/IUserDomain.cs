// <copyright file="IUserDomain.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Business.Interfaces
{
    using WeatherForecastApp.Core.Models;

    /// <summary>
    /// Contains the definition of an interface of type <see cref="IUserDomain"/>.
    /// </summary>
    public interface IUserDomain
    {
        /// <summary>
        /// Logs the user in.
        /// </summary>
        /// <param name="userLogin">The user login.</param>
        /// <returns>The Json Web Token.</returns>
        string Login(Login userLogin);
    }
}
