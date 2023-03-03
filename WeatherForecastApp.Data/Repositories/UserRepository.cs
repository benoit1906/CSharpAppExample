// <copyright file="UserRepository.cs" company="MyTopCompany">
// Copyright (c) MyTopCompany. All rights reserved.
// </copyright>

namespace WeatherForecastApp.Data.Repositories
{
    using Newtonsoft.Json;
    using WeatherForecastApp.Core.Models;
    using WeatherForecastApp.Data.Interfaces;

    /// <summary>
    /// /// Contains the definition of a class of type <see cref="UserRepository"/>.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The path to the database.
        /// </summary>
        public const string DatabasePath = "../WeatherForecastApp.Data/Databases/UserDataBase.json";

        /// <inheritdoc/>
        public User GetUserByLogin(Login userLogin)
            => this.FetchDataBase().FirstOrDefault(u => u.Username.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) &&
                                                        u.Password == userLogin.Password);

        private IEnumerable<User> FetchDataBase()
        {
            var rawData = File.ReadAllText(DatabasePath);

            return JsonConvert.DeserializeObject<IEnumerable<User>>(rawData);
        }
    }
}
