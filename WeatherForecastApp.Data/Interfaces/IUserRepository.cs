// <copyright file="IUserRepository.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Data.Interfaces
{
    using WeatherForecastApp.Core.Models;

    /// <summary>
    /// Contains the definition of an interface of type <see cref="IUserRepository"/>.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the user from the database by its login.
        /// </summary>
        /// <param name="userLogin">The user login.</param>
        /// <returns>The user.</returns>
        User GetUserByLogin(Login userLogin);
    }
}
